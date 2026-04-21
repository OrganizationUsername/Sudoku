namespace SudokuStudio.Configuration;

/// <summary>
/// Represents with preference items that is used in library-related pages.
/// </summary>
public sealed partial class LibraryPreferenceGroup : PreferenceGroup
{
	private static readonly LibraryCandidatesVisibility LibraryCandidatesVisibilityDefaultValue = LibraryCandidatesVisibility.AlwaysShown;

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryCandidatesVisibility"/>.
	/// </summary>
	/// <seealso cref="LibraryCandidatesVisibility"/>
	public static readonly DependencyProperty LibraryCandidatesVisibilityProperty =
		DependencyProperty.Register(nameof(LibraryCandidatesVisibility), typeof(LibraryCandidatesVisibility), typeof(LibraryPreferenceGroup), new PropertyMetadata(LibraryCandidatesVisibilityDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryPuzzleTransformations"/>.
	/// </summary>
	/// <seealso cref="LibraryPuzzleTransformations"/>
	public static readonly DependencyProperty LibraryPuzzleTransformationsProperty =
		DependencyProperty.Register(nameof(LibraryPuzzleTransformations), typeof(TransformType), typeof(LibraryPreferenceGroup), new PropertyMetadata((TransformType)0));


	/// <summary>
	/// Indicates whether the candidates in a puzzle defined in puzzle libraries should be shown.
	/// </summary>
	public LibraryCandidatesVisibility LibraryCandidatesVisibility
	{
		get => (LibraryCandidatesVisibility)GetValue(LibraryCandidatesVisibilityProperty);

		set => SetValue(LibraryCandidatesVisibilityProperty, value);
	}

	/// <summary>
	/// Indicates the transforming kinds for library puzzles.
	/// </summary>
	public TransformType LibraryPuzzleTransformations
	{
		get => (TransformType)GetValue(LibraryPuzzleTransformationsProperty);

		set => SetValue(LibraryPuzzleTransformationsProperty, value);
	}
}
