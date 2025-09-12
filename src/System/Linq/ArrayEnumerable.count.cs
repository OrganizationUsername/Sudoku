namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	/// <typeparam name="TSource">The type of each element.</typeparam>
	/// <param name="source">The array.</param>
	extension<TSource>(TSource[] source)
	{
		/// <summary>
		/// Totals up the number of elements that satisfy the specified condition.
		/// </summary>
		/// <param name="predicate">The condition.</param>
		/// <returns>The number of elements satisfying the specified condition.</returns>
		public int Count(Func<TSource, bool> predicate)
		{
			var result = 0;
			foreach (var element in source)
			{
				if (predicate(element))
				{
					result++;
				}
			}
			return result;
		}

		/// <inheritdoc cref="Count{T}(T[], Func{T, bool})"/>
		public unsafe int CountUnsafe(delegate*<TSource, bool> predicate)
		{
			var result = 0;
			foreach (var element in source)
			{
				if (predicate(element))
				{
					result++;
				}
			}
			return result;
		}
	}
}
