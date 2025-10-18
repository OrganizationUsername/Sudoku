namespace System.Linq;

public static partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="ISkipMethod{TSelf, TSource}.Skip(int)"/>
		public ReadOnlySpan<TSource> Skip(int count) => source.Length < count ? [] : source[count..];
	}
}
