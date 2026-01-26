namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <typeparam name="TResult">The type of result elements.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TSource, TResult>(TSource[] source)
	{
		/// <returns>
		/// An array of <typeparamref name="TResult"/> instances being the result
		/// of invoking the transform function on each element of <paramref name="source"/>.
		/// </returns>
		/// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
		public TResult[] Select(Func<TSource, TResult> selector)
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
		public TResult[] Select(Func<TSource, int, TResult> selector)
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
