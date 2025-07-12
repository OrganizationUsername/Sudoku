namespace Sudoku.Generating;

public partial struct EmptyHouseBasedGenerator
{
	/// <summary>
	/// <para>Indicates valid combinations of blocks to be cleared.</para>
	/// <para>
	/// This field is provided as optimization on selection,
	/// in order to prevent combinations that will cause multiple solutions after selected.
	/// But different with <see cref="InvalidLineCombinations"/>, this field can be checked as valid combinations.
	/// If you can find a block that is inside the current table, the block will be a valid selection; otherwise, not.
	/// </para>
	/// <para>
	/// This table requires you select at least 2 blocks before using.
	/// You should use a <see langword="foreach"/> loop to iterate all pairs of selected blocks like this:
	/// <code><![CDATA[
	/// var invalidFlag = false;
	/// foreach (var combination in blocks.AllSets.GetSubsets(2))
	/// {
	///     // Read table through the following way:
	///     var validBlocks = ValidHouseCombinations_Blocks[combination[0] * 9 + combination[1]];
	/// 
	///     // Determine whether the chosen house is invalid:
	///     if ((validBlocks >> newSelectedHouse & 1) == 0)
	///     {
	///         // Invalid selection.
	///         invalidFlag = true;
	///         break;
	///     }
	/// }
	/// ]]></code>
	/// </para>
	/// </summary>
	public static readonly HouseMask[] ValidBlockCombinations = [
		0,
		1 << 5 | 1 << 8,
		1 << 4 | 1 << 7,
		1 << 7 | 1 << 8,
		1 << 2 | 1 << 5 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 1 | 1 << 4 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 4 | 1 << 5,
		1 << 2 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 8,
		1 << 1 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 7,
		1 << 5 | 1 << 8,
		0,
		1 << 3 | 1 << 6,
		1 << 2 | 1 << 5 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 6 | 1 << 8,
		1 << 0 | 1 << 3 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 2 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 8,
		1 << 3 | 1 << 5,
		1 << 0 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 6,
		1 << 4 | 1 << 7,
		1 << 3 | 1 << 6,
		0,
		1 << 1 | 1 << 4 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 0 | 1 << 3 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 6 | 1 << 7,
		1 << 1 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 7,
		1 << 0 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 6,
		1 << 3 | 1 << 4,
		1 << 7 | 1 << 8,
		1 << 2 | 1 << 5 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 1 | 1 << 4 | 1 << 6 | 1 << 7 | 1 << 8,
		0,
		1 << 2 | 1 << 8,
		1 << 1 | 1 << 7,
		1 << 1 | 1 << 2,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 5 | 1 << 8,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 4 | 1 << 7,
		1 << 2 | 1 << 5 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 6 | 1 << 8,
		1 << 0 | 1 << 3 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 2 | 1 << 8,
		0,
		1 << 0 | 1 << 6,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 5 | 1 << 8,
		1 << 0 | 1 << 2,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 6,
		1 << 1 | 1 << 4 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 0 | 1 << 3 | 1 << 6 | 1 << 7 | 1 << 8,
		1 << 6 | 1 << 7,
		1 << 1 | 1 << 7,
		1 << 0 | 1 << 6,
		0,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 4 | 1 << 7,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 6,
		1 << 0 | 1 << 1,
		1 << 4 | 1 << 5,
		1 << 2 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 8,
		1 << 1 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 7,
		1 << 1 | 1 << 2,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 5 | 1 << 8,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 4 | 1 << 7,
		0,
		1 << 2 | 1 << 5,
		1 << 1 | 1 << 4,
		1 << 2 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 8,
		1 << 3 | 1 << 5,
		1 << 0 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 6,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 5 | 1 << 8,
		1 << 0 | 1 << 2,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 6,
		1 << 2 | 1 << 5,
		0,
		1 << 0 | 1 << 3,
		1 << 1 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 7,
		1 << 0 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 6,
		1 << 3 | 1 << 4,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 4 | 1 << 7,
		1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 6,
		1 << 0 | 1 << 1,
		1 << 1 | 1 << 4,
		1 << 0 | 1 << 3,
		0
	];

	/// <summary>
	/// <para>
	/// Indicates invalid combinations of lines (index 9 - 26) to be cleared.
	/// Such combinations will make puzzle have multiple solutions.
	/// </para>
	/// <para>
	/// You can compare houses cleared with such values,
	/// to know whether a combination of cleared houses are invalid.
	/// For example, a valid puzzle (having a unique solution) cannot remove all cells from row 1 and 2;
	/// otherwise, digits from row 1 can be replaced with digits from row 2 with same column.
	/// </para>
	/// </summary>
	public static readonly HouseMask[][] InvalidLineCombinations = [
		[0b000_000_000__000_000_011__000_000_000, 0b000_000_000__000_000_101__000_000_000],
		[0b000_000_000__000_000_110__000_000_000, 0b000_000_000__000_000_011__000_000_000],
		[0b000_000_000__000_000_101__000_000_000, 0b000_000_000__000_000_110__000_000_000],
		[0b000_000_000__000_011_000__000_000_000, 0b000_000_000__000_101_000__000_000_000],
		[0b000_000_000__000_110_000__000_000_000, 0b000_000_000__000_011_000__000_000_000],
		[0b000_000_000__000_101_000__000_000_000, 0b000_000_000__000_110_000__000_000_000],
		[0b000_000_000__011_000_000__000_000_000, 0b000_000_000__101_000_000__000_000_000],
		[0b000_000_000__110_000_000__000_000_000, 0b000_000_000__011_000_000__000_000_000],
		[0b101_000_000__000_000_000__000_000_000, 0b110_000_000__000_000_000__000_000_000],
		[0b000_000_011__000_000_000__000_000_000, 0b000_000_101__000_000_000__000_000_000],
		[0b000_000_110__000_000_000__000_000_000, 0b000_000_011__000_000_000__000_000_000],
		[0b000_000_101__000_000_000__000_000_000, 0b000_000_110__000_000_000__000_000_000],
		[0b000_011_000__000_000_000__000_000_000, 0b000_101_000__000_000_000__000_000_000],
		[0b000_110_000__000_000_000__000_000_000, 0b000_011_000__000_000_000__000_000_000],
		[0b000_101_000__000_000_000__000_000_000, 0b000_110_000__000_000_000__000_000_000],
		[0b011_000_000__000_000_000__000_000_000, 0b101_000_000__000_000_000__000_000_000],
		[0b110_000_000__000_000_000__000_000_000, 0b011_000_000__000_000_000__000_000_000],
		[0b101_000_000__000_000_000__000_000_000, 0b110_000_000__000_000_000__000_000_000]
	];
}
