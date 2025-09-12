namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	/// <typeparam name="TSource">The type of each element.</typeparam>
	/// <param name="source">An array of elements to be aggregated over.</param>
	extension<TSource>(TSource[] source)
	{
		/// <summary>
		/// Applies an accumulator function over a sequence.
		/// </summary>
		/// <param name="func">The function that aggregates the values.</param>
		/// <returns>An element accumulated, of type <typeparamref name="TSource"/>.</returns>
		public TSource? Aggregate(Func<TSource?, TSource?, TSource> func)
		{
			var result = default(TSource);
			foreach (var element in source)
			{
				result = func(result, element);
			}
			return result;
		}

		/// <summary>
		/// Applies an accumulator function over a sequence. The initial value can be set in this method.
		/// </summary>
		/// <typeparam name="TAccumulate">The type of the accumulated values.</typeparam>
		/// <param name="seed">The initial value.</param>
		/// <param name="func">The function that aggregates the values.</param>
		/// <returns>An element accumulated, of type <typeparamref name="TSource"/>.</returns>
		public TAccumulate Aggregate<TAccumulate>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
			where TAccumulate : allows ref struct
		{
			var result = seed;
			foreach (var element in source)
			{
				result = func(result, element);
			}
			return result;
		}
	}
}
