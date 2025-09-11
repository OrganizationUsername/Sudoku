namespace System.Linq;

/// <summary>
/// Provides with LINQ methods on multi-dimensional array.
/// </summary>
public static class MultidimensionalArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[,].
	/// </summary>
	extension<TSource>(TSource[,] @this)
	{
		/// <inheritdoc cref="ArrayEnumerable.Select{T, TResult}(T[], Func{T, TResult})"/>
		public TResult[,] Select<TResult>(Func<TSource, TResult> selector)
		{
			var result = new TResult[@this.GetLength(0), @this.GetLength(1)];
			for (var i = 0; i < @this.GetLength(0); i++)
			{
				for (var j = 0; j < @this.GetLength(1); j++)
				{
					result[i, j] = selector(@this[i, j]);
				}
			}
			return result;
		}

		/// <inheritdoc cref="ArrayEnumerable.Select{T, TResult}(T[], Func{T, int, TResult})"/>
		public TResult[,] Select<TResult>(Func<TSource, int, int, TResult> selector)
		{
			var result = new TResult[@this.GetLength(0), @this.GetLength(1)];
			for (var i = 0; i < @this.GetLength(0); i++)
			{
				for (var j = 0; j < @this.GetLength(1); j++)
				{
					result[i, j] = selector(@this[i, j], i, j);
				}
			}
			return result;
		}
	}
}
