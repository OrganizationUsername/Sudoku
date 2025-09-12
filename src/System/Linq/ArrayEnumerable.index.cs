namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	/// <typeparam name="TSource">The type of each element.</typeparam>
	/// <param name="source">The object to be iterated.</param>
	extension<TSource>(TSource[] source)
	{
		/// <summary>
		/// Returns a new array instance that contains each element with its corresponding index.
		/// </summary>
		/// <returns>A new array instance.</returns>
		public (int Index, TSource Value)[] Index()
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
