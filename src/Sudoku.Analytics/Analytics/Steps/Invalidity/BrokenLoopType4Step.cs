namespace Sudoku.Analytics.Steps;

/// <summary>
/// Provides with a step that is a <b>Broken Loop Type 4</b> technique.
/// </summary>
/// <param name="conclusions"><inheritdoc cref="Step.Conclusions" path="/summary"/></param>
/// <param name="views"><inheritdoc cref="Step.Views" path="/summary"/></param>
/// <param name="options"><inheritdoc cref="Step.Options" path="/summary"/></param>
/// <param name="loop"><inheritdoc cref="BrokenLoopStep.Loop" path="/summary"/></param>
/// <param name="guardians"><inheritdoc cref="BrokenLoopStep.Guardians" path="/summary"/></param>
/// <param name="conjugate"><inheritdoc cref="Conjugate" path="/summary"/></param>
public sealed class BrokenLoopType4Step(
	ReadOnlyMemory<Conclusion> conclusions,
	View[]? views,
	StepGathererOptions options,
	ReadOnlyMemory<Candidate> loop,
	in CandidateMap guardians,
	Conjugate conjugate
) : BrokenLoopStep(conclusions, views, options, loop, guardians)
{
	/// <inheritdoc/>
	public override int Type => 4;

	/// <inheritdoc/>
	public override int BaseDifficulty => base.BaseDifficulty + 2;

	/// <inheritdoc/>
	public override Mask DigitsUsed => (Mask)(base.DigitsUsed | (Mask)(1 << Conjugate.Digit));

	/// <summary>
	/// Indicates the conjugate pair.
	/// </summary>
	public Conjugate Conjugate { get; } = conjugate;

	/// <inheritdoc/>
	public override InterpolationArray Interpolations
		=> [
			new(SR.EnglishLanguage, [LoopStr, GuardiansStr, ConjugateStr]),
			new(SR.ChineseLanguage, [LoopStr, GuardiansStr, ConjugateStr])
		];

	private string ConjugateStr => Options.Converter.ConjugateConverter([Conjugate]);
}
