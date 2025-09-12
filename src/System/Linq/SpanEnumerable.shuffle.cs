namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
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
