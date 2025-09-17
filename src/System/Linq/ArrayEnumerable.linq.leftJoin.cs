namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TOuter"/>[].
	/// </summary>
	extension<TOuter>(TOuter[] outer)
	{
		/// <inheritdoc cref="ILeftJoinMethod{TSelf, TSource}.LeftJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult?[] LeftJoin<TInner, TKey, TResult>(
			TInner[] inner,
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
		public TResult?[] LeftJoin<TInner, TKey, TResult>(
			TInner[] inner,
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
			foreach (var outerElement in outer)
			{
				if (innerLookup[outerKeySelector(outerElement)] is var innerElements and not [])
				{
					foreach (var innerElement in innerElements)
					{
						result.AddRef(resultSelector(outerElement, innerElement));
					}
				}
				else
				{
					result.AddRef(resultSelector(outerElement, default));
				}
			}
			return [.. result];
		}
	}
}
