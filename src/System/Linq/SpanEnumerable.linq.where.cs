namespace System.Linq;

public partial class SpanEnumerable
{
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="IWhereMethod{TSelf, TSource}.Where(Func{TSource, bool})"/>
		public ReadOnlySpan<TSource> Where(Func<TSource, bool> predicate)
		{
			var result = new TSource[source.Length];
			var i = 0;
			foreach (var element in source)
			{
				if (predicate(element))
				{
					result[i++] = element;
				}
			}
			return result.AsReadOnlySpan()[..i];
		}

		/// <inheritdoc cref="IWhereMethod{TSelf, TSource}.Where(Func{TSource, int, bool})"/>
		public ReadOnlySpan<TSource> Where(Func<TSource, int, bool> predicate)
		{
			var result = new TSource[source.Length];
			var i = 0;
			for (var j = 0; j < source.Length; j++)
			{
				if (predicate(source[j], j))
				{
					result[i++] = source[j];
				}
			}
			return result.AsReadOnlySpan()[..i];
		}
	}
}
