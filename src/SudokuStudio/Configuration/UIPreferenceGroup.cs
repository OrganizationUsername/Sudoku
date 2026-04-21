namespace SudokuStudio.Configuration;

/// <summary>
/// Defines a list of UI-related preference items. Some items in this group may not be found in settings page
/// because they are controlled by UI only, not by users.
/// </summary>
public sealed partial class UIPreferenceGroup : PreferenceGroup
{
	private static readonly decimal MainNavigationPageOpenPaneLengthDefaultValue = 200M;

	private static readonly decimal HighlightedPencilmarkBackgroundEllipseScaleDefaultValue = 0.9M;

	private static readonly decimal HighlightedBackgroundOpacityDefaultValue = .15M;

	private static readonly decimal ChainStrokeThicknessDefaultValue = 1.5M;

	private static readonly decimal GivenFontScaleDefaultValue = .85M;

	private static readonly decimal ModifiableFontScaleDefaultValue = .85M;

	private static readonly decimal PencilmarkFontScaleDefaultValue = .3M;

	private static readonly decimal BabaGroupingFontScaleDefaultValue = .6M;

	private static readonly decimal CoordinateLabelFontScaleDefaultValue = .4M;

	private static readonly decimal SudokuGridSizeDefaultValue = 610M;

	private static readonly Color GivenFontColorDefaultValue = Colors.Black;

	private static readonly Color GivenFontColor_DarkDefaultValue = Colors.Gray;

	private static readonly Color ModifiableFontColorDefaultValue = Colors.Blue;

	private static readonly Color ModifiableFontColor_DarkDefaultValue = Color.FromArgb(255, 86, 156, 214);

	private static readonly Color PencilmarkFontColorDefaultValue = Color.FromArgb(255, 100, 100, 100);

	private static readonly Color PencilmarkFontColor_DarkDefaultValue = Color.FromArgb(255, 80, 80, 80);

	private static readonly Color BabaGroupingFontColorDefaultValue = Colors.Red;

	private static readonly Color BabaGroupingFontColor_DarkDefaultValue = Colors.Red;

	private static readonly Color CoordinateLabelFontColorDefaultValue = Color.FromArgb(255, 100, 100, 100);

	private static readonly Color CoordinateLabelFontColor_DarkDefaultValue = Color.FromArgb(255, 155, 155, 155);

	private static readonly Color DeltaValueColorDefaultValue = Colors.Red;

	private static readonly Color DeltaValueColor_DarkDefaultValue = Colors.Red;

	private static readonly Color DeltaPencilmarkColorDefaultValue = Color.FromArgb(255, 255, 185, 185);

	private static readonly Color DeltaPencilmarkColor_DarkDefaultValue = Colors.Magenta;

	private static readonly Color SudokuPaneBorderColorDefaultValue = Colors.Black;

	private static readonly Color SudokuPaneBorderColor_DarkDefaultValue = Colors.Gray;

	private static readonly Color CursorBackgroundColorDefaultValue = Colors.Blue with { A = 32 };

	private static readonly Color CursorBackgroundColor_DarkDefaultValue = Color.FromArgb(32, 86, 156, 214);

	private static readonly Color ChainColorDefaultValue = Colors.Red;

	private static readonly Color ChainColor_DarkDefaultValue = Colors.Red;

	private static readonly Color NormalColorDefaultValue = Color.FromArgb(255, 63, 218, 101);

	private static readonly Color NormalColor_DarkDefaultValue = Color.FromArgb(255, 63, 218, 101);

	private static readonly Color AssignmentColorDefaultValue = Color.FromArgb(255, 63, 218, 101);

	private static readonly Color AssignmentColor_DarkDefaultValue = Color.FromArgb(255, 63, 218, 101);

	private static readonly Color OverlappedAssignmentColorDefaultValue = Color.FromArgb(255, 0, 255, 204);

	private static readonly Color OverlappedAssignmentColor_DarkDefaultValue = Color.FromArgb(255, 0, 255, 204);

	private static readonly Color EliminationColorDefaultValue = Color.FromArgb(255, 255, 118, 132);

	private static readonly Color EliminationColor_DarkDefaultValue = Color.FromArgb(255, 255, 118, 132);

	private static readonly Color CannibalismColorDefaultValue = Color.FromArgb(255, 235, 0, 0);

	private static readonly Color CannibalismColor_DarkDefaultValue = Color.FromArgb(255, 235, 0, 0);

	private static readonly Color ExofinColorDefaultValue = Color.FromArgb(255, 127, 187, 255);

	private static readonly Color ExofinColor_DarkDefaultValue = Color.FromArgb(255, 127, 187, 255);

	private static readonly Color EndofinColorDefaultValue = Color.FromArgb(255, 216, 178, 255);

	private static readonly Color EndofinColor_DarkDefaultValue = Color.FromArgb(255, 216, 178, 255);

	private static readonly Color GroupedNodeStrokeColorDefaultValue = Colors.Orange;

	private static readonly Color GroupedNodeStrokeColor_DarkDefaultValue = Color.FromArgb(64, 67, 53, 25);

	private static readonly Color GroupedNodeBackgroundColorDefaultValue = Colors.Yellow with { A = 64 };

	private static readonly Color GroupedNodeBackgroundColor_DarkDefaultValue = Color.FromArgb(255, 157, 93, 0);

	private static readonly Color HouseCompletedFeedbackColorDefaultValue = Colors.HotPink;

	private static readonly Color HouseCompletedFeedbackColor_DarkDefaultValue = Colors.DarkMagenta;

	private static readonly Color ActiveCellColorDefaultValue = Colors.SkyBlue;

	private static readonly Color ActiveCellColor_DarkDefaultValue = Color.FromArgb(255, 93, 138, 226);

	private static readonly DashArray StrongLinkDashStyleDefaultValue = [];

	private static readonly DashArray WeakLinkDashStyleDefaultValue = [3, 1.5];

	private static readonly Grid LastGridPuzzleDefaultValue = Grid.Empty;

	private static readonly ColorPalette AuxiliaryColorsDefaultValue = [
		Color.FromArgb(255, 255, 192, 89),
		Color.FromArgb(255, 127, 187, 255),
		Color.FromArgb(255, 216, 178, 255)
	];

	private static readonly ColorPalette AuxiliaryColors_DarkDefaultValue = [
		Color.FromArgb(255, 255, 192, 89),
		Color.FromArgb(255, 127, 187, 255),
		Color.FromArgb(255, 216, 178, 255)
	];

	private static readonly ColorPalette AlmostLockedSetsColorsDefaultValue = [
		Color.FromArgb(255, 255, 203, 203),
		Color.FromArgb(255, 178, 223, 223),
		Color.FromArgb(255, 252, 220, 165),
		Color.FromArgb(255, 255, 255, 150),
		Color.FromArgb(255, 247, 222, 143)
	];

	private static readonly ColorPalette AlmostLockedSetsColors_DarkDefaultValue = [
		Color.FromArgb(255, 255, 203, 203),
		Color.FromArgb(255, 178, 223, 223),
		Color.FromArgb(255, 252, 220, 165),
		Color.FromArgb(255, 255, 255, 150),
		Color.FromArgb(255, 247, 222, 143)
	];

	private static readonly ColorPalette DifficultyLevelForegroundsDefaultValue = [
		Color.FromArgb(255, 0, 51, 204),
		Color.FromArgb(255, 0, 102, 0),
		Color.FromArgb(255, 102, 51, 0),
		Color.FromArgb(255, 102, 51, 0),
		Color.FromArgb(255, 102, 0, 0),
		Colors.Black
	];

	private static readonly ColorPalette DifficultyLevelForegrounds_DarkDefaultValue = [
		Color.FromArgb(255, 0, 51, 204),
		Color.FromArgb(255, 0, 102, 0),
		Color.FromArgb(255, 102, 51, 0),
		Color.FromArgb(255, 102, 51, 0),
		Color.FromArgb(255, 102, 0, 0),
		Colors.White
	];

	private static readonly ColorPalette DifficultyLevelBackgroundsDefaultValue = [
		Color.FromArgb(255, 204, 204, 255),
		Color.FromArgb(255, 100, 255, 100),
		Color.FromArgb(255, 255, 255, 100),
		Color.FromArgb(255, 255, 150, 80),
		Color.FromArgb(255, 255, 100, 100),
		Color.FromArgb(255, 220, 220, 220)
	];

	private static readonly ColorPalette DifficultyLevelBackgrounds_DarkDefaultValue = [
		Color.FromArgb(255, 204, 204, 255),
		Color.FromArgb(255, 100, 255, 100),
		Color.FromArgb(255, 255, 255, 100),
		Color.FromArgb(255, 255, 150, 80),
		Color.FromArgb(255, 255, 100, 100),
		Color.FromArgb(255, 220, 220, 220)
	];

	private static readonly ColorPalette UserDefinedColorPaletteDefaultValue = [
		Color.FromArgb(255, 63, 218, 101),
		Color.FromArgb(255, 255, 192, 89),
		Color.FromArgb(255, 127, 187, 255),
		Color.FromArgb(255, 216, 178, 255),
		Color.FromArgb(255, 197, 232, 140),
		Color.FromArgb(255, 255, 203, 203),
		Color.FromArgb(255, 178, 223, 223),
		Color.FromArgb(255, 252, 220, 165),
		Color.FromArgb(255, 255, 255, 150),
		Color.FromArgb(255, 247, 222, 143),
		Color.FromArgb(255, 220, 212, 252),
		Color.FromArgb(255, 255, 118, 132),
		Color.FromArgb(255, 206, 251, 237),
		Color.FromArgb(255, 215, 255, 215),
		Color.FromArgb(255, 192, 192, 192)
	];

	private static readonly ColorPalette UserDefinedColorPalette_DarkDefaultValue = [
		Color.FromArgb(255, 63, 218, 101),
		Color.FromArgb(255, 255, 192, 89),
		Color.FromArgb(255, 127, 187, 255),
		Color.FromArgb(255, 216, 178, 255),
		Color.FromArgb(255, 197, 232, 140),
		Color.FromArgb(255, 255, 203, 203),
		Color.FromArgb(255, 178, 223, 223),
		Color.FromArgb(255, 252, 220, 165),
		Color.FromArgb(255, 255, 255, 150),
		Color.FromArgb(255, 247, 222, 143),
		Color.FromArgb(255, 220, 212, 252),
		Color.FromArgb(255, 255, 118, 132),
		Color.FromArgb(255, 206, 251, 237),
		Color.FromArgb(255, 215, 255, 215),
		Color.FromArgb(255, 192, 192, 192)
	];

	private static readonly ColorPalette RectangleColorsDefaultValue = [
		Color.FromArgb(255, 216, 178, 255), // Purple
		Color.FromArgb(255, 204, 150, 248), // Purple
		Color.FromArgb(255, 114, 82, 170), // Dark purple
	];

	private static readonly ColorPalette RectangleColors_DarkDefaultValue = [
		Color.FromArgb(255, 58, 51, 108), // Dark purple
		Color.FromArgb(255, 105, 97, 138), // Dark purple
		Color.FromArgb(255, 230, 215, 249) // Light purple
	];

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisplayCandidates"/>.
	/// </summary>
	/// <seealso cref="DisplayCandidates"/>
	public static readonly DependencyProperty DisplayCandidatesProperty =
		DependencyProperty.Register(nameof(DisplayCandidates), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="IsDirectMode"/>.
	/// </summary>
	/// <seealso cref="IsDirectMode"/>
	public static readonly DependencyProperty IsDirectModeProperty =
		DependencyProperty.Register(nameof(IsDirectMode), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(false));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisplayCursors"/>.
	/// </summary>
	/// <seealso cref="DisplayCursors"/>
	public static readonly DependencyProperty DisplayCursorsProperty =
		DependencyProperty.Register(nameof(DisplayCursors), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DistinctWithDeltaDigits"/>.
	/// </summary>
	/// <seealso cref="DistinctWithDeltaDigits"/>
	public static readonly DependencyProperty DistinctWithDeltaDigitsProperty =
		DependencyProperty.Register(nameof(DistinctWithDeltaDigits), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisableSudokuPaneLayout"/>.
	/// </summary>
	/// <seealso cref="DisableSudokuPaneLayout"/>
	public static readonly DependencyProperty DisableSudokuPaneLayoutProperty =
		DependencyProperty.Register(nameof(DisableSudokuPaneLayout), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PreventConflictingInput"/>.
	/// </summary>
	/// <seealso cref="PreventConflictingInput"/>
	public static readonly DependencyProperty PreventConflictingInputProperty =
		DependencyProperty.Register(nameof(PreventConflictingInput), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SavePuzzleGeneratingHistory"/>.
	/// </summary>
	/// <seealso cref="SavePuzzleGeneratingHistory"/>
	public static readonly DependencyProperty SavePuzzleGeneratingHistoryProperty =
		DependencyProperty.Register(nameof(SavePuzzleGeneratingHistory), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableDoubleTapFillingForSudokuPane"/>.
	/// </summary>
	/// <seealso cref="EnableDoubleTapFillingForSudokuPane"/>
	public static readonly DependencyProperty EnableDoubleTapFillingForSudokuPaneProperty =
		DependencyProperty.Register(nameof(EnableDoubleTapFillingForSudokuPane), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableRightTapRemovingForSudokuPane"/>.
	/// </summary>
	/// <seealso cref="EnableRightTapRemovingForSudokuPane"/>
	public static readonly DependencyProperty EnableRightTapRemovingForSudokuPaneProperty =
		DependencyProperty.Register(nameof(EnableRightTapRemovingForSudokuPane), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableAnimationFeedback"/>.
	/// </summary>
	/// <seealso cref="EnableAnimationFeedback"/>
	public static readonly DependencyProperty EnableAnimationFeedbackProperty =
		DependencyProperty.Register(nameof(EnableAnimationFeedback), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="TransparentBackground"/>.
	/// </summary>
	/// <seealso cref="TransparentBackground"/>
	public static readonly DependencyProperty TransparentBackgroundProperty =
		DependencyProperty.Register(nameof(TransparentBackground), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AutoCachePuzzleAndView"/>.
	/// </summary>
	/// <seealso cref="AutoCachePuzzleAndView"/>
	public static readonly DependencyProperty AutoCachePuzzleAndViewProperty =
		DependencyProperty.Register(nameof(AutoCachePuzzleAndView), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MakeLettersUpperCaseInRxCyNotation"/>.
	/// </summary>
	/// <seealso cref="MakeLettersUpperCaseInRxCyNotation"/>
	public static readonly DependencyProperty MakeLettersUpperCaseInRxCyNotationProperty =
		DependencyProperty.Register(nameof(MakeLettersUpperCaseInRxCyNotation), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MakeLettersUpperCaseInK9Notation"/>.
	/// </summary>
	/// <seealso cref="MakeLettersUpperCaseInK9Notation"/>
	public static readonly DependencyProperty MakeLettersUpperCaseInK9NotationProperty =
		DependencyProperty.Register(nameof(MakeLettersUpperCaseInK9Notation), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MakeLettersUpperCaseInExcelNotation"/>.
	/// </summary>
	/// <seealso cref="MakeLettersUpperCaseInExcelNotation"/>
	public static readonly DependencyProperty MakeLettersUpperCaseInExcelNotationProperty =
		DependencyProperty.Register(nameof(MakeLettersUpperCaseInExcelNotation), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MakeDigitBeforeCellInRxCyNotation"/>.
	/// </summary>
	/// <seealso cref="MakeDigitBeforeCellInRxCyNotation"/>
	public static readonly DependencyProperty MakeDigitBeforeCellInRxCyNotationProperty =
		DependencyProperty.Register(nameof(MakeDigitBeforeCellInRxCyNotation), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HouseNotationOnlyDisplayCapitalsInRxCyNotation"/>.
	/// </summary>
	/// <seealso cref="HouseNotationOnlyDisplayCapitalsInRxCyNotation"/>
	public static readonly DependencyProperty HouseNotationOnlyDisplayCapitalsInRxCyNotationProperty =
		DependencyProperty.Register(nameof(HouseNotationOnlyDisplayCapitalsInRxCyNotation), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AlsoSaveBatchGeneratedPuzzlesIntoHistory"/>.
	/// </summary>
	/// <seealso cref="AlsoSaveBatchGeneratedPuzzlesIntoHistory"/>
	public static readonly DependencyProperty AlsoSaveBatchGeneratedPuzzlesIntoHistoryProperty =
		DependencyProperty.Register(nameof(AlsoSaveBatchGeneratedPuzzlesIntoHistory), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableCornerRadiusForSudokuPanes"/>.
	/// </summary>
	/// <seealso cref="EnableCornerRadiusForSudokuPanes"/>
	public static readonly DependencyProperty EnableCornerRadiusForSudokuPanesProperty =
		DependencyProperty.Register(nameof(EnableCornerRadiusForSudokuPanes), typeof(bool), typeof(UIPreferenceGroup), new PropertyMetadata(true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EmptyCellCharacter"/>.
	/// </summary>
	/// <seealso cref="EmptyCellCharacter"/>
	public static readonly DependencyProperty EmptyCellCharacterProperty =
		DependencyProperty.Register(nameof(EmptyCellCharacter), typeof(char), typeof(UIPreferenceGroup), new PropertyMetadata('0'));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="FinalRowLetterInK9Notation"/>.
	/// </summary>
	/// <seealso cref="FinalRowLetterInK9Notation"/>
	public static readonly DependencyProperty FinalRowLetterInK9NotationProperty =
		DependencyProperty.Register(nameof(FinalRowLetterInK9Notation), typeof(char), typeof(UIPreferenceGroup), new PropertyMetadata('I'));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="MainNavigationPageOpenPaneLength"/>.
	/// </summary>
	/// <seealso cref="MainNavigationPageOpenPaneLength"/>
	public static readonly DependencyProperty MainNavigationPageOpenPaneLengthProperty =
		DependencyProperty.Register(nameof(MainNavigationPageOpenPaneLength), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(MainNavigationPageOpenPaneLengthDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HighlightedPencilmarkBackgroundEllipseScale"/>.
	/// </summary>
	/// <seealso cref="HighlightedPencilmarkBackgroundEllipseScale"/>
	public static readonly DependencyProperty HighlightedPencilmarkBackgroundEllipseScaleProperty =
		DependencyProperty.Register(nameof(HighlightedPencilmarkBackgroundEllipseScale), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(HighlightedPencilmarkBackgroundEllipseScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HighlightedBackgroundOpacity"/>.
	/// </summary>
	/// <seealso cref="HighlightedBackgroundOpacity"/>
	public static readonly DependencyProperty HighlightedBackgroundOpacityProperty =
		DependencyProperty.Register(nameof(HighlightedBackgroundOpacity), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(HighlightedBackgroundOpacityDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ChainStrokeThickness"/>.
	/// </summary>
	/// <seealso cref="ChainStrokeThickness"/>
	public static readonly DependencyProperty ChainStrokeThicknessProperty =
		DependencyProperty.Register(nameof(ChainStrokeThickness), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(ChainStrokeThicknessDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GivenFontScale"/>.
	/// </summary>
	/// <seealso cref="GivenFontScale"/>
	public static readonly DependencyProperty GivenFontScaleProperty =
		DependencyProperty.Register(nameof(GivenFontScale), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(GivenFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ModifiableFontScale"/>.
	/// </summary>
	/// <seealso cref="ModifiableFontScale"/>
	public static readonly DependencyProperty ModifiableFontScaleProperty =
		DependencyProperty.Register(nameof(ModifiableFontScale), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(ModifiableFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PencilmarkFontScale"/>.
	/// </summary>
	/// <seealso cref="PencilmarkFontScale"/>
	public static readonly DependencyProperty PencilmarkFontScaleProperty =
		DependencyProperty.Register(nameof(PencilmarkFontScale), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(PencilmarkFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BabaGroupingFontScale"/>.
	/// </summary>
	/// <seealso cref="BabaGroupingFontScale"/>
	public static readonly DependencyProperty BabaGroupingFontScaleProperty =
		DependencyProperty.Register(nameof(BabaGroupingFontScale), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(BabaGroupingFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelFontScale"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelFontScale"/>
	public static readonly DependencyProperty CoordinateLabelFontScaleProperty =
		DependencyProperty.Register(nameof(CoordinateLabelFontScale), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(CoordinateLabelFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SudokuGridSize"/>.
	/// </summary>
	/// <seealso cref="SudokuGridSize"/>
	public static readonly DependencyProperty SudokuGridSizeProperty =
		DependencyProperty.Register(nameof(SudokuGridSize), typeof(decimal), typeof(UIPreferenceGroup), new PropertyMetadata(SudokuGridSizeDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelDisplayMode"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelDisplayMode"/>
	public static readonly DependencyProperty CoordinateLabelDisplayModeProperty =
		DependencyProperty.Register(nameof(CoordinateLabelDisplayMode), typeof(int), typeof(UIPreferenceGroup), new PropertyMetadata(2));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CandidateViewNodeDisplayMode"/>.
	/// </summary>
	/// <seealso cref="CandidateViewNodeDisplayMode"/>
	public static readonly DependencyProperty CandidateViewNodeDisplayModeProperty =
		DependencyProperty.Register(nameof(CandidateViewNodeDisplayMode), typeof(int), typeof(UIPreferenceGroup), new PropertyMetadata(0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EliminationDisplayMode"/>.
	/// </summary>
	/// <seealso cref="EliminationDisplayMode"/>
	public static readonly DependencyProperty EliminationDisplayModeProperty =
		DependencyProperty.Register(nameof(EliminationDisplayMode), typeof(int), typeof(UIPreferenceGroup), new PropertyMetadata(0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AssignmentDisplayMode"/>.
	/// </summary>
	/// <seealso cref="AssignmentDisplayMode"/>
	public static readonly DependencyProperty AssignmentDisplayModeProperty =
		DependencyProperty.Register(nameof(AssignmentDisplayMode), typeof(int), typeof(UIPreferenceGroup), new PropertyMetadata(0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DesiredPictureSizeOnSaving"/>.
	/// </summary>
	/// <seealso cref="DesiredPictureSizeOnSaving"/>
	public static readonly DependencyProperty DesiredPictureSizeOnSavingProperty =
		DependencyProperty.Register(nameof(DesiredPictureSizeOnSaving), typeof(int), typeof(UIPreferenceGroup), new PropertyMetadata(1000));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="IttoryuLength"/>.
	/// </summary>
	/// <seealso cref="IttoryuLength"/>
	public static readonly DependencyProperty IttoryuLengthProperty =
		DependencyProperty.Register(nameof(IttoryuLength), typeof(int), typeof(UIPreferenceGroup), new PropertyMetadata(0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Language"/>.
	/// </summary>
	/// <seealso cref="Language"/>
	public static readonly DependencyProperty LanguageProperty =
		DependencyProperty.Register(nameof(Language), typeof(int), typeof(UIPreferenceGroup), new PropertyMetadata(0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GivenFontName"/>.
	/// </summary>
	/// <seealso cref="GivenFontName"/>
	public static readonly DependencyProperty GivenFontNameProperty =
		DependencyProperty.Register(nameof(GivenFontName), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata("Cascadia Code"));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ModifiableFontName"/>.
	/// </summary>
	/// <seealso cref="ModifiableFontName"/>
	public static readonly DependencyProperty ModifiableFontNameProperty =
		DependencyProperty.Register(nameof(ModifiableFontName), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata("Cascadia Code"));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PencilmarkFontName"/>.
	/// </summary>
	/// <seealso cref="PencilmarkFontName"/>
	public static readonly DependencyProperty PencilmarkFontNameProperty =
		DependencyProperty.Register(nameof(PencilmarkFontName), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata("Cascadia Code"));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BabaGroupingFontName"/>.
	/// </summary>
	/// <seealso cref="BabaGroupingFontName"/>
	public static readonly DependencyProperty BabaGroupingFontNameProperty =
		DependencyProperty.Register(nameof(BabaGroupingFontName), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata("Times New Roman"));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelFontName"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelFontName"/>
	public static readonly DependencyProperty CoordinateLabelFontNameProperty =
		DependencyProperty.Register(nameof(CoordinateLabelFontName), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata("Cascadia Code"));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DefaultSeparatorInNotation"/>.
	/// </summary>
	/// <seealso cref="DefaultSeparatorInNotation"/>
	public static readonly DependencyProperty DefaultSeparatorInNotationProperty =
		DependencyProperty.Register(nameof(DefaultSeparatorInNotation), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata(", "));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DigitsSeparatorInNotation"/>.
	/// </summary>
	/// <seealso cref="DigitsSeparatorInNotation"/>
	public static readonly DependencyProperty DigitsSeparatorInNotationProperty =
		DependencyProperty.Register(nameof(DigitsSeparatorInNotation), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="FetchingPuzzleLibrary"/>.
	/// </summary>
	/// <seealso cref="FetchingPuzzleLibrary"/>
	public static readonly DependencyProperty FetchingPuzzleLibraryProperty =
		DependencyProperty.Register(nameof(FetchingPuzzleLibrary), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BackgroundPicturePath"/>.
	/// </summary>
	/// <seealso cref="BackgroundPicturePath"/>
	public static readonly DependencyProperty BackgroundPicturePathProperty =
		DependencyProperty.Register(nameof(BackgroundPicturePath), typeof(string), typeof(UIPreferenceGroup), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Backdrop"/>.
	/// </summary>
	/// <seealso cref="Backdrop"/>
	public static readonly DependencyProperty BackdropProperty =
		DependencyProperty.Register(nameof(Backdrop), typeof(BackdropKind), typeof(UIPreferenceGroup), new PropertyMetadata((BackdropKind)3, BackdropPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="StepDisplayItems"/>.
	/// </summary>
	/// <seealso cref="StepDisplayItems"/>
	public static readonly DependencyProperty StepDisplayItemsProperty =
		DependencyProperty.Register(nameof(StepDisplayItems), typeof(StepTooltipDisplayItems), typeof(UIPreferenceGroup), new PropertyMetadata(StepTooltipDisplayItems.TechniqueName | StepTooltipDisplayItems.DifficultyRating | StepTooltipDisplayItems.SimpleDescription | StepTooltipDisplayItems.ExtraDifficultyCases));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ConceptNotationBasedKind"/>.
	/// </summary>
	/// <seealso cref="ConceptNotationBasedKind"/>
	public static readonly DependencyProperty ConceptNotationBasedKindProperty =
		DependencyProperty.Register(nameof(ConceptNotationBasedKind), typeof(CoordinateType), typeof(UIPreferenceGroup), new PropertyMetadata((CoordinateType)1));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CurrentTheme"/>.
	/// </summary>
	/// <seealso cref="CurrentTheme"/>
	public static readonly DependencyProperty CurrentThemeProperty =
		DependencyProperty.Register(nameof(CurrentTheme), typeof(Theme), typeof(UIPreferenceGroup), new PropertyMetadata((Theme)0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GivenFontColor"/>.
	/// </summary>
	/// <seealso cref="GivenFontColor"/>
	public static readonly DependencyProperty GivenFontColorProperty =
		DependencyProperty.Register(nameof(GivenFontColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(GivenFontColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GivenFontColor_Dark"/>.
	/// </summary>
	/// <seealso cref="GivenFontColor_Dark"/>
	public static readonly DependencyProperty GivenFontColor_DarkProperty =
		DependencyProperty.Register(nameof(GivenFontColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(GivenFontColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ModifiableFontColor"/>.
	/// </summary>
	/// <seealso cref="ModifiableFontColor"/>
	public static readonly DependencyProperty ModifiableFontColorProperty =
		DependencyProperty.Register(nameof(ModifiableFontColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(ModifiableFontColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ModifiableFontColor_Dark"/>.
	/// </summary>
	/// <seealso cref="ModifiableFontColor_Dark"/>
	public static readonly DependencyProperty ModifiableFontColor_DarkProperty =
		DependencyProperty.Register(nameof(ModifiableFontColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(ModifiableFontColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PencilmarkFontColor"/>.
	/// </summary>
	/// <seealso cref="PencilmarkFontColor"/>
	public static readonly DependencyProperty PencilmarkFontColorProperty =
		DependencyProperty.Register(nameof(PencilmarkFontColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(PencilmarkFontColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PencilmarkFontColor_Dark"/>.
	/// </summary>
	/// <seealso cref="PencilmarkFontColor_Dark"/>
	public static readonly DependencyProperty PencilmarkFontColor_DarkProperty =
		DependencyProperty.Register(nameof(PencilmarkFontColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(PencilmarkFontColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BabaGroupingFontColor"/>.
	/// </summary>
	/// <seealso cref="BabaGroupingFontColor"/>
	public static readonly DependencyProperty BabaGroupingFontColorProperty =
		DependencyProperty.Register(nameof(BabaGroupingFontColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(BabaGroupingFontColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BabaGroupingFontColor_Dark"/>.
	/// </summary>
	/// <seealso cref="BabaGroupingFontColor_Dark"/>
	public static readonly DependencyProperty BabaGroupingFontColor_DarkProperty =
		DependencyProperty.Register(nameof(BabaGroupingFontColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(BabaGroupingFontColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelFontColor"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelFontColor"/>
	public static readonly DependencyProperty CoordinateLabelFontColorProperty =
		DependencyProperty.Register(nameof(CoordinateLabelFontColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(CoordinateLabelFontColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelFontColor_Dark"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelFontColor_Dark"/>
	public static readonly DependencyProperty CoordinateLabelFontColor_DarkProperty =
		DependencyProperty.Register(nameof(CoordinateLabelFontColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(CoordinateLabelFontColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DeltaValueColor"/>.
	/// </summary>
	/// <seealso cref="DeltaValueColor"/>
	public static readonly DependencyProperty DeltaValueColorProperty =
		DependencyProperty.Register(nameof(DeltaValueColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(DeltaValueColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DeltaValueColor_Dark"/>.
	/// </summary>
	/// <seealso cref="DeltaValueColor_Dark"/>
	public static readonly DependencyProperty DeltaValueColor_DarkProperty =
		DependencyProperty.Register(nameof(DeltaValueColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(DeltaValueColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DeltaPencilmarkColor"/>.
	/// </summary>
	/// <seealso cref="DeltaPencilmarkColor"/>
	public static readonly DependencyProperty DeltaPencilmarkColorProperty =
		DependencyProperty.Register(nameof(DeltaPencilmarkColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(DeltaPencilmarkColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DeltaPencilmarkColor_Dark"/>.
	/// </summary>
	/// <seealso cref="DeltaPencilmarkColor_Dark"/>
	public static readonly DependencyProperty DeltaPencilmarkColor_DarkProperty =
		DependencyProperty.Register(nameof(DeltaPencilmarkColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(DeltaPencilmarkColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SudokuPaneBorderColor"/>.
	/// </summary>
	/// <seealso cref="SudokuPaneBorderColor"/>
	public static readonly DependencyProperty SudokuPaneBorderColorProperty =
		DependencyProperty.Register(nameof(SudokuPaneBorderColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(SudokuPaneBorderColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SudokuPaneBorderColor_Dark"/>.
	/// </summary>
	/// <seealso cref="SudokuPaneBorderColor_Dark"/>
	public static readonly DependencyProperty SudokuPaneBorderColor_DarkProperty =
		DependencyProperty.Register(nameof(SudokuPaneBorderColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(SudokuPaneBorderColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CursorBackgroundColor"/>.
	/// </summary>
	/// <seealso cref="CursorBackgroundColor"/>
	public static readonly DependencyProperty CursorBackgroundColorProperty =
		DependencyProperty.Register(nameof(CursorBackgroundColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(CursorBackgroundColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CursorBackgroundColor_Dark"/>.
	/// </summary>
	/// <seealso cref="CursorBackgroundColor_Dark"/>
	public static readonly DependencyProperty CursorBackgroundColor_DarkProperty =
		DependencyProperty.Register(nameof(CursorBackgroundColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(CursorBackgroundColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ChainColor"/>.
	/// </summary>
	/// <seealso cref="ChainColor"/>
	public static readonly DependencyProperty ChainColorProperty =
		DependencyProperty.Register(nameof(ChainColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(ChainColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ChainColor_Dark"/>.
	/// </summary>
	/// <seealso cref="ChainColor_Dark"/>
	public static readonly DependencyProperty ChainColor_DarkProperty =
		DependencyProperty.Register(nameof(ChainColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(ChainColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="NormalColor"/>.
	/// </summary>
	/// <seealso cref="NormalColor"/>
	public static readonly DependencyProperty NormalColorProperty =
		DependencyProperty.Register(nameof(NormalColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(NormalColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="NormalColor_Dark"/>.
	/// </summary>
	/// <seealso cref="NormalColor_Dark"/>
	public static readonly DependencyProperty NormalColor_DarkProperty =
		DependencyProperty.Register(nameof(NormalColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(NormalColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AssignmentColor"/>.
	/// </summary>
	/// <seealso cref="AssignmentColor"/>
	public static readonly DependencyProperty AssignmentColorProperty =
		DependencyProperty.Register(nameof(AssignmentColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(AssignmentColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AssignmentColor_Dark"/>.
	/// </summary>
	/// <seealso cref="AssignmentColor_Dark"/>
	public static readonly DependencyProperty AssignmentColor_DarkProperty =
		DependencyProperty.Register(nameof(AssignmentColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(AssignmentColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="OverlappedAssignmentColor"/>.
	/// </summary>
	/// <seealso cref="OverlappedAssignmentColor"/>
	public static readonly DependencyProperty OverlappedAssignmentColorProperty =
		DependencyProperty.Register(nameof(OverlappedAssignmentColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(OverlappedAssignmentColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="OverlappedAssignmentColor_Dark"/>.
	/// </summary>
	/// <seealso cref="OverlappedAssignmentColor_Dark"/>
	public static readonly DependencyProperty OverlappedAssignmentColor_DarkProperty =
		DependencyProperty.Register(nameof(OverlappedAssignmentColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(OverlappedAssignmentColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EliminationColor"/>.
	/// </summary>
	/// <seealso cref="EliminationColor"/>
	public static readonly DependencyProperty EliminationColorProperty =
		DependencyProperty.Register(nameof(EliminationColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(EliminationColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EliminationColor_Dark"/>.
	/// </summary>
	/// <seealso cref="EliminationColor_Dark"/>
	public static readonly DependencyProperty EliminationColor_DarkProperty =
		DependencyProperty.Register(nameof(EliminationColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(EliminationColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CannibalismColor"/>.
	/// </summary>
	/// <seealso cref="CannibalismColor"/>
	public static readonly DependencyProperty CannibalismColorProperty =
		DependencyProperty.Register(nameof(CannibalismColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(CannibalismColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CannibalismColor_Dark"/>.
	/// </summary>
	/// <seealso cref="CannibalismColor_Dark"/>
	public static readonly DependencyProperty CannibalismColor_DarkProperty =
		DependencyProperty.Register(nameof(CannibalismColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(CannibalismColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ExofinColor"/>.
	/// </summary>
	/// <seealso cref="ExofinColor"/>
	public static readonly DependencyProperty ExofinColorProperty =
		DependencyProperty.Register(nameof(ExofinColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(ExofinColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ExofinColor_Dark"/>.
	/// </summary>
	/// <seealso cref="ExofinColor_Dark"/>
	public static readonly DependencyProperty ExofinColor_DarkProperty =
		DependencyProperty.Register(nameof(ExofinColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(ExofinColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EndofinColor"/>.
	/// </summary>
	/// <seealso cref="EndofinColor"/>
	public static readonly DependencyProperty EndofinColorProperty =
		DependencyProperty.Register(nameof(EndofinColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(EndofinColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EndofinColor_Dark"/>.
	/// </summary>
	/// <seealso cref="EndofinColor_Dark"/>
	public static readonly DependencyProperty EndofinColor_DarkProperty =
		DependencyProperty.Register(nameof(EndofinColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(EndofinColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GroupedNodeStrokeColor"/>.
	/// </summary>
	/// <seealso cref="GroupedNodeStrokeColor"/>
	public static readonly DependencyProperty GroupedNodeStrokeColorProperty =
		DependencyProperty.Register(nameof(GroupedNodeStrokeColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(GroupedNodeStrokeColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GroupedNodeStrokeColor_Dark"/>.
	/// </summary>
	/// <seealso cref="GroupedNodeStrokeColor_Dark"/>
	public static readonly DependencyProperty GroupedNodeStrokeColor_DarkProperty =
		DependencyProperty.Register(nameof(GroupedNodeStrokeColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(GroupedNodeStrokeColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GroupedNodeBackgroundColor"/>.
	/// </summary>
	/// <seealso cref="GroupedNodeBackgroundColor"/>
	public static readonly DependencyProperty GroupedNodeBackgroundColorProperty =
		DependencyProperty.Register(nameof(GroupedNodeBackgroundColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(GroupedNodeBackgroundColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GroupedNodeBackgroundColor_Dark"/>.
	/// </summary>
	/// <seealso cref="GroupedNodeBackgroundColor_Dark"/>
	public static readonly DependencyProperty GroupedNodeBackgroundColor_DarkProperty =
		DependencyProperty.Register(nameof(GroupedNodeBackgroundColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(GroupedNodeBackgroundColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HouseCompletedFeedbackColor"/>.
	/// </summary>
	/// <seealso cref="HouseCompletedFeedbackColor"/>
	public static readonly DependencyProperty HouseCompletedFeedbackColorProperty =
		DependencyProperty.Register(nameof(HouseCompletedFeedbackColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(HouseCompletedFeedbackColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HouseCompletedFeedbackColor_Dark"/>.
	/// </summary>
	/// <seealso cref="HouseCompletedFeedbackColor_Dark"/>
	public static readonly DependencyProperty HouseCompletedFeedbackColor_DarkProperty =
		DependencyProperty.Register(nameof(HouseCompletedFeedbackColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(HouseCompletedFeedbackColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ActiveCellColor"/>.
	/// </summary>
	/// <seealso cref="ActiveCellColor"/>
	public static readonly DependencyProperty ActiveCellColorProperty =
		DependencyProperty.Register(nameof(ActiveCellColor), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(ActiveCellColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ActiveCellColor_Dark"/>.
	/// </summary>
	/// <seealso cref="ActiveCellColor_Dark"/>
	public static readonly DependencyProperty ActiveCellColor_DarkProperty =
		DependencyProperty.Register(nameof(ActiveCellColor_Dark), typeof(Color), typeof(UIPreferenceGroup), new PropertyMetadata(ActiveCellColor_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="StrongLinkDashStyle"/>.
	/// </summary>
	/// <seealso cref="StrongLinkDashStyle"/>
	public static readonly DependencyProperty StrongLinkDashStyleProperty =
		DependencyProperty.Register(nameof(StrongLinkDashStyle), typeof(DashArray), typeof(UIPreferenceGroup), new PropertyMetadata(StrongLinkDashStyleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="WeakLinkDashStyle"/>.
	/// </summary>
	/// <seealso cref="WeakLinkDashStyle"/>
	public static readonly DependencyProperty WeakLinkDashStyleProperty =
		DependencyProperty.Register(nameof(WeakLinkDashStyle), typeof(DashArray), typeof(UIPreferenceGroup), new PropertyMetadata(WeakLinkDashStyleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LastGridPuzzle"/>.
	/// </summary>
	/// <seealso cref="LastGridPuzzle"/>
	public static readonly DependencyProperty LastGridPuzzleProperty =
		DependencyProperty.Register(nameof(LastGridPuzzle), typeof(Grid), typeof(UIPreferenceGroup), new PropertyMetadata(LastGridPuzzleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LastRenderable"/>.
	/// </summary>
	/// <seealso cref="LastRenderable"/>
	public static readonly DependencyProperty LastRenderableProperty =
		DependencyProperty.Register(nameof(LastRenderable), typeof(UserDefinedDrawable?), typeof(UIPreferenceGroup), new PropertyMetadata(default(UserDefinedDrawable?)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AuxiliaryColors"/>.
	/// </summary>
	/// <seealso cref="AuxiliaryColors"/>
	public static readonly DependencyProperty AuxiliaryColorsProperty =
		DependencyProperty.Register(nameof(AuxiliaryColors), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(AuxiliaryColorsDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AuxiliaryColors_Dark"/>.
	/// </summary>
	/// <seealso cref="AuxiliaryColors_Dark"/>
	public static readonly DependencyProperty AuxiliaryColors_DarkProperty =
		DependencyProperty.Register(nameof(AuxiliaryColors_Dark), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(AuxiliaryColors_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DifficultyLevelForegrounds"/>.
	/// </summary>
	/// <seealso cref="DifficultyLevelForegrounds"/>
	public static readonly DependencyProperty DifficultyLevelForegroundsProperty =
		DependencyProperty.Register(nameof(DifficultyLevelForegrounds), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(DifficultyLevelForegroundsDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DifficultyLevelForegrounds_Dark"/>.
	/// </summary>
	/// <seealso cref="DifficultyLevelForegrounds_Dark"/>
	public static readonly DependencyProperty DifficultyLevelForegrounds_DarkProperty =
		DependencyProperty.Register(nameof(DifficultyLevelForegrounds_Dark), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(DifficultyLevelForegrounds_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DifficultyLevelBackgrounds"/>.
	/// </summary>
	/// <seealso cref="DifficultyLevelBackgrounds"/>
	public static readonly DependencyProperty DifficultyLevelBackgroundsProperty =
		DependencyProperty.Register(nameof(DifficultyLevelBackgrounds), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(DifficultyLevelBackgroundsDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DifficultyLevelBackgrounds_Dark"/>.
	/// </summary>
	/// <seealso cref="DifficultyLevelBackgrounds_Dark"/>
	public static readonly DependencyProperty DifficultyLevelBackgrounds_DarkProperty =
		DependencyProperty.Register(nameof(DifficultyLevelBackgrounds_Dark), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(DifficultyLevelBackgrounds_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="UserDefinedColorPalette"/>.
	/// </summary>
	/// <seealso cref="UserDefinedColorPalette"/>
	public static readonly DependencyProperty UserDefinedColorPaletteProperty =
		DependencyProperty.Register(nameof(UserDefinedColorPalette), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(UserDefinedColorPaletteDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="UserDefinedColorPalette_Dark"/>.
	/// </summary>
	/// <seealso cref="UserDefinedColorPalette_Dark"/>
	public static readonly DependencyProperty UserDefinedColorPalette_DarkProperty =
		DependencyProperty.Register(nameof(UserDefinedColorPalette_Dark), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(UserDefinedColorPalette_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AlmostLockedSetsColors"/>.
	/// </summary>
	/// <seealso cref="AlmostLockedSetsColors"/>
	public static readonly DependencyProperty AlmostLockedSetsColorsProperty =
		DependencyProperty.Register(nameof(AlmostLockedSetsColors), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(AlmostLockedSetsColorsDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AlmostLockedSetsColors_Dark"/>.
	/// </summary>
	/// <seealso cref="AlmostLockedSetsColors_Dark"/>
	public static readonly DependencyProperty AlmostLockedSetsColors_DarkProperty =
		DependencyProperty.Register(nameof(AlmostLockedSetsColors_Dark), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(AlmostLockedSetsColors_DarkDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="RectangleColors"/>.
	/// </summary>
	/// <seealso cref="RectangleColors"/>
	public static readonly DependencyProperty RectangleColorsProperty =
		DependencyProperty.Register(nameof(RectangleColors), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(RectangleColorsDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="RectangleColors_Dark"/>.
	/// </summary>
	/// <seealso cref="RectangleColors_Dark"/>
	public static readonly DependencyProperty RectangleColors_DarkProperty =
		DependencyProperty.Register(nameof(RectangleColors_Dark), typeof(ColorPalette), typeof(UIPreferenceGroup), new PropertyMetadata(RectangleColors_DarkDefaultValue));


	/// <inheritdoc cref="SudokuPane.DisplayCandidates"/>
	public bool DisplayCandidates
	{
		get => (bool)GetValue(DisplayCandidatesProperty);

		set => SetValue(DisplayCandidatesProperty, value);
	}

	/// <summary>
	/// Indicates whether the current mode is direct mode.
	/// </summary>
	public bool IsDirectMode
	{
		get => (bool)GetValue(IsDirectModeProperty);

		set => SetValue(IsDirectModeProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.DisplayCursors"/>
	public bool DisplayCursors
	{
		get => (bool)GetValue(DisplayCursorsProperty);

		set => SetValue(DisplayCursorsProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.UseDifferentColorToDisplayDeltaDigits"/>
	public bool DistinctWithDeltaDigits
	{
		get => (bool)GetValue(DistinctWithDeltaDigitsProperty);

		set => SetValue(DistinctWithDeltaDigitsProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.DisableFlyout"/>
	public bool DisableSudokuPaneLayout
	{
		get => (bool)GetValue(DisableSudokuPaneLayoutProperty);

		set => SetValue(DisableSudokuPaneLayoutProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.PreventConflictingInput"/>
	public bool PreventConflictingInput
	{
		get => (bool)GetValue(PreventConflictingInputProperty);

		set => SetValue(PreventConflictingInputProperty, value);
	}

	/// <summary>
	/// Indicates whether the program saves for puzzle-generating history.
	/// </summary>
	public bool SavePuzzleGeneratingHistory
	{
		get => (bool)GetValue(SavePuzzleGeneratingHistoryProperty);

		set => SetValue(SavePuzzleGeneratingHistoryProperty, value);
	}

	/// <summary>
	/// Indicates whether sudoku pane in analysis page provides with a simpler way to fill with Digits via double tapping.
	/// </summary>
	public bool EnableDoubleTapFillingForSudokuPane
	{
		get => (bool)GetValue(EnableDoubleTapFillingForSudokuPaneProperty);

		set => SetValue(EnableDoubleTapFillingForSudokuPaneProperty, value);
	}

	/// <summary>
	/// Indicates whether sudoku pane in analysis page provides with a simpler way to delete Digits via right tapping.
	/// </summary>
	public bool EnableRightTapRemovingForSudokuPane
	{
		get => (bool)GetValue(EnableRightTapRemovingForSudokuPaneProperty);

		set => SetValue(EnableRightTapRemovingForSudokuPaneProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.EnableAnimationFeedback"/>
	public bool EnableAnimationFeedback
	{
		get => (bool)GetValue(EnableAnimationFeedbackProperty);

		set => SetValue(EnableAnimationFeedbackProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.TransparentBackground"/>
	public bool TransparentBackground
	{
		get => (bool)GetValue(TransparentBackgroundProperty);

		set => SetValue(TransparentBackgroundProperty, value);
	}

	/// <summary>
	/// Indicates whether the last puzzle and its views should be cached to local path,
	/// in order to recover them after you re-start or launch the program.
	/// </summary>
	public bool AutoCachePuzzleAndView
	{
		get => (bool)GetValue(AutoCachePuzzleAndViewProperty);

		set => SetValue(AutoCachePuzzleAndViewProperty, value);
	}

	/// <summary>
	/// Indicates whether UI makes letters upper case on displaying coordinates if worth.
	/// </summary>
	public bool MakeLettersUpperCaseInRxCyNotation
	{
		get => (bool)GetValue(MakeLettersUpperCaseInRxCyNotationProperty);

		set => SetValue(MakeLettersUpperCaseInRxCyNotationProperty, value);
	}

	/// <summary>
	/// Indicates whether UI makes letters upper case on displaying coordinates in K9 notation if worth.
	/// </summary>
	public bool MakeLettersUpperCaseInK9Notation
	{
		get => (bool)GetValue(MakeLettersUpperCaseInK9NotationProperty);

		set => SetValue(MakeLettersUpperCaseInK9NotationProperty, value);
	}

	/// <summary>
	/// Indicates whether UI makes letters upper case on displaying coordinates in Excel notation if worth.
	/// </summary>
	public bool MakeLettersUpperCaseInExcelNotation
	{
		get => (bool)GetValue(MakeLettersUpperCaseInExcelNotationProperty);

		set => SetValue(MakeLettersUpperCaseInExcelNotationProperty, value);
	}

	/// <summary>
	/// Indicates whether UI makes Digits displaying before cells.
	/// </summary>
	public bool MakeDigitBeforeCellInRxCyNotation
	{
		get => (bool)GetValue(MakeDigitBeforeCellInRxCyNotationProperty);

		set => SetValue(MakeDigitBeforeCellInRxCyNotationProperty, value);
	}

	/// <summary>
	/// Indicates whether UI makes houses display its capital letters.
	/// </summary>
	public bool HouseNotationOnlyDisplayCapitalsInRxCyNotation
	{
		get => (bool)GetValue(HouseNotationOnlyDisplayCapitalsInRxCyNotationProperty);

		set => SetValue(HouseNotationOnlyDisplayCapitalsInRxCyNotationProperty, value);
	}

	/// <summary>
	/// Indicates whether the program also save for batch generated puzzles into history.
	/// </summary>
	public bool AlsoSaveBatchGeneratedPuzzlesIntoHistory
	{
		get => (bool)GetValue(AlsoSaveBatchGeneratedPuzzlesIntoHistoryProperty);

		set => SetValue(AlsoSaveBatchGeneratedPuzzlesIntoHistoryProperty, value);
	}

	/// <summary>
	/// Indicates whether the program uses corner radius property to apply to sudoku panes.
	/// </summary>
	public bool EnableCornerRadiusForSudokuPanes
	{
		get => (bool)GetValue(EnableCornerRadiusForSudokuPanesProperty);

		set => SetValue(EnableCornerRadiusForSudokuPanesProperty, value);
	}

	/// <summary>
	/// Indicates the default empty character you want to use. The value can be '0' or '.'.
	/// </summary>
	public char EmptyCellCharacter
	{
		get => (char)GetValue(EmptyCellCharacterProperty);

		set => SetValue(EmptyCellCharacterProperty, value);
	}

	/// <summary>
	/// Indicates the last letter representing the last row of the grid in displaying coordinates in K9 notation.
	/// </summary>
	public char FinalRowLetterInK9Notation
	{
		get => (char)GetValue(FinalRowLetterInK9NotationProperty);

		set => SetValue(FinalRowLetterInK9NotationProperty, value);
	}

	/// <summary>
	/// Indicates the open-pane length of main navigation page.
	/// </summary>
	public decimal MainNavigationPageOpenPaneLength
	{
		get => (decimal)GetValue(MainNavigationPageOpenPaneLengthProperty);

		set => SetValue(MainNavigationPageOpenPaneLengthProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.HighlightCandidateCircleScale"/>
	public decimal HighlightedPencilmarkBackgroundEllipseScale
	{
		get => (decimal)GetValue(HighlightedPencilmarkBackgroundEllipseScaleProperty);

		set => SetValue(HighlightedPencilmarkBackgroundEllipseScaleProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.HighlightBackgroundOpacity"/>
	public decimal HighlightedBackgroundOpacity
	{
		get => (decimal)GetValue(HighlightedBackgroundOpacityProperty);

		set => SetValue(HighlightedBackgroundOpacityProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.ChainStrokeThickness"/>
	public decimal ChainStrokeThickness
	{
		get => (decimal)GetValue(ChainStrokeThicknessProperty);

		set => SetValue(ChainStrokeThicknessProperty, value);
	}

	/// <summary>
	/// Indicates the given font scale.
	/// </summary>
	public decimal GivenFontScale
	{
		get => (decimal)GetValue(GivenFontScaleProperty);

		set => SetValue(GivenFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the modifiable font scale.
	/// </summary>
	public decimal ModifiableFontScale
	{
		get => (decimal)GetValue(ModifiableFontScaleProperty);

		set => SetValue(ModifiableFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the pencilmark font scale.
	/// </summary>
	public decimal PencilmarkFontScale
	{
		get => (decimal)GetValue(PencilmarkFontScaleProperty);

		set => SetValue(PencilmarkFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the babe grouping font scale.
	/// </summary>
	public decimal BabaGroupingFontScale
	{
		get => (decimal)GetValue(BabaGroupingFontScaleProperty);

		set => SetValue(BabaGroupingFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the coordinate label font scale.
	/// </summary>
	public decimal CoordinateLabelFontScale
	{
		get => (decimal)GetValue(CoordinateLabelFontScaleProperty);

		set => SetValue(CoordinateLabelFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the sudoku grid size (width and height). In pixels.
	/// </summary>
	public decimal SudokuGridSize
	{
		get => (decimal)GetValue(SudokuGridSizeProperty);

		set => SetValue(SudokuGridSizeProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.CoordinateLabelDisplayMode"/>
	public int CoordinateLabelDisplayMode
	{
		get => (int)GetValue(CoordinateLabelDisplayModeProperty);

		set => SetValue(CoordinateLabelDisplayModeProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.CandidateViewNodeDisplayMode"/>
	public int CandidateViewNodeDisplayMode
	{
		get => (int)GetValue(CandidateViewNodeDisplayModeProperty);

		set => SetValue(CandidateViewNodeDisplayModeProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.EliminationDisplayMode"/>
	public int EliminationDisplayMode
	{
		get => (int)GetValue(EliminationDisplayModeProperty);

		set => SetValue(EliminationDisplayModeProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.AssignmentDisplayMode"/>
	public int AssignmentDisplayMode
	{
		get => (int)GetValue(AssignmentDisplayModeProperty);

		set => SetValue(AssignmentDisplayModeProperty, value);
	}

	/// <summary>
	/// Indicates the desired size of output picture while saving.
	/// </summary>
	public int DesiredPictureSizeOnSaving
	{
		get => (int)GetValue(DesiredPictureSizeOnSavingProperty);

		set => SetValue(DesiredPictureSizeOnSavingProperty, value);
	}

	/// <summary>
	/// Indicates the ittoryu length for the generated puzzles.
	/// </summary>
	public int IttoryuLength
	{
		get => (int)GetValue(IttoryuLengthProperty);

		set => SetValue(IttoryuLengthProperty, value);
	}

	/// <summary>
	/// Indicates the language of UI.
	/// </summary>
	public int Language
	{
		get => (int)GetValue(LanguageProperty);

		set => SetValue(LanguageProperty, value);
	}

	/// <summary>
	/// Indicates the given font name.
	/// </summary>
	public string GivenFontName
	{
		get => (string)GetValue(GivenFontNameProperty);

		set => SetValue(GivenFontNameProperty, value);
	}

	/// <summary>
	/// Indicates the modifiable font name.
	/// </summary>
	public string ModifiableFontName
	{
		get => (string)GetValue(ModifiableFontNameProperty);

		set => SetValue(ModifiableFontNameProperty, value);
	}

	/// <summary>
	/// Indicates the pencilmark font name.
	/// </summary>
	public string PencilmarkFontName
	{
		get => (string)GetValue(PencilmarkFontNameProperty);

		set => SetValue(PencilmarkFontNameProperty, value);
	}

	/// <summary>
	/// Indicates the baba grouping font name.
	/// </summary>
	public string BabaGroupingFontName
	{
		get => (string)GetValue(BabaGroupingFontNameProperty);

		set => SetValue(BabaGroupingFontNameProperty, value);
	}

	/// <summary>
	/// Indicates the coordinate label font name.
	/// </summary>
	public string CoordinateLabelFontName
	{
		get => (string)GetValue(CoordinateLabelFontNameProperty);

		set => SetValue(CoordinateLabelFontNameProperty, value);
	}

	/// <summary>
	/// Indicates the default separators for separating with coordinates.
	/// </summary>
	public string DefaultSeparatorInNotation
	{
		get => (string)GetValue(DefaultSeparatorInNotationProperty);

		set => SetValue(DefaultSeparatorInNotationProperty, value);
	}

	/// <summary>
	/// Indicates the default digit separators for displaying Digits.
	/// </summary>
	public string? DigitsSeparatorInNotation
	{
		get => (string?)GetValue(DigitsSeparatorInNotationProperty);

		set => SetValue(DigitsSeparatorInNotationProperty, value);
	}

	/// <summary>
	/// Indicates the file ID of the puzzle library that you want to be used for generating in analyzer page.
	/// </summary>
	public string? FetchingPuzzleLibrary
	{
		get => (string?)GetValue(FetchingPuzzleLibraryProperty);

		set => SetValue(FetchingPuzzleLibraryProperty, value);
	}

	/// <summary>
	/// Indicates the background picture path.
	/// </summary>
	public string? BackgroundPicturePath
	{
		get => (string?)GetValue(BackgroundPicturePathProperty);

		set => SetValue(BackgroundPicturePathProperty, value);
	}

	/// <summary>
	/// Indicates the backdrop.
	/// </summary>
	public BackdropKind Backdrop
	{
		get => (BackdropKind)GetValue(BackdropProperty);

		set => SetValue(BackdropProperty, value);
	}

	/// <summary>
	/// Indicates the tooltip display items.
	/// </summary>
	public StepTooltipDisplayItems StepDisplayItems
	{
		get => (StepTooltipDisplayItems)GetValue(StepDisplayItemsProperty);

		set => SetValue(StepDisplayItemsProperty, value);
	}

	/// <summary>
	/// Indicates the based type for displaying a concept notation.
	/// </summary>
	public CoordinateType ConceptNotationBasedKind
	{
		get => (CoordinateType)GetValue(ConceptNotationBasedKindProperty);

		set => SetValue(ConceptNotationBasedKindProperty, value);
	}

	/// <summary>
	/// Indicates the theme used in this program.
	/// </summary>
	public Theme CurrentTheme
	{
		get => (Theme)GetValue(CurrentThemeProperty);

		set => SetValue(CurrentThemeProperty, value);
	}

	/// <summary>
	/// Indicates the given font color.
	/// </summary>
	public Color GivenFontColor
	{
		get => (Color)GetValue(GivenFontColorProperty);

		set => SetValue(GivenFontColorProperty, value);
	}

	/// <summary>
	/// Indicates the given font color, in dark theme.
	/// </summary>
	public Color GivenFontColor_Dark
	{
		get => (Color)GetValue(GivenFontColor_DarkProperty);

		set => SetValue(GivenFontColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the modifiable font color.
	/// </summary>
	public Color ModifiableFontColor
	{
		get => (Color)GetValue(ModifiableFontColorProperty);

		set => SetValue(ModifiableFontColorProperty, value);
	}

	/// <summary>
	/// Indicates the modifiable font color, in dark theme.
	/// </summary>
	public Color ModifiableFontColor_Dark
	{
		get => (Color)GetValue(ModifiableFontColor_DarkProperty);

		set => SetValue(ModifiableFontColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the pencilmark font color.
	/// </summary>
	public Color PencilmarkFontColor
	{
		get => (Color)GetValue(PencilmarkFontColorProperty);

		set => SetValue(PencilmarkFontColorProperty, value);
	}

	/// <summary>
	/// Indicates the pencilmark font color, in dark theme.
	/// </summary>
	public Color PencilmarkFontColor_Dark
	{
		get => (Color)GetValue(PencilmarkFontColor_DarkProperty);

		set => SetValue(PencilmarkFontColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the baba grouping font color.
	/// </summary>
	public Color BabaGroupingFontColor
	{
		get => (Color)GetValue(BabaGroupingFontColorProperty);

		set => SetValue(BabaGroupingFontColorProperty, value);
	}

	/// <summary>
	/// Indicates the baba grouping font color, in dark theme.
	/// </summary>
	public Color BabaGroupingFontColor_Dark
	{
		get => (Color)GetValue(BabaGroupingFontColor_DarkProperty);

		set => SetValue(BabaGroupingFontColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the coordinate label font color.
	/// </summary>
	public Color CoordinateLabelFontColor
	{
		get => (Color)GetValue(CoordinateLabelFontColorProperty);

		set => SetValue(CoordinateLabelFontColorProperty, value);
	}

	/// <summary>
	/// Indicates the coordinate label font color, in dark theme.
	/// </summary>
	public Color CoordinateLabelFontColor_Dark
	{
		get => (Color)GetValue(CoordinateLabelFontColor_DarkProperty);

		set => SetValue(CoordinateLabelFontColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the default value color.
	/// </summary>
	public Color DeltaValueColor
	{
		get => (Color)GetValue(DeltaValueColorProperty);

		set => SetValue(DeltaValueColorProperty, value);
	}

	/// <summary>
	/// Indicates the default value color, in dark theme.
	/// </summary>
	public Color DeltaValueColor_Dark
	{
		get => (Color)GetValue(DeltaValueColor_DarkProperty);

		set => SetValue(DeltaValueColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the delta pencilmark color.
	/// </summary>
	public Color DeltaPencilmarkColor
	{
		get => (Color)GetValue(DeltaPencilmarkColorProperty);

		set => SetValue(DeltaPencilmarkColorProperty, value);
	}

	/// <summary>
	/// Indicates the delta pencilmark color, in dark theme.
	/// </summary>
	public Color DeltaPencilmarkColor_Dark
	{
		get => (Color)GetValue(DeltaPencilmarkColor_DarkProperty);

		set => SetValue(DeltaPencilmarkColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the sudoku pane border color.
	/// </summary>
	public Color SudokuPaneBorderColor
	{
		get => (Color)GetValue(SudokuPaneBorderColorProperty);

		set => SetValue(SudokuPaneBorderColorProperty, value);
	}

	/// <summary>
	/// Indicates the sudoku pane border color, in dark theme.
	/// </summary>
	public Color SudokuPaneBorderColor_Dark
	{
		get => (Color)GetValue(SudokuPaneBorderColor_DarkProperty);

		set => SetValue(SudokuPaneBorderColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the cursor background color.
	/// </summary>
	public Color CursorBackgroundColor
	{
		get => (Color)GetValue(CursorBackgroundColorProperty);

		set => SetValue(CursorBackgroundColorProperty, value);
	}

	/// <summary>
	/// Indicates the cursor background color, in dark theme.
	/// </summary>
	public Color CursorBackgroundColor_Dark
	{
		get => (Color)GetValue(CursorBackgroundColor_DarkProperty);

		set => SetValue(CursorBackgroundColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the chain color.
	/// </summary>
	public Color ChainColor
	{
		get => (Color)GetValue(ChainColorProperty);

		set => SetValue(ChainColorProperty, value);
	}

	/// <summary>
	/// Indicates the chain color, in dark theme.
	/// </summary>
	public Color ChainColor_Dark
	{
		get => (Color)GetValue(ChainColor_DarkProperty);

		set => SetValue(ChainColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the normal color.
	/// </summary>
	public Color NormalColor
	{
		get => (Color)GetValue(NormalColorProperty);

		set => SetValue(NormalColorProperty, value);
	}

	/// <summary>
	/// Indicates the normal color, in dark theme.
	/// </summary>
	public Color NormalColor_Dark
	{
		get => (Color)GetValue(NormalColor_DarkProperty);

		set => SetValue(NormalColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the assignment color.
	/// </summary>
	public Color AssignmentColor
	{
		get => (Color)GetValue(AssignmentColorProperty);

		set => SetValue(AssignmentColorProperty, value);
	}

	/// <summary>
	/// Indicates the assignment color, in dark theme.
	/// </summary>
	public Color AssignmentColor_Dark
	{
		get => (Color)GetValue(AssignmentColor_DarkProperty);

		set => SetValue(AssignmentColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the overlapped assignment color.
	/// </summary>
	public Color OverlappedAssignmentColor
	{
		get => (Color)GetValue(OverlappedAssignmentColorProperty);

		set => SetValue(OverlappedAssignmentColorProperty, value);
	}

	/// <summary>
	/// Indicates the overlapped assignment color, in dark theme.
	/// </summary>
	public Color OverlappedAssignmentColor_Dark
	{
		get => (Color)GetValue(OverlappedAssignmentColor_DarkProperty);

		set => SetValue(OverlappedAssignmentColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the elimination color.
	/// </summary>
	public Color EliminationColor
	{
		get => (Color)GetValue(EliminationColorProperty);

		set => SetValue(EliminationColorProperty, value);
	}

	/// <summary>
	/// Indicates the elimination color, in dark theme.
	/// </summary>
	public Color EliminationColor_Dark
	{
		get => (Color)GetValue(EliminationColor_DarkProperty);

		set => SetValue(EliminationColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the cannibalism color.
	/// </summary>
	public Color CannibalismColor
	{
		get => (Color)GetValue(CannibalismColorProperty);

		set => SetValue(CannibalismColorProperty, value);
	}

	/// <summary>
	/// Indicates the cannibalism color, in dark theme.
	/// </summary>
	public Color CannibalismColor_Dark
	{
		get => (Color)GetValue(CannibalismColor_DarkProperty);

		set => SetValue(CannibalismColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the exo-fin color.
	/// </summary>
	public Color ExofinColor
	{
		get => (Color)GetValue(ExofinColorProperty);

		set => SetValue(ExofinColorProperty, value);
	}

	/// <summary>
	/// Indicates the exo-fin color, in dark theme.
	/// </summary>
	public Color ExofinColor_Dark
	{
		get => (Color)GetValue(ExofinColor_DarkProperty);

		set => SetValue(ExofinColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates the endo-fin color.
	/// </summary>
	public Color EndofinColor
	{
		get => (Color)GetValue(EndofinColorProperty);

		set => SetValue(EndofinColorProperty, value);
	}

	/// <summary>
	/// Indicates the endo-fin color, in dark theme.
	/// </summary>
	public Color EndofinColor_Dark
	{
		get => (Color)GetValue(EndofinColor_DarkProperty);

		set => SetValue(EndofinColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates grouped node stroke color.
	/// </summary>
	public Color GroupedNodeStrokeColor
	{
		get => (Color)GetValue(GroupedNodeStrokeColorProperty);

		set => SetValue(GroupedNodeStrokeColorProperty, value);
	}

	/// <summary>
	/// Indicates grouped node stroke color, in dark theme.
	/// </summary>
	public Color GroupedNodeStrokeColor_Dark
	{
		get => (Color)GetValue(GroupedNodeStrokeColor_DarkProperty);

		set => SetValue(GroupedNodeStrokeColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates grouped node background color.
	/// </summary>
	public Color GroupedNodeBackgroundColor
	{
		get => (Color)GetValue(GroupedNodeBackgroundColorProperty);

		set => SetValue(GroupedNodeBackgroundColorProperty, value);
	}

	/// <summary>
	/// Indicates grouped node background color, in dark theme.
	/// </summary>
	public Color GroupedNodeBackgroundColor_Dark
	{
		get => (Color)GetValue(GroupedNodeBackgroundColor_DarkProperty);

		set => SetValue(GroupedNodeBackgroundColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates house completed feedback color.
	/// </summary>
	public Color HouseCompletedFeedbackColor
	{
		get => (Color)GetValue(HouseCompletedFeedbackColorProperty);

		set => SetValue(HouseCompletedFeedbackColorProperty, value);
	}

	/// <summary>
	/// Indicates house completed feedback color, in dark theme.
	/// </summary>
	public Color HouseCompletedFeedbackColor_Dark
	{
		get => (Color)GetValue(HouseCompletedFeedbackColor_DarkProperty);

		set => SetValue(HouseCompletedFeedbackColor_DarkProperty, value);
	}

	/// <summary>
	/// Indicates active cell color.
	/// </summary>
	public Color ActiveCellColor
	{
		get => (Color)GetValue(ActiveCellColorProperty);

		set => SetValue(ActiveCellColorProperty, value);
	}

	/// <summary>
	/// Indicates active cell color, in dark theme.
	/// </summary>
	public Color ActiveCellColor_Dark
	{
		get => (Color)GetValue(ActiveCellColor_DarkProperty);

		set => SetValue(ActiveCellColor_DarkProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.StrongLinkDashStyle"/>
	public DashArray StrongLinkDashStyle
	{
		get => (DashArray)GetValue(StrongLinkDashStyleProperty);

		set => SetValue(StrongLinkDashStyleProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.WeakLinkDashStyle"/>
	public DashArray WeakLinkDashStyle
	{
		get => (DashArray)GetValue(WeakLinkDashStyleProperty);

		set => SetValue(WeakLinkDashStyleProperty, value);
	}

	/// <summary>
	/// Indicates the last opened puzzle to be loaded or saved.
	/// </summary>
	public Grid LastGridPuzzle
	{
		get => (Grid)GetValue(LastGridPuzzleProperty);

		set => SetValue(LastGridPuzzleProperty, value);
	}

	/// <summary>
	/// Indicates the drawable items produced by last opened puzzle.
	/// </summary>
	public UserDefinedDrawable? LastRenderable
	{
		get => (UserDefinedDrawable?)GetValue(LastRenderableProperty);

		set => SetValue(LastRenderableProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.AuxiliaryColors"/>
	public ColorPalette AuxiliaryColors
	{
		get => (ColorPalette)GetValue(AuxiliaryColorsProperty);

		set => SetValue(AuxiliaryColorsProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.AuxiliaryColors"/>
	public ColorPalette AuxiliaryColors_Dark
	{
		get => (ColorPalette)GetValue(AuxiliaryColors_DarkProperty);

		set => SetValue(AuxiliaryColors_DarkProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.DifficultyLevelForegrounds"/>
	public ColorPalette DifficultyLevelForegrounds
	{
		get => (ColorPalette)GetValue(DifficultyLevelForegroundsProperty);

		set => SetValue(DifficultyLevelForegroundsProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.DifficultyLevelForegrounds"/>
	public ColorPalette DifficultyLevelForegrounds_Dark
	{
		get => (ColorPalette)GetValue(DifficultyLevelForegrounds_DarkProperty);

		set => SetValue(DifficultyLevelForegrounds_DarkProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.DifficultyLevelBackgrounds"/>
	public ColorPalette DifficultyLevelBackgrounds
	{
		get => (ColorPalette)GetValue(DifficultyLevelBackgroundsProperty);

		set => SetValue(DifficultyLevelBackgroundsProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.DifficultyLevelBackgrounds"/>
	public ColorPalette DifficultyLevelBackgrounds_Dark
	{
		get => (ColorPalette)GetValue(DifficultyLevelBackgrounds_DarkProperty);

		set => SetValue(DifficultyLevelBackgrounds_DarkProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.UserDefinedColorPalette"/>
	public ColorPalette UserDefinedColorPalette
	{
		get => (ColorPalette)GetValue(UserDefinedColorPaletteProperty);

		set => SetValue(UserDefinedColorPaletteProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.UserDefinedColorPalette"/>
	public ColorPalette UserDefinedColorPalette_Dark
	{
		get => (ColorPalette)GetValue(UserDefinedColorPalette_DarkProperty);

		set => SetValue(UserDefinedColorPalette_DarkProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.AlmostLockedSetsColors"/>
	public ColorPalette AlmostLockedSetsColors
	{
		get => (ColorPalette)GetValue(AlmostLockedSetsColorsProperty);

		set => SetValue(AlmostLockedSetsColorsProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.AlmostLockedSetsColors"/>
	public ColorPalette AlmostLockedSetsColors_Dark
	{
		get => (ColorPalette)GetValue(AlmostLockedSetsColors_DarkProperty);

		set => SetValue(AlmostLockedSetsColors_DarkProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.RectangleColors"/>
	public ColorPalette RectangleColors
	{
		get => (ColorPalette)GetValue(RectangleColorsProperty);

		set => SetValue(RectangleColorsProperty, value);
	}

	/// <inheritdoc cref="SudokuPane.RectangleColors"/>
	public ColorPalette RectangleColors_Dark
	{
		get => (ColorPalette)GetValue(RectangleColors_DarkProperty);

		set => SetValue(RectangleColors_DarkProperty, value);
	}


	private static void BackdropPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
#if CUSTOMIZED_BACKDROP
		if (e.NewValue is not BackdropKind value/* || !Enum.IsDefined(value)*/)
		{
			return;
		}

		foreach (var window in Application.CurrentApp.WindowManager.ActiveWindows.OfType<IBackdropSupportedWindow>())
		{
			WindowComposition.SetBackdrop(window, value);
		}
#endif
	}
}
