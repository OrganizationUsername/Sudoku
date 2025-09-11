namespace System.Linq;

public partial class DictionaryEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="IReadOnlyDictionary{TKey, TValue}"/>
	/// of <typeparamref name="TKey"/> and <typeparamref name="TValue"/>,
	/// where <typeparamref name="TKey"/> satisfies <see langword="notnull"/> constraint.
	/// </summary>
	extension<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> @this) where TKey : notnull
	{
		/// <summary>
		/// Determine whether all keys in the dictionary satisfy the specified condition.
		/// </summary>
		/// <param name="predicate">The condition to be checked.</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public bool AllKey(Func<TKey, bool> predicate)
		{
			foreach (var key in @this.Keys)
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
			foreach (var value in @this.Values)
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
			foreach (var key in @this.Keys)
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
			foreach (var value in @this.Values)
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
