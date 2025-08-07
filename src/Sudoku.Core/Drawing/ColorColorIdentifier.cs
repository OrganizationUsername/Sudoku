namespace Sudoku.Drawing;

/// <summary>
/// Defines a <see cref="ColorIdentifier"/> derived type that uses color value (like type <c>System.Drawing.Color</c>) to distinct with colors.
/// </summary>
/// <param name="alpha"><inheritdoc cref="Alpha" path="/summary"/></param>
/// <param name="red"><inheritdoc cref="Red" path="/summary"/></param>
/// <param name="green"><inheritdoc cref="Green" path="/summary"/></param>
/// <param name="blue"><inheritdoc cref="Blue" path="/summary"/></param>
[method: JsonConstructor]
public sealed class ColorColorIdentifier(byte alpha, byte red, byte green, byte blue) : ColorIdentifier
{
	/// <summary>
	/// Indicates the color alpha raw values to be assigned.
	/// </summary>
	public byte Alpha { get; } = alpha;

	/// <summary>
	/// Indicates the color red raw values to be assigned.
	/// </summary>
	public byte Red { get; } = red;

	/// <summary>
	/// Indicates the color green raw values to be assigned.
	/// </summary>
	public byte Green { get; } = green;

	/// <summary>
	/// Indicates the color blue raw values to be assigned.
	/// </summary>
	public byte Blue { get; } = blue;


	/// <include file="../../global-doc-comments.xml" path="g/csharp7/feature[@name='deconstruction-method']/target[@name='method']"/>
	public void Deconstruct(out byte r, out byte g, out byte b) => (r, g, b) = (Red, Green, Blue);

	/// <include file="../../global-doc-comments.xml" path="g/csharp7/feature[@name='deconstruction-method']/target[@name='method']"/>
	public void Deconstruct(out byte a, out byte r, out byte g, out byte b) => (a, (r, g, b)) = (Alpha, this);

	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] ColorIdentifier? other)
		=> other is ColorColorIdentifier comparer && GetHashCode() == comparer.GetHashCode();

	/// <inheritdoc/>
	public override int GetHashCode() => Alpha << 24 | Red << 16 | Green << 8 | Blue;

	/// <inheritdoc/>
	public override string ToString()
		=> $"{nameof(ColorColorIdentifier)} {{ {nameof(Alpha)} = {Alpha}, {nameof(Red)} = {Red}, {nameof(Green)} = {Green}, {nameof(Blue)} = {Blue} }}";
}
