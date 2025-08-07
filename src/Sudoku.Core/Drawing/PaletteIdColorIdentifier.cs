namespace Sudoku.Drawing;

/// <summary>
/// Defines a <see cref="ColorIdentifier"/> derived type that uses palette ID value to distinct with colors.
/// </summary>
/// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
[method: JsonConstructor]
public sealed class PaletteIdColorIdentifier(int value) : ColorIdentifier
{
	/// <summary>
	/// The palette color ID value to be assigned. The color palette requires implementation of target projects.
	/// </summary>
	public int Value { get; } = value;


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] ColorIdentifier? other)
		=> other is PaletteIdColorIdentifier comparer && Value == comparer.Value;

	/// <inheritdoc/>
	public override int GetHashCode() => Value;

	/// <inheritdoc/>
	public override string ToString() => Value.ToString();
}
