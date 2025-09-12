namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	/// <typeparam name="TSource">The type of each element.</typeparam>
	/// <param name="source">The array that contains a list of elements to be calculated.</param>
	extension<TSource>(TSource[] source)
		where TSource : IAdditiveIdentity<TSource, TSource>, IAdditionOperators<TSource, TSource, TSource>
	{
		/// <summary>
		/// Sum all elements up and return the result.
		/// </summary>
		/// <returns>A <typeparamref name="TSource"/> instance as the result.</returns>
		public TSource Sum()
		{
			var result = TSource.AdditiveIdentity;
			foreach (ref readonly var element in source.AsReadOnlySpan())
			{
				result += element;
			}
			return result;
		}
	}

	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	/// <typeparam name="TSource">The type of element of <paramref name="source"/>.</typeparam>
	/// <param name="source">Indicates the source values.</param>
	extension<TSource>(TSource[] source)
	{
		/// <summary>
		/// Computes the sum of the sequence of <typeparamref name="TResult"/> values that are obtained by invoking a transform function
		/// on each element of the input sequence.
		/// </summary>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <param name="selector">The method that projects the value into an instance of type <typeparamref name="TResult"/>.</param>
		/// <returns>The result value.</returns>
		public TResult Sum<TResult>(Func<TSource, TResult> selector)
			where TResult : IAdditionOperators<TResult, TResult, TResult>, IAdditiveIdentity<TResult, TResult>
		{
			var result = TResult.AdditiveIdentity;
			foreach (var element in source)
			{
				result += selector(element);
			}
			return result;
		}

		/// <inheritdoc cref="Sum{T, TResult}(T[], Func{T, TResult})"/>
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
