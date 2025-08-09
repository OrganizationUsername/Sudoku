namespace Sudoku.SourceGeneration.Handlers;

internal static class DependencyPropertyHandler
{
	/// <inheritdoc/>
	public static void Output(SourceProductionContext spc, ImmutableArray<CollectedResult> values)
	{
		var types = new List<string>();
		foreach (var group in values.GroupBy(static r => r.Type, (IEqualityComparer<INamedTypeSymbol>)SymbolEqualityComparer.Default))
		{
			var containingType = group.Key;
			var containingTypeStr = containingType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
			var namespaceStr = containingType.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
			var dependencyProperties = new List<string>();
			var properties = new List<string>();
			foreach (var (_, (propertyName, propertyType, generatorMemberName, generatorMemberKind, defaultValue, callbackMethodName, isNullable, accessibility)) in group)
			{
				var propertyTypeStr = propertyType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
				var defaultValueCreatorStr = XamlBinding.GetPropertyMetadataString(defaultValue, propertyType, generatorMemberName, generatorMemberKind, callbackMethodName, propertyTypeStr);
				if (defaultValueCreatorStr is null)
				{
					// Error case has been encountered.
					continue;
				}

				var accessibilityModifier = Regex.Replace(accessibility.ToString(), "[A-Z]", static match => $" {match.Value.ToLower()}");
				var nullableToken = isNullable ? "?" : string.Empty;
				dependencyProperties.Add(
					$"""
					/// <summary>
							/// Defines a dependency property that binds with property <see cref="{propertyName}"/>.
							/// </summary>
							/// <seealso cref="{propertyName}"/>
							[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute]
							[global::System.CodeDom.Compiler.GeneratedCodeAttribute("DependencyPropertyGenerator", "1.0")]
							{accessibilityModifier} static readonly global::Microsoft.UI.Xaml.DependencyProperty {propertyName}Property =
								global::Microsoft.UI.Xaml.DependencyProperty.Register(nameof({propertyName}), typeof({propertyTypeStr}), typeof({containingTypeStr}), {defaultValueCreatorStr});
					"""
				);

				properties.Add(
					$$"""
					[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute]
							[global::System.CodeDom.Compiler.GeneratedCodeAttribute("DependencyPropertyGenerator", "1.0")]
							{{accessibilityModifier}} partial {{propertyTypeStr}}{{nullableToken}} {{propertyName}}
							{
								[global::System.Diagnostics.DebuggerStepThroughAttribute]
								[global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
								get => ({{propertyTypeStr}}{{nullableToken}})GetValue({{propertyName}}Property);

								[global::System.Diagnostics.DebuggerStepThroughAttribute]
								[global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
								set => SetValue({{propertyName}}Property, value);
							}
					"""
				);
			}

			types.Add(
				$$"""
				namespace {{namespaceStr["global::".Length..]}}
				{
					partial class {{containingType.Name}}
					{
						//
						// Declaration of dependency properties
						//
						#region Dependency properties
						{{string.Join("\r\n\r\n\t\t", dependencyProperties)}}
						#endregion
				
				
						//
						// Declaration of interactive properties
						//
						#region Interactive properties
						{{string.Join("\r\n\r\n\t\t", properties)}}
						#endregion
					}
				}
				"""
			);
		}

		spc.AddSource(
			"AutoDependencyProperties.g.cs",
			$$"""
			#nullable enable

			{{string.Join("\r\n\r\n", types)}}
			"""
		);
	}

	/// <inheritdoc/>
	public static CollectedResult? Transform(GeneratorAttributeSyntaxContext gasc, CancellationToken cancellationToken)
	{
		if (gasc is not
			{
				TargetSymbol: IPropertySymbol
				{
					DeclaredAccessibility: var declaredAccessibility,
					ContainingType: var typeSymbol,
					Type: var propertyType,
					Name: var propertyName
				},
				Attributes: [{ NamedArguments: var namedArgs }],
				SemanticModel.Compilation: var compilation
			})
		{
			return null;
		}

		if (compilation.GetTypeByMetadataName("Microsoft.UI.Xaml.DependencyObject") is not { } dependencyObjectType)
		{
			return null;
		}

		if (!typeSymbol.IsDerivedFrom(dependencyObjectType))
		{
			return null;
		}

		var propertiesData = new List<Data>();
		var defaultValueGenerator = default(string);
		var defaultValue = default(object);
		var callbackMethodName = default(string);
		if (namedArgs.TryGetValueOrDefault<object>("DefaultValue", out var v))
		{
			defaultValue = v;
		}

		const string callbackMethodSuffix = "PropertyCallback";
		var callbackAttribute = compilation.GetTypeByMetadataName("SudokuStudio.ComponentModel.CallbackAttribute")!;
		callbackMethodName ??= (
			from methodSymbol in typeSymbol.GetMembers().OfType<IMethodSymbol>()
			where methodSymbol is { IsStatic: true, ReturnsVoid: true }
			let methodName = methodSymbol.Name
			where methodName.EndsWith(callbackMethodSuffix)
			let relatedPropertyName = methodName[..methodName.IndexOf(callbackMethodSuffix)]
			where relatedPropertyName == propertyName
			let attributesData = methodSymbol.GetAttributes()
			where attributesData.Any(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, callbackAttribute))
			select methodName
		).FirstOrDefault();

		const string defaultValueFieldSuffix = "DefaultValue";
		var defaultValueAttribute = compilation.GetTypeByMetadataName("SudokuStudio.ComponentModel.DefaultAttribute")!;
		defaultValueGenerator ??= (
			from fieldSymbol in typeSymbol.GetMembers().OfType<IFieldSymbol>()
			where fieldSymbol.IsStatic
			let fieldName = fieldSymbol.Name
			where fieldName.EndsWith(defaultValueFieldSuffix)
			let relatedPropertyName = fieldName[..fieldName.IndexOf(defaultValueFieldSuffix)]
			where relatedPropertyName == propertyName
			let attributesData = fieldSymbol.GetAttributes()
			where attributesData.Any(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, defaultValueAttribute))
			select fieldName
		).FirstOrDefault();

		var defaultValueGeneratorKind = default(DefaultValueGeneratingMemberKind?);
		if (defaultValueGenerator is not null)
		{
			bool e(ITypeSymbol t) => SymbolEqualityComparer.IncludeNullability.Equals(t, propertyType);
			defaultValueGeneratorKind = typeSymbol.GetAllMembers().FirstOrDefault(m => m.Name == defaultValueGenerator) switch
			{
				IFieldSymbol { Type: var t, IsStatic: true } when e(t) => DefaultValueGeneratingMemberKind.Field,
				IPropertySymbol { Type: var t, IsStatic: true } when e(t) => DefaultValueGeneratingMemberKind.Property,
				IMethodSymbol { Parameters: [], ReturnType: var t, IsStatic: true } when e(t)
					=> DefaultValueGeneratingMemberKind.ParameterlessMethod,
				null => DefaultValueGeneratingMemberKind.CannotReference,
				_ => DefaultValueGeneratingMemberKind.Otherwise
			};
		}

		if (defaultValueGeneratorKind is DefaultValueGeneratingMemberKind.CannotReference or DefaultValueGeneratingMemberKind.Otherwise)
		{
			// Invalid generator name.
			return null;
		}

		return new(
			typeSymbol,
			new(
				propertyName,
				propertyType,
				defaultValueGenerator,
				defaultValueGeneratorKind,
				defaultValue,
				callbackMethodName,
				propertyType is { IsReferenceType: true, NullableAnnotation: NullableAnnotation.Annotated },
				declaredAccessibility switch
				{
					DeclaredAccessibility.NotApplicable or DeclaredAccessibility.Private => Accessibility.Private,
					DeclaredAccessibility.ProtectedAndInternal => Accessibility.PrivateProtected,
					DeclaredAccessibility.Protected => Accessibility.Protected,
					DeclaredAccessibility.Internal => Accessibility.Internal,
					DeclaredAccessibility.ProtectedOrInternal => Accessibility.ProtectedInternal,
					DeclaredAccessibility.Public => Accessibility.Public,
				}
			)
		);
	}

	/// <summary>
	/// The nesting data structure for <see cref="CollectedResult"/>.
	/// </summary>
	/// <seealso cref="CollectedResult"/>
	internal sealed record Data(
		string PropertyName,
		ITypeSymbol PropertyType,
		string? DefaultValueGeneratingMemberName,
		DefaultValueGeneratingMemberKind? DefaultValueGeneratingMemberKind,
		object? DefaultValue,
		string? CallbackMethodName,
		bool IsNullable,
		Accessibility Accessibility
	);

	/// <summary>
	/// Indicates the data collected via <see cref="DependencyPropertyHandler"/>.
	/// </summary>
	/// <seealso cref="DependencyPropertyHandler"/>
	internal sealed record CollectedResult(INamedTypeSymbol Type, Data PropertiesData);

	/// <summary>
	/// Defines an accessibility kind.
	/// </summary>
	internal enum Accessibility
	{
		None,

		/// <summary>
		/// Indicates the accessibility is <see langword="file"/>-scoped.
		/// </summary>
		File,

		/// <summary>
		/// Indicates the accessibility is <see langword="private"/>.
		/// </summary>
		Private,

		/// <summary>
		/// Indicates the accessibility is <see langword="protected"/>.
		/// </summary>
		Protected,

		/// <summary>
		/// Indicates the accessibility is <see langword="private protected"/>.
		/// </summary>
		PrivateProtected,

		/// <summary>
		/// Indicates the accessibility is <see langword="internal"/>.
		/// </summary>
		Internal,

		/// <summary>
		/// Indicates the accessibility is <see langword="protected internal"/>.
		/// </summary>
		ProtectedInternal,

		/// <summary>
		/// Indicates the accessibility is <see langword="public"/>.
		/// </summary>
		Public
	}
}

file static class Extensions
{
	extension<TKey, TValue>(KeyValuePair<TKey, TValue> @this) where TKey : notnull
	{
		public void Deconstruct(out TKey key, out TValue value) => (key, value) = (@this.Key, @this.Value);
	}

	extension(ImmutableArray<KeyValuePair<string, TypedConstant>> @this)
	{
		public bool TryGetValueOrDefault<T>(string name, [NotNullWhen(true)] out T? resultValue)
		{
			foreach (var (key, value) in @this)
			{
				if (key == name)
				{
					resultValue = (T)value.Value!;
					return true;
				}
			}

			resultValue = default;
			return false;
		}
	}

	extension(INamedTypeSymbol @this)
	{
		public bool IsDerivedFrom(INamedTypeSymbol baseType)
		{
			for (var temp = @this.BaseType; temp is not null; temp = temp.BaseType)
			{
				if (SymbolEqualityComparer.Default.Equals(temp, baseType))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<ISymbol> GetAllMembers(bool enumerateInterfaces = false)
		{
			for (var current = @this; current is not null; current = current.BaseType)
			{
				foreach (var member in current.GetMembers())
				{
					yield return member;
				}
			}

			if (enumerateInterfaces)
			{
				foreach (var interfaceType in @this.AllInterfaces)
				{
					foreach (var member in interfaceType.GetMembers())
					{
						yield return member;
					}
				}
			}
		}
	}
}
