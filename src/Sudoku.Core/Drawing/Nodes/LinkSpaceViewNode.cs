namespace Sudoku.Drawing.Nodes;

/// <summary>
/// Represents link view node.
/// </summary>
/// <param name="identifier"><inheritdoc cref="SetViewNode(ColorIdentifier, Space)" path="/param[@name='identifier']"/></param>
/// <param name="space"><inheritdoc cref="SetViewNode(ColorIdentifier, Space)" path="/param[@name='space']"/></param>
public sealed class LinkSpaceViewNode(ColorIdentifier identifier, Space space) : SetViewNode(identifier, space)
{
	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] ViewNode? other)
		=> base.Equals(other) && other is LinkSpaceViewNode comparer && Space == comparer.Space;

	/// <inheritdoc/>
	public override LinkSpaceViewNode Clone() => new(Identifier, Space);
}
