namespace Sudoku.Concepts.Marshalling;

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

		/// <summary>
		/// Try to get the band index (mega-row) of the specified cell.
		/// </summary>
		public int Band => @this / 27;

		/// <summary>
		/// Try to get the tower index (mega-column) of the specified cell.
		/// </summary>
		/// <returns>The chute index.</returns>
		public int Tower => @this / 3 % 3;

		/// <summary>
		/// Get the houses for the specified cell, representing as a <see cref="HouseMask"/> instance.
		/// </summary>
		public HouseMask Houses
		{
			get
			{
				var result = 0;
				result |= 1 << (@this >> HouseType.Block);
				result |= 1 << (@this >> HouseType.Row);
				result |= 1 << (@this >> HouseType.Column);
				return result;
			}
		}


		/// <summary>
		/// Gets the row, column and block value and copies to the specified array that represents by a pointer
		/// of 3 elements, where the first element stores the block index, second element stores the row index
		/// and the third element stores the column index.
		/// </summary>
		/// <param name="reference">
		/// The specified reference to the first element in a sequence. The sequence type can be an array or a <see cref="Span{T}"/>,
		/// only if the sequence can store at least 3 values.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Throws when the argument <paramref name="reference"/> references to <see langword="null"/>.
		/// </exception>
		public void CopyHouseInfo(ref House reference)
		{
			reference = BlockTable[@this];
			Unsafe.Add(ref reference, 1) = RowTable[@this];
			Unsafe.Add(ref reference, 2) = ColumnTable[@this];
		}

		/// <inheritdoc cref="op_RightShift(Cell, HouseType)"/>
		[Obsolete(DeprecatedMessages.ExtensionOperator_StateChange, false)]
		public House ToHouse(HouseType houseType) => @this >> houseType;


		/// <summary>
		/// Converts a cell instance into a string instance that represents for a cell.
		/// </summary>
		/// <param name="cell">The cell.</param>
		/// <param name="formatProvider">The formatter.</param>
		/// <returns>The string representation.</returns>
		public static string ToCellString(Cell cell, IFormatProvider? formatProvider)
		{
			var converter = CoordinateConverter.GetInstance(formatProvider);
			return converter.CellConverter(cell.AsCellMap());
		}


		/// <summary>
		/// Get the house index (0..27 for block 1-9, row 1-9 and column 1-9) for the specified cell and the house type.
		/// </summary>
		/// <param name="cell">The cell.</param>
		/// <param name="houseType">The house type.</param>
		/// <returns>The house index. The return value must be between 0 and 26.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Throws when the argument <paramref name="houseType"/> is not defined.
		/// </exception>
		public static House operator >>(Cell cell, HouseType houseType)
			=> houseType switch
			{
				HouseType.Block => BlockTable[cell],
				HouseType.Row => RowTable[cell],
				HouseType.Column => ColumnTable[cell],
				_ => throw new ArgumentOutOfRangeException(nameof(houseType))
			};
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
