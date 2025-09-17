namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(ReadOnlySpan<TSource> source) where TSource : INumberBase<TSource>
	{
		/// <inheritdoc cref="IAverageMethod{TSelf, TSource}.Average{TAccumulator, TResult}()"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TResult Average<TResult>() where TResult : INumberBase<TResult>
		{
			var sum = source.Sum();
			return TResult.CreateChecked(sum) / TResult.CreateChecked(source.Length);
		}
	}
}
