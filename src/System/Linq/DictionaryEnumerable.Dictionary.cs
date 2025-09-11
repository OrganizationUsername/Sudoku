namespace System.Linq;

public partial class DictionaryEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="Dictionary{TKey, TValue}"/> of <typeparamref name="TKey"/> and <typeparamref name="TValue"/>,
	/// where <typeparamref name="TKey"/> satisfies <see langword="notnull"/> constraint.
	/// </summary>
	extension<TKey, TValue>(Dictionary<TKey, TValue> @this) where TKey : notnull
	{
		/// <inheritdoc cref="Enumerable.ElementAt{TSource}(IEnumerable{TSource}, int)"/>
		public KeyValuePair<TKey, TValue> ElementAt(int index)
		{
			using var enumerator = @this.GetEnumerator();
			var tempIndex = -1;
			while (enumerator.MoveNext())
			{
				if (++tempIndex == index)
				{
					return enumerator.Current;
				}
			}
			throw new IndexOutOfRangeException();
		}

		/// <inheritdoc cref="Enumerable.ElementAt{TSource}(IEnumerable{TSource}, Index)"/>
		public KeyValuePair<TKey, TValue> ElementAt(Index index)
			=> @this.ElementAt(index.GetOffset(@this.Count));
	}

	/// <summary>
	/// Provides extension members on <see cref="Dictionary{TKey, TValue}"/> of <typeparamref name="TKey"/> and <typeparamref name="TValue"/>,
	/// where <typeparamref name="TKey"/> satisfies <see langword="notnull"/> constraint,
	/// and <typeparamref name="TValue"/> satisfies <see cref="IComparable{T}"/>,
	/// <see cref="IComparisonOperators{TSelf, TOther, TResult}"/> and <see cref="IMinMaxValue{TSelf}"/> constraints.
	/// </summary>
	extension<TKey, TValue>(Dictionary<TKey, TValue> @this)
		where TKey : notnull
		where TValue : IComparable<TValue>, IComparisonOperators<TValue, TValue, bool>, IMinMaxValue<TValue>
	{
		/// <summary>
		/// Get the maximal value in all <see cref="Dictionary{TKey, TValue}.Values"/>.
		/// </summary>
		/// <returns>An instance of type <typeparamref name="TValue"/> as maximal-valued one.</returns>
		/// <seealso cref="Dictionary{TKey, TValue}.Values"/>
		public TValue MaxByValue()
		{
			var result = TValue.MinValue;
			foreach (var value in @this.Values)
			{
				if (value >= result)
				{
					result = value;
				}
			}
			return result;
		}

		/// <summary>
		/// Get the minimal value in all <see cref="Dictionary{TKey, TValue}.Values"/>.
		/// </summary>
		/// <returns>An instance of type <typeparamref name="TValue"/> as minimal-valued one.</returns>
		/// <seealso cref="Dictionary{TKey, TValue}.Values"/>
		public TValue MinByValue()
		{
			var result = TValue.MaxValue;
			foreach (var value in @this.Values)
			{
				if (value <= result)
				{
					result = value;
				}
			}
			return result;
		}
	}
}
