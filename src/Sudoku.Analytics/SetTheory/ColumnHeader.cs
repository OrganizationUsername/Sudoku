namespace Sudoku.SetTheory;

/// <summary>
/// Represents a column header.
/// </summary>
internal sealed class ColumnHeader : Node
{
	/// <summary>
	/// Indicates the number of nodes in column.
	/// </summary>
	public int Size;

	/// <summary>
	/// Indicates the ID.
	/// </summary>
	public readonly int Id;

	/// <summary>
	/// Indicates whether the column is primary (or secondary).
	/// </summary>
	public readonly bool IsPrimary;


	/// <summary>
	/// Initializes a <see cref="ColumnHeader"/> instance via ID and is-primary property.
	/// </summary>
	/// <param name="id">The ID.</param>
	/// <param name="isPrimary">Is-primary property.</param>
	public ColumnHeader(int id, bool isPrimary) => (Id, IsPrimary, Size, U, D) = (id, isPrimary, 0, this, this);
}
