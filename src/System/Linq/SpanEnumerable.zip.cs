namespace System.Linq;

public partial class SpanEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TFirst">The type of elements from the first collection.</typeparam>
	/// <typeparam name="TSecond">The type of elements from the second collection.</typeparam>
	/// <param name="first">The first collection.</param>
	extension<TFirst, TSecond>(ReadOnlySpan<TFirst> first)
	{
		/// <inheritdoc cref="Enumerable.Zip{TFirst, TSecond}(IEnumerable{TFirst}, IEnumerable{TSecond})"/>
		public ReadOnlySpan<(TFirst Left, TSecond Right)> Zip(ReadOnlySpan<TSecond> second)
		{
			ArgumentException.Assert(first.Length == second.Length);

			var result = new (TFirst, TSecond)[first.Length];
			for (var i = 0; i < first.Length; i++)
			{
				result[i] = (first[i], second[i]);
			}
			return result;
		}
	}
}
