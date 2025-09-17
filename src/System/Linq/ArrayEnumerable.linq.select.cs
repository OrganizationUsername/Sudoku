namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	extension<TSource>(TSource[] source)
	{
		/// <returns>
		/// An array of <typeparamref name="TResult"/> instances being the result
		/// of invoking the transform function on each element of <paramref name="source"/>.
		/// </returns>
		/// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult[] Select<TResult>(Func<TSource, TResult> selector)
		{
			var length = source.Length;
			var result = new TResult[length];
			for (var i = 0; i < length; i++)
			{
				result[i] = selector(source[i]);
			}
			return result;
		}

		/// <summary>
		/// An array of <typeparamref name="TResult"/> instances being the result
		/// of invoking the transform function on each element of <paramref name="source"/>, and its indices.
		/// </summary>
		/// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, int, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult[] Select<TResult>(Func<TSource, int, TResult> selector)
		{
			var length = source.Length;
			var result = new TResult[length];
			for (var i = 0; i < length; i++)
			{
				result[i] = selector(source[i], i);
			}
			return result;
		}
	}
}
