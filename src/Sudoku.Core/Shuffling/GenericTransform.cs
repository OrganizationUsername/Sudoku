namespace Sudoku.Shuffling;

/// <summary>
/// Represents a generic transform that includes the ranks of morphing types.
/// </summary>
/// <param name="TransposeRank">Indicates the rank of transpose.</param>
/// <param name="RelabeledRowsRank">Indicates the rank of relabeled rows.</param>
/// <param name="RelabeledColumnsRank">Indicates the rank of relabeled columns.</param>
/// <param name="RelabeledDigitsRank">Indicates the rank of relabeled digits.</param>
public readonly record struct GenericTransform(int TransposeRank, int RelabeledRowsRank, int RelabeledColumnsRank, int RelabeledDigitsRank) :
	IEqualityOperators<GenericTransform, GenericTransform, bool>
{
	/// <summary>
	/// Represents equivalent transform.
	/// </summary>
	public static readonly GenericTransform Equivalent = new(0, 0, 0, 0);

	/// <summary>
	/// Represents a transform that rotates 90 degrees clockwise.
	/// </summary>
	public static readonly GenericTransform ClockwiseRotate90Degrees = new(1, 0, ^1, 0);

	/// <summary>
	/// Represents a transform that rotates 180 degrees clockwise.
	/// </summary>
	public static readonly GenericTransform ClockwiseRotate180Degrees = new(0, ^1, ^1, 0);

	/// <summary>
	/// Represents a transform that rotates 270 degrees clockwise.
	/// </summary>
	public static readonly GenericTransform ClockwiseRotate270Degrees = new(1, ^1, 0, 0);

	/// <summary>
	/// Represents a transform that rotates 90 degrees counterclockwise.
	/// </summary>
	public static readonly GenericTransform CounterclockwiseRotate90Degrees = new(1, ^1, 0, 0);

	/// <summary>
	/// Represents a transform that rotates 180 degrees counterclockwise.
	/// </summary>
	public static readonly GenericTransform CounterclockwiseRotate180Degrees = new(0, ^1, ^1, 0);

	/// <summary>
	/// Represents a transform that rotates 270 degrees counterclockwise.
	/// </summary>
	public static readonly GenericTransform CounterclockwiseRotate270Degrees = new(1, 0, ^1, 0);

	/// <summary>
	/// Represents a transform that mirrors left-right side.
	/// </summary>
	public static readonly GenericTransform MirrorLeftRight = new(0, ^1, 0, 0);

	/// <summary>
	/// Represents a transform that mirrors top-bottom side.
	/// </summary>
	public static readonly GenericTransform MirrorTopBottom = new(0, 0, ^1, 0);

	/// <summary>
	/// Represents a transform that mirrors diagonal.
	/// </summary>
	public static readonly GenericTransform MirrorDiagonal = new(1, 0, 0, 0);

	/// <summary>
	/// Represents a transform that mirrors anti-diagonal.
	/// </summary>
	public static readonly GenericTransform MirrorAntidiagonal = new(1, ^1, ^1, 0);

	/// <summary>
	/// Represents a transpose transform.
	/// </summary>
	public static readonly GenericTransform Transpose = new(1, 0, 0, 0);


	/// <summary>
	/// Initializes a <see cref="GenericTransform"/> instance.
	/// </summary>
	/// <param name="transposeRank">
	/// <inheritdoc cref="GenericTransform(int, int, int, int)" path="/param[@name='TransposeRank']"/>
	/// </param>
	/// <param name="relabeledRowsRank">
	/// <inheritdoc cref="GenericTransform(int, int, int, int)" path="/param[@name='RelabeledRowsRank']"/>
	/// </param>
	/// <param name="relabeledColumnsRank">
	/// <inheritdoc cref="GenericTransform(int, int, int, int)" path="/param[@name='RelabeledColumnsRank']"/>
	/// </param>
	/// <param name="relabeledDigitsRank">
	/// <inheritdoc cref="GenericTransform(int, int, int, int)" path="/param[@name='RelabeledDigitsRank']"/>
	/// </param>
	public GenericTransform(int transposeRank, Index relabeledRowsRank, Index relabeledColumnsRank, Index relabeledDigitsRank) :
		this(
			transposeRank,
			relabeledRowsRank.GetOffset((int)TransformIdentifier.RelabelLinesPermutationsCount),
			relabeledColumnsRank.GetOffset((int)TransformIdentifier.RelabelLinesPermutationsCount),
			relabeledDigitsRank.GetOffset((int)TransformIdentifier.RelabelDigitsPermutationsCount)
		)
	{
	}

	/// <summary>
	/// Initializes a <see cref="GenericTransform"/> via the base-mixed rank.
	/// </summary>
	/// <param name="baseMixedRank">The base-mixed rank.</param>
	public GenericTransform(long baseMixedRank) :
		this(
			(int)(
				baseMixedRank
					/ TransformIdentifier.RelabelDigitsPermutationsCount
					/ TransformIdentifier.RelabelLinesPermutationsCount
					/ TransformIdentifier.RelabelLinesPermutationsCount
					% TransformIdentifier.TransposePermutationsCount
			),
			(int)(
				baseMixedRank
					/ TransformIdentifier.RelabelDigitsPermutationsCount
					/ TransformIdentifier.RelabelLinesPermutationsCount
					% TransformIdentifier.RelabelLinesPermutationsCount
			),
			(int)(
				baseMixedRank
					/ TransformIdentifier.RelabelDigitsPermutationsCount
					% TransformIdentifier.RelabelLinesPermutationsCount
			),
			(int)(baseMixedRank % TransformIdentifier.RelabelDigitsPermutationsCount)
		)
	{
	}


	/// <summary>
	/// Indicates whether to transpose.
	/// </summary>
	public bool ShouldTranspose => TransposeRank == 1;

	/// <summary>
	/// Indicates the base-mixed rank.
	/// </summary>
	public long BaseMixedRank
		=> TransposeRank * TransformIdentifier.RelabelLinesPermutationsCount * TransformIdentifier.RelabelLinesPermutationsCount * TransformIdentifier.RelabelDigitsPermutationsCount
		+ RelabeledRowsRank * TransformIdentifier.RelabelLinesPermutationsCount * TransformIdentifier.RelabelDigitsPermutationsCount
		+ RelabeledColumnsRank * TransformIdentifier.RelabelDigitsPermutationsCount
		+ RelabeledDigitsRank;

	/// <summary>
	/// Represents a value that displays relabeled row indices.
	/// </summary>
	public ReadOnlySpan<RowIndex> RowIndicesRelabeled => CantorExpansion.UnrankRelabeledLines(RelabeledRowsRank);

	/// <summary>
	/// Represents a value that displays relabeled column indices.
	/// </summary>
	public ReadOnlySpan<ColumnIndex> ColumnIndicesRelabeled => CantorExpansion.UnrankRelabeledLines(RelabeledColumnsRank);

	/// <summary>
	/// Represents a value that displayes relabeled digits.
	/// </summary>
	public ReadOnlySpan<Digit> DigitsRelabeled => CantorExpansion.UnrankRelabeledDigits(RelabeledDigitsRank, SpanEnumerable.Range(9));


	/// <summary>
	/// Explicit cast from <see cref="long"/> to <see cref="GenericTransform"/>.
	/// </summary>
	/// <param name="baseMixedRank">The base-mixed rank.</param>
	public static explicit operator GenericTransform(long baseMixedRank)
		=> new(Math.Abs(baseMixedRank) % TransformIdentifier.AllPermutationsCount);

	/// <summary>
	/// Explicit cast from <see cref="long"/> to <see cref="GenericTransform"/>, with range check.
	/// </summary>
	/// <param name="baseMixedRank">The base-mixed rank.</param>
	/// <exception cref="OverflowException">Throws when <paramref name="baseMixedRank"/> is invalid.</exception>
	public static explicit operator checked GenericTransform(long baseMixedRank)
		=> new(
			baseMixedRank is >= 0 and < TransformIdentifier.AllPermutationsCount
				? baseMixedRank
				: throw new OverflowException()
		);

	/// <summary>
	/// Implicit cast from <see cref="GenericTransform"/> to <see cref="long"/>.
	/// </summary>
	/// <param name="transform">The transform.</param>
	public static implicit operator long(GenericTransform transform) => transform.BaseMixedRank;
}
