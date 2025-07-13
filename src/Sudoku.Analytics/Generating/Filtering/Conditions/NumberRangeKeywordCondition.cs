namespace Sudoku.Generating.Filtering.Conditions;

/// <summary>
/// Represents number range keyword condition.
/// </summary>
[TypeImpl(TypeImplFlags.Object_GetHashCode)]
public sealed partial class NumberRangeKeywordCondition : KeywordCondition
{
	/// <summary>
	/// Indicates whether the range includes minimum value.
	/// </summary>
	[HashCodeMember]
	public bool IncludesMinimum { get; set; }

	/// <summary>
	/// Indicates whether the range includes maximum value.
	/// </summary>
	[HashCodeMember]
	public bool IncludesMaximum { get; set; }

	/// <summary>
	/// Indicates the minimum value.
	/// </summary>
	[HashCodeMember]
	public int Minimum { get; set; }

	/// <summary>
	/// Indicates the maximum value.
	/// </summary>
	[HashCodeMember]
	public int Maximum { get; set; }

	/// <inheritdoc/>
	public override KeywordVerbs Verb => KeywordVerbs.NumberRange;


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] KeywordCondition? other)
		=> other is NumberRangeKeywordCondition comparer
		&& Minimum == comparer.Minimum && Maximum == comparer.Maximum
		&& IncludesMinimum == comparer.IncludesMinimum && IncludesMaximum == comparer.IncludesMaximum;

	/// <inheritdoc/>
	public override bool IsSatisifed(Step instance, string keyword)
		=> GetValue(instance, keyword) switch
		{
			int keywordValue => (IncludesMinimum, IncludesMaximum) switch
			{
				(true, true) => keywordValue >= Minimum && keywordValue <= Maximum,
				(true, _) => keywordValue >= Minimum && keywordValue < Maximum,
				(_, true) => keywordValue > Minimum && keywordValue <= Maximum,
				_ => keywordValue > Minimum && keywordValue < Maximum
			},
			_ => false
		};

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
		=> string.Format(
			SR.Get("KeywordCondition_NumberRangeKeywordCondition", formatProvider as CultureInfo),
			[
				IncludesMinimum ? "[" : "(",
				Minimum.ToString(),
				Maximum.ToString(),
				IncludesMaximum ? "]" : ")"
			]
		);

	/// <inheritdoc/>
	public override NumberRangeKeywordCondition Clone()
		=> new() { Minimum = Minimum, Maximum = Maximum, IncludesMinimum = IncludesMinimum, IncludesMaximum = IncludesMaximum };
}
