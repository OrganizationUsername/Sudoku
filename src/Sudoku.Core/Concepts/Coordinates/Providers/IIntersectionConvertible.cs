namespace Sudoku.Concepts.Coordinates.Providers;

/// <summary>
/// Represents an intersection converter.
/// </summary>
[Obsolete($"Use '{nameof(ISegmentConvertible)}' instead.", false)]
public interface IIntersectionConvertible
{
	/// <summary>
	/// The converter method that creates a <see cref="string"/> via the specified information for an intersection.
	/// </summary>
	Func<ReadOnlySpan<Miniline>, string> IntersectionConverter { get; }
}
