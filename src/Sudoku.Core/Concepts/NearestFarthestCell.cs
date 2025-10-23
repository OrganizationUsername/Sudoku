namespace Sudoku.Concepts;

/// <summary>
/// Represents a pair of cells that defines the nearest and farthest cell to a certain cell.
/// </summary>
/// <param name="Nearest">Indicates the nearest cell.</param>
/// <param name="Farthest">Indicates the farthest cell.</param>
public readonly record struct NearestFarthestCell(Cell Nearest, Cell Farthest) : IEqualityOperators<NearestFarthestCell, NearestFarthestCell, bool>
{
	/// <summary>
	/// Represents untouched case.
	/// </summary>
	public static readonly NearestFarthestCell Untouched = new(-1, -1);
}
