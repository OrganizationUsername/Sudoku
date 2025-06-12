namespace Sudoku.Analytics.Ranking;

/// <summary>
/// Represents a rank set type.
/// </summary>
public enum RankSetType
{
	/// <summary>
	/// Indicates the cell truth.
	/// </summary>
	CellTruth,

	/// <summary>
	/// Indicates the house truth.
	/// </summary>
	HouseTruth,

	/// <summary>
	/// Indicates the cell link.
	/// </summary>
	CellLink,

	/// <summary>
	/// Indicates the house link.
	/// </summary>
	HouseLink
}
