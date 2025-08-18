namespace SudokuStudio.Composition;

/// <summary>
/// Represents a <see cref="Window"/> type that supports background picture.
/// </summary>
internal interface IBackgroundPictureSupportedWindow
{
	/// <summary>
	/// Indicates the root grid layout.
	/// </summary>
	Panel RootGridLayout { get; }
}
