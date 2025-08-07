namespace Sudoku.Drawing;

/// <summary>
/// Defines a <see cref="ColorIdentifier"/> derived type that uses well-known kinds to distinct with colors.
/// </summary>
/// <param name="kind"><inheritdoc cref="Kind" path="/summary"/></param>
[method: JsonConstructor]
public sealed class WellKnownColorIdentifier(WellKnownColorIdentifierKind kind) : ColorIdentifier
{
	/// <summary>
	/// The well-known identifier kind to be assigned.
	/// </summary>
	public WellKnownColorIdentifierKind Kind { get; } = kind;


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] ColorIdentifier? other)
		=> other is WellKnownColorIdentifier comparer && Kind == comparer.Kind;

	/// <inheritdoc/>
	public override int GetHashCode() => (int)Kind;

	/// <inheritdoc/>
	public override string ToString() => Kind.ToString();
}
