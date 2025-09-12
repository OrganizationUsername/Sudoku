namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="IGroupByMethod{TSelf, TSource}.GroupBy{TKey}(Func{TSource, TKey})"/>
		public ReadOnlySpan<SpanGrouping<TSource, TKey>> GroupBy<TKey>(Func<TSource, TKey> keySelector)
			where TKey : notnull
		{
			var tempDictionary = new Dictionary<TKey, List<TSource>>(source.Length >> 2);
			foreach (var element in source)
			{
				var key = keySelector(element);
				if (!tempDictionary.TryAdd(key, [element]))
				{
					tempDictionary[key].AddRef(element);
				}
			}

			var result = new List<SpanGrouping<TSource, TKey>>(tempDictionary.Count);
			foreach (var key in tempDictionary.Keys)
			{
				var tempValues = tempDictionary[key];
				result.AddRef(new([.. tempValues], key));
			}
			return result.AsSpan();
		}

		/// <inheritdoc cref="IGroupByMethod{TSelf, TSource}.GroupBy{TKey, TElement}(Func{TSource, TKey}, Func{TSource, TElement})"/>
		public ReadOnlySpan<SpanGrouping<TElement, TKey>> GroupBy<TKey, TElement>(
			Func<TSource, TKey> keySelector,
			Func<TSource, TElement> elementSelector
		)
			where TKey : notnull
		{
			var tempDictionary = new Dictionary<TKey, List<TSource>>(source.Length >> 2);
			foreach (var element in source)
			{
				var key = keySelector(element);
				if (!tempDictionary.TryAdd(key, [element]))
				{
					tempDictionary[key].AddRef(element);
				}
			}

			var result = new List<SpanGrouping<TElement, TKey>>(tempDictionary.Count);
			foreach (var key in tempDictionary.Keys)
			{
				var tempValues = tempDictionary[key];
				var valuesConverted = from value in tempValues select elementSelector(value);
				result.AddRef(new(valuesConverted.ToArray(), key));
			}
			return result.AsSpan();
		}
	}
}
