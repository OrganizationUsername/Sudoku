namespace Sudoku.Concepts;

/// <summary>
/// Represents a concept "Cell".
/// </summary>
public static class CellMarshal
{
	/// <summary>
	/// Provides extension members on <see cref="Cell"/>.
	/// </summary>
	extension(Cell @this)
	{
		/// <summary>
		/// Converts the specified <see cref="Cell"/> into a singleton <see cref="CellMap"/> instance.
		/// </summary>
		/// <returns>A <see cref="CellMap"/> instance, containing only one element of the current cell.</returns>
		public ref readonly CellMap AsCellMap() => ref CellMaps[@this];
	}

	/// <summary>
	/// Provides extension members on <see cref="Cell"/>[].
	/// </summary>
	extension(Cell[] @this)
	{
		/// <inheritdoc cref="extension(ReadOnlySpan{Cell}).AsCellMap()"/>
		public CellMap AsCellMap() => [.. @this];
	}

	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <see cref="Cell"/>.
	/// </summary>
	extension(ReadOnlySpan<Cell> @this)
	{
		/// <summary>
		/// Converts the specified list of <see cref="Cell"/> instances into a <see cref="CellMap"/> instance.
		/// </summary>
		/// <returns>A <see cref="CellMap"/> instance, containing all elements come from the current sequence.</returns>
		public CellMap AsCellMap() => [.. @this];
	}
}
