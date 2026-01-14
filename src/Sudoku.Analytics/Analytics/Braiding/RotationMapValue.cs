namespace Sudoku.Analytics.Braiding;

/// <summary>
/// Represents cell information on braiding.
/// </summary>
/// <param name="containing"><inheritdoc cref="Containing" path="/summary"/></param>
/// <param name="notContaining"><inheritdoc cref="NotContaining" path="/summary"/></param>
public readonly struct RotationMapValue(in CellMap containing, in CellMap notContaining)
{
	/// <summary>
	/// Indicates cells contained for a certain type of braid mode in a chute.
	/// </summary>
	public readonly CellMap Containing = containing;

	/// <summary>
	/// Indicates cells not contained for a certain type of braid mode in a chute.
	/// </summary>
	public readonly CellMap NotContaining = notContaining;
}
