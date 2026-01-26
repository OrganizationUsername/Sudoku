namespace System.Linq;

/// <summary>
/// Provides with extension methods on <see cref="ArrayList"/>.
/// </summary>
/// <seealso cref="ArrayList"/>
public static class ArrayListEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="source">The source collection.</param>
	extension(ArrayList source)
	{
		/// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
		public ReadOnlySpan<TResult?> Cast<TResult>()
		{
			var result = new TResult?[source.Count];
			for (var i = 0; i < source.Count; i++)
			{
				result[i] = (TResult?)source[i];
			}
			return result;
		}

		/// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
		public ReadOnlySpan<T> Select<T>(Func<object?, T> selector)
		{
			var result = new T[source.Count];
			for (var i = 0; i < source.Count; i++)
			{
				result[i] = selector(source[i]);
			}
			return result;
		}
	}
}
