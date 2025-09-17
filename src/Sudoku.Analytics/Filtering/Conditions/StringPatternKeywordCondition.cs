namespace Sudoku.Filtering.Conditions;

/// <summary>
/// Represents a keyword condition.
/// </summary>
public sealed class StringPatternKeywordCondition : KeywordCondition
{
	/// <summary>
	/// Indicates the value to be checked.
	/// </summary>
	public string Value { get; set; } = "*";

	/// <inheritdoc/>
	public override KeywordVerbs Verb => KeywordVerbs.StringPattern;

	/// <summary>
	/// Indicates the pattern to be used.
	/// </summary>
	private Regex Pattern => new(Value);


	/// <inheritdoc/>
	public override bool IsValueValid()
	{
		try
		{
			Regex.Match(string.Empty, Value);
			return true;
		}
		catch (ArgumentException)
		{
			return false;
		}
	}

	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] KeywordCondition? other)
		=> other is StringPatternKeywordCondition comparer && Value == comparer.Value;

	/// <inheritdoc/>
	public override bool IsSatisifed(Step instance, string keyword)
		=> GetValue(instance, keyword) switch { string str => Pattern.IsMatch(str), _ => false };

	/// <inheritdoc/>
	public override int GetHashCode() => Value.GetHashCode();

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
		=> string.Format(
			SR.Get("KeywordCondition_StringPatternKeywordCondition", formatProvider as CultureInfo),
			Value
		);

	/// <inheritdoc/>
	public override StringPatternKeywordCondition Clone() => new() { Value = Value };
}
