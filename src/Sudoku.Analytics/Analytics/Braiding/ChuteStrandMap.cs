namespace Sudoku.Analytics.Braiding;

/// <summary>
/// Represents a pair of <see cref="CellMap"/> indicating used and unused cells in a chute.
/// </summary>
/// <param name="included"><inheritdoc cref="Included" path="/summary"/></param>
/// <param name="excluded"><inheritdoc cref="Excluded" path="/summary"/></param>
public readonly struct ChuteStrandMap(in CellMap included, in CellMap excluded)
{
	/// <summary>
	/// Indicates cells contained for a certain type of braid mode in a chute.
	/// </summary>
	public readonly CellMap Included = included;

	/// <summary>
	/// Indicates cells not contained for a certain type of braid mode in a chute.
	/// </summary>
	public readonly CellMap Excluded = excluded;


	/// <inheritdoc cref="object.ToString"/>
	public override string ToString()
		=> $$"""{{nameof(ChuteStrandMap)}} { {{nameof(Included)}} = {{Included}}, {{nameof(Excluded)}} = {{Excluded}} }""";
}
