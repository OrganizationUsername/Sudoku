namespace Sudoku.Filtering.Conditions;

/// <summary>
/// Represents number equality keyword condition.
/// </summary>
public sealed class NumberComparisonKeywordCondition : KeywordCondition
{
	/// <summary>
	/// Indicates the value to be compared.
	/// </summary>
	public int Value { get; set; }

	/// <summary>
	/// Indicates the operator to be used.
	/// </summary>
	public ComparisonOperator Operator { get; set; }

	/// <inheritdoc/>
	public override KeywordVerbs Verb => KeywordVerbs.NumberComparison;


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] KeywordCondition? other)
		=> other is NumberComparisonKeywordCondition comparer && Value == comparer.Value && Operator == comparer.Operator;

	/// <inheritdoc/>
	public override bool IsSatisifed(Step instance, string keyword)
		=> GetValue(instance, keyword) switch { int keywordValue => Operator.OperatorInt32(keywordValue, Value), _ => false };

	/// <inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(Value, Operator);

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
		=> string.Format(
			SR.Get("KeywordCondition_NumberComparisonKeywordCondition", formatProvider as CultureInfo),
			[Operator.OperatorString, Value.ToString()]
		);

	/// <inheritdoc/>
	public override NumberComparisonKeywordCondition Clone() => new() { Value = Value, Operator = Operator };
}
