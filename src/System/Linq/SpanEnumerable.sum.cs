namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(ReadOnlySpan<TSource> source)
		where TSource : IAdditiveIdentity<TSource, TSource>, IAdditionOperators<TSource, TSource, TSource>
	{
		/// <inheritdoc cref="ISumMethod{TSelf, TSource}.Sum"/>
		public TSource Sum()
		{
			var result = TSource.AdditiveIdentity;
			foreach (ref readonly var element in source)
			{
				result += element;
			}
			return result;
		}
	}

	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <summary>
		/// Totals up all elements, and return the result of the sum by the specified property calculated from each element.
		/// </summary>
		/// <typeparam name="TKey">The type of key to add up.</typeparam>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <returns>The value with the sum key in the sequence.</returns>
		public TKey Sum<TKey>(Func<TSource, TKey> keySelector)
			where TKey : IAdditiveIdentity<TKey, TKey>, IAdditionOperators<TKey, TKey, TKey>
		{
			var result = TKey.AdditiveIdentity;
			foreach (var element in source)
			{
				result += keySelector(element);
			}
			return result;
		}

		/// <inheritdoc cref="Sum{TSource, TKey}(ReadOnlySpan{TSource}, Func{TSource, TKey})"/>
		public unsafe TResult SumUnsafe<TResult>(delegate*<TSource, TResult> selector)
			where TResult : IAdditionOperators<TResult, TResult, TResult>, IAdditiveIdentity<TResult, TResult>
		{
			var result = TResult.AdditiveIdentity;
			foreach (var element in source)
			{
				result += selector(element);
			}
			return result;
		}
	}
}
