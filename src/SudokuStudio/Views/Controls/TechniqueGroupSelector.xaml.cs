namespace SudokuStudio.Views.Controls;

/// <summary>
/// Represents a technique group selector.
/// </summary>
public sealed partial class TechniqueGroupSelector : UserControl
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SelectedIndex"/>.
	/// </summary>
	/// <seealso cref="SelectedIndex"/>
	public static readonly DependencyProperty SelectedIndexProperty =
		DependencyProperty.Register(nameof(SelectedIndex), typeof(int), typeof(TechniqueGroupSelector), new PropertyMetadata(default(int)));


	/// <summary>
	/// Initializes a <see cref="TechniqueGroupSelector"/> instance.
	/// </summary>
	public TechniqueGroupSelector() => InitializeComponent();


	/// <summary>
	/// Indicates the selected index.
	/// </summary>
	public int SelectedIndex
	{
		get => (int)GetValue(SelectedIndexProperty);

		set => SetValue(SelectedIndexProperty, value);
	}

	/// <summary>
	/// Indicates the base items source.
	/// </summary>
	internal TechniqueGroupBindableSource_IWillChangeThisTypeNameLater[] ItemsSource
		=>
		from @field in TechniqueGroup.AllValues.ToArray()
		let displayName = @field == 0 ? SR.Get("TechniqueGroupSelector_NoTechniqueSelected", App.CurrentCulture) : @field.GetName(App.CurrentCulture)
		select new TechniqueGroupBindableSource_IWillChangeThisTypeNameLater { DisplayName = displayName, TechniqueGroup = @field };


	/// <inheritdoc cref="Selector.SelectionChanged"/>
	public event SelectionChangedEventHandler? SelectionChanged;


	private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => SelectionChanged?.Invoke(this, e);
}
