namespace System.Linq.Providers;

/// <summary>
/// Represents a type that supports method group <c>Count</c> and <c>LongCount</c>.
/// </summary>
/// <inheritdoc/>
public interface ICountMethod<TSelf, TSource> : ILinqMethod<TSelf, TSource>
	where TSelf : ICountMethod<TSelf, TSource>, allows ref struct
	where TSource : allows ref struct
{
	/// <inheritdoc cref="Enumerable.Count{TSource}(IEnumerable{TSource})"/>
	int Count()
	{
		var result = 0;
		foreach (var element in this)
		{
			result++;
		}
		return result;
	}

	/// <inheritdoc cref="Enumerable.Count{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
	int Count(Func<TSource, bool> predicate)
	{
		var result = 0;
		foreach (var element in this)
		{
			if (predicate(element))
			{
				result++;
			}
		}
		return result;
	}

	/// <inheritdoc cref="Enumerable.LongCount{TSource}(IEnumerable{TSource})"/>
	long LongCount()
	{
		var result = 0L;
		foreach (var element in this)
		{
			result++;
		}
		return result;
	}

	/// <inheritdoc cref="Enumerable.LongCount{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
	long LongCount(Func<TSource, bool> predicate)
	{
		var result = 0L;
		foreach (var element in this)
		{
			if (predicate(element))
			{
				result++;
			}
		}
		return result;
	}
}
