namespace Sudoku.Analytics.Dependency;

/// <summary>
/// Represents an assignment for a group of cells and the specified digit.
/// </summary>
/// <param name="Digit">Indicates the digit.</param>
/// <param name="Cells">Indicates cells used.</param>
public readonly record struct DependencyAssignment(Digit Digit, in CellMap Cells) :
	IEqualityOperators<DependencyAssignment, DependencyAssignment, bool>
{
	/// <summary>
	/// Initializes an <see cref="DependencyAssignment"/> instance via the specified candidate.
	/// </summary>
	/// <param name="candidate">The candidate.</param>
	public DependencyAssignment(Candidate candidate) : this(candidate % 9, (candidate / 9).AsCellMap())
	{
	}


	/// <summary>
	/// Indicates whether the assignment instance is for grouped set rule.
	/// </summary>
	public bool IsGrouped => Cells.Count != 1;


	/// <inheritdoc cref="ToCandidateFormatString(bool, IFormatProvider?)"/>
	public string ToCandidateFormatString(bool enableConsoleColors) => ToCandidateFormatString(enableConsoleColors, null);

	/// <summary>
	/// Returns a string instance that displays like a candidate format.
	/// </summary>
	/// <param name="enableConsoleColors">
	/// Indicates whether the output text will include control characters like <c>\e</c>,
	/// in order to display colors in console output stream.
	/// </param>
	/// <param name="formatProvider">The coordinate format converter.</param>
	/// <returns>The string representation.</returns>
	public string ToCandidateFormatString(bool enableConsoleColors, IFormatProvider? formatProvider)
	{
		var converter = CoordinateConverter.GetInstance(formatProvider);
		var candidates = Cells * Digit;
		return IsGrouped && enableConsoleColors
			? $"\e[38;2;255;255;0m{converter.CandidateConverter(candidates)}\e[0m"
			: converter.CandidateConverter(candidates);
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp9/feature[@name='records']/target[@name='method' and @cref='PrintMembers']"/>
	private bool PrintMembers(StringBuilder builder)
	{
		builder.Append($"{nameof(Digit)} = {Digit + 1}, ");
		builder.Append($"{nameof(Cells)} = {Cells}");
		return true;
	}
}
