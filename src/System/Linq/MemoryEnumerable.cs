namespace System.Linq;

/// <summary>
/// Represents a list of methods that are LINQ methods operating with <see cref="ReadOnlyMemory{T}"/> instances.
/// </summary>
/// <seealso cref="ReadOnlyMemory{T}"/>
public static class MemoryEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TSource>(ReadOnlyMemory<TSource> source)
	{
		/// <inheritdoc cref="SpanEnumerable.Select{T, TResult}(ReadOnlySpan{T}, Func{T, TResult})"/>
		public ReadOnlyMemory<TResult> Select<TResult>(Func<TSource, TResult> selector)
			=> (from element in source.Span select selector(element)).ToArray();

		/// <inheritdoc cref="SpanEnumerable.Where{T}(ReadOnlySpan{T}, Func{T, bool})"/>
		public ReadOnlyMemory<TSource> Where(Func<TSource, bool> predicate)
			=> (from element in source.Span where predicate(element) select element).ToArray();
	}
}
