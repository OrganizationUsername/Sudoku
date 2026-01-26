namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <typeparam name="TKey">The type of key.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TSource, TKey>(TSource[] source) where TKey : notnull
	{
		/// <inheritdoc cref="Enumerable.GroupBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/>
		public ArrayGrouping<TSource, TKey>[] GroupBy(Func<TSource, TKey> keySelector)
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

			var result = new List<ArrayGrouping<TSource, TKey>>(tempDictionary.Count);
			foreach (var key in tempDictionary.Keys)
			{
				var tempValues = tempDictionary[key];
				result.Add(new([.. tempValues], key));
			}
			return [.. result];
		}

		/// <inheritdoc cref="Enumerable.GroupBy{TSource, TKey, TElement}(IEnumerable{TSource}, Func{TSource, TKey}, Func{TSource, TElement})"/>
		public ArrayGrouping<TElement, TKey>[] GroupBy<TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
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

			var result = new List<ArrayGrouping<TElement, TKey>>(tempDictionary.Count);
			foreach (var key in tempDictionary.Keys)
			{
				var tempValues = tempDictionary[key];
				var valuesConverted = from value in tempValues select elementSelector(value);
				result.Add(new([.. valuesConverted], key));
			}
			return [.. result];
		}
	}
}
