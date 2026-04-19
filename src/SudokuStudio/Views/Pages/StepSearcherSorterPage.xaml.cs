namespace SudokuStudio.Views.Pages;

/// <summary>
/// Represents step searcher sorter page.
/// </summary>
public sealed partial class StepSearcherSorterPage : Page
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CurrentSelectedStepSearcher"/>.
	/// </summary>
	/// <seealso cref="CurrentSelectedStepSearcher"/>
	internal static readonly DependencyProperty CurrentSelectedStepSearcherProperty =
		DependencyProperty.Register(nameof(CurrentSelectedStepSearcher), typeof(StepSearcherInfo), typeof(StepSearcherSorterPage), new PropertyMetadata(default(StepSearcherInfo)));


	/// <summary>
	/// Initializes a <see cref="StepSearcherSorterPage"/> instance.
	/// </summary>
	public StepSearcherSorterPage() => InitializeComponent();


	/// <summary>
	/// Indicates the currently selected step searcher and its details.
	/// </summary>
	internal StepSearcherInfo? CurrentSelectedStepSearcher
	{
		get => (StepSearcherInfo?)GetValue(CurrentSelectedStepSearcherProperty);

		set => SetValue(CurrentSelectedStepSearcherProperty, value);
	}


	private void StepSearcherView_ItemSelected(StepSearcherListView sender, StepSearcherListViewItemSelectedEventArgs e)
		=> CurrentSelectedStepSearcher = e.SelectedSearcherInfo;
}
