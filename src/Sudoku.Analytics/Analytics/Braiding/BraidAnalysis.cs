namespace Sudoku.Analytics.Braiding;

/// <summary>
/// Provides an entry to analyze braiding of a chute in a pattern.
/// </summary>
public static class BraidAnalysis
{
	/// <summary>
	/// Indicates top-3 cells defined in the specified chute, sequence index and type.
	/// </summary>
	private static readonly CellMap[] TopThreeCellsMap;

	/// <summary>
	/// Represents the map of all rotation patterns, grouped by sequence index (0..3) and type.
	/// </summary>
	private static readonly FrozenDictionary<Strand, ChuteStrandMap> StrandsMap;


	/// <include file='../../global-doc-comments.xml' path='g/static-constructor' />
	static BraidAnalysis()
	{
		var strandsMap = new Dictionary<Strand, ChuteStrandMap>();
		TopThreeCellsMap = new CellMap[Chute.MaxChuteIndex * 3];

		// Iterate on each chute.
		foreach (var (chuteIndex, _, housesMask) in Chute.Chutes)
		{
			// Get three houses of the chute.
			var house1 = BitOperations.TrailingZeroCount(housesMask);
			var house2 = housesMask.GetNextSet(house1);
			var house3 = housesMask.GetNextSet(house2);

			// Starts with the specified segment.
			for (var sequenceIndex = 0; sequenceIndex < 3; sequenceIndex++)
			{
				// Try to get the first 3 cells from the top-left segment.
				ref readonly var cellsFromHouse1 = ref HousesMap[sequenceIndex switch { 0 => house1, 1 => house2, _ => house3 }];
				var cells1 = cellsFromHouse1[..3];
				var otherCells1 = cellsFromHouse1 & ~cells1;
				var globalIndex = ProjectGlobalIndex(chuteIndex, sequenceIndex);
				TopThreeCellsMap[globalIndex] = cells1;

				// Then do rotate-shifting with N or Z mode.
				foreach (var mode in (StrandType.Downside, StrandType.Upside))
				{
					// Get the second segment.
					ref readonly var cellsFromHouse2 = ref HousesMap[
						(sequenceIndex, mode) switch
						{
							(0, StrandType.Downside) => house2,
							(0, _) => house3,
							(1, StrandType.Downside) => house3,
							(1, _) => house1,
							(2, StrandType.Downside) => house1,
							_ => house2
						}
					];
					var cells2 = cellsFromHouse2[3..6];
					var otherCells2 = cellsFromHouse2 & ~cells2;

					// Get the third segment.
					ref readonly var cellsFromHouse3 = ref HousesMap[
						(sequenceIndex, mode) switch
						{
							(0, StrandType.Downside) => house3,
							(0, _) => house2,
							(1, StrandType.Downside) => house1,
							(1, _) => house3,
							(2, StrandType.Downside) => house2,
							_ => house1
						}
					];
					var cells3 = cellsFromHouse3[6..];
					var otherCells3 = cellsFromHouse3 & ~cells3;

					// Merge them up.
					var otherCellsFromChute = otherCells1 | otherCells2 | otherCells3;

					// Add value into the dictionary.
					strandsMap.Add(new(chuteIndex, sequenceIndex, mode), new([cells1, cells2, cells3], otherCellsFromChute));
				}
			}
		}

		StrandsMap = strandsMap.ToFrozenDictionary();
	}


	/// <summary>
	/// Projects global index from chute index (0..6) and sequence index (0..3).
	/// </summary>
	/// <param name="chuteIndex">The chute index.</param>
	/// <param name="sequenceIndex">The sequence index.</param>
	/// <returns>The global index.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ProjectGlobalIndex(int chuteIndex, int sequenceIndex)
		=> (chuteIndex / 3 * 3 + chuteIndex % 3) * 3 + sequenceIndex;

	/// <summary>
	/// Get cells at the specified chute, sequence index and type.
	/// </summary>
	/// <param name="chuteIndex">The chute index (0..6).</param>
	/// <param name="sequenceIndex">The sequence index (0..3).</param>
	/// <param name="type">The type.</param>
	/// <returns>The map of the strand.</returns>
	public static ref readonly ChuteStrandMap GetCellsAt(int chuteIndex, Digit sequenceIndex, StrandType type)
		=> ref GetCellsAt(new(chuteIndex, sequenceIndex, type));

	/// <summary>
	/// Get cells at the specified strand.
	/// </summary>
	/// <param name="label">The label of strand.</param>
	/// <returns>The map of the strand.</returns>
	public static ref readonly ChuteStrandMap GetCellsAt(Strand label) => ref StrandsMap[label];

	/// <summary>
	/// Gets the pattern type of three digits in the specified chute.
	/// </summary>
	/// <param name="solutionGrid">The solution to a certain grid.</param>
	/// <param name="chuteIndex">The chute (0..6).</param>
	/// <param name="sequenceIndex">The sequence index (0..3).</param>
	/// <returns>The first three digits from the segment, specified as <paramref name="sequenceIndex"/>.</returns>
	/// <exception cref="ArgumentException">Throws when the argument must be solved.</exception>
	public static BraidingType GetPattern(in Grid solutionGrid, int chuteIndex, int sequenceIndex)
	{
		ArgumentException.Assert(solutionGrid.IsSolved);

		var globalIndex = ProjectGlobalIndex(chuteIndex, sequenceIndex);
		ref readonly var topThreeCells = ref TopThreeCellsMap[globalIndex];
		var valuesMap = solutionGrid.ValuesMap;

		var result = new List<StrandType>(3);

		// Iterate on each cell.
		foreach (var cell in topThreeCells)
		{
			var digit = solutionGrid.GetDigit(cell);

			// Check for two types of rotation.
			foreach (var type in (StrandType.Downside, StrandType.Upside))
			{
				var strand = new Strand(chuteIndex, sequenceIndex, type);
				ref readonly var cells = ref StrandsMap[strand].Included;
				if ((valuesMap[digit] & cells).Count == 3)
				{
					// Valid.
					result.Add(type);
					break;
				}
			}
		}
		return BraidingType.Create(result[0], result[1], result[2]);
	}

	/// <summary>
	/// Maps all digits in the specified grid that can be categorized as N or Z mode in the specified chute.
	/// </summary>
	/// <param name="grid">The grid.</param>
	/// <param name="chuteIndex">The chute index (0..6).</param>
	/// <returns>A dictionary of strands and the digits that can be categorized as this strand.</returns>
	public static FrozenDictionary<Strand, Mask> MapStrands(in Grid grid, int chuteIndex)
	{
		var result = new Dictionary<Strand, Mask>();
		MapStrandsCore(grid, chuteIndex, result);
		return result.ToFrozenDictionary();
	}

	/// <summary>
	/// Maps all digits in the specified grid that can be categorized as N or Z mode.
	/// </summary>
	/// <param name="grid">The grid.</param>
	/// <returns>A dictionary of strands and the digits that can be categorized as this strand.</returns>
	public static FrozenDictionary<Strand, Mask> MapStrands(in Grid grid)
	{
		var result = new Dictionary<Strand, Mask>();
		MapStrandsCore(grid, -1, result);
		return result.ToFrozenDictionary();
	}

	/// <summary>
	/// Try to infer braiding type of the specified chute.
	/// </summary>
	/// <param name="grid">The grid.</param>
	/// <param name="chuteIndex">The chute index (0..6).</param>
	/// <param name="result">The type inferred. If none found, <see cref="BraidingType.None"/> will be returned.</param>
	/// <param name="singlesLookup">
	/// The result distribution of digits must be appeared in the specified strands.
	/// The value is not <see langword="null"/> if and only if the return value is <see langword="true"/>.
	/// </param>
	/// <returns>A <see cref="bool"/> result indicating whether the type can be inferred with unique value.</returns>
	/// <seealso cref="BraidingType.None"/>
	public static bool TryInferType(
		in Grid grid,
		int chuteIndex,
		out BraidingType result,
		[NotNullWhen(true)] out FrozenDictionary<Strand, Mask>? singlesLookup
	)
	{
		result = BraidingType.None;

		// Define a result dictionary and initialize it with original values.
		var resultDictionary = new Dictionary<Strand, Mask>(MapStrands(grid, chuteIndex));
		var candidateBraidingTypes = BraidingType.NRope | BraidingType.NBraid | BraidingType.ZBraid | BraidingType.ZRope;

		// Find hidden / naked single appeared in either N part or Z part.<br/>
		// Here "hidden single" and "naked single" are not technique ones,
		// they are special concepts describing cases that can be concluded:
		// <list type="bullet">
		// <item>
		// <b>Hidden single</b> -
		// If a digit can only appeared once in the only strand of all strands defined in <c>mappedStrands</c>,
		// it must be correct.
		// </item>
		// <item>
		// <b>Naked single</b> - If a digit is the only one satisifed in a single strand
		// (others are not appeared), it must be correct.
		// </item>
		// </list>
		var tempDictionary = new Dictionary<Strand, Mask>();
		bool hasAnyChanges;
		do
		{
			tempDictionary.Clear();
			hasAnyChanges = false;

			// Hidden single part.
			for (var digit = 0; digit < 9; digit++)
			{
				var lastAppearedStrand = default(Strand?);
				foreach (var strand in resultDictionary.Keys)
				{
					// Check whether this strand contains such digit or not.
					if ((resultDictionary[strand] >> digit & 1) != 0)
					{
						if (lastAppearedStrand is not null)
						{
							// The digit can be appeared in at least 2 strands.
							// We cannot determine which one is correct.
							goto NextDigit;
						}

						// Otherwise, assign it into temporary variable.
						lastAppearedStrand = strand;
					}
				}

				// If here, we know that the digit can only be appeared in one strand.
				if (lastAppearedStrand is not { } onlyStrand)
				{
					throw new InvalidOperationException("Why here?!");
				}

				// Add it into dictionary as "hidden single" rule.
				var mask = (Mask)(1 << digit);
				hasAnyChanges = updateAndCheckChanges(tempDictionary, onlyStrand, mask);

			NextDigit:
				;
			}

			// Naked single part.
			foreach (var (strand, mask) in resultDictionary)
			{
				if (BitOperations.IsPow2(mask))
				{
					hasAnyChanges = updateAndCheckChanges(tempDictionary, strand, mask);
				}
			}

			// TODO: Hidden pair and naked pair part.

			// Now we should update dictionary if worth, and infer braiding types.
			if (hasAnyChanges)
			{
				// Infer braiding types.
				// Check each strand in 'tempDictionary' to know whether any conclusions here.
				foreach (var ((_, _, strandType), mask) in tempDictionary)
				{
					switch (BitOperations.PopCount((uint)mask))
					{
						// Must be NNN or ZZZ.
						case 3:
						{
							candidateBraidingTypes = strandType == StrandType.Downside ? BraidingType.NRope : BraidingType.ZRope;
							break;
						}

						// N mode with <c>popcount == 2</c> <=> Not NZZ.
						// Z mode with <c>popcount == 2</c> <=> Not NNZ.
						case 2:
						{
							candidateBraidingTypes &= ~(strandType == StrandType.Downside ? BraidingType.ZBraid : BraidingType.NBraid);
							goto case 1;
						}

						// N mode with <c>popcount >= 0</c> <=> Not ZZZ.
						// Z mode with <c>popcount >= 0</c> <=> Not NNN.
						case 1:
						{
							candidateBraidingTypes &= ~(strandType == StrandType.Downside ? BraidingType.ZRope : BraidingType.NRope);
							break;
						}
					}
				}

				// Check and update result dictionary table.
				if (candidateBraidingTypes.IsFlag)
				{
					result = candidateBraidingTypes;
					(hasAnyChanges, var (nCount, zCount)) = (false, (result.NCount, result.ZCount));
					foreach (var (strand, mask) in tempDictionary)
					{
						if (BitOperations.PopCount((uint)mask) == (strand.Type == StrandType.Downside ? nCount : zCount))
						{
							resultDictionary[strand] &= mask;
							hasAnyChanges = true;
						}
					}
				}
			}
		} while (hasAnyChanges);

		// Get values and return.
		singlesLookup = result != BraidingType.None ? resultDictionary.ToFrozenDictionary() : null;
		return result != BraidingType.None;


		static bool updateAndCheckChanges(Dictionary<Strand, Mask> dictionary, in Strand strand, Mask mask)
		{
			if (!dictionary.TryGetValue(strand, out var originalMask))
			{
				dictionary.Add(strand, mask);
				return true;
			}
			if ((originalMask & mask) != mask)
			{
				dictionary[strand] |= mask;
				return true;
			}
			return false;
		}
	}

	/// <summary>
	/// The core method of mapping strands.
	/// </summary>
	/// <param name="grid">The grid.</param>
	/// <param name="chuteIndex">The chute index (0..6). -1 for all chutes checking.</param>
	/// <param name="value">The value.</param>
	private static void MapStrandsCore(in Grid grid, int chuteIndex, Dictionary<Strand, Mask> value)
	{
		var digitsMap = grid.DigitsMap;
		foreach (ref readonly var strand in Strand.Strands)
		{
			var ((c, sequenceIndex, _), mask) = (strand, (Mask)0);
			if (chuteIndex != -1 && c != chuteIndex)
			{
				continue;
			}

			var includedSegments = StrandsMap[strand].IncludedSegments;

			// Iterate on each digit appeared in this group of cells.
			var globalIndex = ProjectGlobalIndex(chuteIndex, sequenceIndex);
			foreach (var digit in grid[TopThreeCellsMap[globalIndex], true])
			{
				var allSegmentsSatisfied = true;
				foreach (ref readonly var segmentCells in includedSegments)
				{
					if (!(digitsMap[digit] & segmentCells))
					{
						allSegmentsSatisfied = false;
						break;
					}
				}
				if (allSegmentsSatisfied)
				{
					mask |= (Mask)(1 << digit);
				}
			}

			// Add the target mask into dictionary.
			value.Add(strand, mask);
		}
	}
}
