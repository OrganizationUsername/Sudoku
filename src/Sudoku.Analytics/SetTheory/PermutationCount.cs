namespace Sudoku.SetTheory;

/// <summary>
/// Represents a range of number of permutations found in a pattern.
/// Instances of this type will be returned by method .
/// </summary>
/// <param name="MinimumCount">Indicates the minimum number of a permutation.</param>
/// <param name="MaximumCount">Indicates the maximum number of a permutation.</param>
public readonly record struct PermutationCountRange(int MinimumCount, int MaximumCount) :
	IEqualityOperators<PermutationCountRange, PermutationCountRange, bool>
{
	/// <summary>
	/// Indicates whether the pattern is stable.
	/// </summary>
	public bool IsStable => MinimumCount == MaximumCount;

	/// <summary>
	/// Indicates the delta value.
	/// </summary>
	public int Delta => MaximumCount - MinimumCount;
}
