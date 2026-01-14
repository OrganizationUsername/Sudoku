namespace Sudoku.Analytics.Braiding;

/// <summary>
/// <para>Represents a strand.</para>
/// <para>
/// A <b>Strand</b> is a distribution pattern for a single digit in 3 of the 9 intersections aligned in a chute.
/// There are 6 different strands in each chute.
/// </para>
/// </summary>
/// <param name="ChuteIndex">Indicates chute index (0..6).</param>
/// <param name="SequenceIndex">Indicates sequence index (0..3).</param>
/// <param name="Type">Indicates type of rotation.</param>
/// <remarks>For more information, please visit <see href="http://sudopedia.enjoysudoku.com/Strand.html">this link</see>.</remarks>
public readonly record struct Strand(int ChuteIndex, Digit SequenceIndex, StrandType Type)
{
	/// <summary>
	/// Indicates global sequence index.
	/// </summary>
	public Digit GlobalSequenceIndex => ChuteIndex % 3 * 3 + SequenceIndex;


	/// <inheritdoc cref="object.ToString"/>
	public override string ToString() => $"{(ChuteIndex > 3 ? 'T' : 'F')}{GlobalSequenceIndex + 1}{(Type == StrandType.Upside ? 'Z' : 'N')}";
}
