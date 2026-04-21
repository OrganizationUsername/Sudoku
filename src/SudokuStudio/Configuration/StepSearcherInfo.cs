namespace SudokuStudio.Configuration;

/// <summary>
/// Defines a serialization data of a step searcher.
/// </summary>
public sealed partial class StepSearcherInfo : DependencyObject
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="IsEnabled"/>.
	/// </summary>
	/// <seealso cref="IsEnabled"/>
	public static readonly DependencyProperty IsEnabledProperty =
		DependencyProperty.Register(nameof(IsEnabled), typeof(bool), typeof(StepSearcherInfo), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="TypeName"/>.
	/// </summary>
	/// <seealso cref="TypeName"/>
	public static readonly DependencyProperty TypeNameProperty =
		DependencyProperty.Register(nameof(TypeName), typeof(string), typeof(StepSearcherInfo), new PropertyMetadata(default(string)));


	/// <summary>
	/// Indicates whether the technique option is not fixed and can be used for drag-and-drop operation.
	/// </summary>
	[JsonIgnore]
	public bool CanDrag => !CreateStepSearcher().Metadata.IsOrderingFixed;

	/// <summary>
	/// Indicates whether the technique option is not read-only and can be used for toggle operation.
	/// </summary>
	[JsonIgnore]
	public bool CanToggle => !CreateStepSearcher().Metadata.IsReadOnly;

	/// <summary>
	/// Indicates whether the step searcher is enabled.
	/// </summary>
	public bool IsEnabled
	{
		get => (bool)GetValue(IsEnabledProperty);

		set => SetValue(IsEnabledProperty, value);
	}

	/// <summary>
	/// Indicates the name of the step searcher.
	/// </summary>
	[JsonIgnore]
	public string Name => CreateStepSearcher().Metadata.GetName(App.CurrentCulture);

	/// <summary>
	/// Indicates the type name of the step searcher.
	/// This property can be used for creating instances via reflection using getMetaProperties <see cref="Activator.CreateInstance(Type)"/>.
	/// </summary>
	/// <seealso cref="Activator.CreateInstance(Type)"/>
	public string TypeName
	{
		get => (string)GetValue(TypeNameProperty);

		set => SetValue(TypeNameProperty, value);
	}


	/// <inheritdoc/>
	public override string ToString()
		=> $$"""{{nameof(StepSearcherInfo)}} { {{nameof(IsEnabled)}} = {{IsEnabled}}, {{nameof(Name)}} = {{Name}}, {{nameof(TypeName)}} = {{TypeName}} }""";

	/// <summary>
	/// Creates a list of <see cref="StepSearcher"/> instances.
	/// </summary>
	/// <returns>A list of <see cref="StepSearcher"/> instances.</returns>
	public StepSearcher CreateStepSearcher() => StepSearcher.GetStepSearcher(TypeName);
}
