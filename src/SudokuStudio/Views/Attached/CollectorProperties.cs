namespace SudokuStudio.Views.Attached;

/// <summary>
/// Defines a bind behaviors on <see cref="SudokuPane"/> instances, for <see cref="Collector"/> instance's interaction.
/// </summary>
/// <seealso cref="SudokuPane"/>
/// <seealso cref="Collector"/>
public static class CollectorProperties
{
	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="CollectorMaxStepsCollectedProperty"/>.
	/// </summary>
	public static readonly DependencyProperty CollectorMaxStepsCollectedProperty =
		DependencyProperty.RegisterAttached("CollectorMaxStepsCollected", typeof(int), typeof(CollectorProperties), new PropertyMetadata(1000, CollectorMaxStepsCollectedPropertyCallback));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="DifficultyLevelModeProperty"/>.
	/// </summary>
	public static readonly DependencyProperty DifficultyLevelModeProperty =
		DependencyProperty.RegisterAttached("DifficultyLevelMode", typeof(int), typeof(CollectorProperties), new PropertyMetadata(0, DifficultyLevelModePropertyCallback));


	/// <summary>
	/// Sets the attached property <see cref="CollectorMaxStepsCollectedProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetCollectorMaxStepsCollected(DependencyObject obj, int value)
		=> obj.SetValue(CollectorMaxStepsCollectedProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="CollectorMaxStepsCollectedProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetCollectorMaxStepsCollected(DependencyObject obj)
		=> (int)obj.GetValue(CollectorMaxStepsCollectedProperty);

	/// <summary>
	/// Sets the attached property <see cref="DifficultyLevelModeProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetDifficultyLevelMode(DependencyObject obj, int value)
		=> obj.SetValue(DifficultyLevelModeProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="DifficultyLevelModeProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetDifficultyLevelMode(DependencyObject obj)
		=> (int)obj.GetValue(DifficultyLevelModeProperty);

	private static void DifficultyLevelModePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> SudokuPaneBindable.GetStepCollector((SudokuPane)d).WithSameLevelConfiguration((CollectorDifficultyLevelMode)(int)e.NewValue);

	private static void CollectorMaxStepsCollectedPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> SudokuPaneBindable.GetStepCollector((SudokuPane)d).WithMaxSteps((int)e.NewValue);
}
