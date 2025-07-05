namespace Sudoku.Generating.Filtering.Constraints;

/// <summary>
/// Represents a constraint that checks for a keyword.
/// </summary>
/// <param name="condition"><inheritdoc cref="Condition" path="/summary"/></param>
/// <param name="technique"><inheritdoc cref="Technique" path="/summary"/></param>
/// <param name="keyword"><inheritdoc cref="Keyword" path="/summary"/></param>
[ConstraintOptions(AllowsMultiple = true)]
[TypeImpl(TypeImplFlags.Object_GetHashCode | TypeImplFlags.Object_ToString)]
public sealed partial class KeywordConditionConstraint(KeywordCondition condition, Technique technique, string keyword) : Constraint
{
	/// <summary>
	/// Indicates the keyword.
	/// </summary>
	[HashCodeMember]
	public string Keyword { get; } = keyword;

	/// <summary>
	/// Indicates the technique.
	/// </summary>
	[HashCodeMember]
	public Technique Technique { get; } = technique;

	/// <summary>
	/// Indicates the condition encapsulated.
	/// </summary>
	[HashCodeMember]
	public KeywordCondition Condition { get; } = condition;


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] Constraint? other)
		=> other is KeywordConditionConstraint comparer
		&& Condition == comparer.Condition && Technique == comparer.Technique && Keyword == comparer.Keyword;

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
	{
		var culture = formatProvider as CultureInfo;
		return string.Format(
			SR.Get("KeywordConditionConstraint", culture),
			[Technique.GetName(culture), Condition.ToString(culture)]
		);
	}

	/// <inheritdoc/>
	public override KeywordConditionConstraint Clone() => new(Condition.Clone(), Technique, Keyword);

	/// <inheritdoc/>
	protected override bool CheckCore(ConstraintCheckingContext context)
	{
		foreach (var step in context.AnalysisResult)
		{
			if (step.Code == Technique && Condition.IsSatisifed(step, Keyword))
			{
				return true;
			}
		}
		return false;
	}
}
