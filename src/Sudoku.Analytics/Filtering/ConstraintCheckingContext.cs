namespace Sudoku.Filtering;

/// <summary>
/// Represents context that will be called by method <see cref="Constraint.Check(ConstraintCheckingContext)"/>.
/// </summary>
/// <param name="grid"><inheritdoc cref="Grid" path="/summary"/></param>
/// <param name="analysisResult"><inheritdoc cref="AnalysisResult" path="/summary"/></param>
/// <seealso cref="Constraint.Check(ConstraintCheckingContext)"/>
public readonly ref struct ConstraintCheckingContext(in Grid grid, AnalysisResult analysisResult)
{
	/// <summary>
	/// Indicates the reference to the grid to be checked.
	/// </summary>
	public readonly ref readonly Grid Grid = ref grid;


	/// <summary>
	/// Indicates the analysis result.
	/// </summary>
	public AnalysisResult AnalysisResult { get; } = analysisResult;
}
