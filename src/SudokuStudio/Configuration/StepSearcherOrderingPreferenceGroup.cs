namespace SudokuStudio.Configuration;

/// <summary>
/// Represents with preference items that is used by <see cref="Analyzer"/>, for the ordering of <see cref="StepSearcher"/>s.
/// </summary>
/// <seealso cref="Analyzer"/>
/// <seealso cref="StepSearcher"/>
public sealed partial class StepSearcherOrderingPreferenceGroup : PreferenceGroup
{
	private static readonly ObservableCollection<StepSearcherInfo> StepSearchersOrderDefaultValue = [with(
		(
			from searcher in StepSearcher.StepSearchers
			select new StepSearcherInfo
			{
				IsEnabled = searcher.RunningArea.HasFlag(StepSearcherRunningArea.Searching),
				TypeName = searcher.GetType().Name
			}
		).ToArray()
	)];

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="StepSearchersOrder"/>.
	/// </summary>
	/// <seealso cref="StepSearchersOrder"/>
	public static readonly DependencyProperty StepSearchersOrderProperty =
		DependencyProperty.Register(nameof(StepSearchersOrder), typeof(ObservableCollection<StepSearcherInfo>), typeof(StepSearcherOrderingPreferenceGroup), new PropertyMetadata(StepSearchersOrderDefaultValue, StepSearchersOrderPropertyCallback));


	/// <summary>
	/// Indicates the order of step searchers.
	/// </summary>
	public ObservableCollection<StepSearcherInfo> StepSearchersOrder
	{
		get => (ObservableCollection<StepSearcherInfo>)GetValue(StepSearchersOrderProperty);

		set => SetValue(StepSearchersOrderProperty, value);
	}


	private static void StepSearchersOrderPropertyCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		if (e is not { NewValue: ObservableCollection<StepSearcherInfo> stepSearchers })
		{
			return;
		}

		if (Application.CurrentApp.Analyzer is not { } analyzer)
		{
			return;
		}

		analyzer.WithStepSearchers([.. from s in stepSearchers select s.CreateStepSearcher()]);
	}
}
