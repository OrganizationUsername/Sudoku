namespace Sudoku.Reasoning;

/// <summary>
/// Represents reasoning hub type.
/// </summary>
internal abstract class ReasoningHubBase
{
	/// <summary>
	/// Indicates supported step searcher types.
	/// </summary>
	public abstract ReadOnlyMemory<Type> SupportedStepSearcherTypes { get; }


	/// <inheritdoc cref="ReadOnlySpan{T}.Equals"/>
	[Obsolete("This type should not compare equality and get hash code.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed override bool Equals(object? obj) => throw new NotSupportedException();

	/// <inheritdoc cref="ReadOnlySpan{T}.Equals"/>
	[Obsolete("This type should not compare equality and get hash code.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed override int GetHashCode() => throw new NotSupportedException();

	/// <inheritdoc cref="ReadOnlySpan{T}.Equals"/>
	[Obsolete("This type should not be used by invoking 'ToString' method.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed override string ToString() => throw new NotSupportedException();
}
