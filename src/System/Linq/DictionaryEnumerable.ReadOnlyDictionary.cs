namespace System.Linq;

public partial class DictionaryEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TKey">The type of key.</typeparam>
	/// <typeparam name="TValue">The type of value.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> source) where TKey : notnull
	{
		/// <summary>
		/// Determine whether all keys in the dictionary satisfy the specified condition.
		/// </summary>
		/// <param name="predicate">The condition to be checked.</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public bool AllKey(Func<TKey, bool> predicate)
		{
			foreach (var key in source.Keys)
			{
				if (!predicate(key))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Determine whether all values in the dictionary satisfy the specified condition.
		/// </summary>
		/// <param name="predicate">The condition to be checked.</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public bool AllValue(Func<TValue, bool> predicate)
		{
			foreach (var value in source.Values)
			{
				if (!predicate(value))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Determine whether at least one key in the dictionary satisfies the specified condition.
		/// </summary>
		/// <param name="predicate">The condition to be checked.</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public bool AnyKey(Func<TKey, bool> predicate)
		{
			foreach (var key in source.Keys)
			{
				if (predicate(key))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Determine whether at least one value in the dictionary satisfies the specified condition.
		/// </summary>
		/// <param name="predicate">The condition to be checked.</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public bool AnyValue(Func<TValue, bool> predicate)
		{
			foreach (var value in source.Values)
			{
				if (predicate(value))
				{
					return true;
				}
			}
			return false;
		}
	}
}
