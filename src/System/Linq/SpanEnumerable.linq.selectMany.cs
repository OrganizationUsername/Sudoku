namespace System.Linq;

public partial class SpanEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <typeparam name="TCollection">The type of interim collection elements.</typeparam>
	/// <typeparam name="TResult">The type of result.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TSource, TCollection, TResult>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="ISelectManyMethod{TSelf, TSource}.SelectMany{TCollection, TResult}(Func{TSource, IEnumerable{TCollection}}, Func{TSource, TCollection, TResult})"/>
		public ReadOnlySpan<TResult> SelectMany(
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
