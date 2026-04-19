namespace SudokuStudio.Views.Pages.Analyze;

/// <summary>
/// Defines a summary page.
/// </summary>
public sealed partial class Summary : Page, IAnalyzerTab
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AnalysisResult"/>.
	/// </summary>
	/// <seealso cref="AnalysisResult"/>
	public static readonly DependencyProperty AnalysisResultProperty =
		DependencyProperty.Register(nameof(AnalysisResult), typeof(AnalysisResult), typeof(Summary), new PropertyMetadata(default(AnalysisResult), AnalysisResultPropertyCallback));


	/// <summary>
	/// Initializes a <see cref="Summary"/> instance.
	/// </summary>
	public Summary() => InitializeComponent();


	/// <inheritdoc/>
	public AnalyzePage BasePage { get; set; } = null!;

	/// <summary>
	/// Indicates the analysis result.
	/// </summary>
	public AnalysisResult? AnalysisResult
	{
		get => (AnalysisResult?)GetValue(AnalysisResultProperty);

		set => SetValue(AnalysisResultProperty, value);
	}


	private static void AnalysisResultPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is not (Summary page, { NewValue: var rawValue and (null or AnalysisResult _) }))
		{
			return;
		}

		page.SummaryTable.ItemsSource = rawValue is AnalysisResult value ? SummaryViewBindableSource.CreateListFrom(value) : null;
	}
}
