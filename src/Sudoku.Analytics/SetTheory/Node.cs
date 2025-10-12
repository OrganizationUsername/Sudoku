namespace Sudoku.SetTheory;

/// <summary>
/// Represents a node. All fields in this type is nullable unaware.
/// </summary>
internal class Node
{
	/// <summary>
	/// Provides up, down, left, right nodes.
	/// </summary>
	public Node? L, R, U, D;

	/// <summary>
	/// Indicates the column header.
	/// </summary>
	public ColumnHeader? C;

	/// <summary>
	/// Indicates row ID.
	/// This field is optional: identify which input row this node belongs to.
	/// </summary>
	public int RowId;
}
