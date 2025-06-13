namespace Sudoku.Analytics.Ranking;

/// <summary>
/// Represents a link (a set of 9 positions which allows at most 1 digit can be filled).
/// </summary>
public abstract class Link : RankSet
{
	/// <summary>
	/// Try to find all possible candidates in the current rank set.
	/// </summary>
	/// <param name="grid">The grid.</param>
	/// <returns>The candidates.</returns>
	[DoesNotReturn]
	public sealed override CandidateMap GetAvailableRange(in Grid grid)
		=> throw new NotSupportedException("Links are not supported to calculate available range.");
}
