namespace System.Collections.Generic;

/// <summary>
/// Provides with extension methods on <see cref="SortedDictionary{TKey, TValue}"/>.
/// </summary>
/// <seealso cref="SortedDictionary{TKey, TValue}"/>
public static class SortedDictionaryExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TKey">The type of key.</typeparam>
	/// <typeparam name="TValue">The type of value.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<TKey, TValue>(SortedDictionary<TKey, TValue> @this) where TKey : notnull
	{
		/// <summary>
		/// Indicates the minimal key of the collection.
		/// </summary>
		public TKey? MinKey
		{
			get
			{
				var result = default(TKey);
				var comparer = @this.Comparer;
				foreach (var key in @this.Keys)
				{
					if (comparer.Compare(key, result) <= 0)
					{
						result = key;
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Indicates the maximal key of the collection.
		/// </summary>
		public TKey? MaxKey
		{
			get
			{
				var result = default(TKey);
				var comparer = @this.Comparer;
				foreach (var key in @this.Keys)
				{
					if (comparer.Compare(key, result) >= 0)
					{
						result = key;
					}
				}
				return result;
			}
		}
	}
}
