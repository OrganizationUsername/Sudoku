namespace Sudoku.Analytics.Traits;

/// <summary>
/// Represents a size trait.
/// </summary>
public interface ISizeTrait : ITrait
{
	/// <summary>
	/// Indicates the size of the pattern.
	/// </summary>
	int Size { get; }
}
