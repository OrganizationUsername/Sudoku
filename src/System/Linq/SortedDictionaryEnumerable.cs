namespace System.Linq;

/// <summary>
/// Provides extension methods on <see cref="SortedDictionary{TKey, TValue}"/>.
/// </summary>
/// <seealso cref="SortedDictionary{TKey, TValue}"/>
public static class SortedDictionaryEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="SortedDictionary{TKey, TValue}"/> of <typeparamref name="TKey"/> and <typeparamref name="TValue"/>,
	/// where <typeparamref name="TKey"/> satisfies <see langword="notnull"/>.
	/// </summary>
	extension<TKey, TValue>(SortedDictionary<TKey, TValue> @this) where TKey : notnull
	{
		/// <inheritdoc cref="Enumerable.First{TSource}(IEnumerable{TSource})"/>
		public KeyValuePair<TKey, TValue> First()
		{
			using var enumerator = @this.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
			throw new InvalidOperationException();
		}
	}
}
