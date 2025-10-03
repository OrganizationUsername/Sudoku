namespace Sudoku.Analytics.Steps;

/// <summary>
/// Provides with a step that is a <b>Broken Loop Type 2</b> technique.
/// </summary>
/// <param name="conclusions"><inheritdoc cref="Step.Conclusions" path="/summary"/></param>
/// <param name="views"><inheritdoc cref="Step.Views" path="/summary"/></param>
/// <param name="options"><inheritdoc cref="Step.Options" path="/summary"/></param>
/// <param name="loop"><inheritdoc cref="BrokenLoopStep.Loop" path="/summary"/></param>
/// <param name="guardians"><inheritdoc cref="BrokenLoopStep.Guardians" path="/summary"/></param>
public sealed class BrokenLoopType2Step(
	ReadOnlyMemory<Conclusion> conclusions,
	View[]? views,
	StepGathererOptions options,
	ReadOnlyMemory<Candidate> loop,
	in CandidateMap guardians
) : BrokenLoopStep(conclusions, views, options, loop, guardians)
{
	/// <inheritdoc/>
	public override int Type => 2;

	/// <inheritdoc/>
	public override int BaseDifficulty => base.BaseDifficulty + 1;
}
