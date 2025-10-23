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

	/// <summary>
	/// Backing field of <see cref="ChuteMaps"/>.
	/// </summary>
	private static readonly CellMap[] ChuteMapsBackingField;

	/// <summary>
	/// Backing field of <see cref="Chutes"/>.
	/// </summary>
	private static readonly Chute[] ChutesBackingField;


	/// <summary>
	/// Indicates the chute maps.
	/// </summary>
	public static ReadOnlySpan<CellMap> ChuteMaps => ChuteMapsBackingField;

	/// <summary>
	/// Indicates a list of <see cref="Chute"/> instances representing chutes.
	/// </summary>
	public static ReadOnlySpan<Chute> Chutes => ChutesBackingField;


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

		var chuteHouses = (ReadOnlySpan<(House, House, House)>)[(9, 10, 11), (12, 13, 14), (15, 16, 17), (18, 19, 20), (21, 22, 23), (24, 25, 26)];

		//
		// ChuteMaps
		//
		{
			ChuteMapsBackingField = new CellMap[6];
			for (var chute = 0; chute < 3; chute++)
			{
				var ((r1, r2, r3), (c1, c2, c3)) = (chuteHouses[chute], chuteHouses[chute + 3]);
				(ChuteMapsBackingField[chute], ChuteMapsBackingField[chute + 3]) = (HousesMap[r1] | HousesMap[r2] | HousesMap[r3], HousesMap[c1] | HousesMap[c2] | HousesMap[c3]);
			}
		}

		//
		// Chutes
		//
		{
			ChutesBackingField = new Chute[6];
			for (var chute = 0; chute < 3; chute++)
			{
				var ((r1, r2, r3), (c1, c2, c3)) = (chuteHouses[chute], chuteHouses[chute + 3]);
				(ChutesBackingField[chute], ChutesBackingField[chute + 3]) = (
					new(chute, true, 1 << r1 | 1 << r2 | 1 << r3),
					new(chute + 3, false, 1 << c1 | 1 << c2 | 1 << c3)
				);
			}
		}
	}
}
