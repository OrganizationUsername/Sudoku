namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TOuter"/>[].
	/// </summary>
	extension<TOuter, TInner, TKey, TResult>(TOuter[] outer) where TKey : notnull
	{
		/// <inheritdoc cref="IRightJoinMethod{TSelf, TSource}.RightJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult})"/>
		public TResult?[] RightJoin(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter?, TInner, TResult?> resultSelector
		) => RightJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);

		/// <inheritdoc cref="IRightJoinMethod{TSelf, TSource}.RightJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult}, IEqualityComparer{TKey}?)"/>
		public TResult?[] RightJoin(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter?, TInner, TResult?> resultSelector,
			IEqualityComparer<TKey>? comparer
		)
		{
			comparer ??= EqualityComparer<TKey>.Default;

			var outerLookup = outer.ToLookup(outerKeySelector, comparer);
			var result = new List<TResult?>();
			foreach (var innerElement in inner)
			{
				if (outerLookup[innerKeySelector(innerElement)] is var outerElements and not [])
				{
					foreach (var outerElement in outerElements)
					{
						result.AddRef(resultSelector(outerElement, innerElement));
					}
				}
				else
				{
					result.AddRef(resultSelector(default, innerElement));
				}
			}
			return [.. result];
		}
	}
}
