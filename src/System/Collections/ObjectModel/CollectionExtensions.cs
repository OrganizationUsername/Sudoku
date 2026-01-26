namespace System.Collections.ObjectModel;

/// <summary>
/// Provides with extension methods on <see cref="Collection{T}"/>.
/// </summary>
/// <seealso cref="Collection{T}"/>
public static class CollectionExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension<T>(Collection<T> @this)
	{
		/// <inheritdoc cref="Collection{T}.RemoveAt(int)"/>
		public void RemoveAt(Index index) => @this.RemoveAt(index.GetOffset(@this.Count));
	}
}
