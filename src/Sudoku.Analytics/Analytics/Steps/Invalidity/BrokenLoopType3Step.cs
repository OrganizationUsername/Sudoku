namespace Sudoku.Analytics.Steps;

/// <summary>
/// Provides with a step that is a <b>Broken Loop Type 3</b> technique.
/// </summary>
/// <param name="conclusions"><inheritdoc cref="Step.Conclusions" path="/summary"/></param>
/// <param name="views"><inheritdoc cref="Step.Views" path="/summary"/></param>
/// <param name="options"><inheritdoc cref="Step.Options" path="/summary"/></param>
/// <param name="loop"><inheritdoc cref="BrokenLoopStep.Loop" path="/summary"/></param>
/// <param name="guardians"><inheritdoc cref="BrokenLoopStep.Guardians" path="/summary"/></param>
/// <param name="extraCells"><inheritdoc cref="ExtraCells" path="/summary"/></param>
/// <param name="extraDigitsMask"><inheritdoc cref="ExtraDigitsMask" path="/summary"/></param>
public sealed class BrokenLoopType3Step(
	ReadOnlyMemory<Conclusion> conclusions,
	View[]? views,
	StepGathererOptions options,
	ReadOnlyMemory<Candidate> loop,
	in CandidateMap guardians,
	in CellMap extraCells,
	Mask extraDigitsMask
) : BrokenLoopStep(conclusions, views, options, loop, guardians)
{
	/// <inheritdoc/>
	public override int BaseDifficulty => base.BaseDifficulty - 1;

	/// <inheritdoc/>
	public override int Type => 3;

	/// <summary>
	/// Indicates the size of subset.
	/// </summary>
	public int ExtraDigitsSize => BitOperations.PopCount((uint)ExtraDigitsMask);

	/// <summary>
	/// Indicates extra cells.
	/// </summary>
	public CellMap ExtraCells { get; } = extraCells;

	/// <summary>
	/// Indicates extra digits mask.
	/// </summary>
	public Mask ExtraDigitsMask { get; } = extraDigitsMask;

	/// <inheritdoc/>
	public override Mask DigitsUsed => (Mask)(base.DigitsUsed | ExtraDigitsMask);

	/// <inheritdoc/>
	public override FactorArray Factors
		=> [
			.. base.Factors,
			Factor.Create(
				"Factor_BrokenLoopSubsetSizeFactor",
				[nameof(ExtraDigitsSize)],
				GetType(),
				static args => DifficultyCalculator.OeisSequences.A002024((int)args[0]!)
			)
		];

	/// <inheritdoc/>
	public override InterpolationArray Interpolations
		=> [
			new(SR.EnglishLanguage, [LoopStr, GuardiansStr, ExtraCellsStr, ExtraDigitsStr]),
			new(SR.ChineseLanguage, [LoopStr, GuardiansStr, ExtraCellsStr, ExtraDigitsStr])
		];

	private string ExtraCellsStr => Options.Converter.CellConverter(ExtraCells);

	private string ExtraDigitsStr => Options.Converter.DigitConverter(ExtraDigitsMask);
}
