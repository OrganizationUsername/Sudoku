namespace Sudoku.Analytics.Ranking;

/// <summary>
/// Represents a house truth.
/// </summary>
[TypeImpl(TypeImplFlags.Object_GetHashCode)]
public sealed partial class HouseTruth : RankSet
{
	/// <summary>
	/// Initializes a <see cref="HouseTruth"/> instance.
	/// </summary>
	/// <param name="house">Indicataes the house.</param>
	/// <param name="digit">Indicates the digit.</param>
	internal HouseTruth(House house, Digit digit) => (House, Digit) = (house, digit);


	/// <inheritdoc/>
	public override RankSetType Type => RankSetType.HouseTruth;

	/// <summary>
	/// Indicates the house.
	/// </summary>
	[HashCodeMember]
	public House House { get; }

	/// <summary>
	/// Indicates the digit.
	/// </summary>
	[HashCodeMember]
	public Digit Digit { get; }


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] RankSet? other)
		=> other is HouseTruth comparer && Type == comparer.Type && House == comparer.House && Digit == comparer.Digit;

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
		if (House.CompareTo(((HouseTruth)other).House) is var r2 and not 0)
		{
			return r2;
		}
		return Digit.CompareTo(((HouseTruth)other).Digit);
	}

	/// <inheritdoc/>
	public override string ToString()
		=> (
			House switch
			{
				< 9 => Space.BlockNumber(House, Digit),
				< 18 => Space.RowNumber(House, Digit),
				_ => Space.ColumnNumber(House, Digit)
			}
		).ToString();
}
