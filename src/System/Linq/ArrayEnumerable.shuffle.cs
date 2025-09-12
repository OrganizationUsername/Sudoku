namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	extension<TSource>(TSource[] source)
	{
		/// <inheritdoc cref="IShuffleMethod{TSelf, TSource}.Shuffle()"/>
		public TSource[] Shuffle() => source.Shuffle(Random.Shared);

		/// <inheritdoc cref="IShuffleMethod{TSelf, TSource}.Shuffle(Random)"/>
		public TSource[] Shuffle(Random random)
		{
			var result = source[..];
			random.Shuffle(result);
			return result;
		}
	}
}
