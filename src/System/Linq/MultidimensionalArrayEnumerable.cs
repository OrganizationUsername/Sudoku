namespace System.Linq;

/// <summary>
/// Provides with LINQ methods on multi-dimensional array.
/// </summary>
public static class MultidimensionalArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[,].
	/// </summary>
	extension<TSource>(TSource[,] source)
	{
		/// <inheritdoc cref="ArrayEnumerable.Select{T, TResult}(T[], Func{T, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult[,] Select<TResult>(Func<TSource, TResult> selector)
		{
			var result = new TResult[source.GetLength(0), source.GetLength(1)];
			for (var i = 0; i < source.GetLength(0); i++)
			{
				for (var j = 0; j < source.GetLength(1); j++)
				{
					result[i, j] = selector(source[i, j]);
				}
			}
			return result;
		}

		/// <inheritdoc cref="ArrayEnumerable.Select{T, TResult}(T[], Func{T, int, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult[,] Select<TResult>(Func<TSource, int, int, TResult> selector)
		{
			var result = new TResult[source.GetLength(0), source.GetLength(1)];
			for (var i = 0; i < source.GetLength(0); i++)
			{
				for (var j = 0; j < source.GetLength(1); j++)
				{
					result[i, j] = selector(source[i, j], i, j);
				}
			}
			return result;
		}
	}
}
