namespace Sudoku.Analytics.Ranking;

/// <summary>
/// Represents a rank set.
/// </summary>
[TypeImpl(
	TypeImplFlags.AllObjectMethods | TypeImplFlags.AllEqualityComparisonOperators,
	OtherModifiersOnEquals = "sealed",
	GetHashCodeBehavior = GetHashCodeBehavior.MakeAbstract,
	ToStringBehavior = ToStringBehavior.MakeAbstract)]
public abstract partial class RankSet :
	IComparable<RankSet>,
	IComparisonOperators<RankSet, RankSet, bool>,
	IEquatable<RankSet>,
	IEqualityOperators<RankSet, RankSet, bool>
{
	/// <summary>
	/// Indicates whether the rank set is truth. Generally the value is negated from <see cref="IsLink"/>.
	/// </summary>
	/// <seealso cref="IsLink"/>
	public bool IsTruth => Type is RankSetType.CellTruth or RankSetType.HouseTruth;

	/// <summary>
	/// Indicates whether the rank set is link. Generally the value is negated from <see cref="IsTruth"/>.
	/// </summary>
	/// <seealso cref="IsTruth"/>
	public bool IsLink => Type is RankSetType.CellLink or RankSetType.HouseLink;

	/// <summary>
	/// Indicates the type.
	/// </summary>
	public abstract RankSetType Type { get; }


	/// <inheritdoc/>
	public abstract bool Equals([NotNullWhen(true)] RankSet? other);

	/// <inheritdoc/>
	public abstract int CompareTo(RankSet? other);
}
