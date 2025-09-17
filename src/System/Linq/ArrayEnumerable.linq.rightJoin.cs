namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TOuter"/>[].
	/// </summary>
	extension<TOuter>(TOuter[] outer)
	{
		/// <inheritdoc cref="IRightJoinMethod{TSelf, TSource}.RightJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult?[] RightJoin<TInner, TKey, TResult>(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter?, TInner, TResult?> resultSelector
		) where TKey : notnull => RightJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);

		/// <inheritdoc cref="IRightJoinMethod{TSelf, TSource}.RightJoin{TInner, TKey, TResult}(IEnumerable{TInner}, Func{TSource, TKey}, Func{TInner, TKey}, Func{TSource, TInner, TResult}, IEqualityComparer{TKey}?)"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult?[] RightJoin<TInner, TKey, TResult>(
			TInner[] inner,
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
