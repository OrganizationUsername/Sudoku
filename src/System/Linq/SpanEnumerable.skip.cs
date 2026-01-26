namespace System.Linq;

public static partial class SpanEnumerable
{
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="ISkipMethod{TSelf, TSource}.Skip(int)"/>
		public ReadOnlySpan<TSource> Skip(int count) => source.Length < count ? [] : source[count..];
	}
}
