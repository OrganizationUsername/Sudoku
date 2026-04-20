namespace SudokuStudio.Views.Controls;

/// <summary>
/// Defines a sudoku pane control.
/// </summary>
public sealed partial class SudokuPane : UserControl, INotifyPropertyChanged
{
	private static readonly decimal HighlightCandidateCircleScaleDefaultValue = .9M;

	private static readonly decimal HighlightBackgroundOpacityDefaultValue = .15M;

	private static readonly decimal ChainStrokeThicknessDefaultValue = 2.0M;

	private static readonly decimal GivenFontScaleDefaultValue = 1.0M;

	private static readonly decimal ModifiableFontScaleDefaultValue = 1.0M;

	private static readonly decimal PencilmarkFontScaleDefaultValue = .33M;

	private static readonly decimal BabaGroupLabelFontScaleDefaultValue = .6M;

	private static readonly decimal CoordinateLabelFontScaleDefaultValue = .4M;

	private static readonly Color GivenColorDefaultValue = Colors.Black;

	private static readonly Color DeltaCandidateColorDefaultValue = Color.FromArgb(255, 255, 185, 185);

	private static readonly Color BorderColorDefaultValue = Colors.Black;

	private static readonly Color CursorBackgroundColorDefaultValue = Colors.Blue with { A = 32 };

	private static readonly Color LinkColorDefaultValue = Colors.Red;

	private static readonly Color NormalColorDefaultValue = Color.FromArgb(255, 63, 218, 101);

	private static readonly Color AssignmentColorDefaultValue = Color.FromArgb(255, 63, 218, 101);

	private static readonly Color OverlappedAssignmentColorDefaultValue = Color.FromArgb(255, 0, 255, 204);

	private static readonly Color EliminationColorDefaultValue = Color.FromArgb(255, 255, 118, 132);

	private static readonly Color CannibalismColorDefaultValue = new() { A = 255, R = 235 };

	private static readonly Color ExofinColorDefaultValue = Color.FromArgb(255, 127, 187, 255);

	private static readonly Color EndofinColorDefaultValue = Color.FromArgb(255, 216, 178, 255);

	private static readonly Color GroupedNodeStrokeColorDefaultValue = Colors.Yellow with { A = 64 };

	private static readonly Color GroupedNodeBackgroundColorDefaultValue = Colors.Orange;

	private static readonly Color HouseCompletedFeedbackColorDefaultValue = Colors.HotPink;

	private static readonly Color CellTruthColorDefaultValue = Color.FromArgb(255, 64, 128, 192);

	private static readonly Color RowTruthColorDefaultValue = Color.FromArgb(255, 187, 62, 125);

	private static readonly Color ColumnTruthColorDefaultValue = Color.FromArgb(255, 46, 138, 92);

	private static readonly Color BlockTruthColorDefaultValue = Color.FromArgb(255, 172, 126, 113);

	private static readonly Color LineOrCellLinkColorDefaultValue = Color.FromArgb(86, 128, 128, 128);

	private static readonly Color BlockLinkColorDefaultValue = Color.FromArgb(86, 172, 126, 113);

	private static readonly Color RankSetBoundCandidatesColorDefaultValue = Color.FromArgb(255, 129, 192, 255);

	private static readonly DashArray StrongLinkDashStyleDefaultValue = [];

	private static readonly DashArray WeakLinkDashStyleDefaultValue = [3, 1.5];

	private static readonly Thickness CellsInnerPaddingDefaultValue = new(6);

	private static readonly CornerRadius CellsInnerCornerRadiusDefaultValue = new(6);

	private static readonly FontFamily GivenFontDefaultValue = new("Tahoma");

	private static readonly FontFamily ModifiableFontDefaultValue = new("Tahoma");

	private static readonly FontFamily PencilmarkFontDefaultValue = new("Tahoma");

	private static readonly FontFamily CoordinateLabelFontDefaultValue = new("Tahoma");

	private static readonly FontFamily BabaGroupLabelFontDefaultValue = new("Times New Roman");

	private static readonly ColorPalette AuxiliaryColorsDefaultValue = [
		Color.FromArgb(255, 255, 192, 89),
		Color.FromArgb(255, 127, 187, 255),
		Color.FromArgb(255, 216, 178, 255)
	];

	private static readonly ColorPalette DifficultyLevelForegroundsDefaultValue = [
		Color.FromArgb(255, 0, 51, 204),
		Color.FromArgb(255, 0, 102, 0),
		Color.FromArgb(255, 102, 51, 0),
		Color.FromArgb(255, 102, 51, 0),
		Color.FromArgb(255, 102, 0, 0),
		Colors.Black
	];

	private static readonly ColorPalette DifficultyLevelBackgroundsDefaultValue = [
		Color.FromArgb(255, 204, 204, 255),
		Color.FromArgb(255, 100, 255, 100),
		Color.FromArgb(255, 255, 255, 100),
		Color.FromArgb(255, 255, 150, 80),
		Color.FromArgb(255, 255, 100, 100),
		Color.FromArgb(255, 220, 220, 220)
	];

	private static readonly ColorPalette UserDefinedColorPaletteDefaultValue = [
		Color.FromArgb(255, 63, 218, 101), // Green
		Color.FromArgb(255, 255, 192, 89), // Orange
		Color.FromArgb(255, 127, 187, 255), // Sky-blue
		Color.FromArgb(255, 216, 178, 255), // Purple
		Color.FromArgb(255, 197, 232, 140), // Yellow-green
		Color.FromArgb(255, 255, 203, 203), // Light red
		Color.FromArgb(255, 178, 223, 223), // Blue green
		Color.FromArgb(255, 252, 220, 165), // Light orange
		Color.FromArgb(255, 255, 255, 150), // Yellow
		Color.FromArgb(255, 247, 222, 143), // Golden yellow
		Color.FromArgb(255, 220, 212, 252), // Purple
		Color.FromArgb(255, 255, 118, 132), // Red
		Color.FromArgb(255, 206, 251, 237), // Light sky-blue
		Color.FromArgb(255, 215, 255, 215), // Light green
		Color.FromArgb(255, 192, 192, 192) // Gray
	];

	private static readonly ColorPalette AlmostLockedSetsColorsDefaultValue = [
		Color.FromArgb(255, 255, 203, 203),
		Color.FromArgb(255, 178, 223, 223),
		Color.FromArgb(255, 252, 220, 165),
		Color.FromArgb(255, 255, 255, 150),
		Color.FromArgb(255, 247, 222, 143)
	];

	private static readonly ColorPalette RectangleColorsDefaultValue = [
		Color.FromArgb(255, 216, 178, 255), // Purple
		Color.FromArgb(255, 204, 150, 248), // Purple
		Color.FromArgb(255, 114, 82, 170), // Dark purple
	];

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisplayCandidates"/>.
	/// </summary>
	/// <seealso cref="DisplayCandidates"/>
	public static readonly DependencyProperty DisplayCandidatesProperty =
		DependencyProperty.Register(nameof(DisplayCandidates), typeof(bool), typeof(SudokuPane), new PropertyMetadata((bool)true, DisplayCandidatesPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisplayCursors"/>.
	/// </summary>
	/// <seealso cref="DisplayCursors"/>
	public static readonly DependencyProperty DisplayCursorsProperty =
		DependencyProperty.Register(nameof(DisplayCursors), typeof(bool), typeof(SudokuPane), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="UseDifferentColorToDisplayDeltaDigits"/>.
	/// </summary>
	/// <seealso cref="UseDifferentColorToDisplayDeltaDigits"/>
	public static readonly DependencyProperty UseDifferentColorToDisplayDeltaDigitsProperty =
		DependencyProperty.Register(nameof(UseDifferentColorToDisplayDeltaDigits), typeof(bool), typeof(SudokuPane), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DisableFlyout"/>.
	/// </summary>
	/// <seealso cref="DisableFlyout"/>
	public static readonly DependencyProperty DisableFlyoutProperty =
		DependencyProperty.Register(nameof(DisableFlyout), typeof(bool), typeof(SudokuPane), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PreventConflictingInput"/>.
	/// </summary>
	/// <seealso cref="PreventConflictingInput"/>
	public static readonly DependencyProperty PreventConflictingInputProperty =
		DependencyProperty.Register(nameof(PreventConflictingInput), typeof(bool), typeof(SudokuPane), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableUndoRedoStacking"/>.
	/// </summary>
	/// <seealso cref="EnableUndoRedoStacking"/>
	public static readonly DependencyProperty EnableUndoRedoStackingProperty =
		DependencyProperty.Register(nameof(EnableUndoRedoStacking), typeof(bool), typeof(SudokuPane), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableDoubleTapFilling"/>.
	/// </summary>
	/// <seealso cref="EnableDoubleTapFilling"/>
	public static readonly DependencyProperty EnableDoubleTapFillingProperty =
		DependencyProperty.Register(nameof(EnableDoubleTapFilling), typeof(bool), typeof(SudokuPane), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableRightTapRemoving"/>.
	/// </summary>
	/// <seealso cref="EnableRightTapRemoving"/>
	public static readonly DependencyProperty EnableRightTapRemovingProperty =
		DependencyProperty.Register(nameof(EnableRightTapRemoving), typeof(bool), typeof(SudokuPane), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EnableAnimationFeedback"/>.
	/// </summary>
	/// <seealso cref="EnableAnimationFeedback"/>
	public static readonly DependencyProperty EnableAnimationFeedbackProperty =
		DependencyProperty.Register(nameof(EnableAnimationFeedback), typeof(bool), typeof(SudokuPane), new PropertyMetadata((bool)true));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="TransparentBackground"/>.
	/// </summary>
	/// <seealso cref="TransparentBackground"/>
	public static readonly DependencyProperty TransparentBackgroundProperty =
		DependencyProperty.Register(nameof(TransparentBackground), typeof(bool), typeof(SudokuPane), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HighlightCandidateCircleScale"/>.
	/// </summary>
	/// <seealso cref="HighlightCandidateCircleScale"/>
	public static readonly DependencyProperty HighlightCandidateCircleScaleProperty =
		DependencyProperty.Register(nameof(HighlightCandidateCircleScale), typeof(decimal), typeof(SudokuPane), new PropertyMetadata(HighlightCandidateCircleScaleDefaultValue, HighlightCandidateCircleScalePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HighlightBackgroundOpacity"/>.
	/// </summary>
	/// <seealso cref="HighlightBackgroundOpacity"/>
	public static readonly DependencyProperty HighlightBackgroundOpacityProperty =
		DependencyProperty.Register(nameof(HighlightBackgroundOpacity), typeof(decimal), typeof(SudokuPane), new PropertyMetadata(HighlightBackgroundOpacityDefaultValue, HighlightBackgroundOpacityPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ChainStrokeThickness"/>.
	/// </summary>
	/// <seealso cref="ChainStrokeThickness"/>
	public static readonly DependencyProperty ChainStrokeThicknessProperty =
		DependencyProperty.Register(nameof(ChainStrokeThickness), typeof(decimal), typeof(SudokuPane), new PropertyMetadata(ChainStrokeThicknessDefaultValue, ChainStrokeThicknessPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GivenFontScale"/>.
	/// </summary>
	/// <seealso cref="GivenFontScale"/>
	public static readonly DependencyProperty GivenFontScaleProperty =
		DependencyProperty.Register(nameof(GivenFontScale), typeof(decimal), typeof(SudokuPane), new PropertyMetadata(GivenFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ModifiableFontScale"/>.
	/// </summary>
	/// <seealso cref="ModifiableFontScale"/>
	public static readonly DependencyProperty ModifiableFontScaleProperty =
		DependencyProperty.Register(nameof(ModifiableFontScale), typeof(decimal), typeof(SudokuPane), new PropertyMetadata(ModifiableFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PencilmarkFontScale"/>.
	/// </summary>
	/// <seealso cref="PencilmarkFontScale"/>
	public static readonly DependencyProperty PencilmarkFontScaleProperty =
		DependencyProperty.Register(nameof(PencilmarkFontScale), typeof(decimal), typeof(SudokuPane), new PropertyMetadata(PencilmarkFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BabaGroupLabelFontScale"/>.
	/// </summary>
	/// <seealso cref="BabaGroupLabelFontScale"/>
	public static readonly DependencyProperty BabaGroupLabelFontScaleProperty =
		DependencyProperty.Register(nameof(BabaGroupLabelFontScale), typeof(decimal), typeof(SudokuPane), new PropertyMetadata(BabaGroupLabelFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelFontScale"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelFontScale"/>
	public static readonly DependencyProperty CoordinateLabelFontScaleProperty =
		DependencyProperty.Register(nameof(CoordinateLabelFontScale), typeof(decimal), typeof(SudokuPane), new PropertyMetadata(CoordinateLabelFontScaleDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HouseCompletedFeedbackDuration"/>.
	/// </summary>
	/// <seealso cref="HouseCompletedFeedbackDuration"/>
	public static readonly DependencyProperty HouseCompletedFeedbackDurationProperty =
		DependencyProperty.Register(nameof(HouseCompletedFeedbackDuration), typeof(int), typeof(SudokuPane), new PropertyMetadata((int)800, HouseCompletedFeedbackDurationPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelDisplayKind"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelDisplayKind"/>
	public static readonly DependencyProperty CoordinateLabelDisplayKindProperty =
		DependencyProperty.Register(nameof(CoordinateLabelDisplayKind), typeof(CoordinateType), typeof(SudokuPane), new PropertyMetadata((CoordinateType)1, CoordinateLabelDisplayKindPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelDisplayMode"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelDisplayMode"/>
	public static readonly DependencyProperty CoordinateLabelDisplayModeProperty =
		DependencyProperty.Register(nameof(CoordinateLabelDisplayMode), typeof(CoordinateLabelDisplay), typeof(SudokuPane), new PropertyMetadata((CoordinateLabelDisplay)1));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CandidateViewNodeDisplayMode"/>.
	/// </summary>
	/// <seealso cref="CandidateViewNodeDisplayMode"/>
	public static readonly DependencyProperty CandidateViewNodeDisplayModeProperty =
		DependencyProperty.Register(nameof(CandidateViewNodeDisplayMode), typeof(CandidateViewNodeDisplay), typeof(SudokuPane), new PropertyMetadata((CandidateViewNodeDisplay)0, CandidateViewNodeDisplayModePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AssignmentDisplayMode"/>.
	/// </summary>
	/// <seealso cref="AssignmentDisplayMode"/>
	public static readonly DependencyProperty AssignmentDisplayModeProperty =
		DependencyProperty.Register(nameof(AssignmentDisplayMode), typeof(AssignmentDisplay), typeof(SudokuPane), new PropertyMetadata((AssignmentDisplay)0, AssignmentDisplayModePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EliminationDisplayMode"/>.
	/// </summary>
	/// <seealso cref="EliminationDisplayMode"/>
	public static readonly DependencyProperty EliminationDisplayModeProperty =
		DependencyProperty.Register(nameof(EliminationDisplayMode), typeof(EliminationDisplay), typeof(SudokuPane), new PropertyMetadata((EliminationDisplay)0, EliminationDisplayModePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CandidateRotating"/>.
	/// </summary>
	/// <seealso cref="CandidateRotating"/>
	public static readonly DependencyProperty CandidateRotatingProperty =
		DependencyProperty.Register(nameof(CandidateRotating), typeof(GridCandidateRotating), typeof(SudokuPane), new PropertyMetadata((GridCandidateRotating)0, CandidateRotatingPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SelectedCell"/>.
	/// </summary>
	/// <seealso cref="SelectedCell"/>
	public static readonly DependencyProperty SelectedCellProperty =
		DependencyProperty.Register(nameof(SelectedCell), typeof(int), typeof(SudokuPane), new PropertyMetadata(default(int)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CellsInnerCornerRadius"/>.
	/// </summary>
	/// <seealso cref="CellsInnerCornerRadius"/>
	public static readonly DependencyProperty CellsInnerCornerRadiusProperty =
		DependencyProperty.Register(nameof(CellsInnerCornerRadius), typeof(CornerRadius), typeof(SudokuPane), new PropertyMetadata(CellsInnerCornerRadiusDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GivenColor"/>.
	/// </summary>
	/// <seealso cref="GivenColor"/>
	public static readonly DependencyProperty GivenColorProperty =
		DependencyProperty.Register(nameof(GivenColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(GivenColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ModifiableColor"/>.
	/// </summary>
	/// <seealso cref="ModifiableColor"/>
	public static readonly DependencyProperty ModifiableColorProperty =
		DependencyProperty.Register(nameof(ModifiableColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(default(Color)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PencilmarkColor"/>.
	/// </summary>
	/// <seealso cref="PencilmarkColor"/>
	public static readonly DependencyProperty PencilmarkColorProperty =
		DependencyProperty.Register(nameof(PencilmarkColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(default(Color)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelColor"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelColor"/>
	public static readonly DependencyProperty CoordinateLabelColorProperty =
		DependencyProperty.Register(nameof(CoordinateLabelColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(default(Color)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BabaGroupLabelColor"/>.
	/// </summary>
	/// <seealso cref="BabaGroupLabelColor"/>
	public static readonly DependencyProperty BabaGroupLabelColorProperty =
		DependencyProperty.Register(nameof(BabaGroupLabelColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(default(Color), BabaGroupLabelColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DeltaCandidateColor"/>.
	/// </summary>
	/// <seealso cref="DeltaCandidateColor"/>
	public static readonly DependencyProperty DeltaCandidateColorProperty =
		DependencyProperty.Register(nameof(DeltaCandidateColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(DeltaCandidateColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DeltaCellColor"/>.
	/// </summary>
	/// <seealso cref="DeltaCellColor"/>
	public static readonly DependencyProperty DeltaCellColorProperty =
		DependencyProperty.Register(nameof(DeltaCellColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(default(Color)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BorderColor"/>.
	/// </summary>
	/// <seealso cref="BorderColor"/>
	public static readonly DependencyProperty BorderColorProperty =
		DependencyProperty.Register(nameof(BorderColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(BorderColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CursorBackgroundColor"/>.
	/// </summary>
	/// <seealso cref="CursorBackgroundColor"/>
	public static readonly DependencyProperty CursorBackgroundColorProperty =
		DependencyProperty.Register(nameof(CursorBackgroundColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(CursorBackgroundColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LinkColor"/>.
	/// </summary>
	/// <seealso cref="LinkColor"/>
	public static readonly DependencyProperty LinkColorProperty =
		DependencyProperty.Register(nameof(LinkColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(LinkColorDefaultValue, LinkColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="NormalColor"/>.
	/// </summary>
	/// <seealso cref="NormalColor"/>
	public static readonly DependencyProperty NormalColorProperty =
		DependencyProperty.Register(nameof(NormalColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(NormalColorDefaultValue, NormalColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AssignmentColor"/>.
	/// </summary>
	/// <seealso cref="AssignmentColor"/>
	public static readonly DependencyProperty AssignmentColorProperty =
		DependencyProperty.Register(nameof(AssignmentColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(AssignmentColorDefaultValue, AssignmentColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="OverlappedAssignmentColor"/>.
	/// </summary>
	/// <seealso cref="OverlappedAssignmentColor"/>
	public static readonly DependencyProperty OverlappedAssignmentColorProperty =
		DependencyProperty.Register(nameof(OverlappedAssignmentColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(OverlappedAssignmentColorDefaultValue, OverlappedAssignmentColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EliminationColor"/>.
	/// </summary>
	/// <seealso cref="EliminationColor"/>
	public static readonly DependencyProperty EliminationColorProperty =
		DependencyProperty.Register(nameof(EliminationColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(EliminationColorDefaultValue, EliminationColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CannibalismColor"/>.
	/// </summary>
	/// <seealso cref="CannibalismColor"/>
	public static readonly DependencyProperty CannibalismColorProperty =
		DependencyProperty.Register(nameof(CannibalismColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(CannibalismColorDefaultValue, CannibalismColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ExofinColor"/>.
	/// </summary>
	/// <seealso cref="ExofinColor"/>
	public static readonly DependencyProperty ExofinColorProperty =
		DependencyProperty.Register(nameof(ExofinColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(ExofinColorDefaultValue, ExofinColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="EndofinColor"/>.
	/// </summary>
	/// <seealso cref="EndofinColor"/>
	public static readonly DependencyProperty EndofinColorProperty =
		DependencyProperty.Register(nameof(EndofinColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(EndofinColorDefaultValue, EndofinColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GroupedNodeStrokeColor"/>.
	/// </summary>
	/// <seealso cref="GroupedNodeStrokeColor"/>
	public static readonly DependencyProperty GroupedNodeStrokeColorProperty =
		DependencyProperty.Register(nameof(GroupedNodeStrokeColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(GroupedNodeStrokeColorDefaultValue, GroupedNodeStrokeColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GroupedNodeBackgroundColor"/>.
	/// </summary>
	/// <seealso cref="GroupedNodeBackgroundColor"/>
	public static readonly DependencyProperty GroupedNodeBackgroundColorProperty =
		DependencyProperty.Register(nameof(GroupedNodeBackgroundColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(GroupedNodeBackgroundColorDefaultValue, GroupedNodeBackgroundColorPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HouseCompletedFeedbackColor"/>.
	/// </summary>
	/// <seealso cref="HouseCompletedFeedbackColor"/>
	public static readonly DependencyProperty HouseCompletedFeedbackColorProperty =
		DependencyProperty.Register(nameof(HouseCompletedFeedbackColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(HouseCompletedFeedbackColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CellTruthColor"/>.
	/// </summary>
	/// <seealso cref="CellTruthColor"/>
	public static readonly DependencyProperty CellTruthColorProperty =
		DependencyProperty.Register(nameof(CellTruthColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(CellTruthColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="RowTruthColor"/>.
	/// </summary>
	/// <seealso cref="RowTruthColor"/>
	public static readonly DependencyProperty RowTruthColorProperty =
		DependencyProperty.Register(nameof(RowTruthColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(RowTruthColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ColumnTruthColor"/>.
	/// </summary>
	/// <seealso cref="ColumnTruthColor"/>
	public static readonly DependencyProperty ColumnTruthColorProperty =
		DependencyProperty.Register(nameof(ColumnTruthColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(ColumnTruthColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BlockTruthColor"/>.
	/// </summary>
	/// <seealso cref="BlockTruthColor"/>
	public static readonly DependencyProperty BlockTruthColorProperty =
		DependencyProperty.Register(nameof(BlockTruthColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(BlockTruthColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LineOrCellLinkColor"/>.
	/// </summary>
	/// <seealso cref="LineOrCellLinkColor"/>
	public static readonly DependencyProperty LineOrCellLinkColorProperty =
		DependencyProperty.Register(nameof(LineOrCellLinkColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(LineOrCellLinkColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BlockLinkColor"/>.
	/// </summary>
	/// <seealso cref="BlockLinkColor"/>
	public static readonly DependencyProperty BlockLinkColorProperty =
		DependencyProperty.Register(nameof(BlockLinkColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(BlockLinkColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="RankSetBoundCandidatesColor"/>.
	/// </summary>
	/// <seealso cref="RankSetBoundCandidatesColor"/>
	public static readonly DependencyProperty RankSetBoundCandidatesColorProperty =
		DependencyProperty.Register(nameof(RankSetBoundCandidatesColor), typeof(Color), typeof(SudokuPane), new PropertyMetadata(RankSetBoundCandidatesColorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="StrongLinkDashStyle"/>.
	/// </summary>
	/// <seealso cref="StrongLinkDashStyle"/>
	public static readonly DependencyProperty StrongLinkDashStyleProperty =
		DependencyProperty.Register(nameof(StrongLinkDashStyle), typeof(DashArray), typeof(SudokuPane), new PropertyMetadata(StrongLinkDashStyleDefaultValue, StrongLinkDashStylePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="WeakLinkDashStyle"/>.
	/// </summary>
	/// <seealso cref="WeakLinkDashStyle"/>
	public static readonly DependencyProperty WeakLinkDashStyleProperty =
		DependencyProperty.Register(nameof(WeakLinkDashStyle), typeof(DashArray), typeof(SudokuPane), new PropertyMetadata(WeakLinkDashStyleDefaultValue, WeakLinkDashStylePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CellsInnerPadding"/>.
	/// </summary>
	/// <seealso cref="CellsInnerPadding"/>
	public static readonly DependencyProperty CellsInnerPaddingProperty =
		DependencyProperty.Register(nameof(CellsInnerPadding), typeof(Thickness), typeof(SudokuPane), new PropertyMetadata(CellsInnerPaddingDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="GivenFont"/>.
	/// </summary>
	/// <seealso cref="GivenFont"/>
	public static readonly DependencyProperty GivenFontProperty =
		DependencyProperty.Register(nameof(GivenFont), typeof(FontFamily), typeof(SudokuPane), new PropertyMetadata(GivenFontDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ModifiableFont"/>.
	/// </summary>
	/// <seealso cref="ModifiableFont"/>
	public static readonly DependencyProperty ModifiableFontProperty =
		DependencyProperty.Register(nameof(ModifiableFont), typeof(FontFamily), typeof(SudokuPane), new PropertyMetadata(ModifiableFontDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="PencilmarkFont"/>.
	/// </summary>
	/// <seealso cref="PencilmarkFont"/>
	public static readonly DependencyProperty PencilmarkFontProperty =
		DependencyProperty.Register(nameof(PencilmarkFont), typeof(FontFamily), typeof(SudokuPane), new PropertyMetadata(PencilmarkFontDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="CoordinateLabelFont"/>.
	/// </summary>
	/// <seealso cref="CoordinateLabelFont"/>
	public static readonly DependencyProperty CoordinateLabelFontProperty =
		DependencyProperty.Register(nameof(CoordinateLabelFont), typeof(FontFamily), typeof(SudokuPane), new PropertyMetadata(CoordinateLabelFontDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BabaGroupLabelFont"/>.
	/// </summary>
	/// <seealso cref="BabaGroupLabelFont"/>
	public static readonly DependencyProperty BabaGroupLabelFontProperty =
		DependencyProperty.Register(nameof(BabaGroupLabelFont), typeof(FontFamily), typeof(SudokuPane), new PropertyMetadata(BabaGroupLabelFontDefaultValue, BabaGroupLabelFontPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ViewUnit"/>.
	/// </summary>
	/// <seealso cref="ViewUnit"/>
	public static readonly DependencyProperty ViewUnitProperty =
		DependencyProperty.Register(nameof(ViewUnit), typeof(ViewUnitBindableSource), typeof(SudokuPane), new PropertyMetadata(default(ViewUnitBindableSource), ViewUnitPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AuxiliaryColors"/>.
	/// </summary>
	/// <seealso cref="AuxiliaryColors"/>
	public static readonly DependencyProperty AuxiliaryColorsProperty =
		DependencyProperty.Register(nameof(AuxiliaryColors), typeof(ColorPalette), typeof(SudokuPane), new PropertyMetadata(AuxiliaryColorsDefaultValue, AuxiliaryColorsPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DifficultyLevelForegrounds"/>.
	/// </summary>
	/// <seealso cref="DifficultyLevelForegrounds"/>
	public static readonly DependencyProperty DifficultyLevelForegroundsProperty =
		DependencyProperty.Register(nameof(DifficultyLevelForegrounds), typeof(ColorPalette), typeof(SudokuPane), new PropertyMetadata(DifficultyLevelForegroundsDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DifficultyLevelBackgrounds"/>.
	/// </summary>
	/// <seealso cref="DifficultyLevelBackgrounds"/>
	public static readonly DependencyProperty DifficultyLevelBackgroundsProperty =
		DependencyProperty.Register(nameof(DifficultyLevelBackgrounds), typeof(ColorPalette), typeof(SudokuPane), new PropertyMetadata(DifficultyLevelBackgroundsDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="UserDefinedColorPalette"/>.
	/// </summary>
	/// <seealso cref="UserDefinedColorPalette"/>
	public static readonly DependencyProperty UserDefinedColorPaletteProperty =
		DependencyProperty.Register(nameof(UserDefinedColorPalette), typeof(ColorPalette), typeof(SudokuPane), new PropertyMetadata(UserDefinedColorPaletteDefaultValue, UserDefinedColorPalettePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="AlmostLockedSetsColors"/>.
	/// </summary>
	/// <seealso cref="AlmostLockedSetsColors"/>
	public static readonly DependencyProperty AlmostLockedSetsColorsProperty =
		DependencyProperty.Register(nameof(AlmostLockedSetsColors), typeof(ColorPalette), typeof(SudokuPane), new PropertyMetadata(AlmostLockedSetsColorsDefaultValue, AlmostLockedSetsColorsPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="RectangleColors"/>.
	/// </summary>
	/// <seealso cref="RectangleColors"/>
	public static readonly DependencyProperty RectangleColorsProperty =
		DependencyProperty.Register(nameof(RectangleColors), typeof(ColorPalette), typeof(SudokuPane), new PropertyMetadata(RectangleColorsDefaultValue));


	/// <summary>
	/// Indicates the temporary selected cell.
	/// </summary>
	internal Cell _temporarySelectedCell = -1;

	/// <summary>
	/// Defines a pair of stacks that stores undo steps.
	/// This field can be used when <see cref="EnableUndoRedoStacking"/> is <see langword="true"/>.
	/// </summary>
	/// <seealso cref="EnableUndoRedoStacking"/>
	internal ObservableStack<Grid>? _undoStack;

	/// <summary>
	/// Defines a pair of stacks that stores redo steps.
	/// This field can be used when <see cref="EnableUndoRedoStacking"/> is <see langword="true"/>.
	/// </summary>
	/// <seealso cref="EnableUndoRedoStacking"/>
	internal ObservableStack<Grid>? _redoStack;

	/// <summary>
	/// The easy entry to visit children <see cref="SudokuPaneCell"/> instances. This field contains 81 elements,
	/// indicating controls being displayed as 81 cells in a sudoku grid respectively.
	/// </summary>
	/// <remarks>
	/// Although this field is not marked as <see langword="readonly"/>, it will only be initialized during initialization.
	/// <b>Please do not modify any elements in this array.</b>
	/// </remarks>
	internal SudokuPaneCell[] _children;

	/// <summary>
	/// The backing field of property <see cref="Puzzle"/>.
	/// </summary>
	private Grid _puzzle;


	/// <summary>
	/// Initializes a <see cref="SudokuPane"/> instance.
	/// </summary>
	public SudokuPane()
	{
		InitializeComponent();
		InitializeChildrenControls();

		_puzzle = Grid.Empty;

		UpdateCellData(_puzzle);
		InitializeEvents();
	}


	/// <summary>
	/// Indicates whether the pane displays for candidates.
	/// </summary>
	public bool DisplayCandidates
	{
		get => (bool)GetValue(DisplayCandidatesProperty);

		set => SetValue(DisplayCandidatesProperty, value);
	}

	/// <summary>
	/// Indicates whether the pane displays cursors that uses different colors to highlight some cells as peers
	/// of the target cell that is the one your mouse points to.
	/// </summary>
	public bool DisplayCursors
	{
		get => (bool)GetValue(DisplayCursorsProperty);

		set => SetValue(DisplayCursorsProperty, value);
	}

	/// <summary>
	/// Indicates whether the pane displays for delta Digits using different colors.
	/// </summary>
	public bool UseDifferentColorToDisplayDeltaDigits
	{
		get => (bool)GetValue(UseDifferentColorToDisplayDeltaDigitsProperty);

		set => SetValue(UseDifferentColorToDisplayDeltaDigitsProperty, value);
	}

	/// <summary>
	/// Indicates whether the pane disable flyout open.
	/// </summary>
	public bool DisableFlyout
	{
		get => (bool)GetValue(DisableFlyoutProperty);

		set => SetValue(DisableFlyoutProperty, value);
	}

	/// <summary>
	/// Indicates whether the pane prevent the simple conflict, which means,
	/// if you input a digit that is conflict with the Digits in its containing houses,
	/// this pane will do nothing by this value being <see langword="true"/>.
	/// If not, the pane won't check for any conflict and always allow you inputting the digit regardless of possible conflict.
	/// </summary>
	public bool PreventConflictingInput
	{
		get => (bool)GetValue(PreventConflictingInputProperty);

		set => SetValue(PreventConflictingInputProperty, value);
	}

	/// <summary>
	/// Indicates whether the pane enables for undoing and redoing operation.
	/// </summary>
	[MemberNotNullWhen(true, nameof(_redoStack), nameof(_undoStack))]
	public bool EnableUndoRedoStacking
	{
		get => (bool)GetValue(EnableUndoRedoStackingProperty);

		set => SetValue(EnableUndoRedoStackingProperty, value);
	}

	/// <summary>
	/// Indicates whether the digit will be automatically input by double tapping a candidate.
	/// </summary>
	public bool EnableDoubleTapFilling
	{
		get => (bool)GetValue(EnableDoubleTapFillingProperty);

		set => SetValue(EnableDoubleTapFillingProperty, value);
	}

	/// <summary>
	/// Indicates whether the digit will be removed (eliminated) from the containing cell by tapping a candidate using right mouse button.
	/// </summary>
	public bool EnableRightTapRemoving
	{
		get => (bool)GetValue(EnableRightTapRemovingProperty);

		set => SetValue(EnableRightTapRemovingProperty, value);
	}

	/// <summary>
	/// Indicates whether sudoku pane enables for animation feedback.
	/// </summary>
	public bool EnableAnimationFeedback
	{
		get => (bool)GetValue(EnableAnimationFeedbackProperty);

		set => SetValue(EnableAnimationFeedbackProperty, value);
	}

	/// <summary>
	/// Indicates whether sudoku pane does not use background color to display a sudoku puzzle.
	/// </summary>
	public bool TransparentBackground
	{
		get => (bool)GetValue(TransparentBackgroundProperty);

		set => SetValue(TransparentBackgroundProperty, value);
	}

	/// <summary>
	/// Indicates the scale of highlighted candidate circles. The value should generally be below 1.0.
	/// </summary>
	public decimal HighlightCandidateCircleScale
	{
		get => (decimal)GetValue(HighlightCandidateCircleScaleProperty);

		set => SetValue(HighlightCandidateCircleScaleProperty, value);
	}

	/// <summary>
	/// Indicates the opacity of the background highlighted elements. The value should generally be below 1.0.
	/// </summary>
	public decimal HighlightBackgroundOpacity
	{
		get => (decimal)GetValue(HighlightBackgroundOpacityProperty);

		set => SetValue(HighlightBackgroundOpacityProperty, value);
	}

	/// <summary>
	/// Indicates the chain stroke thickness.
	/// </summary>
	public decimal ChainStrokeThickness
	{
		get => (decimal)GetValue(ChainStrokeThicknessProperty);

		set => SetValue(ChainStrokeThicknessProperty, value);
	}

	/// <summary>
	/// Indicates the font scale of given Digits. The value should generally be below 1.0.
	/// </summary>
	public decimal GivenFontScale
	{
		get => (decimal)GetValue(GivenFontScaleProperty);

		set => SetValue(GivenFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the font scale of modifiable Digits. The value should generally be below 1.0.
	/// </summary>
	public decimal ModifiableFontScale
	{
		get => (decimal)GetValue(ModifiableFontScaleProperty);

		set => SetValue(ModifiableFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the font scale of pencilmark Digits (candidates). The value should generally be below 1.0.
	/// </summary>
	public decimal PencilmarkFontScale
	{
		get => (decimal)GetValue(PencilmarkFontScaleProperty);

		set => SetValue(PencilmarkFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the font scale of baba group characters. The value should generally be below 1.0.
	/// </summary>
	public decimal BabaGroupLabelFontScale
	{
		get => (decimal)GetValue(BabaGroupLabelFontScaleProperty);

		set => SetValue(BabaGroupLabelFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the coordinate label font scale. The value should generally be below 1.0.
	/// </summary>
	public decimal CoordinateLabelFontScale
	{
		get => (decimal)GetValue(CoordinateLabelFontScaleProperty);

		set => SetValue(CoordinateLabelFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the duration of feedback when a house is completed.
	/// </summary>
	public int HouseCompletedFeedbackDuration
	{
		get => (int)GetValue(HouseCompletedFeedbackDurationProperty);

		set => SetValue(HouseCompletedFeedbackDurationProperty, value);
	}

	/// <summary>
	/// Indicates the displaying kind of coordinate labels.
	/// </summary>
	public CoordinateType CoordinateLabelDisplayKind
	{
		get => (CoordinateType)GetValue(CoordinateLabelDisplayKindProperty);

		set => SetValue(CoordinateLabelDisplayKindProperty, value);
	}

	/// <summary>
	/// Indicates the displaying mode of coordinate labels.
	/// </summary>
	/// <remarks>
	/// For more information please visit <see cref="CoordinateLabelDisplay"/>.
	/// </remarks>
	/// <seealso cref="CoordinateLabelDisplay"/>
	public CoordinateLabelDisplay CoordinateLabelDisplayMode
	{
		get => (CoordinateLabelDisplay)GetValue(CoordinateLabelDisplayModeProperty);

		set => SetValue(CoordinateLabelDisplayModeProperty, value);
	}

	/// <summary>
	/// Indicates the displaying mode of candidate view nodes.
	/// </summary>
	public CandidateViewNodeDisplay CandidateViewNodeDisplayMode
	{
		get => (CandidateViewNodeDisplay)GetValue(CandidateViewNodeDisplayModeProperty);

		set => SetValue(CandidateViewNodeDisplayModeProperty, value);
	}

	/// <summary>
	/// Indicates the displaying mode of an assignment.
	/// </summary>
	public AssignmentDisplay AssignmentDisplayMode
	{
		get => (AssignmentDisplay)GetValue(AssignmentDisplayModeProperty);

		set => SetValue(AssignmentDisplayModeProperty, value);
	}

	/// <summary>
	/// Indicates the displaying mode of an elimination.
	/// </summary>
	public EliminationDisplay EliminationDisplayMode
	{
		get => (EliminationDisplay)GetValue(EliminationDisplayModeProperty);

		set => SetValue(EliminationDisplayModeProperty, value);
	}

	/// <summary>
	/// Indicates the rotating mode of candidates.
	/// </summary>
	public GridCandidateRotating CandidateRotating
	{
		get => (GridCandidateRotating)GetValue(CandidateRotatingProperty);

		set => SetValue(CandidateRotatingProperty, value);
	}

	/// <summary>
	/// Indicates the currently selected cell.
	/// </summary>
	public Cell SelectedCell
	{
		get => (Cell)GetValue(SelectedCellProperty);

		set => SetValue(SelectedCellProperty, value);
	}

	/// <summary>
	/// Indicates the core-operating sudoku puzzle.
	/// </summary>
	public Grid Puzzle
	{
		get => _puzzle;

		set
		{
			SetPuzzleInternal(value, PuzzleUpdatingMethod.Programmatic, true);
			GridUpdated?.Invoke(this, new(GridUpdatedBehavior.Replacing, value));
		}
	}

	/// <summary>
	/// Indicates the value that describes corner radius for displaying cell view nodes.
	/// </summary>
	public CornerRadius CellsInnerCornerRadius
	{
		get => (CornerRadius)GetValue(CellsInnerCornerRadiusProperty);

		set => SetValue(CellsInnerCornerRadiusProperty, value);
	}

	/// <summary>
	/// Indicates the given color.
	/// </summary>
	public Color GivenColor
	{
		get => (Color)GetValue(GivenColorProperty);

		set => SetValue(GivenColorProperty, value);
	}

	/// <summary>
	/// Indicates the modifiable color.
	/// </summary>
	public Color ModifiableColor
	{
		get => (Color)GetValue(ModifiableColorProperty);

		set => SetValue(ModifiableColorProperty, value);
	}

	/// <summary>
	/// Indicates the pencilmark color.
	/// </summary>
	public Color PencilmarkColor
	{
		get => (Color)GetValue(PencilmarkColorProperty);

		set => SetValue(PencilmarkColorProperty, value);
	}

	/// <summary>
	/// Indicates the coordinate label color.
	/// </summary>
	public Color CoordinateLabelColor
	{
		get => (Color)GetValue(CoordinateLabelColorProperty);

		set => SetValue(CoordinateLabelColorProperty, value);
	}

	/// <summary>
	/// Indicates the baba group label color.
	/// </summary>
	public Color BabaGroupLabelColor
	{
		get => (Color)GetValue(BabaGroupLabelColorProperty);

		set => SetValue(BabaGroupLabelColorProperty, value);
	}

	/// <summary>
	/// Indicates the color that is used for displaying candidates that are wrongly removed, but correct.
	/// </summary>
	public Color DeltaCandidateColor
	{
		get => (Color)GetValue(DeltaCandidateColorProperty);

		set => SetValue(DeltaCandidateColorProperty, value);
	}

	/// <summary>
	/// Indicates the color that is used for displaying cell Digits that are wrongly filled.
	/// </summary>
	public Color DeltaCellColor
	{
		get => (Color)GetValue(DeltaCellColorProperty);

		set => SetValue(DeltaCellColorProperty, value);
	}

	/// <summary>
	/// Indicates the border color.
	/// </summary>
	public Color BorderColor
	{
		get => (Color)GetValue(BorderColorProperty);

		set => SetValue(BorderColorProperty, value);
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
	/// Indicates the link color.
	/// </summary>
	public Color LinkColor
	{
		get => (Color)GetValue(LinkColorProperty);

		set => SetValue(LinkColorProperty, value);
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
	/// Indicates the assignment color.
	/// </summary>
	public Color AssignmentColor
	{
		get => (Color)GetValue(AssignmentColorProperty);

		set => SetValue(AssignmentColorProperty, value);
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
	/// Indicates the elimination color.
	/// </summary>
	public Color EliminationColor
	{
		get => (Color)GetValue(EliminationColorProperty);

		set => SetValue(EliminationColorProperty, value);
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
	/// Indicates the exofin color.
	/// </summary>
	public Color ExofinColor
	{
		get => (Color)GetValue(ExofinColorProperty);

		set => SetValue(ExofinColorProperty, value);
	}

	/// <summary>
	/// Indicates the endofin color.
	/// </summary>
	public Color EndofinColor
	{
		get => (Color)GetValue(EndofinColorProperty);

		set => SetValue(EndofinColorProperty, value);
	}

	/// <summary>
	/// Indicates the grouped node stroke color.
	/// </summary>
	public Color GroupedNodeStrokeColor
	{
		get => (Color)GetValue(GroupedNodeStrokeColorProperty);

		set => SetValue(GroupedNodeStrokeColorProperty, value);
	}

	/// <summary>
	/// Indicates the grouped node background color.
	/// </summary>
	public Color GroupedNodeBackgroundColor
	{
		get => (Color)GetValue(GroupedNodeBackgroundColorProperty);

		set => SetValue(GroupedNodeBackgroundColorProperty, value);
	}

	/// <summary>
	/// Indicates the feedback color when a house is completed.
	/// </summary>
	public Color HouseCompletedFeedbackColor
	{
		get => (Color)GetValue(HouseCompletedFeedbackColorProperty);

		set => SetValue(HouseCompletedFeedbackColorProperty, value);
	}

	/// <summary>
	/// Indicates the cell truth color.
	/// </summary>
	public Color CellTruthColor
	{
		get => (Color)GetValue(CellTruthColorProperty);

		set => SetValue(CellTruthColorProperty, value);
	}

	/// <summary>
	/// Indicates the row truth color.
	/// </summary>
	public Color RowTruthColor
	{
		get => (Color)GetValue(RowTruthColorProperty);

		set => SetValue(RowTruthColorProperty, value);
	}

	/// <summary>
	/// Indicates the column truth color.
	/// </summary>
	public Color ColumnTruthColor
	{
		get => (Color)GetValue(ColumnTruthColorProperty);

		set => SetValue(ColumnTruthColorProperty, value);
	}

	/// <summary>
	/// Indicates the block truth color.
	/// </summary>
	public Color BlockTruthColor
	{
		get => (Color)GetValue(BlockTruthColorProperty);

		set => SetValue(BlockTruthColorProperty, value);
	}

	/// <summary>
	/// Indicates the line or cell link color.
	/// </summary>
	public Color LineOrCellLinkColor
	{
		get => (Color)GetValue(LineOrCellLinkColorProperty);

		set => SetValue(LineOrCellLinkColorProperty, value);
	}

	/// <summary>
	/// Indicates the block link color.
	/// </summary>
	public Color BlockLinkColor
	{
		get => (Color)GetValue(BlockLinkColorProperty);

		set => SetValue(BlockLinkColorProperty, value);
	}

	/// <summary>
	/// Indicates the bound candidates color on rank sets.
	/// </summary>
	public Color RankSetBoundCandidatesColor
	{
		get => (Color)GetValue(RankSetBoundCandidatesColorProperty);

		set => SetValue(RankSetBoundCandidatesColorProperty, value);
	}

	/// <summary>
	/// Indicates the dash style of the strong links.
	/// </summary>
	public DashArray StrongLinkDashStyle
	{
		get => (DashArray)GetValue(StrongLinkDashStyleProperty);

		set => SetValue(StrongLinkDashStyleProperty, value);
	}

	/// <summary>
	/// Indicates the dash style of the weak links.
	/// </summary>
	public DashArray WeakLinkDashStyle
	{
		get => (DashArray)GetValue(WeakLinkDashStyleProperty);

		set => SetValue(WeakLinkDashStyleProperty, value);
	}

	/// <summary>
	/// Indicates the value that describes the padding value displaying cell view nodes.
	/// </summary>
	public Thickness CellsInnerPadding
	{
		get => (Thickness)GetValue(CellsInnerPaddingProperty);

		set => SetValue(CellsInnerPaddingProperty, value);
	}

	/// <summary>
	/// Indicates the given font.
	/// </summary>
	public FontFamily GivenFont
	{
		get => (FontFamily)GetValue(GivenFontProperty);

		set => SetValue(GivenFontProperty, value);
	}

	/// <summary>
	/// Indicates the modifiable font.
	/// </summary>
	public FontFamily ModifiableFont
	{
		get => (FontFamily)GetValue(ModifiableFontProperty);

		set => SetValue(ModifiableFontProperty, value);
	}

	/// <summary>
	/// Indicates the candidate font.
	/// </summary>
	public FontFamily PencilmarkFont
	{
		get => (FontFamily)GetValue(PencilmarkFontProperty);

		set => SetValue(PencilmarkFontProperty, value);
	}

	/// <summary>
	/// Indicates the coordinate label font.
	/// </summary>
	public FontFamily CoordinateLabelFont
	{
		get => (FontFamily)GetValue(CoordinateLabelFontProperty);

		set => SetValue(CoordinateLabelFontProperty, value);
	}

	/// <summary>
	/// Indicates the baba group label font.
	/// </summary>
	public FontFamily BabaGroupLabelFont
	{
		get => (FontFamily)GetValue(BabaGroupLabelFontProperty);

		set => SetValue(BabaGroupLabelFontProperty, value);
	}

	/// <summary>
	/// Indicates the view unit used.
	/// </summary>
	public ViewUnitBindableSource? ViewUnit
	{
		get => (ViewUnitBindableSource?)GetValue(ViewUnitProperty);

		set => SetValue(ViewUnitProperty, value);
	}

	/// <summary>
	/// Indicates the auxiliary colors.
	/// </summary>
	public ColorPalette AuxiliaryColors
	{
		get => (ColorPalette)GetValue(AuxiliaryColorsProperty);

		set => SetValue(AuxiliaryColorsProperty, value);
	}

	/// <summary>
	/// Indicates the foreground colors of all 6 kinds of difficulty levels.
	/// </summary>
	public ColorPalette DifficultyLevelForegrounds
	{
		get => (ColorPalette)GetValue(DifficultyLevelForegroundsProperty);

		set => SetValue(DifficultyLevelForegroundsProperty, value);
	}

	/// <summary>
	/// Indicates the background colors of all 6 kinds of difficulty levels.
	/// </summary>
	public ColorPalette DifficultyLevelBackgrounds
	{
		get => (ColorPalette)GetValue(DifficultyLevelBackgroundsProperty);

		set => SetValue(DifficultyLevelBackgroundsProperty, value);
	}

	/// <summary>
	/// Indicates the user-defined colors used by customized views.
	/// </summary>
	public ColorPalette UserDefinedColorPalette
	{
		get => (ColorPalette)GetValue(UserDefinedColorPaletteProperty);

		set => SetValue(UserDefinedColorPaletteProperty, value);
	}

	/// <summary>
	/// Indicates the colors applied to technique pattern Almost Locked Sets.
	/// </summary>
	public ColorPalette AlmostLockedSetsColors
	{
		get => (ColorPalette)GetValue(AlmostLockedSetsColorsProperty);

		set => SetValue(AlmostLockedSetsColorsProperty, value);
	}

	/// <summary>
	/// Indicates the colors applied to technique pattern Rectangles (URs and ARs).
	/// </summary>
	public ColorPalette RectangleColors
	{
		get => (ColorPalette)GetValue(RectangleColorsProperty);

		set => SetValue(RectangleColorsProperty, value);
	}

	/// <summary>
	/// Indicates the approximately-measured width and height value of a cell.
	/// </summary>
	internal double ApproximateCellWidth => ((Width + Height) / 2 - 100 - (4 << 1)) / 10;

	/// <summary>
	/// Indicates the solution of property <see cref="Puzzle"/>.
	/// </summary>
	/// <seealso cref="Puzzle"/>
	internal Grid Solution => _puzzle.SolutionGrid;


	/// <inheritdoc/>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Indicates the event that is triggered when a file is successfully to be received via dropped file.
	/// </summary>
	public event EventHandler<SudokuPane, ReceivedDroppedFileSuccessfullyEventArgs>? ReceivedDroppedFileSuccessfully;

	/// <summary>
	/// Indicates the event that is triggered when a file is failed to be received via dropped file.
	/// </summary>
	public event EventHandler<SudokuPane, ReceivedDroppedFileFailedEventArgs>? ReceivedDroppedFileFailed;

	/// <summary>
	/// Indicates the event that is triggered when a digit is input (that cause a change in a cell).
	/// </summary>
	public event EventHandler<SudokuPane, DigitInputEventArgs>? DigitInput;

	/// <summary>
	/// Indicates the event that is triggered when the internal grid is updated with the specified behavior,
	/// such as removed a candidate, filled with a digit, etc..
	/// </summary>
	public event EventHandler<SudokuPane, GridUpdatedEventArgs>? GridUpdated;

	/// <summary>
	/// Indicates the event that is triggered when the mouse wheel is changed.
	/// </summary>
	public event EventHandler<SudokuPane, SudokuPaneMouseWheelChangedEventArgs>? MouseWheelChanged;

	/// <summary>
	/// Indicates the event that is triggered when a candidate is clicked.
	/// This event can be also used for checking the clicked cell, house, chute, etc..
	/// </summary>
	public event EventHandler<SudokuPane, GridClickedEventArgs>? Clicked;

	/// <summary>
	/// Indicates the event that is triggered when "displaying candidates" option is toggled.
	/// </summary>
	public event EventHandler<SudokuPane, CandidatesDisplayingToggledEventArgs>? CandidatesDisplayingToggled;

	/// <summary>
	/// Indicates the event that is triggered when a house is completed.
	/// </summary>
	public event EventHandler<SudokuPane, HouseCompletedEventArgs>? HouseCompleted;

	/// <summary>
	/// Indicates the event that is triggered when the current puzzle is completed.
	/// </summary>
	public event EventHandler<SudokuPane, PuzzleCompletedEventArgs>? PuzzleCompleted;

	/// <summary>
	/// Indicates the event that is triggered when caching.
	/// </summary>
	public event EventHandler? Caching;


	/// <summary>
	/// Undo a step. This method requires member <see cref="EnableUndoRedoStacking"/> be <see langword="true"/>.
	/// </summary>
	/// <exception cref="InvalidOperationException">
	/// Throws when the property <see cref="EnableUndoRedoStacking"/> is not <see langword="true"/>.
	/// </exception>
	public void UndoStep()
	{
		if (!EnableUndoRedoStacking)
		{
			throw new InvalidOperationException($"Undoing operation requires property '{nameof(EnableUndoRedoStacking)}' be true value.");
		}

		if (_undoStack.Count == 0)
		{
			// No more steps can be undone.
			return;
		}

		_redoStack.Push(_puzzle);

		var target = _undoStack.Pop();

		SetPuzzleCore(target, new(PuzzleUpdatingMethod.UserUpdating, false, true));

		GridUpdated?.Invoke(this, new(GridUpdatedBehavior.Undoing, target));
	}

	/// <summary>
	/// Redo a step. This method requires member <see cref="EnableUndoRedoStacking"/> be <see langword="true"/>.
	/// </summary>
	/// <exception cref="InvalidOperationException">
	/// Throws when the property <see cref="EnableUndoRedoStacking"/> is not <see langword="true"/>.
	/// </exception>
	public void RedoStep()
	{
		if (!EnableUndoRedoStacking)
		{
			throw new InvalidOperationException($"Redoing operation requires property '{nameof(EnableUndoRedoStacking)}' be true value.");
		}

		if (_redoStack.Count == 0)
		{
			// No more steps can be redone.
			return;
		}

		_undoStack.Push(_puzzle);

		var target = _redoStack.Pop();

		SetPuzzleCore(target, new(PuzzleUpdatingMethod.UserUpdating, false, true));

		GridUpdated?.Invoke(this, new(GridUpdatedBehavior.Redoing, target));
	}

	/// <summary>
	/// Try to set a digit into a cell, or delete a digit from a cell.
	/// </summary>
	/// <param name="cell">The cell to be set or delete.</param>
	/// <param name="digit">The digit to be set or delete.</param>
	/// <param name="isSet">Indicates whether the operation is to set a digit into the target cell.</param>
	public void SetOrDeleteDigit(Cell cell, Digit digit, bool isSet)
	{
		var puzzle = Puzzle;
		puzzle.Apply(isSet ? new(Assignment, cell, digit) : new(Elimination, cell, digit));
		SetPuzzleInternal(puzzle, PuzzleUpdatingMethod.UserUpdating);
		GridUpdated?.Invoke(this, new(isSet ? GridUpdatedBehavior.Assignment : GridUpdatedBehavior.Elimination, cell * 9 + digit));
	}

	/// <summary>
	/// Try to update grid state.
	/// </summary>
	/// <param name="newGrid">The new grid to be used for assigning to the target.</param>
	public void UpdateGrid(in Grid newGrid) => SetPuzzleInternal(newGrid, PuzzleUpdatingMethod.Programmatic);

	/// <summary>
	/// <para>Triggers <see cref="GridUpdated"/> event.</para>
	/// <para>This method can only be used by internal control type <see cref="SudokuPaneCell"/> or the current type scope.</para>
	/// </summary>
	/// <param name="behavior">The behavior.</param>
	/// <param name="value">The new value to assign.</param>
	/// <seealso cref="SudokuPaneCell"/>
	internal void TriggerGridUpdated(GridUpdatedBehavior behavior, object value) => GridUpdated?.Invoke(this, new(behavior, value));

	/// <summary>
	///	<para>Triggers <see cref="Clicked"/> event.</para>
	///	<para><inheritdoc cref="TriggerGridUpdated(GridUpdatedBehavior, object)" path="//summary/para[2]"/></para>
	/// </summary>
	/// <param name="mouseButton">Indicates the mouse button clicked.</param>
	/// <param name="candidate">The candidate.</param>
	/// <param name="isDoubleTapped">Indicates whether the operation is double-tapped.</param>
	internal void TriggerClicked(MouseButton mouseButton, Candidate candidate, bool isDoubleTapped)
		=> Clicked?.Invoke(this, new(mouseButton, candidate, isDoubleTapped));

	/// <summary>
	/// <para>Try to set puzzle, with a <see cref="bool"/> value indicating whether undoing and redoing stacks should be cleared.</para>
	/// <para><inheritdoc cref="TriggerGridUpdated(GridUpdatedBehavior, object)" path="//summary/para[2]"/></para>
	/// </summary>
	/// <param name="value">The newer grid.</param>
	/// <param name="method">The updating method.</param>
	/// <param name="clearStack">
	/// Indicates whether undoing and redoing stacks should be cleared. The default value is <see langword="false"/>.
	/// </param>
	/// <seealso cref="SudokuPaneCell"/>
	internal void SetPuzzleInternal(in Grid value, PuzzleUpdatingMethod method, bool clearStack = false)
		=> SetPuzzleCore(value, new(method, clearStack, false));

	/// <summary>
	/// To initialize children controls for <see cref="_children"/>.
	/// </summary>
	[MemberNotNull(nameof(_children))]
	private void InitializeChildrenControls()
	{
		_children = new SudokuPaneCell[81];
		for (var i = 0; i < 81; i++)
		{
			var cellControl = new SudokuPaneCell { CellIndex = i, BasePane = this };

			GridLayout.SetRow(cellControl, i / 9 + 2);
			GridLayout.SetColumn(cellControl, i % 9 + 2);

			if (CandidateRotating == GridCandidateRotating.XSudoRotating)
			{
				cellControl.SetRotating(App.RotatedCandidateTranslationVectors);
			}

			MainGrid.Children.Add(cellControl);
			_children[i] = cellControl;
		}
	}

	/// <summary>
	/// To initializes for stack events.
	/// </summary>
	private void InitializeEvents()
	{
		if (EnableUndoRedoStacking)
		{
			(_undoStack = []).Changed += _ => PropertyChanged?.Invoke(this, new(nameof(_undoStack)));
			(_redoStack = []).Changed += _ => PropertyChanged?.Invoke(this, new(nameof(_redoStack)));
		}

		if (EnableAnimationFeedback)
		{
			HouseCompleted += static (sender, e) => sender.OnHouseCompletedAsync(e);
		}
	}

	/// <summary>
	/// The default handler that is used by <see cref="HouseCompleted"/> event.
	/// </summary>
	/// <param name="e">The event arguments.</param>
	private async void OnHouseCompletedAsync(HouseCompletedEventArgs e)
	{
		if (e.Method == PuzzleUpdatingMethod.Programmatic)
		{
			return;
		}

		foreach (var cells in e.LastCell.GetCellsOrdered(e.House).ToArray())
		{
			cells.ForEach(cell => _children[cell].LightUpAsync(250));
			await 100.ms;
		}
	}

	/// <summary>
	/// To initialize <see cref="_children"/> values via the specified grid.
	/// </summary>
	/// <param name="grid">The grid.</param>
	/// <seealso cref="_children"/>
	private void UpdateCellData(in Grid grid)
	{
		for (var i = 0; i < 81; i++)
		{
			var cellControl = _children[i];
			cellControl.State = grid.GetState(i);
			cellControl.CandidatesMask = grid.GetCandidates(i);
		}
	}

	/// <summary>
	/// Try to update the puzzle value by using the specified newer <see cref="Grid"/> instance,
	/// and two parameters indicating the details of the current updating operation.
	/// </summary>
	/// <param name="value">
	/// <inheritdoc cref="SetPuzzleInternal(in Grid, PuzzleUpdatingMethod, bool)" path="/param[@name='value']"/>
	/// </param>
	/// <param name="data">The details of updating.</param>
	private void SetPuzzleCore(in Grid value, GridUpdatingDetails data)
	{
		var (method, clearStack, whileUndoingOrRedoing) = data;

		// Pushes the grid into the stack if worth.
		if (!whileUndoingOrRedoing && !clearStack && EnableUndoRedoStacking)
		{
			_undoStack.Push(_puzzle);
		}

		// Check whether a house is going to be completed.
		var housesToBeCompleted = value.CompletedHouses & ~_puzzle.CompletedHouses;
		var lastCells = new List<Cell>(PopCount((uint)housesToBeCompleted));
		foreach (var houseToBeCompleted in housesToBeCompleted)
		{
			foreach (var cell in HousesCells[houseToBeCompleted])
			{
				if (_puzzle.GetState(cell) == CellState.Empty && value.GetState(cell) != CellState.Empty)
				{
					lastCells.Add(cell);
					break;
				}
			}
		}

		// Assigns the puzzle.
		_puzzle = value;

		UpdateCellData(value);
		switch (clearStack, whileUndoingOrRedoing)
		{
			case (true, _) when EnableUndoRedoStacking:
			{
				_undoStack.Clear();
				_redoStack.Clear();
				break;
			}
			case (false, false) when EnableUndoRedoStacking:
			{
				_redoStack.Clear();
				break;
			}
		}

		// Triggers the event.
		PropertyChanged?.Invoke(this, new(nameof(Puzzle)));

		var houses = housesToBeCompleted.AllSets;
		for (var i = 0; i < houses.Length; i++)
		{
			HouseCompleted?.Invoke(this, new(lastCells[i], houses[i], method));
		}

		if (value.IsSolved)
		{
			PuzzleCompleted?.Invoke(this, new(value));
		}
	}


	private static void DisplayCandidatesPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is SudokuPane pane)
		{
			pane.CandidatesDisplayingToggled?.Invoke(pane, new());
			UpdateViewUnitControls(pane); // Update view nodes no matter whether the event is triggered.
		}
	}

	private static void ViewUnitPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is SudokuPane pane)
		{
			IncrementalUpdateViewUnitControls(pane, (ViewUnitBindableSource?)e.OldValue, (ViewUnitBindableSource?)e.NewValue);
			pane.Caching?.Invoke(pane, EventArgs.Empty);
		}
	}

	private static void BabaGroupLabelColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void LinkColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void NormalColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void AssignmentColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void OverlappedAssignmentColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void EliminationColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void CannibalismColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void ExofinColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void EndofinColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void GroupedNodeStrokeColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void GroupedNodeBackgroundColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void BabaGroupLabelFontPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void AuxiliaryColorsPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void UserDefinedColorPalettePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void AlmostLockedSetsColorsPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void StrongLinkDashStylePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void WeakLinkDashStylePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void HighlightCandidateCircleScalePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void HighlightBackgroundOpacityPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void ChainStrokeThicknessPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void CandidateViewNodeDisplayModePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void EliminationDisplayModePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void AssignmentDisplayModePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		=> UpdateViewUnitControls((SudokuPane)d);

	private static void HouseCompletedFeedbackDurationPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		foreach (var element in ((SudokuPane)d)._children)
		{
			element.HouseCompletedFeedbackDuration = (int)e.NewValue;
		}
	}

	private static void CoordinateLabelDisplayKindPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (e.NewValue is not CoordinateType value)
		{
			return;
		}

		var i = 0;
		foreach (var element in ((SudokuPane)d).MainGrid.Children)
		{
			if (element is not TextBlock t)
			{
				continue;
			}

			t.Text = CoordinateLabelConversion.ToCoordinateLabelText(value, i % 9, i < 18);
			i++;
		}
	}

	private static void CandidateRotatingPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is not SudokuPane pane || e.NewValue is not GridCandidateRotating rotating)
		{
			return;
		}

		var rotatingArray = rotating switch
		{
			GridCandidateRotating.None => [new(), new(), new(), new(), new(), new(), new(), new(), new()],
			GridCandidateRotating.XSudoRotating => App.RotatedCandidateTranslationVectors,
			_ => throw new InvalidOperationException()
		};
		for (var cell = 0; cell < 81; cell++)
		{
			pane._children[cell].SetRotating(rotatingArray);
		}
	}


	private void UserControl_PointerEntered(object sender, PointerRoutedEventArgs e) => Focus(FocusState.Programmatic);

	private void UserControl_DragOver(object sender, DragEventArgs e)
	{
		e.AcceptedOperation = DataPackageOperation.Copy;
		e.DragUIOverride.Caption = SR.Get("SudokuPane_DropSudokuFileHere", App.CurrentCulture);
		e.DragUIOverride.IsCaptionVisible = true;
		e.DragUIOverride.IsContentVisible = true;
	}

	private async void UserControl_DropAsync(object sender, DragEventArgs e)
	{
		if (e.DataView is not { } dataView)
		{
			return;
		}

		if (!dataView.Contains(StandardDataFormats.StorageItems))
		{
			return;
		}

		switch (await dataView.GetStorageItemsAsync())
		{
			case [StorageFolder folder]:
			{
				var files = await folder.GetFilesAsync(CommonFileQuery.DefaultQuery, 0, 2);
				if (files is not [StorageFile { FileType: FileExtensions.Text or FileExtensions.PlainText } file])
				{
					return;
				}

				await handleSudokuFileAsync(file);
				break;
			}
			case [StorageFile { FileType: FileExtensions.Text or FileExtensions.PlainText } file]:
			{
				await handleSudokuFileAsync(file);
				break;
			}
		}


		async Task handleSudokuFileAsync(StorageFile file)
		{
			var filePath = file.Path;
			var fileInfo = new FileInfo(filePath);
			switch (fileInfo.Length)
			{
				case 0:
				{
					ReceivedDroppedFileFailed?.Invoke(this, new(ReceivedDroppedFileFailedReason.FileIsEmpty));
					return;
				}
				case > 1024 * 64:
				{
					ReceivedDroppedFileFailed?.Invoke(this, new(ReceivedDroppedFileFailedReason.FileIsTooLarge));
					return;
				}
				default:
				{
					switch (io::Path.GetExtension(filePath))
					{
						case FileExtensions.PlainText:
						{
							var content = await FileIO.ReadTextAsync(file);
							if (string.IsNullOrWhiteSpace(content))
							{
								ReceivedDroppedFileFailed?.Invoke(this, new(ReceivedDroppedFileFailedReason.FileIsEmpty));
								return;
							}

							if (!Grid.TryParse(content, out var g))
							{
								ReceivedDroppedFileFailed?.Invoke(this, new(ReceivedDroppedFileFailedReason.FileCannotBeParsed));
								return;
							}

							ReceivedDroppedFileSuccessfully?.Invoke(this, new(filePath, new() { BaseGrid = g }));
							break;
						}
						case FileExtensions.Text:
						{
							Action eventHandler = SudokuFileHandler.Read(filePath) switch
							{
								[var gridInfo] => () => ReceivedDroppedFileSuccessfully?.Invoke(this, new(filePath, gridInfo)),
								_ => () => ReceivedDroppedFileFailed?.Invoke(this, new(ReceivedDroppedFileFailedReason.FileCannotBeParsed))
							};
							eventHandler();
							break;
						}
					}
					break;
				}
			}
		}
	}

	private void UserControl_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
	{
		var pointerPoint = e.GetCurrentPoint((UIElement)sender);
		if (pointerPoint.Properties.MouseWheelDelta is not (var delta and not 0))
		{
			return;
		}

		MouseWheelChanged?.Invoke(this, new(delta < 0));

		e.Handled = true;
	}

	private void UserControl_KeyDown(object sender, KeyRoutedEventArgs e)
	{
		switch (Keyboard.GetModifierStateForCurrentThread(), SelectedCell, e.Key, Keyboard.GetInputDigit(e.Key))
		{
			// Invalid cases.
			default:
			case (_, not (>= 0 and < 81), _, _):
			case var (_, cell, _, _) when Puzzle.GetState(cell) == CellState.Given:
			case (_, _, _, -2):
			{
				return;
			}

			// Clear cell.
			case ({ AllFalse: true }, var cell, _, -1):
			{
				var args = new DigitInputEventArgs(cell, -1);
				DigitInput?.Invoke(this, args);
				if (args.Cancel)
				{
					return;
				}

				var modified = Puzzle;
				modified.SetDigit(cell, -1);
				GridUpdated?.Invoke(this, new(GridUpdatedBehavior.Clear, cell));
				SetPuzzleInternal(modified, PuzzleUpdatingMethod.UserUpdating);
				break;
			}

			// Clear a candidate from a cell.
			case ((false, true, false, false), var cell, _, var digit) when Puzzle.Exists(cell, digit) is true:
			{
				var modified = Puzzle;
				modified.SetExistence(cell, digit, false);
				SetPuzzleInternal(modified, PuzzleUpdatingMethod.UserUpdating);
				GridUpdated?.Invoke(this, new(GridUpdatedBehavior.Elimination, cell * 9 + digit));
				break;
			}

			// Set a cell with a digit.
			case ({ AllFalse: true }, var cell, _, var digit)
			when PreventConflictingInput && !Puzzle.ConflictWith(cell, digit) || !PreventConflictingInput:
			{
				var args = new DigitInputEventArgs(cell, digit);
				DigitInput?.Invoke(this, args);
				if (args.Cancel)
				{
					return;
				}

				var modified = Puzzle;
				if (Puzzle.GetState(cell) == CellState.Modifiable)
				{
					// Temporarily re-compute candidates.
					modified.SetDigit(cell, -1);
				}

				modified.SetDigit(cell, digit);
				SetPuzzleInternal(modified, PuzzleUpdatingMethod.UserUpdating);
				GridUpdated?.Invoke(this, new(GridUpdatedBehavior.Assignment, cell * 9 + digit));
				break;
			}
		}
	}
}

/// <include
///     file="../../global-doc-comments.xml"
///     path="g/csharp11/feature[@name='file-local']/target[@name='class' and @when='extension']"/>
file static class Extensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current cell.</param>
	extension(Cell @this)
	{
		/// <summary>
		/// Get ordered cells.
		/// </summary>
		/// <param name="house">The house index (0..27).</param>
		/// <returns>The ordered cells.</returns>
		public ReadOnlySpan<CellMap> GetCellsOrdered(House house)
		{
			var cells = HousesCells[house];
			switch (house.HouseType)
			{
				case HouseType.Row:
				{
					var pos = Array.FindIndex(cells, cell => cell % 9 == @this % 9);
					var result = new List<CellMap>(5);
					for (var i = 1; ; i++)
					{
						var map = CellMap.Empty;
						if (pos >= i)
						{
							map += cells[pos - i];
						}
						if (pos + i < cells.Length)
						{
							map += cells[pos + i];
						}

						if (map)
						{
							result.AddRef(map);
							continue;
						}
						break;
					}
					return result.AsSpan();
				}
				case HouseType.Column:
				{
					var pos = Array.FindIndex(cells, cell => cell / 9 == @this / 9);
					var result = new List<CellMap>(5);
					for (var i = 1; ; i++)
					{
						var map = CellMap.Empty;
						if (pos >= i)
						{
							map += cells[pos - i];
						}
						if (pos + i < cells.Length)
						{
							map += cells[pos + i];
						}

						if (map)
						{
							result.AddRef(map);
							continue;
						}
						break;
					}
					return result.AsSpan();
				}
				case HouseType.Block:
				{
					return from cell in cells select cell.AsCellMap();
				}
				default:
				{
					throw new UnreachableException();
				}
			}
		}
	}
}
