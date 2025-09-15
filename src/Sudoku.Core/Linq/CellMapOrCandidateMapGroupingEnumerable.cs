namespace Sudoku.Linq;

/// <summary>
/// Represents a list of LINQ methods used by <see cref="CellMapOrCandidateMapGrouping{TMap, TElement, TKey}"/> instances.
/// </summary>
/// <seealso cref="CellMapOrCandidateMapGrouping{TMap, TElement, TKey}"/>
public static class CellMapOrCandidateMapGroupingEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/>
	/// of <see cref="CellMapOrCandidateMapGrouping{TMap, TElement, TKey}"/>
	/// of <see cref="CellMap"/>, <see cref="Cell"/> and <typeparamref name="TKey"/>,
	/// where <typeparamref name="TKey"/> satisfies <see langword="notnull"/> constraint.
	/// </summary>
	/// <typeparam name="TKey">The type of the grouping.</typeparam>
	/// <param name="this">The list to be checked.</param>
	extension<TKey>(ReadOnlySpan<CellMapOrCandidateMapGrouping<CellMap, Cell, TKey>> @this) where TKey : notnull
	{
		/// <summary>
		/// Projects a list of <see cref="CellMapOrCandidateMapGrouping{TMap, TElement, TKey}"/> of types <see cref="CellMap"/>,
		/// <see cref="Cell"/> and <typeparamref name="TKey"/>, into a <see cref="Cell"/> value; collect converted results and merge
		/// into a <see cref="CellMap"/> instance.
		/// </summary>
		/// <param name="selector">The transform method to apply to each element.</param>
		/// <returns>The result.</returns>
		public CellMap Select(Func<CellMapOrCandidateMapGrouping<CellMap, Cell, TKey>, Cell> selector)
		{
			var result = CellMap.Empty;
			foreach (var group in @this)
			{
				result += selector(group);
			}
			return result;
		}
	}

	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/>
	/// of <see cref="CellMapOrCandidateMapGrouping{TMap, TElement, TKey}"/>
	/// of <see cref="CandidateMap"/>, <see cref="Candidate"/> and <typeparamref name="TKey"/>,
	/// where <typeparamref name="TKey"/> satisfies <see langword="notnull"/> constraint.
	/// </summary>
	/// <typeparam name="TKey">The type of the grouping.</typeparam>
	/// <param name="this">The list to be checked.</param>
	extension<TKey>(ReadOnlySpan<CellMapOrCandidateMapGrouping<CandidateMap, Candidate, TKey>> @this) where TKey : notnull
	{
		/// <summary>
		/// Projects a list of <see cref="CellMapOrCandidateMapGrouping{TMap, TElement, TKey}"/> of types <see cref="CandidateMap"/>,
		/// <see cref="Candidate"/> and <typeparamref name="TKey"/>, into a <see cref="Candidate"/> value; collect converted results
		/// and merge into a <see cref="CandidateMap"/> instance.
		/// </summary>
		/// <param name="selector">The transform method to apply to each element.</param>
		/// <returns>The result.</returns>
		public CandidateMap Select(Func<CellMapOrCandidateMapGrouping<CandidateMap, Candidate, TKey>, Candidate> selector)
		{
			var result = CandidateMap.Empty;
			foreach (var group in @this)
			{
				result += selector(group);
			}
			return result;
		}
	}
}
