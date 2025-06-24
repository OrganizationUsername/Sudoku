namespace Sudoku.Drawing.Nodes;

/// <summary>
/// Represents a set (truth or link) view node.
/// </summary>
/// <param name="identifier"><inheritdoc cref="ViewNode.Identifier" path="/summary"/></param>
/// <param name="space"><inheritdoc cref="Space" path="/summary"/></param>
[TypeImpl(
	TypeImplFlags.Object_GetHashCode | TypeImplFlags.Object_ToString,
	OtherModifiersOnGetHashCode = "sealed",
	OtherModifiersOnToString = "sealed")]
public abstract partial class SetViewNode(ColorIdentifier identifier, Space space) : ViewNode(identifier)
{
	/// <summary>
	/// Indicates the space.
	/// </summary>
	[HashCodeMember]
	[StringMember]
	public Space Space { get; } = space;
}
