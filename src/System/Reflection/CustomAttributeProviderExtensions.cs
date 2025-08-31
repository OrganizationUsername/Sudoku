namespace System.Reflection;

/// <summary>
/// Provides with extension methods on <see cref="ICustomAttributeProvider"/>.
/// </summary>
/// <seealso cref="ICustomAttributeProvider"/>
public static class CustomAttributeProviderExtensions
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TCustomAttributeProvider"/>,
	/// where <typeparamref name="TCustomAttributeProvider"/> satisfies
	/// <see langword="class"/> and <see cref="ICustomAttributeProvider"/> constraints.
	/// </summary>
	extension<TCustomAttributeProvider>(TCustomAttributeProvider @this)
		where TCustomAttributeProvider : class, ICustomAttributeProvider
	{
		/// <summary>
		/// Gets the type arguments of the specified attribute type applied to the specified property.
		/// </summary>
		/// <param name="genericAttributeType">The generic attribute type.</param>
		/// <returns>The types of the generic type arguments.</returns>
		public Type[] GetGenericAttributeTypeArguments(Type genericAttributeType)
			=> @this.GetCustomGenericAttribute(genericAttributeType)?.GetType().GenericTypeArguments ?? Type.EmptyTypes;

		/// <summary>
		/// <inheritdoc cref="Attribute.GetCustomAttribute(MemberInfo, Type)" path="/summary"/>
		/// </summary>
		/// <param name="genericAttributeType">The generic attribute type.</param>
		/// <returns>
		/// <inheritdoc cref="Attribute.GetCustomAttribute(MemberInfo, Type)" path="/returns"/>
		/// </returns>
		public Attribute? GetCustomGenericAttribute(Type genericAttributeType)
			=> genericAttributeType switch
			{
				{ IsGenericType: true, FullName: { } genericTypeName }
					=> (
						from a in @this.GetAttributesCore()
						where a.GetType() is { IsGenericType: var g, FullName: { } f } && g && genericTypeName.IndexOfBacktick() == f.IndexOfBacktick()
						select a
					) is [var attribute] ? attribute : null,
				_ => null
			};

		/// <summary>
		/// <inheritdoc cref="Attribute.GetCustomAttributes(MemberInfo, Type)" path="/summary"/>
		/// </summary>
		/// <param name="genericAttributeType">The generic attribute type.</param>
		/// <returns>
		/// <inheritdoc cref="Attribute.GetCustomAttributes(MemberInfo, Type)" path="/returns"/>
		/// </returns>
		public Attribute[] GetCustomGenericAttributes(Type genericAttributeType)
			=> genericAttributeType switch
			{
				{ IsGenericType: true, FullName: { } genericTypeName }
					=>
					from a in @this.GetAttributesCore()
					where a.GetType() is { IsGenericType: var g, FullName: { } f } && g && genericTypeName.IndexOfBacktick() == f.IndexOfBacktick()
					select a,
				_ => []
			};

		/// <summary>
		/// Get custom attributes.
		/// </summary>
		/// <returns>The attributes.</returns>
		private Attribute[] GetAttributesCore()
			=> @this switch
			{
				MemberInfo m => (Attribute[])m.GetCustomAttributes(),
				Assembly a => (Attribute[])a.GetCustomAttributes(),
				_ => (@this.GetCustomAttributes(true) as Attribute[])!
			};
	}

	/// <summary>
	/// Provides extension members on <see cref="string"/>.
	/// </summary>
	extension(string @this)
	{
		/// <summary>
		/// Get the index of the text of the back tick.
		/// </summary>
		/// <returns>The index of the backtick in the string.</returns>
		private int IndexOfBacktick() => @this.IndexOf('`');
	}
}
