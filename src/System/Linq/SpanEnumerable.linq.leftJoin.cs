namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TOuter"/>.
	/// </summary>
	extension<TOuter>(ReadOnlySpan<TOuter> outer)
	{
		/// <inheritdoc cref="ILeftJoinMethod{TSelf, TSource}.LeftJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public ReadOnlySpan<TResult?> LeftJoin<TInner, TKey, TResult>(
			ReadOnlySpan<TInner> inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner?, TResult?> resultSelector
		) where TKey : notnull => LeftJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);

		/// <inheritdoc cref="ILeftJoinMethod{TSelf, TSource}.LeftJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult}, IEqualityComparer{TKey}?)"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public ReadOnlySpan<TResult?> LeftJoin<TInner, TKey, TResult>(
			ReadOnlySpan<TInner> inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner?, TResult?> resultSelector,
			IEqualityComparer<TKey>? comparer
		)
			where TKey : notnull
		{
			comparer ??= EqualityComparer<TKey>.Default;

			var innerLookup = inner.ToLookup(innerKeySelector, comparer);
			var result = new List<TResult?>();
			foreach (ref readonly var outerElement in outer)
			{
				if (innerLookup[outerKeySelector(outerElement)] is var innerElements and not [])
				{
					foreach (ref readonly var innerElement in innerElements)
					{
						result.AddRef(resultSelector(outerElement, innerElement));
					}
				}
				else
				{
					result.AddRef(resultSelector(outerElement, default));
				}
			}
			return result.AsSpan();
		}
	}
}
