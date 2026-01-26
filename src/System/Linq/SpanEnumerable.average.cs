namespace System.Linq;

public partial class SpanEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <typeparam name="TResult">The type of result.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TSource, TResult>(ReadOnlySpan<TSource> source)
		where TSource : INumberBase<TSource>
		where TResult : INumberBase<TResult>
	{
		/// <inheritdoc cref="IAverageMethod{TSelf, TSource}.Average{TAccumulator, TResult}()"/>
		public TResult Average()
		{
			var sum = source.Sum();
			return TResult.CreateChecked(sum) / TResult.CreateChecked(source.Length);
		}
	}
}
