namespace System.Linq;

public partial class SpanEnumerable
{
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="ICountMethod{TSelf, TSource}.Count(Func{TSource, bool})"/>
		public int Count(Func<TSource, bool> condition)
		{
			var result = 0;
			foreach (var element in source)
			{
				if (condition(element))
				{
					result++;
				}
			}
			return result;
		}
	}
}
