namespace Sudoku.Graphics.Primitives;

/// <summary>
/// Provides line drawing method set.
/// </summary>
public interface IGridCanvasDrawLine
{
	/// <summary>
	/// Draw grid lines.
	/// </summary>
	/// <param name="options">Indicates the options.</param>
	void DrawGridLine(ImageDrawingOptions? options = null);
}
