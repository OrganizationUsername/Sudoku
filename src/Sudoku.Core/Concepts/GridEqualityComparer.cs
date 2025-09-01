namespace Sudoku.Concepts;

/// <summary>
/// Represents a default grid equality comparer.
/// </summary>
public sealed class GridEqualityComparer : IEqualityComparer<Grid>
{
	/// <inheritdoc/>
	public bool Equals(Grid x, Grid y) => x == y;

	/// <inheritdoc/>
	public int GetHashCode(Grid obj) => obj.GetHashCode();
}
