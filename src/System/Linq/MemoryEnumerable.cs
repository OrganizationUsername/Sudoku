namespace System.Linq;

/// <summary>
/// Represents a list of methods that are LINQ methods operating with <see cref="ReadOnlyMemory{T}"/> instances.
/// </summary>
/// <seealso cref="ReadOnlyMemory{T}"/>
public static class MemoryEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="T"/>.
	/// </summary>
	extension<T>(ReadOnlyMemory<T> @this)
	{
		/// <inheritdoc cref="SpanEnumerable.Select{T, TResult}(ReadOnlySpan{T}, Func{T, TResult})"/>
		public ReadOnlyMemory<TResult> Select<TResult>(Func<T, TResult> selector)
			=> (from element in @this.Span select selector(element)).ToArray();

		/// <inheritdoc cref="SpanEnumerable.Where{T}(ReadOnlySpan{T}, Func{T, bool})"/>
		public ReadOnlyMemory<T> Where(Func<T, bool> predicate)
			=> (from element in @this.Span where predicate(element) select element).ToArray();
	}
}
