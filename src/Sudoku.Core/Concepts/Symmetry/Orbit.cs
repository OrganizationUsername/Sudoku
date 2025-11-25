namespace Sudoku.Concepts.Symmetry;

/// <summary>
/// Defines a type that is transparent encapsulation of a <see cref="CellMap"/> instance,
/// representing cells defined in a symmetry field.
/// </summary>
/// <param name="Cells">Indicates the cells.</param>
/// <seealso cref="CellMap"/>
[CollectionBuilder(typeof(Orbit), nameof(Create))]
public readonly record struct Orbit(in CellMap Cells) : IEnumerable<Cell>, IEqualityOperators<Orbit, Orbit, bool>
{
	/// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
	public AnonymousSpanEnumerator<Cell> GetEnumerator() => Cells.GetEnumerator();

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Cells).GetEnumerator();

	/// <inheritdoc/>
	IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator() => ((IEnumerable<Cell>)Cells).GetEnumerator();


	/// <summary>
	/// Creates an <see cref="Orbit"/> instance via a list of cells.
	/// </summary>
	/// <param name="cells">The cells.</param>
	/// <returns>Result instance.</returns>
	public static Orbit Create(params ReadOnlySpan<Cell> cells) => new(cells.AsCellMap());


	/// <summary>
	/// Explicit cast from <see cref="CellMap"/> to <see cref="Orbit"/>.
	/// </summary>
	/// <param name="value">The value.</param>
	public static explicit operator Orbit(in CellMap value) => new(value);

	/// <summary>
	/// Implicit cast from <see cref="Orbit"/> to <see cref="CellMap"/>.
	/// </summary>
	/// <param name="value">The value.</param>
	public static implicit operator CellMap(in Orbit value) => value.Cells;
}
