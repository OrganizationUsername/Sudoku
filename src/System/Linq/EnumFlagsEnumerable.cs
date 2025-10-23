namespace System.Linq;

/// <summary>
/// Provides with some extension methods for enumeration types.
/// </summary>
public static class EnumFlagsEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="T"/>,
	/// where <typeparamref name="T"/> satisfies <see langword="unmanaged"/> and <see cref="Enum"/> constraints.
	/// </summary>
	/// <param name="this">The enumeration type field.</param>
	extension<T>(T @this) where T : unmanaged, Enum
	{
		/// <summary>
		/// Try to get all <typeparamref name="T"/> elements as flags stored in argument <paramref name="this"/>,
		/// and convert them into an array of <typeparamref name="TResult"/> instances via specified argument <paramref name="selector"/>,
		/// then return the array.
		/// </summary>
		/// <typeparam name="TResult">The type of the result elements.</typeparam>
		/// <param name="selector">The selector that can convert the enumeration field into the target-typed instance.</param>
		/// <returns>An array of <typeparamref name="TResult"/> elements.</returns>
		/// <exception cref="InvalidOperationException">
		/// Throws when the enumeration type is not marked <see cref="FlagsAttribute"/>.
		/// </exception>
		public ReadOnlySpan<TResult> Select<TResult>(Func<T, TResult> selector)
		{
			if (!typeof(T).IsDefined<FlagsAttribute>())
			{
				throw new InvalidOperationException($"The enumeration type must be marked as '{nameof(FlagsAttribute)}'.");
			}

			if (@this.AllFlags is not (var flags and not []))
			{
				return [];
			}

			var result = new TResult[flags.Length];
			for (var i = 0; i < flags.Length; i++)
			{
				result[i] = selector(flags[i]);
			}
			return result;
		}
	}
}
