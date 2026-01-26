namespace System.Linq;

public partial class SpanEnumerable
{
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="IShuffleMethod{TSelf, TSource}.Shuffle()"/>
		public ReadOnlySpan<TSource> Shuffle() => source.Shuffle(Random.Shared);

		/// <inheritdoc cref="IShuffleMethod{TSelf, TSource}.Shuffle(Random)"/>
		public ReadOnlySpan<TSource> Shuffle(Random random)
		{
			var result = new TSource[source.Length];
			source.CopyTo(result);
			random.Shuffle(result);
			return result;
		}
	}
}
