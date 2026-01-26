namespace System.Linq;

public partial class SpanEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TBase">The type of the elements of source.</typeparam>
	/// <typeparam name="TDerived">The derived type to be checked.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TBase, TDerived>(ReadOnlySpan<TBase> source) where TDerived : TBase?
	{
		/// <summary>
		/// Determines whether all elements are of type <typeparamref name="TDerived"/>.
		/// </summary>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public bool AllAre()
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
