namespace SudokuStudio.Collection;

/// <summary>
/// Represents a color palette that contains a list of <see cref="Color"/> instances that can be used in UI binding.
/// </summary>
public sealed class ColorPalette :
	ObservableCollection<Color>,
	IEquatable<ColorPalette>,
	IEqualityOperators<ColorPalette, ColorPalette, bool>
{
	/// <inheritdoc cref="object.Equals(object?)"/>
	public override bool Equals([NotNullWhen(true)] object? obj) => Equals(obj as ColorPalette);

	/// <inheritdoc/>
	public bool Equals([NotNullWhen(true)] ColorPalette? other)
	{
		if (other is null)
		{
			return false;
		}

		if (Count != other.Count)
		{
			return false;
		}

		for (var i = 0; i < Count; i++)
		{
			if (this[i] != other[i])
			{
				return false;
			}
		}
		return true;
	}

	/// <inheritdoc/>
	public override int GetHashCode()
	{
		var result = default(HashCode);
		foreach (var element in this)
		{
			result.Add(element);
		}
		return result.ToHashCode();
	}

	/// <inheritdoc cref="object.ToString"/>
	public override string ToString() => $"[{string.Join(", ", this)}]";


	/// <inheritdoc/>
	public static bool operator ==(ColorPalette? left, ColorPalette? right)
		=> (left, right) switch { (null, null) => true, (not null, not null) => left.Equals(right), _ => false };

	/// <inheritdoc/>
	public static bool operator !=(ColorPalette? left, ColorPalette? right) => !(left == right);
}
