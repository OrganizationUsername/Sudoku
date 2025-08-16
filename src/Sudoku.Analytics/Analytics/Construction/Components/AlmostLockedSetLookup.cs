namespace Sudoku.Analytics.Construction.Components;

/// <summary>
/// Represents a lookup table of Almost Locked Sets, grouped by house and digit.
/// </summary>
public sealed class AlmostLockedSetLookup() : IComponent
{
	/// <summary>
	/// Represents row view.
	/// </summary>
	public AlmostLockedSetLookupBase RowView { get; } = new(KeyComparer);

	/// <summary>
	/// Represents column view.
	/// </summary>
	public AlmostLockedSetLookupBase ColumnView { get; } = new(KeyComparer);

	/// <inheritdoc/>
	ComponentType IComponent.Type => ComponentType.AlmostLockedSetDictionary;


	/// <summary>
	/// Represents key comparer.
	/// </summary>
	private static IComparer<HouseDigitIdentifier> KeyComparer
		=> field ??= Comparer<HouseDigitIdentifier>.Create(
			static (left, right) =>
			{
				var l = left.House * 9 + left.Digit;
				var r = right.House * 9 + right.Digit;
				return l.CompareTo(r);
			}
		);


	/// <summary>
	/// Returns the entry of the key.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <returns>The hash set entry.</returns>
	public HashSet<(AlmostLockedSetPattern Pattern, House SharedHouse)> this[HouseDigitIdentifier key]
		=> (
			key.House.HouseType switch
			{
				HouseType.Row => RowView,
				_ => ColumnView
			}
		)[key];


	/// <inheritdoc cref="Dictionary{TKey, TValue}.TryAdd(TKey, TValue)"/>
	public bool TryAdd(HouseDigitIdentifier key, HashSet<(AlmostLockedSetPattern, House)> value)
	{
		if (RowView.ContainsKey(key) || ColumnView.ContainsKey(key))
		{
			return false;
		}

		Add(key, value);
		return true;
	}

	/// <inheritdoc cref="SortedDictionary{TKey, TValue}.Add(TKey, TValue)"/>
	public void Add(HouseDigitIdentifier key, HashSet<(AlmostLockedSetPattern, House)> value)
		=> (
			key.House.HouseType switch
			{
				HouseType.Row => RowView,
				_ => ColumnView
			}
		).Add(key, value);
}
