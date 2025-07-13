namespace Sudoku.Generating.Filtering.Conditions;

/// <summary>
/// Represents string equality condition.
/// </summary>
[TypeImpl(TypeImplFlags.Object_GetHashCode)]
public sealed partial class StringEqualityComparisonKeywordCondition : KeywordCondition
{
	/// <summary>
	/// Indicates the value to be compared.
	/// </summary>
	[HashCodeMember]
	public string Value { get; set; } = string.Empty;

	/// <inheritdoc/>
	public override KeywordVerbs Verb => KeywordVerbs.StringEqualityComparison;


	/// <inheritdoc/>
	public override bool IsSatisifed(Step instance, string keyword)
		=> GetValue(instance, keyword) switch
		{
			string str => str == Value,
			Enum field => field.ToString() == Value,
			_ => false
		};

	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] KeywordCondition? other)
		=> other is StringEqualityComparisonKeywordCondition comparer && Value == comparer.Value;

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
		=> string.Format(
			SR.Get("KeywordCondition_StringEqualityComparisonKeywordCondition", formatProvider as CultureInfo),
			Value
		);

	/// <inheritdoc/>
	public override StringEqualityComparisonKeywordCondition Clone() => new() { Value = Value };
}
