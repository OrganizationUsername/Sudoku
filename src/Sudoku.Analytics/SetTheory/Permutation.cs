namespace Sudoku.SetTheory;

/// <summary>
/// Represents a permutation of assigned candidates, indicating such candidates can satisfy specified truths and links.
/// </summary>
/// <param name="Assignments">Indicates the assignments.</param>
public readonly record struct Permutation(ReadOnlyMemory<Candidate> Assignments) :
	IComparable<Permutation>,
	IComparisonOperators<Permutation, Permutation, bool>,
	IEqualityOperators<Permutation, Permutation, bool>,
	IFormattable
{
	/// <summary>
	/// Indicates candidates.
	/// </summary>
	private CandidateMap Candidates => Assignments.Span.AsCandidateMap();


	/// <inheritdoc/>
	public bool Equals(Permutation other) => Candidates == other.Candidates;

	/// <inheritdoc/>
	public override int GetHashCode() => Candidates.GetHashCode();

	/// <inheritdoc/>
	public int CompareTo(Permutation other) => Candidates.CompareTo(other.Candidates);

	/// <inheritdoc/>
	public override string ToString() => ToString(null);

	/// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
	public string ToString(IFormatProvider? formatProvider) => ToString(null, formatProvider);

	/// <inheritdoc/>
	public string ToString(string? format, IFormatProvider? formatProvider)
		=> formatProvider is ICustomFormatter customFormatter
			? customFormatter.Format(format, this, formatProvider)
			: CoordinateConverter.GetInstance(formatProvider).CandidateConverter(Candidates);


	/// <inheritdoc/>
	public static bool operator >(Permutation left, Permutation right) => left.CompareTo(right) > 0;

	/// <inheritdoc/>
	public static bool operator <(Permutation left, Permutation right) => left.CompareTo(right) < 0;

	/// <inheritdoc/>
	public static bool operator >=(Permutation left, Permutation right) => left.CompareTo(right) >= 0;

	/// <inheritdoc/>
	public static bool operator <=(Permutation left, Permutation right) => left.CompareTo(right) <= 0;
}
