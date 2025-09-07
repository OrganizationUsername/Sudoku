namespace Sudoku.MinlexOrder;

/// <summary>
/// Represents an equality comparer that checks for min-lex transformation.
/// </summary>
public sealed class GridRawStringMinlexEqualityComparer : IEqualityComparer<string>
{
	/// <summary>
	/// Indicates the backing min-lex finder object.
	/// </summary>
	private readonly MinlexFinder _finder = new();


	/// <inheritdoc/>
	public bool Equals(string? x, string? y)
		=> (x, y) switch
		{
			(null, null) => true,
			(not null, not null) => _finder.Find(x) == _finder.Find(y),
			_ => false
		};

	/// <inheritdoc/>
	public int GetHashCode(string obj) => _finder.Find(obj).GetHashCode();
}
