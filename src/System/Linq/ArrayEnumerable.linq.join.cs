namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TOuter"/>[].
	/// </summary>
	extension<TOuter>(TOuter[] outer)
	{
		/// <inheritdoc cref="Enumerable.Join{TOuter, TInner, TKey, TResult}(IEnumerable{TOuter}, IEnumerable{TInner}, Func{TOuter, TKey}, Func{TInner, TKey}, Func{TOuter, TInner, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult[] Join<TInner, TKey, TResult>(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner, TResult> resultSelector
		) where TKey : notnull => Join(outer, inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);

		/// <inheritdoc cref="Enumerable.Join{TOuter, TInner, TKey, TResult}(IEnumerable{TOuter}, IEnumerable{TInner}, Func{TOuter, TKey}, Func{TInner, TKey}, Func{TOuter, TInner, TResult}, IEqualityComparer{TKey}?)"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult[] Join<TInner, TKey, TResult>(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner, TResult> resultSelector,
			IEqualityComparer<TKey>? comparer
		) where TKey : notnull
		{
			comparer ??= EqualityComparer<TKey>.Default;

			var result = new List<TResult>(outer.Length * inner.Length);
			foreach (var outerItem in outer)
			{
				var outerKey = outerKeySelector(outerItem);
				var outerKeyHash = comparer.GetHashCode(outerKey);
				foreach (var innerItem in inner)
				{
					var innerKey = innerKeySelector(innerItem);
					var innerKeyHash = comparer.GetHashCode(innerKey);
					if (outerKeyHash != innerKeyHash)
					{
						// They are not same due to hash code difference.
						continue;
					}

					if (!comparer.Equals(outerKey, innerKey))
					{
						// They are not same due to inequality.
						continue;
					}

					result.AddRef(resultSelector(outerItem, innerItem));
				}
			}
			return [.. result];
		}

		/// <inheritdoc cref="Enumerable.GroupJoin{TOuter, TInner, TKey, TResult}(IEnumerable{TOuter}, IEnumerable{TInner}, Func{TOuter, TKey}, Func{TInner, TKey}, Func{TOuter, IEnumerable{TInner}, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult[] GroupJoin<TInner, TKey, TResult>(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner[], TResult> resultSelector
		) where TKey : notnull => GroupJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);

		/// <inheritdoc cref="Enumerable.GroupJoin{TOuter, TInner, TKey, TResult}(IEnumerable{TOuter}, IEnumerable{TInner}, Func{TOuter, TKey}, Func{TInner, TKey}, Func{TOuter, IEnumerable{TInner}, TResult}, IEqualityComparer{TKey}?)"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult[] GroupJoin<TInner, TKey, TResult>(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner[], TResult> resultSelector,
			IEqualityComparer<TKey>? comparer
		) where TKey : notnull
		{
			comparer ??= EqualityComparer<TKey>.Default;

			var innerKvps = from element in inner select new KeyValuePair<TKey, TInner>(innerKeySelector(element), element);
			var result = new List<TResult>();
			foreach (var outerItem in outer)
			{
				var outerKey = outerKeySelector(outerItem);
				var outerKeyHash = comparer.GetHashCode(outerKey);
				var satisfiedInnerKvps = new List<TInner>(innerKvps.Length);
				foreach (var kvp in innerKvps)
				{
					ref readonly var innerKey = ref kvp.KeyRef;
					ref readonly var innerItem = ref kvp.ValueRef;
					var innerKeyHash = comparer.GetHashCode(innerKey);
					if (outerKeyHash != innerKeyHash)
					{
						// They are not same due to hash code difference.
						continue;
					}

					if (!comparer.Equals(outerKey, innerKey))
					{
						// They are not same due to inequality.
						continue;
					}

					satisfiedInnerKvps.AddRef(innerItem);
				}

				result.AddRef(resultSelector(outerItem, [.. satisfiedInnerKvps]));
			}
			return [.. result];
		}
	}
}
