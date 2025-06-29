namespace Sudoku.Ranking;

public partial struct RankPattern
{
	/// <summary>
	/// Indicates whether the current pattern is stable rank-0 pattern, i.e. all links are rank-0 links.
	/// </summary>
	public bool GetIsRank0Pattern() => GetRank0Links().Count == Truths.Count;

	/// <summary>
	/// Indicates the rank of the current pattern. If the pattern is unstable
	/// (sometimes assignments certain times of digits in the pattern but sometimes not),
	/// this property will return <see langword="null"/>.
	/// </summary>
	public int? GetRank() => GetRankCore(GetAssignmentCombinations());

	/// <summary>
	/// Try to find all rank-0 links. A rank-0 link is a link that will become truth
	/// because all valid combinations lead to a same result that the link must hold one correct digit.
	/// </summary>
	/// <returns>A list of links that are determined as rank-0 links.</returns>
	public SpaceSet GetRank0Links() => GetRank0LinksCore(GetAssignmentCombinations());

	/// <summary>
	/// Determine whether the pattern is rank-0 pattern via cached combinations.
	/// </summary>
	/// <param name="combinations">The combinations.</param>
	/// <returns>A <see cref="bool"/> result indicating that.</returns>
	private bool GetIsRank0PatternCore(ReadOnlySpan<ReadOnlyMemory<Candidate>> combinations)
		=> GetRank0LinksCore(combinations) == Links;

	/// <summary>
	/// Calculate rank value via cached combinations.
	/// </summary>
	/// <param name="combinations">The combinations.</param>
	/// <returns>The rank value.</returns>
	private int? GetRankCore(ReadOnlySpan<ReadOnlyMemory<Candidate>> combinations)
	{
		var factAssignmentCountValues = new SortedSet<int>();
		factAssignmentCountValues.AddRange(from assignment in combinations select assignment.Length);

		return factAssignmentCountValues.Max - factAssignmentCountValues.Min;
	}

	/// <summary>
	/// Gets rank-0 links via cached combinations.
	/// </summary>
	/// <param name="combinations">The combinations.</param>
	/// <returns>Rank-0 links.</returns>
	private SpaceSet GetRank0LinksCore(ReadOnlySpan<ReadOnlyMemory<Candidate>> combinations)
	{
		var result = SpaceSet.Empty;
		var links = Links;

		var i = 0;
		foreach (var assignmentGroup in combinations)
		{
			var lightUpLinks = SpaceSet.Empty;
			foreach (var assignment in assignmentGroup)
			{
				foreach (var set in links)
				{
					if (set.Contains(assignment))
					{
						lightUpLinks.Add(set);
					}
				}
			}

			if (i++ == 0)
			{
				result |= lightUpLinks;
			}
			else
			{
				result &= lightUpLinks;
			}
		}

		return result;
	}
}
