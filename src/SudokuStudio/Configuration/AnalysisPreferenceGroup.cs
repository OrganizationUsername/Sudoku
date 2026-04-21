namespace SudokuStudio.Configuration;

/// <summary>
/// Represents with preference items that is used by <see cref="Analyzer"/> or <see cref="Collector"/>.
/// </summary>
/// <seealso cref="Analyzer"/>
/// <seealso cref="Collector"/>
public sealed partial class AnalysisPreferenceGroup : PreferenceGroup
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableFullHouse"/>.
	/// </summary>
	/// <seealso cref="EnableFullHouse"/>
	public static readonly DependencyProperty EnableFullHouseProperty =
		DependencyProperty.Register(nameof(EnableFullHouse), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableLastDigit"/>.
	/// </summary>
	/// <seealso cref="EnableLastDigit"/>
	public static readonly DependencyProperty EnableLastDigitProperty =
		DependencyProperty.Register(nameof(EnableLastDigit), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HiddenSinglesInBlockFirst"/>.
	/// </summary>
	/// <seealso cref="HiddenSinglesInBlockFirst"/>
	public static readonly DependencyProperty HiddenSinglesInBlockFirstProperty =
		DependencyProperty.Register(nameof(HiddenSinglesInBlockFirst), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableOrderingStepsByLastingValue"/>.
	/// </summary>
	/// <seealso cref="EnableOrderingStepsByLastingValue"/>
	public static readonly DependencyProperty EnableOrderingStepsByLastingValueProperty =
		DependencyProperty.Register(nameof(EnableOrderingStepsByLastingValue), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowDirectPointing"/>.
	/// </summary>
	/// <seealso cref="AllowDirectPointing"/>
	public static readonly DependencyProperty AllowDirectPointingProperty =
		DependencyProperty.Register(nameof(AllowDirectPointing), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowDirectClaiming"/>.
	/// </summary>
	/// <seealso cref="AllowDirectClaiming"/>
	public static readonly DependencyProperty AllowDirectClaimingProperty =
		DependencyProperty.Register(nameof(AllowDirectClaiming), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowDirectLockedSubset"/>.
	/// </summary>
	/// <seealso cref="AllowDirectLockedSubset"/>
	public static readonly DependencyProperty AllowDirectLockedSubsetProperty =
		DependencyProperty.Register(nameof(AllowDirectLockedSubset), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowDirectNakedSubset"/>.
	/// </summary>
	/// <seealso cref="AllowDirectNakedSubset"/>
	public static readonly DependencyProperty AllowDirectNakedSubsetProperty =
		DependencyProperty.Register(nameof(AllowDirectNakedSubset), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowDirectLockedHiddenSubset"/>.
	/// </summary>
	/// <seealso cref="AllowDirectLockedHiddenSubset"/>
	public static readonly DependencyProperty AllowDirectLockedHiddenSubsetProperty =
		DependencyProperty.Register(nameof(AllowDirectLockedHiddenSubset), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowDirectHiddenSubset"/>.
	/// </summary>
	/// <seealso cref="AllowDirectHiddenSubset"/>
	public static readonly DependencyProperty AllowDirectHiddenSubsetProperty =
		DependencyProperty.Register(nameof(AllowDirectHiddenSubset), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DirectNakedSubsetMaxSize"/>.
	/// </summary>
	/// <seealso cref="DirectNakedSubsetMaxSize"/>
	public static readonly DependencyProperty DirectNakedSubsetMaxSizeProperty =
		DependencyProperty.Register(nameof(DirectNakedSubsetMaxSize), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(2));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DirectHiddenSubsetMaxSize"/>.
	/// </summary>
	/// <seealso cref="DirectHiddenSubsetMaxSize"/>
	public static readonly DependencyProperty DirectHiddenSubsetMaxSizeProperty =
		DependencyProperty.Register(nameof(DirectHiddenSubsetMaxSize), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(2));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="NakedSubsetMaxSizeInComplexSingle"/>.
	/// </summary>
	/// <seealso cref="NakedSubsetMaxSizeInComplexSingle"/>
	public static readonly DependencyProperty NakedSubsetMaxSizeInComplexSingleProperty =
		DependencyProperty.Register(nameof(NakedSubsetMaxSizeInComplexSingle), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(4));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HiddenSubsetMaxSizeInComplexSingle"/>.
	/// </summary>
	/// <seealso cref="HiddenSubsetMaxSizeInComplexSingle"/>
	public static readonly DependencyProperty HiddenSubsetMaxSizeInComplexSingleProperty =
		DependencyProperty.Register(nameof(HiddenSubsetMaxSizeInComplexSingle), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(4));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisableFinnedOrSashimiXWing"/>.
	/// </summary>
	/// <seealso cref="DisableFinnedOrSashimiXWing"/>
	public static readonly DependencyProperty DisableFinnedOrSashimiXWingProperty =
		DependencyProperty.Register(nameof(DisableFinnedOrSashimiXWing), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisableGroupedTurbotFish"/>.
	/// </summary>
	/// <seealso cref="DisableGroupedTurbotFish"/>
	public static readonly DependencyProperty DisableGroupedTurbotFishProperty =
		DependencyProperty.Register(nameof(DisableGroupedTurbotFish), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowSiameseNormalFish"/>.
	/// </summary>
	/// <seealso cref="AllowSiameseNormalFish"/>
	public static readonly DependencyProperty AllowSiameseNormalFishProperty =
		DependencyProperty.Register(nameof(AllowSiameseNormalFish), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowSiameseComplexFish"/>.
	/// </summary>
	/// <seealso cref="AllowSiameseComplexFish"/>
	public static readonly DependencyProperty AllowSiameseComplexFishProperty =
		DependencyProperty.Register(nameof(AllowSiameseComplexFish), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MaxSizeOfComplexFish"/>.
	/// </summary>
	/// <seealso cref="MaxSizeOfComplexFish"/>
	public static readonly DependencyProperty MaxSizeOfComplexFishProperty =
		DependencyProperty.Register(nameof(MaxSizeOfComplexFish), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(5));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowIncompleteUniqueRectangles"/>.
	/// </summary>
	/// <seealso cref="AllowIncompleteUniqueRectangles"/>
	public static readonly DependencyProperty AllowIncompleteUniqueRectanglesProperty =
		DependencyProperty.Register(nameof(AllowIncompleteUniqueRectangles), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SearchForExtendedUniqueRectangles"/>.
	/// </summary>
	/// <seealso cref="SearchForExtendedUniqueRectangles"/>
	public static readonly DependencyProperty SearchForExtendedUniqueRectanglesProperty =
		DependencyProperty.Register(nameof(SearchForExtendedUniqueRectangles), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SearchExtendedBivalueUniversalGraveTypes"/>.
	/// </summary>
	/// <seealso cref="SearchExtendedBivalueUniversalGraveTypes"/>
	public static readonly DependencyProperty SearchExtendedBivalueUniversalGraveTypesProperty =
		DependencyProperty.Register(nameof(SearchExtendedBivalueUniversalGraveTypes), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AlmostLockedCandidatesCheckValueTypes"/>.
	/// </summary>
	/// <seealso cref="AlmostLockedCandidatesCheckValueTypes"/>
	public static readonly DependencyProperty AlmostLockedCandidatesCheckValueTypesProperty =
		DependencyProperty.Register(nameof(AlmostLockedCandidatesCheckValueTypes), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CheckAlmostLockedQuadruple"/>.
	/// </summary>
	/// <seealso cref="CheckAlmostLockedQuadruple"/>
	public static readonly DependencyProperty CheckAlmostLockedQuadrupleProperty =
		DependencyProperty.Register(nameof(CheckAlmostLockedQuadruple), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AllowSiameseXyzRing"/>.
	/// </summary>
	/// <seealso cref="AllowSiameseXyzRing"/>
	public static readonly DependencyProperty AllowSiameseXyzRingProperty =
		DependencyProperty.Register(nameof(AllowSiameseXyzRing), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MaxSizeOfRegularWing"/>.
	/// </summary>
	/// <seealso cref="MaxSizeOfRegularWing"/>
	public static readonly DependencyProperty MaxSizeOfRegularWingProperty =
		DependencyProperty.Register(nameof(MaxSizeOfRegularWing), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(5));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MakeConclusionAroundBackdoorsNormalChain"/>.
	/// </summary>
	/// <seealso cref="MakeConclusionAroundBackdoorsNormalChain"/>
	public static readonly DependencyProperty MakeConclusionAroundBackdoorsNormalChainProperty =
		DependencyProperty.Register(nameof(MakeConclusionAroundBackdoorsNormalChain), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(false));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MakeConclusionAroundBackdoorsGroupedChain"/>.
	/// </summary>
	/// <seealso cref="MakeConclusionAroundBackdoorsGroupedChain"/>
	public static readonly DependencyProperty MakeConclusionAroundBackdoorsGroupedChainProperty =
		DependencyProperty.Register(nameof(MakeConclusionAroundBackdoorsGroupedChain), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(false));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AlignedExclusionMaxSearchingSize"/>.
	/// </summary>
	/// <seealso cref="AlignedExclusionMaxSearchingSize"/>
	public static readonly DependencyProperty AlignedExclusionMaxSearchingSizeProperty =
		DependencyProperty.Register(nameof(AlignedExclusionMaxSearchingSize), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(3));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SearchForReverseBugPartiallyUsedTypes"/>.
	/// </summary>
	/// <seealso cref="SearchForReverseBugPartiallyUsedTypes"/>
	public static readonly DependencyProperty SearchForReverseBugPartiallyUsedTypesProperty =
		DependencyProperty.Register(nameof(SearchForReverseBugPartiallyUsedTypes), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ReverseBugMaxSearchingEmptyCellsCount"/>.
	/// </summary>
	/// <seealso cref="ReverseBugMaxSearchingEmptyCellsCount"/>
	public static readonly DependencyProperty ReverseBugMaxSearchingEmptyCellsCountProperty =
		DependencyProperty.Register(nameof(ReverseBugMaxSearchingEmptyCellsCount), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(2));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SearchExtendedDeathBlossomTypes"/>.
	/// </summary>
	/// <seealso cref="SearchExtendedDeathBlossomTypes"/>
	public static readonly DependencyProperty SearchExtendedDeathBlossomTypesProperty =
		DependencyProperty.Register(nameof(SearchExtendedDeathBlossomTypes), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisplayDifficultyRatingForSudokuExplainer"/>.
	/// </summary>
	/// <seealso cref="DisplayDifficultyRatingForSudokuExplainer"/>
	public static readonly DependencyProperty DisplayDifficultyRatingForSudokuExplainerProperty =
		DependencyProperty.Register(nameof(DisplayDifficultyRatingForSudokuExplainer), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AlsoDisplayEnglishNameOfStep"/>.
	/// </summary>
	/// <seealso cref="AlsoDisplayEnglishNameOfStep"/>
	public static readonly DependencyProperty AlsoDisplayEnglishNameOfStepProperty =
		DependencyProperty.Register(nameof(AlsoDisplayEnglishNameOfStep), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisplayDifficultyRatingForHodoku"/>.
	/// </summary>
	/// <seealso cref="DisplayDifficultyRatingForHodoku"/>
	public static readonly DependencyProperty DisplayDifficultyRatingForHodokuProperty =
		DependencyProperty.Register(nameof(DisplayDifficultyRatingForHodoku), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AnalyzerIsFullApplying"/>.
	/// </summary>
	/// <seealso cref="AnalyzerIsFullApplying"/>
	public static readonly DependencyProperty AnalyzerIsFullApplyingProperty =
		DependencyProperty.Register(nameof(AnalyzerIsFullApplying), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CollectorMaxStepsCollected"/>.
	/// </summary>
	/// <seealso cref="CollectorMaxStepsCollected"/>
	public static readonly DependencyProperty CollectorMaxStepsCollectedProperty =
		DependencyProperty.Register(nameof(CollectorMaxStepsCollected), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(1000));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DifficultyLevelMode"/>.
	/// </summary>
	/// <seealso cref="DifficultyLevelMode"/>
	public static readonly DependencyProperty DifficultyLevelModeProperty =
		DependencyProperty.Register(nameof(DifficultyLevelMode), typeof(int), typeof(AnalysisPreferenceGroup), new PropertyMetadata(0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AnalyzerUseIttoryuMode"/>.
	/// </summary>
	/// <seealso cref="AnalyzerUseIttoryuMode"/>
	public static readonly DependencyProperty AnalyzerUseIttoryuModeProperty =
		DependencyProperty.Register(nameof(AnalyzerUseIttoryuMode), typeof(bool), typeof(AnalysisPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="InitialLetter"/>.
	/// </summary>
	/// <seealso cref="InitialLetter"/>
	public static readonly DependencyProperty InitialLetterProperty =
		DependencyProperty.Register(nameof(InitialLetter), typeof(BabaGroupInitialLetter), typeof(AnalysisPreferenceGroup), new PropertyMetadata((BabaGroupInitialLetter)4));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LetterCasing"/>.
	/// </summary>
	/// <seealso cref="LetterCasing"/>
	public static readonly DependencyProperty LetterCasingProperty =
		DependencyProperty.Register(nameof(LetterCasing), typeof(BabaGroupLetterCase), typeof(AnalysisPreferenceGroup), new PropertyMetadata((BabaGroupLetterCase)1));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DirectModeBottleneckType"/>.
	/// </summary>
	/// <seealso cref="DirectModeBottleneckType"/>
	public static readonly DependencyProperty DirectModeBottleneckTypeProperty =
		DependencyProperty.Register(nameof(DirectModeBottleneckType), typeof(BottleneckType), typeof(AnalysisPreferenceGroup), new PropertyMetadata((BottleneckType)4));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PartialMarkingModeBottleneckType"/>.
	/// </summary>
	/// <seealso cref="PartialMarkingModeBottleneckType"/>
	public static readonly DependencyProperty PartialMarkingModeBottleneckTypeProperty =
		DependencyProperty.Register(nameof(PartialMarkingModeBottleneckType), typeof(BottleneckType), typeof(AnalysisPreferenceGroup), new PropertyMetadata((BottleneckType)1));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="FullMarkingModeBottleneckType"/>.
	/// </summary>
	/// <seealso cref="FullMarkingModeBottleneckType"/>
	public static readonly DependencyProperty FullMarkingModeBottleneckTypeProperty =
		DependencyProperty.Register(nameof(FullMarkingModeBottleneckType), typeof(BottleneckType), typeof(AnalysisPreferenceGroup), new PropertyMetadata((BottleneckType)0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="OverriddenLinkOptions"/>.
	/// </summary>
	/// <seealso cref="OverriddenLinkOptions"/>
	public static readonly DependencyProperty OverriddenLinkOptionsProperty =
		DependencyProperty.Register(nameof(OverriddenLinkOptions), typeof(Dictionary<LinkType, LinkOption>), typeof(AnalysisPreferenceGroup), new PropertyMetadata(OverriddenLinkOptionsDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="IttoryuSupportedTechniques"/>.
	/// </summary>
	/// <seealso cref="IttoryuSupportedTechniques"/>
	public static readonly DependencyProperty IttoryuSupportedTechniquesProperty =
		DependencyProperty.Register(nameof(IttoryuSupportedTechniques), typeof(List<Technique>), typeof(AnalysisPreferenceGroup), new PropertyMetadata(IttoryuSupportedTechniquesDefaultValue));

	private static readonly List<Technique> IttoryuSupportedTechniquesDefaultValue = [
		Technique.FullHouse,
		Technique.HiddenSingleBlock,
		Technique.HiddenSingleRow,
		Technique.HiddenSingleColumn,
		Technique.NakedSingle
	];

	private static readonly Dictionary<LinkType, LinkOption> OverriddenLinkOptionsDefaultValue = new()
	{
		{ LinkType.SingleDigit, LinkOption.All },
		{ LinkType.SingleCell, LinkOption.All },
		{ LinkType.KrakenNormalFish, LinkOption.None }
	};


	/// <inheritdoc cref="SingleStepSearcher.EnableFullHouse"/>
	public bool EnableFullHouse
	{
		get => (bool)GetValue(EnableFullHouseProperty);

		set => SetValue(EnableFullHouseProperty, value);
	}

	/// <inheritdoc cref="SingleStepSearcher.EnableLastDigit"/>
	public bool EnableLastDigit
	{
		get => (bool)GetValue(EnableLastDigitProperty);

		set => SetValue(EnableLastDigitProperty, value);
	}

	/// <inheritdoc cref="SingleStepSearcher.HiddenSinglesInBlockFirst"/>
	public bool HiddenSinglesInBlockFirst
	{
		get => (bool)GetValue(HiddenSinglesInBlockFirstProperty);

		set => SetValue(HiddenSinglesInBlockFirstProperty, value);
	}

	/// <inheritdoc cref="SingleStepSearcher.EnableOrderingStepsByLastingValue"/>
	public bool EnableOrderingStepsByLastingValue
	{
		get => (bool)GetValue(EnableOrderingStepsByLastingValueProperty);

		set => SetValue(EnableOrderingStepsByLastingValueProperty, value);
	}

	/// <inheritdoc cref="DirectIntersectionStepSearcher.AllowDirectPointing"/>
	public bool AllowDirectPointing
	{
		get => (bool)GetValue(AllowDirectPointingProperty);

		set => SetValue(AllowDirectPointingProperty, value);
	}

	/// <inheritdoc cref="DirectIntersectionStepSearcher.AllowDirectClaiming"/>
	public bool AllowDirectClaiming
	{
		get => (bool)GetValue(AllowDirectClaimingProperty);

		set => SetValue(AllowDirectClaimingProperty, value);
	}

	/// <inheritdoc cref="DirectSubsetStepSearcher.AllowDirectLockedSubset"/>
	public bool AllowDirectLockedSubset
	{
		get => (bool)GetValue(AllowDirectLockedSubsetProperty);

		set => SetValue(AllowDirectLockedSubsetProperty, value);
	}

	/// <inheritdoc cref="DirectSubsetStepSearcher.AllowDirectNakedSubset"/>
	public bool AllowDirectNakedSubset
	{
		get => (bool)GetValue(AllowDirectNakedSubsetProperty);

		set => SetValue(AllowDirectNakedSubsetProperty, value);
	}

	/// <inheritdoc cref="DirectSubsetStepSearcher.AllowDirectLockedHiddenSubset"/>
	public bool AllowDirectLockedHiddenSubset
	{
		get => (bool)GetValue(AllowDirectLockedHiddenSubsetProperty);

		set => SetValue(AllowDirectLockedHiddenSubsetProperty, value);
	}

	/// <inheritdoc cref="DirectSubsetStepSearcher.AllowDirectHiddenSubset"/>
	public bool AllowDirectHiddenSubset
	{
		get => (bool)GetValue(AllowDirectHiddenSubsetProperty);

		set => SetValue(AllowDirectHiddenSubsetProperty, value);
	}

	/// <inheritdoc cref="DirectSubsetStepSearcher.DirectNakedSubsetMaxSize"/>
	public int DirectNakedSubsetMaxSize
	{
		get => (int)GetValue(DirectNakedSubsetMaxSizeProperty);

		set => SetValue(DirectNakedSubsetMaxSizeProperty, value);
	}

	/// <inheritdoc cref="DirectSubsetStepSearcher.DirectHiddenSubsetMaxSize"/>
	public int DirectHiddenSubsetMaxSize
	{
		get => (int)GetValue(DirectHiddenSubsetMaxSizeProperty);

		set => SetValue(DirectHiddenSubsetMaxSizeProperty, value);
	}

	/// <inheritdoc cref="ComplexSingleStepSearcher.NakedSubsetMaxSize"/>
	public int NakedSubsetMaxSizeInComplexSingle
	{
		get => (int)GetValue(NakedSubsetMaxSizeInComplexSingleProperty);

		set => SetValue(NakedSubsetMaxSizeInComplexSingleProperty, value);
	}

	/// <inheritdoc cref="ComplexSingleStepSearcher.HiddenSubsetMaxSize"/>
	public int HiddenSubsetMaxSizeInComplexSingle
	{
		get => (int)GetValue(HiddenSubsetMaxSizeInComplexSingleProperty);

		set => SetValue(HiddenSubsetMaxSizeInComplexSingleProperty, value);
	}

	/// <inheritdoc cref="NormalFishStepSearcher.DisableFinnedOrSashimiXWing"/>
	public bool DisableFinnedOrSashimiXWing
	{
		get => (bool)GetValue(DisableFinnedOrSashimiXWingProperty);

		set => SetValue(DisableFinnedOrSashimiXWingProperty, value);
	}

	/// <inheritdoc cref="GroupedTwoStrongLinksStepSearcher.DisableGroupedTurbotFish"/>
	public bool DisableGroupedTurbotFish
	{
		get => (bool)GetValue(DisableGroupedTurbotFishProperty);

		set => SetValue(DisableGroupedTurbotFishProperty, value);
	}

	/// <inheritdoc cref="NormalFishStepSearcher.AllowSiamese"/>
	public bool AllowSiameseNormalFish
	{
		get => (bool)GetValue(AllowSiameseNormalFishProperty);

		set => SetValue(AllowSiameseNormalFishProperty, value);
	}

	/// <inheritdoc cref="ComplexFishStepSearcher.AllowSiamese"/>
	public bool AllowSiameseComplexFish
	{
		get => (bool)GetValue(AllowSiameseComplexFishProperty);

		set => SetValue(AllowSiameseComplexFishProperty, value);
	}

	/// <inheritdoc cref="ComplexFishStepSearcher.MaxSize"/>
	public int MaxSizeOfComplexFish
	{
		get => (int)GetValue(MaxSizeOfComplexFishProperty);

		set => SetValue(MaxSizeOfComplexFishProperty, value);
	}

	/// <inheritdoc cref="UniqueRectangleStepSearcher.AllowIncompleteUniqueRectangles"/>
	public bool AllowIncompleteUniqueRectangles
	{
		get => (bool)GetValue(AllowIncompleteUniqueRectanglesProperty);

		set => SetValue(AllowIncompleteUniqueRectanglesProperty, value);
	}

	/// <inheritdoc cref="UniqueRectangleStepSearcher.SearchForExtendedUniqueRectangles"/>
	public bool SearchForExtendedUniqueRectangles
	{
		get => (bool)GetValue(SearchForExtendedUniqueRectanglesProperty);

		set => SetValue(SearchForExtendedUniqueRectanglesProperty, value);
	}

	/// <inheritdoc cref="BivalueUniversalGraveStepSearcher.SearchExtendedTypes"/>
	public bool SearchExtendedBivalueUniversalGraveTypes
	{
		get => (bool)GetValue(SearchExtendedBivalueUniversalGraveTypesProperty);

		set => SetValue(SearchExtendedBivalueUniversalGraveTypesProperty, value);
	}

	/// <inheritdoc cref="AlmostLockedCandidatesStepSearcher.CheckValueTypes"/>
	public bool AlmostLockedCandidatesCheckValueTypes
	{
		get => (bool)GetValue(AlmostLockedCandidatesCheckValueTypesProperty);

		set => SetValue(AlmostLockedCandidatesCheckValueTypesProperty, value);
	}

	/// <inheritdoc cref="AlmostLockedCandidatesStepSearcher.CheckAlmostLockedQuadruple"/>
	public bool CheckAlmostLockedQuadruple
	{
		get => (bool)GetValue(CheckAlmostLockedQuadrupleProperty);

		set => SetValue(CheckAlmostLockedQuadrupleProperty, value);
	}

	/// <inheritdoc cref="XyzRingStepSearcher.AllowSiamese"/>
	public bool AllowSiameseXyzRing
	{
		get => (bool)GetValue(AllowSiameseXyzRingProperty);

		set => SetValue(AllowSiameseXyzRingProperty, value);
	}

	/// <inheritdoc cref="RegularWingStepSearcher.MaxSearchingPivotsCount"/>
	public int MaxSizeOfRegularWing
	{
		get => (int)GetValue(MaxSizeOfRegularWingProperty);

		set => SetValue(MaxSizeOfRegularWingProperty, value);
	}

	/// <inheritdoc cref="ChainStepSearcher.MakeConclusionAroundBackdoors"/>
	public bool MakeConclusionAroundBackdoorsNormalChain
	{
		get => (bool)GetValue(MakeConclusionAroundBackdoorsNormalChainProperty);

		set => SetValue(MakeConclusionAroundBackdoorsNormalChainProperty, value);
	}

	/// <inheritdoc cref="GroupedChainStepSearcher.MakeConclusionAroundBackdoors"/>
	public bool MakeConclusionAroundBackdoorsGroupedChain
	{
		get => (bool)GetValue(MakeConclusionAroundBackdoorsGroupedChainProperty);

		set => SetValue(MakeConclusionAroundBackdoorsGroupedChainProperty, value);
	}

	/// <inheritdoc cref="AlignedExclusionStepSearcher.MaxSearchingSize"/>
	public int AlignedExclusionMaxSearchingSize
	{
		get => (int)GetValue(AlignedExclusionMaxSearchingSizeProperty);

		set => SetValue(AlignedExclusionMaxSearchingSizeProperty, value);
	}

	/// <inheritdoc cref="ReverseBivalueUniversalGraveStepSearcher.AllowPartiallyUsedTypes"/>
	public bool SearchForReverseBugPartiallyUsedTypes
	{
		get => (bool)GetValue(SearchForReverseBugPartiallyUsedTypesProperty);

		set => SetValue(SearchForReverseBugPartiallyUsedTypesProperty, value);
	}

	/// <inheritdoc cref="ReverseBivalueUniversalGraveStepSearcher.MaxSearchingEmptyCellsCount"/>
	public int ReverseBugMaxSearchingEmptyCellsCount
	{
		get => (int)GetValue(ReverseBugMaxSearchingEmptyCellsCountProperty);

		set => SetValue(ReverseBugMaxSearchingEmptyCellsCountProperty, value);
	}

	/// <inheritdoc cref="DeathBlossomStepSearcher.SearchExtendedTypes"/>
	public bool SearchExtendedDeathBlossomTypes
	{
		get => (bool)GetValue(SearchExtendedDeathBlossomTypesProperty);

		set => SetValue(SearchExtendedDeathBlossomTypesProperty, value);
	}

	/// <summary>
	/// Indicates whether the step will be displayed its corresponding rating defined in program Sudoku Explainer.
	/// </summary>
	public bool DisplayDifficultyRatingForSudokuExplainer
	{
		get => (bool)GetValue(DisplayDifficultyRatingForSudokuExplainerProperty);

		set => SetValue(DisplayDifficultyRatingForSudokuExplainerProperty, value);
	}


	/// <summary>
	/// Indicates whether the step analyzed will also display its English name of the technique used.
	/// </summary>
	public bool AlsoDisplayEnglishNameOfStep
	{
		get => (bool)GetValue(AlsoDisplayEnglishNameOfStepProperty);

		set => SetValue(AlsoDisplayEnglishNameOfStepProperty, value);
	}

	/// <summary>
	/// Indicates whether the step will display its corresponding rating defined in program HoDoKu.
	/// </summary>
	public bool DisplayDifficultyRatingForHodoku
	{
		get => (bool)GetValue(DisplayDifficultyRatingForHodokuProperty);

		set => SetValue(DisplayDifficultyRatingForHodokuProperty, value);
	}


	/// <inheritdoc cref="Analyzer.IsFullApplying"/>
	public bool AnalyzerIsFullApplying
	{
		get => (bool)GetValue(AnalyzerIsFullApplyingProperty);

		set => SetValue(AnalyzerIsFullApplyingProperty, value);
	}


	/// <inheritdoc cref="Collector.MaxStepsCollected"/>
	public int CollectorMaxStepsCollected
	{
		get => (int)GetValue(CollectorMaxStepsCollectedProperty);

		set => SetValue(CollectorMaxStepsCollectedProperty, value);
	}

	/// <inheritdoc cref="Collector.DifficultyLevelMode"/>
	public int DifficultyLevelMode
	{
		get => (int)GetValue(DifficultyLevelModeProperty);

		set => SetValue(DifficultyLevelModeProperty, value);
	}

	/// <inheritdoc cref="StepGathererOptions.UseIttoryuMode"/>
	public bool AnalyzerUseIttoryuMode
	{
		get => (bool)GetValue(AnalyzerUseIttoryuModeProperty);

		set => SetValue(AnalyzerUseIttoryuModeProperty, value);
	}

	/// <inheritdoc cref="StepGathererOptions.BabaGroupInitialLetter"/>
	public BabaGroupInitialLetter InitialLetter
	{
		get => (BabaGroupInitialLetter)GetValue(InitialLetterProperty);

		set => SetValue(InitialLetterProperty, value);
	}

	/// <inheritdoc cref="StepGathererOptions.BabaGroupLetterCase"/>
	public BabaGroupLetterCase LetterCasing
	{
		get => (BabaGroupLetterCase)GetValue(LetterCasingProperty);

		set => SetValue(LetterCasingProperty, value);
	}

	/// <summary>
	/// Indicates the bottleneck type defined in direct mode.
	/// </summary>
	public BottleneckType DirectModeBottleneckType
	{
		get => (BottleneckType)GetValue(DirectModeBottleneckTypeProperty);

		set => SetValue(DirectModeBottleneckTypeProperty, value);
	}

	/// <summary>
	/// Indicates the bottleneck type defined in Snyder's mode.
	/// </summary>
	public BottleneckType PartialMarkingModeBottleneckType
	{
		get => (BottleneckType)GetValue(PartialMarkingModeBottleneckTypeProperty);

		set => SetValue(PartialMarkingModeBottleneckTypeProperty, value);
	}

	/// <summary>
	/// Indicates the bottleneck type defined in full-marking mode.
	/// </summary>
	public BottleneckType FullMarkingModeBottleneckType
	{
		get => (BottleneckType)GetValue(FullMarkingModeBottleneckTypeProperty);

		set => SetValue(FullMarkingModeBottleneckTypeProperty, value);
	}

	/// <inheritdoc cref="StepGathererOptions.OverriddenLinkOptions"/>
	public Dictionary<LinkType, LinkOption> OverriddenLinkOptions
	{
		get => (Dictionary<LinkType, LinkOption>)GetValue(OverriddenLinkOptionsProperty);

		set => SetValue(OverriddenLinkOptionsProperty, value);
	}

	/// <summary>
	/// <inheritdoc cref="DisorderedIttoryuFinder(TechniqueSet)" path="/param[@name='_supportedTechniques']"/>
	/// </summary>
	public List<Technique> IttoryuSupportedTechniques
	{
		get => (List<Technique>)GetValue(IttoryuSupportedTechniquesProperty);

		set => SetValue(IttoryuSupportedTechniquesProperty, value);
	}
}
