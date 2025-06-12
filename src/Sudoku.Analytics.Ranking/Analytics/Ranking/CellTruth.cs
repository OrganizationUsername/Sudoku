namespace Sudoku.Analytics.Ranking;

/// <summary>
/// Represents a cell truth.
/// </summary>
[TypeImpl(TypeImplFlags.Object_GetHashCode)]
public sealed partial class CellTruth : RankSet
{
	/// <summary>
	/// Initializes a <see cref="CellTruth"/> instance.
	/// </summary>
	/// <param name="cell">The cell.</param>
	internal CellTruth(Cell cell) => Cell = cell;


	/// <inheritdoc/>
	public override RankSetType Type => RankSetType.CellTruth;

	/// <summary>
	/// Indicates the target cell.
	/// </summary>
	[HashCodeMember]
	public Cell Cell { get; }


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] RankSet? other)
		=> other is CellTruth comparer && Type == comparer.Type && Cell == comparer.Cell;

	/// <inheritdoc/>
	public override int CompareTo(RankSet? other)
	{
		if (other is null)
		{
			return 1;
		}
		if (Type.CompareTo(other.Type) is var r1 and not 0)
		{
			return r1;
		}
		return Cell.CompareTo(((CellTruth)other).Cell);
	}

	/// <inheritdoc/>
	public override string ToString() => Space.RowColumn(Cell / 9, Cell % 9).ToString();
}
