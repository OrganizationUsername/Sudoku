namespace System.Linq;

/// <summary>
/// Provides with LINQ methods for <see cref="ITuple"/> instances.
/// </summary>
/// <seealso cref="ITuple"/>
public static class TupleEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(ITuple @this)
	{
		/// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
		public ReadOnlySpan<T> Cast<T>()
		{
			var result = new T[@this.Length];
			var i = 0;
			foreach (var element in @this)
			{
				result[i++] = (T)element!;
			}
			return result;
		}

		/// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
		public ReadOnlySpan<TResult> Select<T, TResult>(Func<T?, TResult> selector)
		{
			var result = new TResult[@this.Length];
			var i = 0;
			foreach (var element in from T? element in @this select element)
			{
				result[i++] = selector(element);
			}
			return result;
		}
	}
}
