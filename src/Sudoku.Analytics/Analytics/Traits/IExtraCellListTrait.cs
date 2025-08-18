namespace Sudoku.Analytics.Traits;

/// <summary>
/// Represents a trait that describes the extra cell list.
/// </summary>
public interface IExtraCellListTrait : ITrait
{
	/// <summary>
	/// Indicates the number of extra cells.
	/// </summary>
	int ExtraCellSize { get; }
}
