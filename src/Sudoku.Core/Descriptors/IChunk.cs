namespace Sudoku.Descriptors;

/// <summary>
/// Defines a chunk object.
/// </summary>
/// <typeparam name="TSelf"><include file="../../global-doc-comments.xml" path="/g/self-type-constraint"/></typeparam>
public interface IChunk<TSelf> : IEnumerable, IFormattable where TSelf : Chunk, IChunk<TSelf>
{
	/// <summary>
	/// Indicates single element type.
	/// </summary>
	static abstract Type SingleElementType { get; }
}
