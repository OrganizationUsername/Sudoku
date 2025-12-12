namespace Sudoku.Analytics.StepSearcherHelpers.Chaining;

/// <summary>
/// Represents a processed view nodes map.
/// </summary>
public sealed class ProcessedViewNodeMap : SortedDictionary<ColorIdentifierAlias, (CellMap Cells, CandidateMap Candidates)>
{
	/// <summary>
	/// Indicates the maximal key in ALS set.
	/// </summary>
	public ColorIdentifierAlias MaxKeyInAlmostLockedSet
	{
		get
		{
			var result = ColorIdentifierAlias.Normal;
			foreach (var key in Keys)
			{
				if (key is >= ColorIdentifierAlias.AlmostLockedSet1 and <= ColorIdentifierAlias.AlmostLockedSet5 && key >= result)
				{
					result = key;
				}
			}
			return result;
		}
	}

	/// <summary>
	/// Indicates the maximal key in rectangle set.
	/// </summary>
	public ColorIdentifierAlias MaxKeyInRectangle
	{
		get
		{
			var result = ColorIdentifierAlias.Normal;
			foreach (var key in Keys)
			{
				if (key is >= ColorIdentifierAlias.Rectangle1 and <= ColorIdentifierAlias.Rectangle3 && key >= result)
				{
					result = key;
				}
			}
			return result;
		}
	}


	/// <summary>
	/// Determines whether the specified cell is stored in the table; if so, return the corresponding key.
	/// </summary>
	/// <param name="cell">The cell.</param>
	/// <param name="identifierKind">The cooresponding identifier kind.</param>
	/// <returns>A <see cref="bool"/> result indicating that.</returns>
	public bool ContainsCell(Cell cell, out ColorIdentifierAlias identifierKind)
	{
		foreach (var kvp in this)
		{
			ref readonly var cells = ref kvp.ValueRef.Cells;
			if (cells.Contains(cell))
			{
				identifierKind = kvp.Key;
				return true;
			}
		}

		identifierKind = default;
		return false;
	}

	/// <summary>
	/// Determines whether the specified candidate is stored in the table; if so, return the corresponding key.
	/// </summary>
	/// <param name="candidate">The candidate.</param>
	/// <param name="identifierKind">The cooresponding identifier kind.</param>
	/// <returns>A <see cref="bool"/> result indicating that.</returns>
	public bool ContainsCandidate(Candidate candidate, out ColorIdentifierAlias identifierKind)
	{
		foreach (var kvp in this)
		{
			ref readonly var candidates = ref kvp.ValueRef.Candidates;
			if (candidates.Contains(candidate))
			{
				identifierKind = kvp.Key;
				return true;
			}
		}

		identifierKind = default;
		return false;
	}
}
