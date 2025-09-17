namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(scoped ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="ISelectMethod{TSelf, TSource}.Select{TResult}(Func{TSource, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public ReadOnlySpan<TResult> Select<TResult>(Func<TSource, TResult> selector)
		{
			var result = new TResult[source.Length];
			var i = 0;
			foreach (var element in source)
			{
				result[i++] = selector(element);
			}
			return result;
		}

		/// <inheritdoc cref="ISelectMethod{TSelf, TSource}.Select{TResult}(Func{TSource, int, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public ReadOnlySpan<TResult> Select<TResult>(Func<TSource, int, TResult> selector)
		{
			var result = new TResult[source.Length];
			var i = 0;
			foreach (var element in source)
			{
				result[i++] = selector(element, i);
			}
			return result;
		}
	}
}
