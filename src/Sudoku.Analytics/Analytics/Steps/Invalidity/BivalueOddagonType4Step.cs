namespace Sudoku.Analytics.Steps;

/// <summary>
/// Provides with a step that is a <b>Bivalue Oddagon Type 4</b> technique.
/// </summary>
/// <param name="conclusions"><inheritdoc cref="Step.Conclusions" path="/summary"/></param>
/// <param name="views"><inheritdoc cref="Step.Views" path="/summary"/></param>
/// <param name="options"><inheritdoc cref="Step.Options" path="/summary"/></param>
/// <param name="loopCells"><inheritdoc cref="BivalueOddagonStep.LoopCells" path="/summary"/></param>
/// <param name="digit1"><inheritdoc cref="BivalueOddagonStep.Digit1" path="/summary"/></param>
/// <param name="digit2"><inheritdoc cref="BivalueOddagonStep.Digit2" path="/summary"/></param>
/// <param name="conjugatePair"><inheritdoc cref="ConjugatePair" path="/summary"/></param>
public sealed class BivalueOddagonType4Step(
	ReadOnlyMemory<Conclusion> conclusions,
	View[]? views,
	StepGathererOptions options,
	in CellMap loopCells,
	Digit digit1,
	Digit digit2,
	Conjugate conjugatePair
) : BivalueOddagonStep(conclusions, views, options, loopCells, digit1, digit2)
{
	/// <inheritdoc/>
	public override int Type => 4;

	/// <inheritdoc/>
	public override int BaseDifficulty => base.BaseDifficulty + 1;

	/// <summary>
	/// Indicates conjugate pair used.
	/// </summary>
	public Conjugate ConjugatePair { get; } = conjugatePair;

	/// <inheritdoc/>
	public override InterpolationArray Interpolations
		=> [
			new(SR.EnglishLanguage, [LoopStr, Digit1Str, Digit2Str, ConjugatePairStr]),
			new(SR.ChineseLanguage, [LoopStr, Digit1Str, Digit2Str, ConjugatePairStr])
		];

	private string Digit1Str => Options.Converter.DigitConverter((Mask)(1 << Digit1));

	private string Digit2Str => Options.Converter.DigitConverter((Mask)(1 << Digit2));

	private string ConjugatePairStr => Options.Converter.ConjugateConverter([ConjugatePair]);
}
