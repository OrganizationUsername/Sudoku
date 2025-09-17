namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TBase"/>.
	/// </summary>
	/// <typeparam name="TBase">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TBase>(ReadOnlySpan<TBase> source)
	{
		/// <summary>
		/// Determines whether all elements are of type <typeparamref name="TDerived"/>.
		/// </summary>
		/// <typeparam name="TDerived">The derived type to be checked.</typeparam>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public bool AllAre<TDerived>() where TDerived : TBase?
		{
			foreach (ref readonly var element in source)
			{
				if (element is not TDerived)
				{
					return false;
				}
			}
			return true;
		}
	}
}
