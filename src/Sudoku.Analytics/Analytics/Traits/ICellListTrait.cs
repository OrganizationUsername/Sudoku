namespace Sudoku.Analytics.Traits;

/// <summary>
/// Represents a trait that describes the cell list.
/// </summary>
public interface ICellListTrait : ITrait
{
	/// <summary>
	/// Indicates the number of cells.
	/// </summary>
	int CellSize { get; }
}
