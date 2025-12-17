namespace Sudoku.Descriptors;

/// <summary>
/// Defines a chunk object.
/// </summary>
public interface IChunk : IEnumerable, IFormattable
{
	/// <summary>
	/// Indicates the chunk element.
	/// </summary>
	ChunkElementFlag ElementType { get; }

	/// <summary>
	/// Indicates all supported element types.
	/// </summary>
	ChunkElementFlag SupportedElementTypes { get; }
}

/// <summary>
/// Defines a chunk object.
/// </summary>
/// <typeparam name="TSelf"><include file="../../global-doc-comments.xml" path="/g/self-type-constraint"/></typeparam>
/// <typeparam name="T">The type of element.</typeparam>
public interface IChunk<out TSelf, T> : IChunk
	where TSelf : IChunk<TSelf, T>
	where T : notnull
{
	/// <summary>
	/// Creates a <typeparamref name="T"/> instance via a single value.
	/// </summary>
	/// <param name="descriptor">The descriptor.</param>
	/// <param name="value">The value.</param>
	/// <returns>The <typeparamref name="T"/> instance.</returns>
	static abstract TSelf Create(ColorDescriptor descriptor, T value);

	/// <summary>
	/// Creates a <typeparamref name="T"/> instance via an array.
	/// </summary>
	/// <param name="descriptor">The descriptor.</param>
	/// <param name="array">The array.</param>
	/// <returns>The <typeparamref name="T"/> instance.</returns>
	static abstract TSelf Create(ColorDescriptor descriptor, T[] array);

	/// <summary>
	/// Creates a <typeparamref name="T"/> instance via a list.
	/// </summary>
	/// <param name="descriptor">The descriptor.</param>
	/// <param name="list">The list.</param>
	/// <returns>The <typeparamref name="T"/> instance.</returns>
	static abstract TSelf Create(ColorDescriptor descriptor, List<T> list);

	/// <summary>
	/// Creates a <typeparamref name="T"/> instance via a hash set.
	/// </summary>
	/// <param name="descriptor">The descriptor.</param>
	/// <param name="hashSet">The hash set.</param>
	/// <returns>The <typeparamref name="T"/> instance.</returns>
	static abstract TSelf Create(ColorDescriptor descriptor, HashSet<T> hashSet);
}

/// <summary>
/// Defines a chunk object.
/// </summary>
/// <typeparam name="TSelf"><include file="../../global-doc-comments.xml" path="/g/self-type-constraint"/></typeparam>
/// <typeparam name="TBitStateMap">The type of bit state map.</typeparam>
/// <typeparam name="T">The type of element.</typeparam>
public interface IChunk<out TSelf, TBitStateMap, T> : IChunk<TSelf, T>
	where TSelf : IChunk<TSelf, TBitStateMap, T>
	where TBitStateMap : unmanaged, IBitStateMap<TBitStateMap, T>
	where T : unmanaged, IBinaryInteger<T>
{
	/// <summary>
	/// Creates a <typeparamref name="T"/> instance via a bit state map.
	/// </summary>
	/// <param name="descriptor">The descriptor.</param>
	/// <param name="map">The map.</param>
	/// <returns>The <typeparamref name="T"/> instance.</returns>
	static abstract TSelf Create(ColorDescriptor descriptor, in TBitStateMap map);
}
