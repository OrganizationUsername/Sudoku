namespace SudokuStudio.Views.Pages;

/// <summary>
/// A page that displays all techniques.
/// </summary>
public sealed partial class TechniqueGalleryPage : Page
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CurrentSelectedTechnique"/>.
	/// </summary>
	/// <seealso cref="CurrentSelectedTechnique"/>
	internal static readonly DependencyProperty CurrentSelectedTechniqueProperty =
		DependencyProperty.Register(nameof(CurrentSelectedTechnique), typeof(Technique), typeof(TechniqueGalleryPage), new PropertyMetadata(default(Technique)));


	/// <summary>
	/// Initializes a <see cref="TechniqueGalleryPage"/> instance.
	/// </summary>
	public TechniqueGalleryPage() => InitializeComponent();


	/// <summary>
	/// Indicates the currently selected technique.
	/// </summary>
	internal Technique CurrentSelectedTechnique
	{
		get => (Technique)GetValue(CurrentSelectedTechniqueProperty);

		set => SetValue(CurrentSelectedTechniqueProperty, value);
	}


	private void TechniqueCoreView_CurrentSelectedTechniqueChanged(TechniqueView sender, TechniqueViewCurrentSelectedTechniqueChangedEventArgs e)
		=> CurrentSelectedTechnique = e.Technique;
}
