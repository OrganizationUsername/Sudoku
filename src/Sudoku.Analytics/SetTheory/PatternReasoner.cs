namespace Sudoku.SetTheory;

/// <summary>
/// Provides a list of members to get pattern detailed information that should be inferred.
/// </summary>
public static class PatternReasoner
{
	/// <summary>
	/// Try to find all possible permutations.
	/// </summary>
	/// <param name="pattern">The pattern.</param>
	/// <returns>The permutations.</returns>
	public static ReadOnlySpan<Permutation> GetPermutations(in Pattern pattern)
		=> SetSolver.Solve(pattern.Grid, pattern.Truths, pattern.Links);
}
