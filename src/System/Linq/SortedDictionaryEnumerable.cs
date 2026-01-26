namespace System.Linq;

/// <summary>
/// Provides extension methods on <see cref="SortedDictionary{TKey, TValue}"/>.
/// </summary>
/// <seealso cref="SortedDictionary{TKey, TValue}"/>
public static class SortedDictionaryEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TKey">The type of key.</typeparam>
	/// <typeparam name="TValue">The type of value.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TKey, TValue>(SortedDictionary<TKey, TValue> source) where TKey : notnull
	{
		/// <inheritdoc cref="Enumerable.First{TSource}(IEnumerable{TSource})"/>
		public KeyValuePair<TKey, TValue> First()
		{
			using var enumerator = source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
			throw new InvalidOperationException();
		}
	}
}
