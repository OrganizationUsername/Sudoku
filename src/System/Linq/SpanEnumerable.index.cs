namespace System.Linq;

public partial class SpanEnumerable
{
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
