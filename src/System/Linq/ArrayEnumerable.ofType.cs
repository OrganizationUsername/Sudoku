namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="object"/>[].
	/// <param name="source">The array to be filtered.</param>
	/// </summary>
	extension(object[] source)
	{
		/// <summary>
		/// Filters the array, removing elements not of type <typeparamref name="TResult"/>.
		/// </summary>
		/// <typeparam name="TResult">The type of the target elements.</typeparam>
		/// <returns>A list of <typeparamref name="TResult"/> elements.</returns>
		public TResult[] OfType<TResult>() => from element in source where element is TResult select (TResult)element;
	}
}
