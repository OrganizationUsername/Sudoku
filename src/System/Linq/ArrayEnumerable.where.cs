namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <param name="source">The source collection.</param>
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
