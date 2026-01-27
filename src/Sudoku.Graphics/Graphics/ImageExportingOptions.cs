namespace Sudoku.Graphics;

/// <summary>
/// Represents image exporting options.
/// </summary>
public sealed class ImageExportingOptions
{
	/// <summary>
	/// Indicates the default options.
	/// </summary>
	public static readonly ImageExportingOptions Default = new();


	/// <summary>
	/// Indicates the quality. Range 0..100. Default 80.
	/// </summary>
	public int Quality { get; init; } = 80;
}
