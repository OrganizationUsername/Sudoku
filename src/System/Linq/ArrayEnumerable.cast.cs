namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="object"/>[].
	/// </summary>
	extension<TResult>(object[] source)
	{
		/// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
		public TResult[] Cast()
		{
			var result = new TResult[source.Length];
			for (var i = 0; i < source.Length; i++)
			{
				result[i] = (TResult)source[i];
			}
			return result;
		}
	}
}
