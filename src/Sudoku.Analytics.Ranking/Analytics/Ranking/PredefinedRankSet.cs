namespace Sudoku.Analytics.Ranking;

/// <summary>
/// Represents predefined rank set.
/// </summary>
public static class PredefinedRankSet
{
	/// <summary>
	/// Indicates all cell truths.
	/// </summary>
	private static readonly CellTruth[] CellTruths;

	/// <summary>
	/// Indicates all cell links.
	/// </summary>
	private static readonly CellLink[] CellLinks;

	/// <summary>
	/// Indicates all house truths.
	/// </summary>
	private static readonly HouseTruth[] HouseTruths;

	/// <summary>
	/// Indicates all house links.
	/// </summary>
	private static readonly HouseLink[] HouseLinks;


	/// <include file='../../global-doc-comments.xml' path='g/static-constructor' />
	static PredefinedRankSet()
	{
		CellTruths = new CellTruth[81];
		CellLinks = new CellLink[81];
		HouseTruths = new HouseTruth[27 * 9];
		HouseLinks = new HouseLink[27 * 9];

		for (var i = 0; i < 81; i++)
		{
			CellTruths[i] = new(i);
			CellLinks[i] = new(i);
		}
		for (var i = 0; i < 27; i++)
		{
			for (var j = 0; j < 9; j++)
			{
				HouseTruths[i * 9 + j] = new(i, j);
				HouseLinks[i * 9 + j] = new(i, j);
			}
		}
	}
}
