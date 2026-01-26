namespace System.Linq;

public partial class SpanEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <typeparam name="TResult">The type of result elements.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TSource, TResult>(ReadOnlySpan<TSource> source)
		where TSource : class
		where TResult : class?, TSource?
	{
		/// <inheritdoc cref="IOfTypeMethod{TSelf, TSource}.OfType{TResult}"/>
		public ReadOnlySpan<TResult> OfType()
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
