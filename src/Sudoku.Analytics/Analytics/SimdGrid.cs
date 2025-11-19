namespace Sudoku.Analytics;

/// <summary>
/// Represents a type that stores cached grid data set that will be used in analysis operation.
/// </summary>
/// <remarks>
/// This type uses 496 bytes.
/// </remarks>
public readonly ref struct SimdGrid
{
	/// <summary>
	/// Indicates whether the grid has multiple solutions or not.
	/// </summary>
	/// <remarks>
	/// If the value is <see langword="false"/>, field <see cref="Solution"/> becomes non-<see langword="null"/>;
	/// otherwise, <see langword="null"/>.
	/// </remarks>
	public readonly bool HasMultipleSolutions;

	/// <summary>
	/// Indicates a list of cells that are empty cells in the grid.
	/// </summary>
	public readonly CellMap EmptyCellsMap;

	/// <summary>
	/// Indicates a list of cells that are bi-value cells in the grid.
	/// </summary>
	public readonly CellMap BivalueCellsMap;

	/// <summary>
	/// Indicates a list of <see cref="CellMap"/> instances indicating cell distribution on empty cell list for each digit.
	/// </summary>
	public readonly InlineArray9<CellMap> CandidatesMap;

	/// <summary>
	/// Indicates a list of <see cref="CellMap"/> instances indicating cell distribution on cell list for each digit,
	/// counting if a cell includes the candidate, or the cell is filled with the digit no matter whether it is a given.
	/// </summary>
	public readonly InlineArray9<CellMap> DigitsMap;

	/// <summary>
	/// Indicates a list of <see cref="CellMap"/> instances indicating cell distribution on cell list for each digit,
	/// counting if a cell is a given or modifiable filling with the digit.
	/// </summary>
	public readonly InlineArray9<CellMap> ValuesMap;

	/// <summary>
	/// Indicates the solution digits to original grid.
	/// </summary>
	public readonly Digit[]? Solution;

	/// <summary>
	/// Indicates the candidate list.
	/// </summary>
	public readonly Candidate[][] Candidates;


	/// <summary>
	/// Initializes a <see cref="SimdGrid"/> instance.
	/// </summary>
	/// <param name="grid">The read-only reference to the original grid.</param>
	public unsafe SimdGrid(ref readonly Grid grid)
	{
		var solutionString = stackalloc char[82];
		solutionString[81] = '\0';

		var solutionsCount = new BitwiseSolver().SolveString(grid.ToString("0"), solutionString, 2);
		if (solutionsCount != 1)
		{
			HasMultipleSolutions = true;
		}
		else
		{
			HasMultipleSolutions = false;
			Solution = new Digit[81];
			for (var i = 0; i < 81; i++)
			{
				Solution[i] = solutionString[i] - '0';
			}
		}

		EmptyCellsMap = grid.EmptyCells;
		BivalueCellsMap = grid.BivalueCells;

		Candidates = new Candidate[81][];
		for (var cell = 0; cell < 81; cell++)
		{
			if (grid.GetState(cell) == CellState.Empty)
			{
				Candidates[cell] = grid.GetCandidates(cell).AllSets.ToArray();
			}
		}

		var candidatesMap = grid.CandidatesMap;
		var digitsMap = grid.DigitsMap;
		var valuesMap = grid.ValuesMap;
		for (var digit = 0; digit < 9; digit++)
		{
			CandidatesMap[digit] = candidatesMap[digit];
			DigitsMap[digit] = digitsMap[digit];
			ValuesMap[digit] = valuesMap[digit];
		}
	}


	/// <inheritdoc/>
	public override unsafe string ToString()
	{
		var indenting = new string(' ', 4);
		char* solutionString;
		if (HasMultipleSolutions)
		{
			solutionString = null;
		}
		else
		{
			var t = stackalloc char[82];
			t[81] = '\0';
			solutionString = t;
		}
		if (!HasMultipleSolutions && Solution is not null)
		{
			for (var cell = 0; cell < 81; cell++)
			{
				solutionString[cell] = (char)(Solution[cell] + '0');
			}
		}

		return
			$"""
			Solution:
			{indenting}{(HasMultipleSolutions ? "<null>" : new(solutionString))}
			Empty cells:
			{indenting}{EmptyCellsMap}
			Bivalue cells:
			{indenting}{BivalueCellsMap}
			Candidates map:
			{indenting}[0]: {CandidatesMap[0]} ({CandidatesMap[0].Count})
			{indenting}[1]: {CandidatesMap[1]} ({CandidatesMap[1].Count})
			{indenting}[2]: {CandidatesMap[2]} ({CandidatesMap[2].Count})
			{indenting}[3]: {CandidatesMap[3]} ({CandidatesMap[3].Count})
			{indenting}[4]: {CandidatesMap[4]} ({CandidatesMap[4].Count})
			{indenting}[5]: {CandidatesMap[5]} ({CandidatesMap[5].Count})
			{indenting}[6]: {CandidatesMap[6]} ({CandidatesMap[6].Count})
			{indenting}[7]: {CandidatesMap[7]} ({CandidatesMap[7].Count})
			{indenting}[8]: {CandidatesMap[8]} ({CandidatesMap[8].Count})
			""";
	}
}
