#undef SORT_SOLUTION_ASSIGNMENTS

namespace Sudoku.SetTheory;

/// <summary>
/// Represents an internal entry for dancing links solver.
/// </summary>
internal static class SetSolver
{
	/// <summary>
	/// Solve for all selections of candidates that satisfy:
	/// <list type="bullet">
	/// <item>Each truth: exactly one selected inside that <see cref="CandidateMap"/></item>
	/// <item>Each link: at most one selected inside that <see cref="CandidateMap"/></item>
	/// </list>
	/// </summary>
	/// <param name="grid">
	/// The grid that represents overall available candidates (i.e. <see cref="CandidateMap"/>)
	/// - but only bits that appear in at least one set are actually added as DLX rows by default.
	/// </param>
	/// <param name="truths">Lists of <see cref="CandidateMap"/> describing which candidates belong to each set.</param>
	/// <param name="links">Lists of <see cref="CandidateMap"/> describing which candidates belong to each set.</param>
	/// <param name="maxSolutions">The limit maximum solutions can be found.</param>
	/// <param name="includeUnconstrained">
	/// Indicates whether unconstrained candidates will be included to check.
	/// By default we <b>skip</b> candidates that are not present in any set (to avoid combinatorial explosion).
	/// If you really want to include unconstrained candidates (combinatorial), set <see langword="true"/> (dangerous).
	/// </param>
	/// <returns>
	/// List of solutions; each solution is <see cref="Candidate"/>[] of candidates (0..728) that are true.
	/// </returns>
	/// <seealso cref="CandidateMap"/>
	public static ReadOnlySpan<ReadOnlyMemory<Candidate>> Solve(
		in Grid grid,
		in SpaceSet truths,
		in SpaceSet links,
		int maxSolutions = int.MaxValue,
		bool includeUnconstrained = false
	)
	{
		var strongRegions = new List<CandidateMap>();
		var weakRegions = new List<CandidateMap>();
		var candidateMap = CandidateMap.Empty;
		foreach (var truth in truths)
		{
			var map = truth.GetAvailableRange(grid);
			strongRegions.Add(map);
			candidateMap |= map;
		}
		foreach (var link in links)
		{
			weakRegions.Add(link.GetAvailableRange(grid) & candidateMap);
		}

		return Solve(in candidateMap, strongRegions, weakRegions, maxSolutions, includeUnconstrained);
	}

	/// <inheritdoc cref="Solve(in Grid, in SpaceSet, in SpaceSet, int, bool)"/>
	public static ReadOnlySpan<ReadOnlyMemory<Candidate>> Solve(
		in Pattern pattern,
		int maxSolutions = int.MaxValue,
		bool includeUnconstrained = false
	) => Solve(in pattern.Grid, pattern.Truths, pattern.Links, maxSolutions, includeUnconstrained);

	/// <summary>
	/// The backing method.
	/// </summary>
	private static ReadOnlySpan<ReadOnlyMemory<Candidate>> Solve(
		scoped ref readonly CandidateMap fullMap,
		List<CandidateMap> truths,
		List<CandidateMap> links,
		int maxSolutions = int.MaxValue,
		bool includeUnconstrained = false
	)
	{
		var strongCount = truths.Count;
		var weakCount = links.Count;
		var colCount = strongCount + weakCount;
		var isPrimary = new bool[colCount];
		for (var i = 0; i < strongCount; i++)
		{
			isPrimary[i] = true;
		}
		for (var i = 0; i < weakCount; i++)
		{
			isPrimary[strongCount + i] = false;
		}

		var dlx = new DancingLinks(colCount, isPrimary);

		// Map from candidateIndex -> list of column indices (where it's present).
		var candidateToCols = new Dictionary<int, List<int>>();

		// Gather mapping for truths.
		for (var r = 0; r < strongCount; r++)
		{
			foreach (var idx in truths[r])
			{
				if (!candidateToCols.TryGetValue(idx, out var list))
				{
					list = [];
					candidateToCols[idx] = list;
				}
				list.Add(r); // Primary column index.
			}
		}

		// Gather mapping for links.
		for (var r = 0; r < weakCount; r++)
		{
			foreach (var idx in links[r])
			{
				if (!candidateToCols.TryGetValue(idx, out var list))
				{
					list = [];
					candidateToCols[idx] = list;
				}
				list.Add(strongCount + r);
			}
		}

		// Decide which candidate to actually add as rows:
		var bitsToConsider = includeUnconstrained
			// Include every candidate allowed by 'fullMap'
			? fullMap
			// Only include candidates that appear in at least one provided set.
			: [.. candidateToCols.Keys];

		// Add rows: each candidate present in candidateMap and considered will be a row.

		// We will use 'rowId' == 'candidateIndex' for simplicity.
		var rowId = 0;
		foreach (var idx in bitsToConsider)
		{
			if (!fullMap.Contains(idx))
			{
				// Skip if not actually available.
				continue;
			}

			if (!candidateToCols.TryGetValue(idx, out var cols) || cols is null || cols.Count == 0)
			{
				if (!includeUnconstrained)
				{
					// Skip unconstrained candidate when 'includeUnconstrained' is false.
					continue;
				}

				// Row with no columns (free choice).
				dlx.AddRow(idx, []);
			}
			else
			{
				dlx.AddRow(idx, cols);
			}
			rowId++;
		}

		// Quick feasibility check:
		// If any primary column has size 0 -> no solution.
		// We can inspect columns by trying to cover via a small helper (not exposing internals).
		// For simplicity, we skip extra check here; DLX will simply produce no results.

		var rawSolutions = dlx.Solve(maxSolutions);

		// Raw solutions are arrays of 'rowIds' which we set equal to candidates, so directly add them into result collection.
		var results = new List<ReadOnlyMemory<Candidate>>();
		foreach (var solution in rawSolutions)
		{
			var arr = solution.ToArray();
#if SORT_SOLUTION_ASSIGNMENTS
			Array.Sort(arr);
#endif
			results.Add(arr);
		}

		return results.AsSpan();
	}
}
