namespace Sudoku.Analytics.BabaGrouping;

/// <summary>
/// Provides a group of <see cref="CellSymbol"/> instances.
/// </summary>
/// <param name="symbols">The symbols.</param>
/// <seealso cref="CellSymbol"/>
public sealed class CellSymbolGroup(params IEnumerable<CellSymbol> symbols) :
	SortedSet<CellSymbol>(symbols),
	IComparable<CellSymbolGroup>,
	IComparisonOperators<CellSymbolGroup, CellSymbolGroup, bool>,
	IEquatable<CellSymbolGroup>,
	IEqualityOperators<CellSymbolGroup, CellSymbolGroup, bool>,
	IFormattable
{
	/// <summary>
	/// Indicates cells used.
	/// </summary>
	public CellMap Cells
	{
		get
		{
			var result = CellMap.Empty;
			foreach (var element in this)
			{
				result += element.Cell;
			}
			return result;
		}
	}

	/// <summary>
	/// Indicates all values used.
	/// </summary>
	public CellSymbolValueGroup Values
	{
		get
		{
			var result = new CellSymbolValueGroup();
			foreach (var element in this)
			{
				result.AddRange(element.Values);
			}
			return result;
		}
	}


	/// <summary>
	/// Indicates the set comparer instance.
	/// </summary>
	private static IEqualityComparer<SortedSet<CellSymbol>> EqualityComparer => field ??= CreateSetComparer();


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] object? obj) => Equals(obj as CellSymbolGroup);

	/// <inheritdoc/>
	public bool Equals([NotNullWhen(true)] CellSymbolGroup? other) => EqualityComparer.Equals(this, other);

	/// <inheritdoc/>
	public override int GetHashCode() => EqualityComparer.GetHashCode(this);

	/// <inheritdoc/>
	public int CompareTo(CellSymbolGroup? other)
	{
		if (other is null)
		{
			return 1;
		}

		using var e1 = GetEnumerator();
		using var e2 = other.GetEnumerator();
		while (true)
		{
			var b1 = e1.MoveNext();
			var b2 = e2.MoveNext();
			if (!b1 || !b2)
			{
				return b1 == b2 ? 0 : b1 ? 1 : -1;
			}
			if (e1.Current.CompareTo(e2.Current) is var result and not 0)
			{
				return result;
			}
		}
	}

	/// <inheritdoc/>
	public override string ToString() => ToString(null);

	/// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
	public string ToString(IFormatProvider? formatProvider)
	{
		// Create a coordinate converter.
		var converter = CoordinateConverter.GetInstance(formatProvider);

		// Group them up by digit.
		var digitDictionary = new SortedDictionary<CellSymbolValueGroup, CellSymbolGroup>();
		foreach (var element in this)
		{
			var values = element.Values;
			if (!digitDictionary.TryAdd(values, [element]))
			{
				digitDictionary[values].Add(element);
			}
		}

		return string.Join(
			", ",
			from value in digitDictionary.Values
			select $"{value.Cells.ToString(converter)} = {value.Values.First}"
		);
	}

	/// <inheritdoc/>
	string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => ToString(formatProvider);


	/// <inheritdoc/>
	public static bool operator ==(CellSymbolGroup? left, CellSymbolGroup? right)
		=> (left, right) switch { (null, null) => true, (not null, not null) => left.Equals(right), _ => false };

	/// <inheritdoc/>
	public static bool operator !=(CellSymbolGroup? left, CellSymbolGroup? right) => !(left == right);

	/// <inheritdoc/>
	public static bool operator >(CellSymbolGroup left, CellSymbolGroup right) => left.CompareTo(right) > 0;

	/// <inheritdoc/>
	public static bool operator <(CellSymbolGroup left, CellSymbolGroup right) => left.CompareTo(right) < 0;

	/// <inheritdoc/>
	public static bool operator >=(CellSymbolGroup left, CellSymbolGroup right) => left.CompareTo(right) >= 0;

	/// <inheritdoc/>
	public static bool operator <=(CellSymbolGroup left, CellSymbolGroup right) => left.CompareTo(right) <= 0;
}
