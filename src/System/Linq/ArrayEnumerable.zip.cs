namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TFirst"/>[].
	/// </summary>
	extension<TFirst>(TFirst[] first)
	{
		/// <inheritdoc cref="Enumerable.Zip{TFirst, TSecond}(IEnumerable{TFirst}, IEnumerable{TSecond})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public (TFirst Left, TSecond Right)[] Zip<TSecond>(TSecond[] second)
		{
			ArgumentException.ThrowIf(first.Length == second.Length);

			var result = new (TFirst, TSecond)[first.Length];
			for (var i = 0; i < first.Length; i++)
			{
				result[i] = (first[i], second[i]);
			}
			return result;
		}
	}
}
