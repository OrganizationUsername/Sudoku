namespace SudokuStudio.Composition;

/// <summary>
/// Represents a <see cref="Window"/> instance that supports backdrop.
/// </summary>
/// <seealso cref="Window"/>
internal interface IBackdropSupportedWindow
{
	/// <summary>
	/// Indicates the root grid layout.
	/// </summary>
	Panel RootGridLayout { get; }


	/// <summary>
	/// Try to set Mica backdrop.
	/// </summary>
	/// <param name="useMicaAlt">Indicates whether the current Mica backdrop use alternated configuration.</param>
	/// <returns>A <see cref="bool"/> value indicating whether the Mica backdrop is supported.</returns>
	bool TrySetMicaBackdrop(bool useMicaAlt);

	/// <summary>
	/// Try to set Acrylic backdrop.
	/// </summary>
	/// <param name="useAcrylicThin">Indicates whether the current Acrylic backdrop use thin configuration.</param>
	/// <returns>A <see cref="bool"/> value indicating whether the Acrylic backdrop is supported.</returns>
	bool TrySetAcrylicBackdrop(bool useAcrylicThin);

	/// <summary>
	/// Try to dispose resource of backdrop-related resources.
	/// </summary>
	void DisposeBackdropRelatedResources();
}
