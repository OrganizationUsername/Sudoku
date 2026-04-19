namespace SudokuStudio.Views.Attached;

/// <summary>
/// Defines a bind behaviors on <see cref="SudokuPane"/> instances.
/// </summary>
/// <seealso cref="SudokuPane"/>
public static class SudokuPaneBindable
{
	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AnalyzerProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AnalyzerProperty =
		DependencyProperty.RegisterAttached("Analyzer", typeof(Analyzer), typeof(SudokuPaneBindable), new PropertyMetadata(Analyzer.Balanced));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="StepCollectorProperty"/>.
	/// </summary>
	public static readonly DependencyProperty StepCollectorProperty =
		DependencyProperty.RegisterAttached("StepCollector", typeof(Collector), typeof(SudokuPaneBindable), new PropertyMetadata(new()));


	/// <summary>
	/// Sets the attached property <see cref="AnalyzerProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAnalyzer(DependencyObject obj, Analyzer value) => obj.SetValue(AnalyzerProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AnalyzerProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static Analyzer GetAnalyzer(DependencyObject obj) => (Analyzer)obj.GetValue(AnalyzerProperty);

	/// <summary>
	/// Sets the attached property <see cref="StepCollectorProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetStepCollector(DependencyObject obj, Collector value) => obj.SetValue(StepCollectorProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="StepCollectorProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static Collector GetStepCollector(DependencyObject obj) => (Collector)obj.GetValue(StepCollectorProperty);
}
