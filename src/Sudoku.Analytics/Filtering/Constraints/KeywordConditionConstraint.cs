namespace Sudoku.Filtering.Constraints;

/// <summary>
/// Represents a constraint that checks for a keyword.
/// </summary>
[ConstraintOptions(AllowsMultiple = true)]
public sealed class KeywordConditionConstraint : Constraint
{
	/// <summary>
	/// Indicates the keyword.
	/// </summary>
	public string Keyword { get; set; } = string.Empty;

	/// <summary>
	/// Indicates the technique.
	/// </summary>
	public Technique Technique { get; set; }

	/// <summary>
	/// Indicates the condition encapsulated.
	/// </summary>
	public KeywordCondition? Condition { get; set; }


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] Constraint? other)
		=> other is KeywordConditionConstraint comparer
		&& Condition == comparer.Condition && Technique == comparer.Technique && Keyword == comparer.Keyword;

	/// <inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(Keyword, Technique, Condition);

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
	{
		var culture = formatProvider as CultureInfo;
		return string.Format(
			SR.Get("KeywordConditionConstraint", culture),
			[Technique.GetName(culture), Condition?.ToString(culture)]
		);
	}

	/// <inheritdoc/>
	public override KeywordConditionConstraint Clone()
		=> new() { Condition = Condition?.Clone(), Technique = Technique, Keyword = Keyword };

	/// <inheritdoc/>
	protected override bool CheckCore(ConstraintCheckingContext context)
	{
		foreach (var step in context.AnalysisResult)
		{
			if (step.Code == Technique && (Condition?.IsSatisifed(step, Keyword) ?? true))
			{
				return true;
			}
		}
		return false;
	}
}
