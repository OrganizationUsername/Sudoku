namespace SudokuStudio.Drawing;

/// <summary>
/// Provides a type that supports drawing.
/// </summary>
public readonly union DrawableConcept(ViewNode, GroupedNodeInfo, CandidateMap, Conclusion)
{
	/// <inheritdoc cref="object.ToString"/>
	public override string ToString() => Value is not null ? $"{Value.GetType()} ({Value})" : string.Empty;
}
