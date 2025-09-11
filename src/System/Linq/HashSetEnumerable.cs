namespace System.Linq;

/// <summary>
/// Represents LINQ methods used by <see cref="HashSet{T}"/> instances.
/// </summary>
/// <seealso cref="HashSet{T}"/>
public static class HashSetEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="HashSet{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	extension<TSource>(HashSet<TSource> source)
	{
		/// <summary>
		/// Indicates the first element of the collection.
		/// </summary>
		/// <returns>The first element of the collection.</returns>
		/// <exception cref="InvalidOperationException">Throws when the collection contains no elements.</exception>
		public TSource First()
		{
			using var enumerator = source.GetEnumerator();
			return enumerator.MoveNext()
				? enumerator.Current
				: throw new InvalidOperationException(SR.ExceptionMessage("NoElementsFoundInCollection"));
		}

		/// <inheritdoc cref="Enumerable.First{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
		public TSource First(Func<TSource, bool> predicate)
		{
			foreach (var element in source)
			{
				if (predicate(element))
				{
					return element;
				}
			}
			throw new InvalidOperationException(SR.ExceptionMessage("NoElementsFoundInCollection"));
		}

		/// <inheritdoc cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource})"/>
		public TSource? FirstOrDefault() => source.Count == 0 ? default : source.First();

		/// <inheritdoc cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
		public TSource? FirstOrDefault(Func<TSource, bool> predicate)
		{
			foreach (var element in source)
			{
				if (predicate(element))
				{
					return element;
				}
			}
			return default;
		}
	}
}
