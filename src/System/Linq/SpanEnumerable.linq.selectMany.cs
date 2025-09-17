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
		/// <inheritdoc cref="ISelectManyMethod{TSelf, TSource}.SelectMany{TCollection, TResult}(Func{TSource, IEnumerable{TCollection}}, Func{TSource, TCollection, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public ReadOnlySpan<TResult> SelectMany<TCollection, TResult>(
			Func<TSource, ReadOnlySpan<TCollection>> collectionSelector,
			Func<TSource, TCollection, TResult> resultSelector
		)
		{
			var length = source.Length;
			var result = new List<TResult>(length << 1);
			for (var i = 0; i < length; i++)
			{
				var element = source[i];
				foreach (ref readonly var subElement in collectionSelector(element))
				{
					result.AddRef(resultSelector(element, subElement));
				}
			}
			return result.ToArray();
		}
	}
}
