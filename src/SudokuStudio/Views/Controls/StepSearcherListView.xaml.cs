namespace SudokuStudio.Views.Controls;

/// <summary>
/// Represents a <see cref="ListView"/> control that displays for <see cref="StepSearcher"/> instances.
/// </summary>
/// <seealso cref="StepSearcher"/>
public sealed partial class StepSearcherListView : UserControl
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="StepSearchers"/>.
	/// </summary>
	/// <seealso cref="StepSearchers"/>
	public static readonly DependencyProperty StepSearchersProperty =
		DependencyProperty.Register(nameof(StepSearchers), typeof(ObservableCollection<StepSearcherInfo>), typeof(StepSearcherListView), new PropertyMetadata(default(ObservableCollection<StepSearcherInfo>)));


	/// <summary>
	/// Initializes a <see cref="StepSearcherListView"/> instance.
	/// </summary>
	public StepSearcherListView() => InitializeComponent();


	/// <summary>
	/// Indicates the step searchers.
	/// </summary>
	public ObservableCollection<StepSearcherInfo> StepSearchers
	{
		get => (ObservableCollection<StepSearcherInfo>)GetValue(StepSearchersProperty);

		set => SetValue(StepSearchersProperty, value);
	}


	/// <summary>
	/// Indicates the event triggered when an item is selected.
	/// </summary>
	public event EventHandler<StepSearcherListView, StepSearcherListViewItemSelectedEventArgs>? ItemSelected;


	private void MainListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
	{
		if (e is not { Items: [StepSearcherInfo { CanDrag: true }] })
		{
			e.Cancel = true;
		}
	}

	private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		=> ItemSelected?.Invoke(this, new((StepSearcherInfo)MainListView.SelectedItem));
}
