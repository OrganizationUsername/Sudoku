namespace Sudoku.Graphics.Primitives;

/// <summary>
/// Provides background drawing method set.
/// </summary>
public interface IGridCanvasDrawBackground
{
	/// <summary>
	/// Draw background.
	/// </summary>
	/// <param name="color">Color.</param>
	void DrawBackground(SKColor color);
}
