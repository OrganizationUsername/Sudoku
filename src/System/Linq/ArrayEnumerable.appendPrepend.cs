namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	extension<TSource>(TSource[] source)
	{
		/// <inheritdoc cref="Enumerable.Append{TSource}(IEnumerable{TSource}, TSource)"/>
		public ArrayAppendIterator<TSource> Append(TSource value) => new(source, value);

		/// <inheritdoc cref="Enumerable.Prepend{TSource}(IEnumerable{TSource}, TSource)"/>
		public ArrayPrependIterator<TSource> Prepend(TSource value) => new(source, value);
	}
}
