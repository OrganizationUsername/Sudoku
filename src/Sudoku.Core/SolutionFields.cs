namespace Sudoku;

/// <summary>
/// Provides with solution-wide read-only fields used.
/// </summary>
public static class SolutionFields
{
	/// <summary>
	/// Indicates a list of <see cref="CellMap"/> instances that are initialized as singleton element by its corresponding index.
	/// For example, <c>CellMaps[0]</c> is to <c>CellMap.Empty + 0</c>, i.e. <c>r1c1</c>.
	/// </summary>
	internal static readonly CellMap[] CellMaps;

#if CACHE_CANDIDATE_MAPS
	/// <summary>
	/// Indicates a list of <see cref="CandidateMap"/> instances that are initialized as singleton element by its corresponding index.
	/// For example, <c>CandidateMaps[0]</c> is to <c>CandidateMap.Empty + 0</c>, i.e. <c>r1c1(1)</c>.
	/// </summary>
	internal static readonly CandidateMap[] CandidateMaps;
#endif


	/// <include file='../../global-doc-comments.xml' path='g/static-constructor' />
	static SolutionFields()
	{
		//
		// CellMaps
		//
		{
			CellMaps = new CellMap[81];
			var span = CellMaps.AsSpan();
			var cell = 0;
			foreach (ref var map in span)
			{
				map += cell++;
			}
		}

#if CACHE_CANDIDATE_MAPS
		//
		// CandidateMaps
		//
		{
			CandidateMaps = new CandidateMap[729];
			var span = CandidateMaps.AsSpan();
			var candidate = 0;
			foreach (ref var map in span)
			{
				map.Add(candidate++);
			}
		}
#endif	
	}
}
