namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TOuter">The type of each element from source collection.</typeparam>
	/// <typeparam name="TInner">The type of each element from interim collection.</typeparam>
	/// <typeparam name="TKey">The type of key chosen for both source and interim collection.</typeparam>
	/// <typeparam name="TResult">The type of each element from result collection.</typeparam>
	/// <param name="outer">The source collection.</param>
	extension<TOuter, TInner, TKey, TResult>(TOuter[] outer) where TKey : notnull
	{
		/// <inheritdoc cref="Enumerable.Join{TOuter, TInner, TKey, TResult}(IEnumerable{TOuter}, IEnumerable{TInner}, Func{TOuter, TKey}, Func{TInner, TKey}, Func{TOuter, TInner, TResult})"/>
		public TResult[] Join(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner, TResult> resultSelector
		) => Join(outer, inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);

		/// <inheritdoc cref="Enumerable.Join{TOuter, TInner, TKey, TResult}(IEnumerable{TOuter}, IEnumerable{TInner}, Func{TOuter, TKey}, Func{TInner, TKey}, Func{TOuter, TInner, TResult}, IEqualityComparer{TKey}?)"/>
		public TResult[] Join(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner, TResult> resultSelector,
			IEqualityComparer<TKey>? comparer
		)
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
		public TResult[] GroupJoin(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner[], TResult> resultSelector
		) => GroupJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);

		/// <inheritdoc cref="Enumerable.GroupJoin{TOuter, TInner, TKey, TResult}(IEnumerable{TOuter}, IEnumerable{TInner}, Func{TOuter, TKey}, Func{TInner, TKey}, Func{TOuter, IEnumerable{TInner}, TResult}, IEqualityComparer{TKey}?)"/>
		public TResult[] GroupJoin(
			TInner[] inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Func<TOuter, TInner[], TResult> resultSelector,
			IEqualityComparer<TKey>? comparer
		)
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
