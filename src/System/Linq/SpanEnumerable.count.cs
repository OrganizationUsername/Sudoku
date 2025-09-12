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
