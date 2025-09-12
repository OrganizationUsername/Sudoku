namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="IAggregateMethod{TSelf, TSource}.Aggregate(Func{TSource, TSource, TSource})"/>
		public TSource Aggregate(Func<TSource, TSource, TSource> func)
		{
			var result = default(TSource)!;
			foreach (var element in source)
			{
				result = func(result, element);
			}
			return result;
		}

		/// <inheritdoc cref="IAggregateMethod{TSelf, TSource}.Aggregate{TAccumulate, TResult}(TAccumulate, Func{TAccumulate, TSource, TAccumulate}, Func{TAccumulate, TResult})"/>
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
