namespace Sudoku.Generating.Filtering.Conditions;

/// <summary>
/// Represents number equality keyword condition.
/// </summary>
[TypeImpl(TypeImplFlags.Object_GetHashCode)]
public sealed partial class NumberComparisonKeywordCondition : KeywordCondition
{
	/// <summary>
	/// Indicates the value to be compared.
	/// </summary>
	[HashCodeMember]
	public int Value { get; set; }

	/// <summary>
	/// Indicates the operator to be used.
	/// </summary>
	[HashCodeMember]
	public ComparisonOperator Operator { get; set; }

	/// <inheritdoc/>
	public override KeywordVerbs Verb => KeywordVerbs.NumberComparison;


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] KeywordCondition? other)
		=> other is NumberComparisonKeywordCondition comparer && Value == comparer.Value && Operator == comparer.Operator;

	/// <inheritdoc/>
	public override bool IsSatisifed(Step instance, string keyword)
		=> GetValue(instance, keyword) switch
		{
			int keywordValue => Operator.GetOperator<int>()(keywordValue, Value),
			_ => false
		};

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
		=> string.Format(
			SR.Get("KeywordCondition_NumberComparisonKeywordCondition", formatProvider as CultureInfo),
			[Operator.OperatorString, Value.ToString()]
		);

	/// <inheritdoc/>
	public override NumberComparisonKeywordCondition Clone() => new() { Value = Value, Operator = Operator };
}
