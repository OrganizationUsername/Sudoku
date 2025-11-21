namespace Sudoku.Analytics.BabaGrouping;

/// <summary>
/// Provides a group of <see cref="CellSymbolValue"/> instances.
/// </summary>
/// <param name="values">The values.</param>
/// <seealso cref="CellSymbolValue"/>
public sealed class CellSymbolValueGroup(params IEnumerable<CellSymbolValue> values) :
	SortedSet<CellSymbolValue>(values),
	IComparable<CellSymbolValueGroup>,
	IComparisonOperators<CellSymbolValueGroup, CellSymbolValueGroup, bool>,
	IEquatable<CellSymbolValueGroup>,
	IEqualityOperators<CellSymbolValueGroup, CellSymbolValueGroup, bool>
{
	/// <summary>
	/// Indicates the first element in this collection.
	/// </summary>
	/// <exception cref="InvalidOperationException">Throws when the current collection is empty.</exception>
	public CellSymbolValue First
	{
		get
		{
			using var enumerator = GetEnumerator();
			return enumerator.MoveNext()
				? enumerator.Current
				: throw new InvalidOperationException("The sequence has no elements.");
		}
	}


	/// <summary>
	/// Indicates the set comparer instance.
	/// </summary>
	private static IEqualityComparer<SortedSet<CellSymbolValue>> EqualityComparer => field ??= CreateSetComparer();


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] object? obj) => Equals(obj as CellSymbolValueGroup);

	/// <inheritdoc/>
	public bool Equals([NotNullWhen(true)] CellSymbolValueGroup? other) => EqualityComparer.Equals(this, other);

	/// <inheritdoc/>
	public override int GetHashCode() => EqualityComparer.GetHashCode(this);

	/// <summary>
	/// Add a list of values into the current collection.
	/// </summary>
	/// <param name="values">The values.</param>
	/// <returns>The number of elements added.</returns>
	public int AddRange(params CellSymbolValueGroup values)
	{
		var result = 0;
		foreach (var value in values)
		{
			if (Add(value))
			{
				result++;
			}
		}
		return result;
	}

	/// <inheritdoc/>
	public int CompareTo(CellSymbolValueGroup? other)
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
	public override string ToString()
		=> ToString(
			SR.IsEnglish(CultureInfo.CurrentUICulture)
				? BabaGroupInitialLetter.EnglishLetter_X
				: BabaGroupInitialLetter.EnglishLetter_A,
			BabaGroupLetterCase.Lower
		);

	/// <summary>
	/// Returns a string that represents the current instance.
	/// </summary>
	/// <param name="initialLetter">The initial letter.</param>
	/// <param name="case">The letter case.</param>
	/// <returns>A string that represents the current instance.</returns>
	/// <exception cref="InvalidOperationException">Throws when the collection contains invalid data.</exception>
	public string ToString(BabaGroupInitialLetter initialLetter, BabaGroupLetterCase @case)
	{
		var sb = new StringBuilder();
		foreach (var item in this)
		{
			sb.Append(
				item == CellSymbolValue.Invalid
					? throw new InvalidOperationException("Cannot perform to-string operation because of invalid data encountered.")
					: initialLetter.GetSequence(@case)[item.Index]
			);
		}
		return sb.ToString();
	}


	/// <inheritdoc/>
	public static bool operator ==(CellSymbolValueGroup? left, CellSymbolValueGroup? right)
		=> (left, right) switch { (null, null) => true, (not null, not null) => left.Equals(right), _ => false };

	/// <inheritdoc/>
	public static bool operator !=(CellSymbolValueGroup? left, CellSymbolValueGroup? right) => !(left == right);

	/// <inheritdoc/>
	public static bool operator >(CellSymbolValueGroup left, CellSymbolValueGroup right) => left.CompareTo(right) > 0;

	/// <inheritdoc/>
	public static bool operator <(CellSymbolValueGroup left, CellSymbolValueGroup right) => left.CompareTo(right) < 0;

	/// <inheritdoc/>
	public static bool operator >=(CellSymbolValueGroup left, CellSymbolValueGroup right) => left.CompareTo(right) >= 0;

	/// <inheritdoc/>
	public static bool operator <=(CellSymbolValueGroup left, CellSymbolValueGroup right) => left.CompareTo(right) <= 0;
}
