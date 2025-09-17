namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(ReadOnlySpan<TSource> source) where TSource : class
	{
		/// <inheritdoc cref="IOfTypeMethod{TSelf, TSource}.OfType{TResult}"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public ReadOnlySpan<TResult> OfType<TResult>() where TResult : class?, TSource?
		{
			var result = new TResult[source.Length];
			var i = 0;
			foreach (ref readonly var element in source)
			{
				if (element is TResult derived)
				{
					result[i++] = derived;
				}
			}
			return result.AsReadOnlySpan()[..i];
		}
	}
}
