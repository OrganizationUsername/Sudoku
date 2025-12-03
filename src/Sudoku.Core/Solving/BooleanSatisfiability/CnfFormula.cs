namespace Sudoku.Solving.BooleanSatisfiability;

/// <summary>
/// Represents a Boolean formula in Conjunctive Normal Form (CNF).
/// Stores a list of clauses, where each clause is an array of <see cref="int"/> literals.
/// Positive integers represent a variable assigned <see langword="true"/>; negative integers represent the
/// negation of that variable (i.e. the literal is <see langword="false"/>).
/// </summary>
/// <param name="VariablesCount">Indicates total number of variables.</param>
/// <remarks>
/// Each clause is a disjunction of literals; the whole formula is the conjunction of clauses.
/// This type is a compact, immutable-ish container for CNF clauses used by the SAT solver.
/// For background on CNF, see <see href="https://en.wikipedia.org/wiki/Conjunctive_normal_form">Wikipedia</see>.
/// </remarks>
/// <seealso href="https://en.wikipedia.org/wiki/Conjunctive_normal_form">Wikipedia - Conjunctive Normal Form</seealso>
public sealed record CnfFormula(int VariablesCount) : IEnumerable<ReadOnlyMemory<int>>
{
	/// <summary>
	/// Number of clauses currently stored in the formula.
	/// </summary>
	public int ClauseCount => Clauses.Count;

	/// <summary>
	/// Internal storage for clauses. Each clause is stored as a <see cref="ReadOnlyMemory{T}"/>
	/// to avoid unnecessary allocations when passing clauses around.
	/// </summary>
	/// <seealso cref="ReadOnlyMemory{T}"/>
	internal List<ReadOnlyMemory<int>> Clauses { get; } = [];


	/// <summary>
	/// Get clause at the specified index.
	/// </summary>
	/// <param name="index">The desired index.</param>
	/// <returns>The clause.</returns>
	public ReadOnlyMemory<int> this[int index] => Clauses[index];


	/// <summary>
	/// Add a new clause (disjunction of literals) to the expression.
	/// </summary>
	/// <param name="literals">The literals that form the clause.</param>
	public void AddClause(ReadOnlyMemory<int> literals) => Clauses.Add(literals);

	/// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
	public AnonymousSpanEnumerator<ReadOnlyMemory<int>> GetEnumerator() => new(Clauses.AsSpan());

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => Clauses.GetEnumerator();

	/// <inheritdoc/>
	IEnumerator<ReadOnlyMemory<int>> IEnumerable<ReadOnlyMemory<int>>.GetEnumerator() => Clauses.GetEnumerator();
}
