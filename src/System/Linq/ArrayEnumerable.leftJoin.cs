namespace System.Linq;

public partial class ArrayEnumerable
{
	extension<TOuter, TInner, TKey, TResult>(TOuter[] outer) where TKey : notnull
	{
		/// <inheritdoc cref="ILeftJoinMethod{TSelf, TSource}.LeftJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult})"/>
		public TResult?[] LeftJoin(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner?, TResult?> resultSelector
		) => LeftJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);

		/// <inheritdoc cref="ILeftJoinMethod{TSelf, TSource}.LeftJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult}, IEqualityComparer{TKey}?)"/>
		public TResult?[] LeftJoin(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner?, TResult?> resultSelector,
			IEqualityComparer<TKey>? comparer
		)
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
