namespace Sudoku.SetTheory;

/// <summary>
/// Represents an encapsulated type that describes how many assigned values are filled into a certain pattern,
/// created by method <see cref="LogicReasoner.GetAssignedCount(ref readonly Logic)"/>.
/// </summary>
/// <param name="Min">Indicates the minimum number of a permutation.</param>
/// <param name="Max">Indicates the maximum number of a permutation.</param>
/// <seealso cref="LogicReasoner.GetAssignedCount(ref readonly Logic)"/>
public readonly record struct AssignedCount(int Min, int Max) : IEqualityOperators<AssignedCount, AssignedCount, bool>
{
	/// <summary>
	/// Indicates whether the pattern is stable.
	/// </summary>
	public bool IsStable => Min == Max;

	/// <summary>
	/// Indicates the delta value.
	/// </summary>
	public int Delta => Max - Min;
}
