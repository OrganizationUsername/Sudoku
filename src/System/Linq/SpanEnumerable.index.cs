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
		/// <inheritdoc cref="Enumerable.Index{TSource}(IEnumerable{TSource})"/>
		public ReadOnlySpan<(int Index, TSource Value)> Index()
		{
			var result = new (int, TSource)[source.Length];
			for (var i = 0; i < source.Length; i++)
			{
				result[i] = (i, source[i]);
			}
			return result;
		}
	}
}
