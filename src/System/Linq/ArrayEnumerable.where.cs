namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">An array of <typeparamref name="TSource"/> instances to filter.</param>
	extension<TSource>(TSource[] source)
	{
		/// <summary>
		/// Filters a sequence of values based on a predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>
		/// An array of <typeparamref name="TSource"/> instances that contains elements from the input sequence that satisfy the condition.
		/// </returns>
		public TSource[] Where(Func<TSource, bool> predicate)
		{
			var (length, finalIndex) = (source.Length, 0);
			var result = new TSource[length];
			for (var i = 0; i < length; i++)
			{
				if (predicate(source[i]))
				{
					result[finalIndex++] = source[i];
				}
			}
			return result[..finalIndex];
		}
	}
}
