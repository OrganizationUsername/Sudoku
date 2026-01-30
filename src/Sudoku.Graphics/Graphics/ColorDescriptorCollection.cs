namespace Sudoku.Graphics;

/// <summary>
/// Represents a list of <see cref="ColorDescriptor"/> instances.
/// </summary>
/// <seealso cref="ColorDescriptor"/>
public sealed class ColorDescriptorCollection : List<ColorDescriptor>, ISliceMethod<ColorDescriptorCollection, ColorDescriptor>
{
	/// <inheritdoc cref="List{T}.Slice(int, int)"/>
	public new ColorDescriptorCollection Slice(int start, int length) => [.. base.Slice(start, length)];

	/// <inheritdoc/>
	IEnumerable<ColorDescriptor> ISliceMethod<ColorDescriptorCollection, ColorDescriptor>.Slice(int start, int count)
		=> Slice(start, count);
}
