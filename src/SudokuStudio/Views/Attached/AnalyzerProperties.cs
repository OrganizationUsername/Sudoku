namespace SudokuStudio.Views.Attached;

/// <summary>
/// Defines a bind behaviors on <see cref="SudokuPane"/> instances, for <see cref="Analyzer"/> instance's interaction.
/// </summary>
/// <remarks>
/// All names of attached properties in this type can be corresponded to the target property in one <see cref="StepSearcher"/>,
/// via <see cref="SettingItemNameAttribute"/>.
/// </remarks>
/// <seealso cref="SudokuPane"/>
/// <seealso cref="Analyzer"/>
public static class AnalyzerProperties
{
	/// <summary>
	/// Indicates the anonymous name for getters.
	/// </summary>
	private const string GetSetterName = "Get";


	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AnalyzerIsFullApplyingProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AnalyzerIsFullApplyingProperty =
		DependencyProperty.RegisterAttached("AnalyzerIsFullApplying", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="IttoryuSupportedTechniquesProperty"/>.
	/// </summary>
	public static readonly DependencyProperty IttoryuSupportedTechniquesProperty =
		DependencyProperty.RegisterAttached(
			"IttoryuSupportedTechniques",
			typeof(List<Technique>),
			typeof(AnalyzerProperties),
			new PropertyMetadata(
				(List<Technique>)[
					Technique.FullHouse,
					Technique.HiddenSingleBlock,
					Technique.HiddenSingleRow,
					Technique.HiddenSingleColumn,
					Technique.NakedSingle
				]
			)
		);

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="EnableFullHouseProperty"/>.
	/// </summary>
	public static readonly DependencyProperty EnableFullHouseProperty =
		DependencyProperty.RegisterAttached("EnableFullHouse", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="EnableLastDigitProperty"/>.
	/// </summary>
	public static readonly DependencyProperty EnableLastDigitProperty =
		DependencyProperty.RegisterAttached("EnableLastDigit", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="HiddenSinglesInBlockFirstProperty"/>.
	/// </summary>
	public static readonly DependencyProperty HiddenSinglesInBlockFirstProperty =
		DependencyProperty.RegisterAttached("HiddenSinglesInBlockFirst", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="EnableOrderingStepsByLastingValueProperty"/>.
	/// </summary>
	public static readonly DependencyProperty EnableOrderingStepsByLastingValueProperty =
		DependencyProperty.RegisterAttached("EnableOrderingStepsByLastingValue", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowDirectPointingProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowDirectPointingProperty =
		DependencyProperty.RegisterAttached("AllowDirectPointing", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowDirectClaimingProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowDirectClaimingProperty =
		DependencyProperty.RegisterAttached("AllowDirectClaiming", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowDirectLockedSubsetProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowDirectLockedSubsetProperty =
		DependencyProperty.RegisterAttached("AllowDirectLockedSubset", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowDirectNakedSubsetProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowDirectNakedSubsetProperty =
		DependencyProperty.RegisterAttached("AllowDirectNakedSubset", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowDirectLockedHiddenSubsetProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowDirectLockedHiddenSubsetProperty =
		DependencyProperty.RegisterAttached("AllowDirectLockedHiddenSubset", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowDirectHiddenSubsetProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowDirectHiddenSubsetProperty =
		DependencyProperty.RegisterAttached("AllowDirectHiddenSubset", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="DirectNakedSubsetMaxSizeProperty"/>.
	/// </summary>
	public static readonly DependencyProperty DirectNakedSubsetMaxSizeProperty =
		DependencyProperty.RegisterAttached("DirectNakedSubsetMaxSize", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata((int)2));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="DirectHiddenSubsetMaxSizeProperty"/>.
	/// </summary>
	public static readonly DependencyProperty DirectHiddenSubsetMaxSizeProperty =
		DependencyProperty.RegisterAttached("DirectHiddenSubsetMaxSize", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata((int)2));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="NakedSubsetMaxSizeInComplexSingleProperty"/>.
	/// </summary>
	public static readonly DependencyProperty NakedSubsetMaxSizeInComplexSingleProperty =
		DependencyProperty.RegisterAttached("NakedSubsetMaxSizeInComplexSingle", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata((int)4));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="HiddenSubsetMaxSizeInComplexSingleProperty"/>.
	/// </summary>
	public static readonly DependencyProperty HiddenSubsetMaxSizeInComplexSingleProperty =
		DependencyProperty.RegisterAttached("HiddenSubsetMaxSizeInComplexSingle", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata((int)4));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="DisableFinnedOrSashimiXWingProperty"/>.
	/// </summary>
	public static readonly DependencyProperty DisableFinnedOrSashimiXWingProperty =
		DependencyProperty.RegisterAttached("DisableFinnedOrSashimiXWing", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="DisableGroupedTurbotFishProperty"/>.
	/// </summary>
	public static readonly DependencyProperty DisableGroupedTurbotFishProperty =
		DependencyProperty.RegisterAttached("DisableGroupedTurbotFish", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowSiameseNormalFishProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowSiameseNormalFishProperty =
		DependencyProperty.RegisterAttached("AllowSiameseNormalFish", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowSiameseComplexFishProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowSiameseComplexFishProperty =
		DependencyProperty.RegisterAttached("AllowSiameseComplexFish", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="MaxSizeOfComplexFishProperty"/>.
	/// </summary>
	public static readonly DependencyProperty MaxSizeOfComplexFishProperty =
		DependencyProperty.RegisterAttached("MaxSizeOfComplexFish", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata(5));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="MaxSizeOfRegularWingProperty"/>.
	/// </summary>
	public static readonly DependencyProperty MaxSizeOfRegularWingProperty =
		DependencyProperty.RegisterAttached("MaxSizeOfRegularWing", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata(5));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowIncompleteUniqueRectanglesProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowIncompleteUniqueRectanglesProperty =
		DependencyProperty.RegisterAttached("AllowIncompleteUniqueRectangles", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="SearchForExtendedUniqueRectanglesProperty"/>.
	/// </summary>
	public static readonly DependencyProperty SearchForExtendedUniqueRectanglesProperty =
		DependencyProperty.RegisterAttached("SearchForExtendedUniqueRectangles", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="SearchExtendedBivalueUniversalGraveTypesProperty"/>.
	/// </summary>
	public static readonly DependencyProperty SearchExtendedBivalueUniversalGraveTypesProperty =
		DependencyProperty.RegisterAttached("SearchExtendedBivalueUniversalGraveTypes", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AlmostLockedCandidatesCheckValueTypesProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AlmostLockedCandidatesCheckValueTypesProperty =
		DependencyProperty.RegisterAttached("AlmostLockedCandidatesCheckValueTypes", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="CheckAlmostLockedQuadrupleProperty"/>.
	/// </summary>
	public static readonly DependencyProperty CheckAlmostLockedQuadrupleProperty =
		DependencyProperty.RegisterAttached("CheckAlmostLockedQuadruple", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="MakeConclusionAroundBackdoorsNormalChainProperty"/>.
	/// </summary>
	public static readonly DependencyProperty MakeConclusionAroundBackdoorsNormalChainProperty =
		DependencyProperty.RegisterAttached("MakeConclusionAroundBackdoorsNormalChain", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)false));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="MakeConclusionAroundBackdoorsGroupedChainProperty"/>.
	/// </summary>
	public static readonly DependencyProperty MakeConclusionAroundBackdoorsGroupedChainProperty =
		DependencyProperty.RegisterAttached("MakeConclusionAroundBackdoorsGroupedChain", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)false));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="SearchExtendedDeathBlossomTypesProperty"/>.
	/// </summary>
	public static readonly DependencyProperty SearchExtendedDeathBlossomTypesProperty =
		DependencyProperty.RegisterAttached("SearchExtendedDeathBlossomTypes", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="SearchForReverseBugPartiallyUsedTypesProperty"/>.
	/// </summary>
	public static readonly DependencyProperty SearchForReverseBugPartiallyUsedTypesProperty =
		DependencyProperty.RegisterAttached("SearchForReverseBugPartiallyUsedTypes", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="ReverseBugMaxSearchingEmptyCellsCountProperty"/>.
	/// </summary>
	public static readonly DependencyProperty ReverseBugMaxSearchingEmptyCellsCountProperty =
		DependencyProperty.RegisterAttached("ReverseBugMaxSearchingEmptyCellsCount", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata((int)2));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AllowSiameseXyzRingProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AllowSiameseXyzRingProperty =
		DependencyProperty.RegisterAttached("AllowSiameseXyzRing", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AlignedExclusionMaxSearchingSizeProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AlignedExclusionMaxSearchingSizeProperty =
		DependencyProperty.RegisterAttached("AlignedExclusionMaxSearchingSize", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata((int)3));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="BowmanBingoMaxLengthProperty"/>.
	/// </summary>
	public static readonly DependencyProperty BowmanBingoMaxLengthProperty =
		DependencyProperty.RegisterAttached("BowmanBingoMaxLength", typeof(int), typeof(AnalyzerProperties), new PropertyMetadata((int)64));

	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="AnalyzerUseIttoryuModeProperty"/>.
	/// </summary>
	public static readonly DependencyProperty AnalyzerUseIttoryuModeProperty =
		DependencyProperty.RegisterAttached("AnalyzerUseIttoryuMode", typeof(bool), typeof(AnalyzerProperties), new PropertyMetadata(default(bool)));


	/// <summary>
	/// Sets the attached property <see cref="AnalyzerIsFullApplyingProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAnalyzerIsFullApplying(DependencyObject obj, bool value)
		=> obj.SetValue(AnalyzerIsFullApplyingProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AnalyzerIsFullApplyingProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAnalyzerIsFullApplying(DependencyObject obj)
		=> (bool)obj.GetValue(AnalyzerIsFullApplyingProperty);

	/// <summary>
	/// Sets the attached property <see cref="IttoryuSupportedTechniquesProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetIttoryuSupportedTechniques(DependencyObject obj, List<Technique> value)
		=> obj.SetValue(IttoryuSupportedTechniquesProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="IttoryuSupportedTechniquesProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static List<Technique> GetIttoryuSupportedTechniques(DependencyObject obj)
		=> (List<Technique>)obj.GetValue(IttoryuSupportedTechniquesProperty);

	/// <summary>
	/// Sets the attached property <see cref="EnableFullHouseProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetEnableFullHouse(DependencyObject obj, bool value)
		=> obj.SetValue(EnableFullHouseProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="EnableFullHouseProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetEnableFullHouse(DependencyObject obj)
		=> (bool)obj.GetValue(EnableFullHouseProperty);

	/// <summary>
	/// Sets the attached property <see cref="EnableLastDigitProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetEnableLastDigit(DependencyObject obj, bool value)
		=> obj.SetValue(EnableLastDigitProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="EnableLastDigitProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetEnableLastDigit(DependencyObject obj)
		=> (bool)obj.GetValue(EnableLastDigitProperty);

	/// <summary>
	/// Sets the attached property <see cref="HiddenSinglesInBlockFirstProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetHiddenSinglesInBlockFirst(DependencyObject obj, bool value)
		=> obj.SetValue(HiddenSinglesInBlockFirstProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="HiddenSinglesInBlockFirstProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetHiddenSinglesInBlockFirst(DependencyObject obj)
		=> (bool)obj.GetValue(HiddenSinglesInBlockFirstProperty);

	/// <summary>
	/// Sets the attached property <see cref="EnableOrderingStepsByLastingValueProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetEnableOrderingStepsByLastingValue(DependencyObject obj, bool value)
		=> obj.SetValue(EnableOrderingStepsByLastingValueProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="EnableOrderingStepsByLastingValueProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetEnableOrderingStepsByLastingValue(DependencyObject obj)
		=> (bool)obj.GetValue(EnableOrderingStepsByLastingValueProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowDirectPointingProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowDirectPointing(DependencyObject obj, bool value)
		=> obj.SetValue(AllowDirectPointingProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowDirectPointingProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowDirectPointing(DependencyObject obj)
		=> (bool)obj.GetValue(AllowDirectPointingProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowDirectClaimingProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowDirectClaiming(DependencyObject obj, bool value)
		=> obj.SetValue(AllowDirectClaimingProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowDirectClaimingProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowDirectClaiming(DependencyObject obj)
		=> (bool)obj.GetValue(AllowDirectClaimingProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowDirectLockedSubsetProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowDirectLockedSubset(DependencyObject obj, bool value)
		=> obj.SetValue(AllowDirectLockedSubsetProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowDirectLockedSubsetProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowDirectLockedSubset(DependencyObject obj)
		=> (bool)obj.GetValue(AllowDirectLockedSubsetProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowDirectNakedSubsetProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowDirectNakedSubset(DependencyObject obj, bool value)
		=> obj.SetValue(AllowDirectNakedSubsetProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowDirectNakedSubsetProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowDirectNakedSubset(DependencyObject obj)
		=> (bool)obj.GetValue(AllowDirectNakedSubsetProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowDirectLockedHiddenSubsetProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowDirectLockedHiddenSubset(DependencyObject obj, bool value)
		=> obj.SetValue(AllowDirectLockedHiddenSubsetProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowDirectLockedHiddenSubsetProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowDirectLockedHiddenSubset(DependencyObject obj)
		=> (bool)obj.GetValue(AllowDirectLockedHiddenSubsetProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowDirectHiddenSubsetProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowDirectHiddenSubset(DependencyObject obj, bool value)
		=> obj.SetValue(AllowDirectHiddenSubsetProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowDirectHiddenSubsetProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowDirectHiddenSubset(DependencyObject obj)
		=> (bool)obj.GetValue(AllowDirectHiddenSubsetProperty);

	/// <summary>
	/// Sets the attached property <see cref="DirectNakedSubsetMaxSizeProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetDirectNakedSubsetMaxSize(DependencyObject obj, int value)
		=> obj.SetValue(DirectNakedSubsetMaxSizeProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="DirectNakedSubsetMaxSizeProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetDirectNakedSubsetMaxSize(DependencyObject obj)
		=> (int)obj.GetValue(DirectNakedSubsetMaxSizeProperty);

	/// <summary>
	/// Sets the attached property <see cref="DirectHiddenSubsetMaxSizeProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetDirectHiddenSubsetMaxSize(DependencyObject obj, int value)
		=> obj.SetValue(DirectHiddenSubsetMaxSizeProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="DirectHiddenSubsetMaxSizeProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetDirectHiddenSubsetMaxSize(DependencyObject obj)
		=> (int)obj.GetValue(DirectHiddenSubsetMaxSizeProperty);

	/// <summary>
	/// Sets the attached property <see cref="NakedSubsetMaxSizeInComplexSingleProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetNakedSubsetMaxSizeInComplexSingle(DependencyObject obj, int value)
		=> obj.SetValue(NakedSubsetMaxSizeInComplexSingleProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="NakedSubsetMaxSizeInComplexSingleProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetNakedSubsetMaxSizeInComplexSingle(DependencyObject obj)
		=> (int)obj.GetValue(NakedSubsetMaxSizeInComplexSingleProperty);

	/// <summary>
	/// Sets the attached property <see cref="HiddenSubsetMaxSizeInComplexSingleProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetHiddenSubsetMaxSizeInComplexSingle(DependencyObject obj, int value)
		=> obj.SetValue(HiddenSubsetMaxSizeInComplexSingleProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="HiddenSubsetMaxSizeInComplexSingleProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetHiddenSubsetMaxSizeInComplexSingle(DependencyObject obj)
		=> (int)obj.GetValue(HiddenSubsetMaxSizeInComplexSingleProperty);

	/// <summary>
	/// Sets the attached property <see cref="DisableFinnedOrSashimiXWingProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetDisableFinnedOrSashimiXWing(DependencyObject obj, bool value)
		=> obj.SetValue(DisableFinnedOrSashimiXWingProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="DisableFinnedOrSashimiXWingProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetDisableFinnedOrSashimiXWing(DependencyObject obj)
		=> (bool)obj.GetValue(DisableFinnedOrSashimiXWingProperty);

	/// <summary>
	/// Sets the attached property <see cref="DisableGroupedTurbotFishProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetDisableGroupedTurbotFish(DependencyObject obj, bool value)
		=> obj.SetValue(DisableGroupedTurbotFishProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="DisableGroupedTurbotFishProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetDisableGroupedTurbotFish(DependencyObject obj)
		=> (bool)obj.GetValue(DisableGroupedTurbotFishProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowSiameseNormalFishProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowSiameseNormalFish(DependencyObject obj, bool value)
		=> obj.SetValue(AllowSiameseNormalFishProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowSiameseNormalFishProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowSiameseNormalFish(DependencyObject obj)
		=> (bool)obj.GetValue(AllowSiameseNormalFishProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowSiameseComplexFishProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowSiameseComplexFish(DependencyObject obj, bool value)
		=> obj.SetValue(AllowSiameseComplexFishProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowSiameseComplexFishProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowSiameseComplexFish(DependencyObject obj)
		=> (bool)obj.GetValue(AllowSiameseComplexFishProperty);

	/// <summary>
	/// Sets the attached property <see cref="MaxSizeOfComplexFishProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetMaxSizeOfComplexFish(DependencyObject obj, int value)
		=> obj.SetValue(MaxSizeOfComplexFishProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="MaxSizeOfComplexFishProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetMaxSizeOfComplexFish(DependencyObject obj)
		=> (int)obj.GetValue(MaxSizeOfComplexFishProperty);

	/// <summary>
	/// Sets the attached property <see cref="MaxSizeOfRegularWingProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetMaxSizeOfRegularWing(DependencyObject obj, int value)
		=> obj.SetValue(MaxSizeOfRegularWingProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="MaxSizeOfRegularWingProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetMaxSizeOfRegularWing(DependencyObject obj)
		=> (int)obj.GetValue(MaxSizeOfRegularWingProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowIncompleteUniqueRectanglesProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowIncompleteUniqueRectangles(DependencyObject obj, bool value)
		=> obj.SetValue(AllowIncompleteUniqueRectanglesProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowIncompleteUniqueRectanglesProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowIncompleteUniqueRectangles(DependencyObject obj)
		=> (bool)obj.GetValue(AllowIncompleteUniqueRectanglesProperty);

	/// <summary>
	/// Sets the attached property <see cref="SearchForExtendedUniqueRectanglesProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetSearchForExtendedUniqueRectangles(DependencyObject obj, bool value)
		=> obj.SetValue(SearchForExtendedUniqueRectanglesProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="SearchForExtendedUniqueRectanglesProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetSearchForExtendedUniqueRectangles(DependencyObject obj)
		=> (bool)obj.GetValue(SearchForExtendedUniqueRectanglesProperty);

	/// <summary>
	/// Sets the attached property <see cref="SearchExtendedBivalueUniversalGraveTypesProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetSearchExtendedBivalueUniversalGraveTypes(DependencyObject obj, bool value)
		=> obj.SetValue(SearchExtendedBivalueUniversalGraveTypesProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="SearchExtendedBivalueUniversalGraveTypesProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetSearchExtendedBivalueUniversalGraveTypes(DependencyObject obj)
		=> (bool)obj.GetValue(SearchExtendedBivalueUniversalGraveTypesProperty);

	/// <summary>
	/// Sets the attached property <see cref="AlmostLockedCandidatesCheckValueTypesProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAlmostLockedCandidatesCheckValueTypes(DependencyObject obj, bool value)
		=> obj.SetValue(AlmostLockedCandidatesCheckValueTypesProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AlmostLockedCandidatesCheckValueTypesProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAlmostLockedCandidatesCheckValueTypes(DependencyObject obj)
		=> (bool)obj.GetValue(AlmostLockedCandidatesCheckValueTypesProperty);

	/// <summary>
	/// Sets the attached property <see cref="CheckAlmostLockedQuadrupleProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetCheckAlmostLockedQuadruple(DependencyObject obj, bool value)
		=> obj.SetValue(CheckAlmostLockedQuadrupleProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="CheckAlmostLockedQuadrupleProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetCheckAlmostLockedQuadruple(DependencyObject obj)
		=> (bool)obj.GetValue(CheckAlmostLockedQuadrupleProperty);

	/// <summary>
	/// Sets the attached property <see cref="MakeConclusionAroundBackdoorsNormalChainProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetMakeConclusionAroundBackdoorsNormalChain(DependencyObject obj, bool value)
		=> obj.SetValue(MakeConclusionAroundBackdoorsNormalChainProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="MakeConclusionAroundBackdoorsNormalChainProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetMakeConclusionAroundBackdoorsNormalChain(DependencyObject obj)
		=> (bool)obj.GetValue(MakeConclusionAroundBackdoorsNormalChainProperty);

	/// <summary>
	/// Sets the attached property <see cref="MakeConclusionAroundBackdoorsGroupedChainProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetMakeConclusionAroundBackdoorsGroupedChain(DependencyObject obj, bool value)
		=> obj.SetValue(MakeConclusionAroundBackdoorsGroupedChainProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="MakeConclusionAroundBackdoorsGroupedChainProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetMakeConclusionAroundBackdoorsGroupedChain(DependencyObject obj)
		=> (bool)obj.GetValue(MakeConclusionAroundBackdoorsGroupedChainProperty);

	/// <summary>
	/// Sets the attached property <see cref="SearchExtendedDeathBlossomTypesProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetSearchExtendedDeathBlossomTypes(DependencyObject obj, bool value)
		=> obj.SetValue(SearchExtendedDeathBlossomTypesProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="SearchExtendedDeathBlossomTypesProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetSearchExtendedDeathBlossomTypes(DependencyObject obj)
		=> (bool)obj.GetValue(SearchExtendedDeathBlossomTypesProperty);

	/// <summary>
	/// Sets the attached property <see cref="SearchForReverseBugPartiallyUsedTypesProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetSearchForReverseBugPartiallyUsedTypes(DependencyObject obj, bool value)
		=> obj.SetValue(SearchForReverseBugPartiallyUsedTypesProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="SearchForReverseBugPartiallyUsedTypesProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetSearchForReverseBugPartiallyUsedTypes(DependencyObject obj)
		=> (bool)obj.GetValue(SearchForReverseBugPartiallyUsedTypesProperty);

	/// <summary>
	/// Sets the attached property <see cref="ReverseBugMaxSearchingEmptyCellsCountProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetReverseBugMaxSearchingEmptyCellsCount(DependencyObject obj, int value)
		=> obj.SetValue(ReverseBugMaxSearchingEmptyCellsCountProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="ReverseBugMaxSearchingEmptyCellsCountProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetReverseBugMaxSearchingEmptyCellsCount(DependencyObject obj)
		=> (int)obj.GetValue(ReverseBugMaxSearchingEmptyCellsCountProperty);

	/// <summary>
	/// Sets the attached property <see cref="AllowSiameseXyzRingProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAllowSiameseXyzRing(DependencyObject obj, bool value)
		=> obj.SetValue(AllowSiameseXyzRingProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AllowSiameseXyzRingProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAllowSiameseXyzRing(DependencyObject obj)
		=> (bool)obj.GetValue(AllowSiameseXyzRingProperty);

	/// <summary>
	/// Sets the attached property <see cref="AlignedExclusionMaxSearchingSizeProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAlignedExclusionMaxSearchingSize(DependencyObject obj, int value)
		=> obj.SetValue(AlignedExclusionMaxSearchingSizeProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AlignedExclusionMaxSearchingSizeProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetAlignedExclusionMaxSearchingSize(DependencyObject obj)
		=> (int)obj.GetValue(AlignedExclusionMaxSearchingSizeProperty);

	/// <summary>
	/// Sets the attached property <see cref="BowmanBingoMaxLengthProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetBowmanBingoMaxLength(DependencyObject obj, int value)
		=> obj.SetValue(BowmanBingoMaxLengthProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="BowmanBingoMaxLengthProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static int GetBowmanBingoMaxLength(DependencyObject obj)
		=> (int)obj.GetValue(BowmanBingoMaxLengthProperty);

	/// <summary>
	/// Sets the attached property <see cref="AnalyzerUseIttoryuModeProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetAnalyzerUseIttoryuMode(DependencyObject obj, bool value)
		=> obj.SetValue(AnalyzerUseIttoryuModeProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="AnalyzerUseIttoryuModeProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static bool GetAnalyzerUseIttoryuMode(DependencyObject obj)
		=> (bool)obj.GetValue(AnalyzerUseIttoryuModeProperty);


	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of step gatherer.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(T @this) where T : StepGatherer
	{
		/// <summary>
		/// Sets the specified property in a <see cref="StepSearcher"/> with the target value via attached properties
		/// stored in type <see cref="AnalyzerProperties"/>.
		/// </summary>
		/// <param name="attachedPropertyValue">The attached property.</param>
		/// <param name="methodName">The name of the property <paramref name="attachedPropertyValue"/>.</param>
		/// <param name="propertyMatched">
		/// A <see cref="bool"/> value indicating whether the property in <see cref="StepSearcher"/> collection is found,
		/// and the target type of that property is same as argument <paramref name="attachedPropertyValue"/>.
		/// </param>
		/// <returns>The same reference as the current instance.</returns>
		/// <seealso cref="AnalyzerProperties"/>
		public T WithRuntimeIdentifierSetter(object attachedPropertyValue, string methodName, out bool propertyMatched)
		{
			foreach (var searcher in @this.ResultStepSearchers)
			{
				if (searcher.GetType().GetProperties().FirstOrDefault(methodNameMatcher) is { } propertyInfo)
				{
					propertyInfo.SetValue(searcher, attachedPropertyValue);
					propertyMatched = true;
					return @this;
				}


				bool methodNameMatcher(PropertyInfo property)
					=> property.GetCustomAttribute<SettingItemNameAttribute>() is { Identifier: var identifier }
					&& methodName[GetSetterName.Length..] == identifier;
			}

			propertyMatched = false;
			return @this;
		}

		/// <summary>
		/// Calls the method <see cref="WithRuntimeIdentifierSetter"/> for all properties in type <see cref="AnalyzerProperties"/>.
		/// </summary>
		/// <param name="attachedPane">Indicates the <see cref="SudokuPane"/> instance that all properties in this type attached to.</param>
		/// <returns>The same reference as the current instance.</returns>
		/// <exception cref="InvalidOperationException">Throws when the matched property is invalid.</exception>
		/// <seealso cref="WithRuntimeIdentifierSetter"/>
		public T WithRuntimeIdentifierSetters(SudokuPane attachedPane)
		{
			foreach (var methodInfo in typeof(AnalyzerProperties).GetMethods(BindingFlags.Static | BindingFlags.Public))
			{
				if (methodInfo.Name.StartsWith(GetSetterName))
				{
					@this.WithRuntimeIdentifierSetter(methodInfo.Invoke(null, [attachedPane])!, methodInfo.Name, out _);
				}
			}
			return @this;
		}
	}
}
