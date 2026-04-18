namespace SudokuStudio.BindableSource;

/// <summary>
/// Represents a list of <see cref="DrawableConcept"/> instances to indicate diff items
/// (which items are added, and which items are removed).
/// </summary>
/// <seealso cref="DrawableConcept"/>
public readonly ref struct ViewUnitBindableSourceDiff
{
	/// <summary>
	/// Indicates whether the collection is empty.
	/// </summary>
	public bool IsEmpty => Positives.Length == 0 && Negatives.Length == 0;

	/// <summary>
	/// Indicates the positives.
	/// </summary>
	public readonly required ReadOnlySpan<DrawableConcept> Positives { get; init; }

	/// <summary>
	/// Indicates the negatives.
	/// </summary>
	public readonly required ReadOnlySpan<DrawableConcept> Negatives { get; init; }


	/// <include file="../../global-doc-comments.xml" path="g/csharp7/feature[@name='deconstruct-method']/target[@name='method']"/>
	public void Deconstruct(out ReadOnlySpan<DrawableConcept> negatives, out ReadOnlySpan<DrawableConcept> positives)
	{
		negatives = Negatives;
		positives = Positives;
	}


	/// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)"/>
	public static ViewUnitBindableSourceDiff operator +(ViewUnitBindableSourceDiff value) => value;

	/// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)"/>
	public static ViewUnitBindableSourceDiff operator -(ViewUnitBindableSourceDiff value)
		=> new() { Negatives = value.Positives, Positives = value.Negatives };
}
