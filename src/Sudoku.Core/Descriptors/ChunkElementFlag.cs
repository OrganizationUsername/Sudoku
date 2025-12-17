namespace Sudoku.Descriptors;

/// <summary>
/// Indicates a kind of chunk element, like rendering a list of candidates by storing a <see cref="List{T}"/> of candidates.
/// </summary>
/// <remarks><include file="../../global-doc-comments.xml" path="/g/flags-attribute"/></remarks>
[Flags]
public enum ChunkElementFlag
{
	/// <summary>
	/// The placeholder of this type.
	/// </summary>
	None = 0,

	/// <summary>
	/// Indicates the element is a single value.
	/// </summary>
	Single = 1 << 0,

	/// <summary>
	/// Indicates the element is an array.
	/// </summary>
	Array = 1 << 1,

	/// <summary>
	/// Indicates the element is a list.
	/// </summary>
	List = 1 << 2,

	/// <summary>
	/// Indicates the element is a hash set.
	/// </summary>
	HashSet = 1 << 3,

	/// <summary>
	/// Indicates the element is bit state map.
	/// </summary>
	BitStateMap = 1 << 4,

	/// <summary>
	/// Indicates the element is a pair of values <c>(cells, digit)</c>.
	/// </summary>
	CellsDigit = 1 << 5
}
