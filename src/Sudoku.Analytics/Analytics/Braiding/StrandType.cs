namespace Sudoku.Analytics.Braiding;

/// <summary>
/// Represents a type of a strand.
/// </summary>
public enum StrandType : byte
{
	/// <summary>
	/// Represents none.
	/// </summary>
	None = 0,

	/// <summary>
	/// Indicates the strand type is N (downside rotation).
	/// </summary>
	Downside,

	/// <summary>
	/// Indicates the strand type is Z (upside rotation).
	/// </summary>
	Upside
}
