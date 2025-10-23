namespace Sudoku.Concepts;

/// <summary>
/// Provides with extension methods on <see cref="CellMap"/> or <see cref="CandidateMap"/>.
/// </summary>
public static class CellOrCandidateMapExtensions
{
	/// <summary>
	/// Provides extension members on <see cref="Cell"/>.
	/// </summary>
	extension(Cell @this)
	{
		/// <summary>
		/// Try to get the band index (mega-row) of the specified cell.
		/// </summary>
		public int Band
		{
			get
			{
				for (var i = 0; i < 3; i++)
				{
					if (Chute.Chutes[i].Cells.Contains(@this))
					{
						return i;
					}
				}
				return -1;
			}
		}

		/// <summary>
		/// Try to get the tower index (mega-column) of the specified cell.
		/// </summary>
		/// <returns>The chute index.</returns>
		public int Tower
		{
			get
			{
				for (var i = 3; i < 6; i++)
				{
					if (Chute.Chutes[i].Cells.Contains(@this))
					{
						return i;
					}
				}
				return -1;
			}
		}

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
	/// Provides extension members on <see cref="Candidate"/>.
	/// </summary>
	extension(Candidate @this)
	{
		/// <summary>
		/// Indicates spaces of the current candidate.
		/// </summary>
		public ReadOnlySpan<Space> Spaces
		{
			get
			{
				var cell = @this / 9;
				var digit = @this % 9;
				return (Space[])[
					Space.RowColumn(cell / 9, cell % 9),
					Space.BlockDigit(cell >> HouseType.Block, digit),
					Space.RowDigit((cell >> HouseType.Row) - 9, digit),
					Space.ColumnDigit((cell >> HouseType.Column) - 18, digit)
				];
			}
		}
	}
}
