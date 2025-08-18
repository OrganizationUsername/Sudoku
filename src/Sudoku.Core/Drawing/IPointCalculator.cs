namespace Sudoku.Drawing;

/// <summary>
/// Represents a base type of pointer calculator.
/// </summary>
public interface IPointCalculator
{
	/// <summary>
	/// Indicates the width of the picture to draw.
	/// </summary>
	float Width { get; }

	/// <summary>
	/// Indicates the height of the picture to draw.
	/// </summary>
	float Height { get; }

	/// <summary>
	/// Indicates the padding of the gap between the picture box outline and the sudoku grid outline.
	/// </summary>
	float Padding { get; }

	/// <summary>
	/// Indicates the control size.
	/// </summary>
	(float Width, float Height) ControlSize { get; }

	/// <summary>
	/// Indicates the grid size.
	/// </summary>
	(float Width, float Height) GridSize { get; }

	/// <summary>
	/// Indicates the cell size.
	/// </summary>
	(float Width, float Height) CellSize { get; }

	/// <summary>
	/// Indicates the candidate size.
	/// </summary>
	(float Width, float Height) CandidateSize { get; }

	/// <summary>
	/// Indicates the absolutely points in grid cross-lines.
	/// This property will be assigned later (and not <see langword="null"/>).
	/// </summary>
	/// <remarks>Note that the size of this 2D array is always 28 by 28.</remarks>
	(float X, float Y)[,] GridPoints { get; }
}
