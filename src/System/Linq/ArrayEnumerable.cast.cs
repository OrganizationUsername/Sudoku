namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TResult">The type of each result value.</typeparam>
	/// <param name="source">The source collection.</param>
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
