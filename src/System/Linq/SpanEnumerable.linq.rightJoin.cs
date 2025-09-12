namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TOuter"/>.
	/// </summary>
	extension<TOuter>(ReadOnlySpan<TOuter> outer)
	{
		/// <inheritdoc cref="IRightJoinMethod{TSelf, TSource}.RightJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult})"/>
		public ReadOnlySpan<TResult?> RightJoin<TInner, TKey, TResult>(
			ReadOnlySpan<TInner> inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter?, TInner, TResult?> resultSelector
		) where TKey : notnull => RightJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);

		/// <inheritdoc cref="IRightJoinMethod{TSelf, TSource}.RightJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult}, IEqualityComparer{TKey}?)"/>
		public ReadOnlySpan<TResult?> RightJoin<TInner, TKey, TResult>(
			ReadOnlySpan<TInner> inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter?, TInner, TResult?> resultSelector,
			IEqualityComparer<TKey>? comparer
		)
			where TKey : notnull
		{
			comparer ??= EqualityComparer<TKey>.Default;

			var outerLookup = outer.ToLookup(outerKeySelector, comparer);
			var result = new List<TResult?>();
			foreach (ref readonly var innerElement in inner)
			{
				if (outerLookup[innerKeySelector(innerElement)] is var outerElements and not [])
				{
					foreach (ref readonly var outerElement in outerElements)
					{
						result.AddRef(resultSelector(outerElement, innerElement));
					}
				}
				else
				{
					result.AddRef(resultSelector(default, innerElement));
				}
			}
			return result.AsSpan();
		}
	}
}
