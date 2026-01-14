namespace Sudoku.Analytics.Braiding;

/// <summary>
/// Provides extension methods on <see cref="BraidType"/>.
/// </summary>
/// <seealso cref="BraidType"/>
public static class BraidTypeExtensions
{
	/// <summary>
	/// Provides extension members on <see cref="BraidType"/>.
	/// </summary>
	/// <param name="this">The current field.</param>
	extension(BraidType @this)
	{
		/// <summary>
		/// Indicates whether the field can be defined as "rope".
		/// </summary>
		public bool IsRope => @this is BraidType.NRope or BraidType.ZRope;

		/// <summary>
		/// Indicates whether the field can be defined as "braid".
		/// </summary>
		public bool IsBraid => @this is BraidType.NBraid or BraidType.ZBraid;


		/// <summary>
		/// Converts the current field into the easy-to-read mode string of 3 characters,
		/// with each character either <c>'N'</c> or <c>'Z'</c>.
		/// </summary>
		/// <returns>A string of 3 characters, with each character either <c>'N'</c> or <c>'Z'</c>.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public string ToSimpleString()
			=> @this switch
			{
				BraidType.None => string.Empty,
				BraidType.NRope => nameof(BraidType.NNN),
				BraidType.NBraid => nameof(BraidType.NNZ),
				BraidType.ZBraid => nameof(BraidType.NZZ),
				BraidType.ZRope => nameof(BraidType.ZZZ),
				_ => throw new ArgumentOutOfRangeException(nameof(@this))
			};


		/// <summary>
		/// Creates a <see cref="BraidType"/> field via 3 rotation types.
		/// </summary>
		/// <param name="type1">The first rotation type.</param>
		/// <param name="type2">The second rotation type.</param>
		/// <param name="type3">The third rotation type.</param>
		/// <returns>The result braid type.</returns>
		public static BraidType Create(StrandType type1, StrandType type2, StrandType type3)
			=> (type1, type2, type3) switch
			{
				(StrandType.Downside, StrandType.Downside, StrandType.Downside) => BraidType.NRope,
				(StrandType.Downside, StrandType.Downside, StrandType.Upside) => BraidType.NBraid,
				(StrandType.Downside, StrandType.Upside, StrandType.Downside) => BraidType.NBraid,
				(StrandType.Upside, StrandType.Downside, StrandType.Downside) => BraidType.NBraid,
				(StrandType.Downside, StrandType.Upside, StrandType.Upside) => BraidType.ZBraid,
				(StrandType.Upside, StrandType.Downside, StrandType.Upside) => BraidType.ZBraid,
				(StrandType.Upside, StrandType.Upside, StrandType.Downside) => BraidType.ZBraid,
				(StrandType.Upside, StrandType.Upside, StrandType.Upside) => BraidType.ZRope,
				_ => throw new ArgumentException($"Invalid type combination ({type1}, {type2}, {type3})")
			};

		/// <summary>
		/// Creates a <see cref="BraidType"/> field via 3 rotation types.
		/// </summary>
		/// <param name="types">The types.</param>
		/// <returns>The result braid type.</returns>
		public static BraidType Create(params ReadOnlySpan<StrandType> types)
		{
			ArgumentException.Assert(types.Length == 3);
			return BraidType.Create(types[0], types[1], types[2]);
		}
	}
}
