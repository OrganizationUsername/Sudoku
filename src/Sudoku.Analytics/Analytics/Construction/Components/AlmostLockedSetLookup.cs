namespace Sudoku.Analytics.Construction.Components;

/// <summary>
/// Represents a lookup table of Almost Locked Sets, grouped by house and digit.
/// </summary>
public sealed class AlmostLockedSetLookup() : AlmostLockedSetLookupBase(KeyComparer), IComponent
{
	/// <summary>
	/// Represents block view.
	/// </summary>
	public AlmostLockedSetLookupBase BlockView { get; } = new(KeyComparer);

	/// <summary>
	/// Represents line view.
	/// </summary>
	public AlmostLockedSetLookupBase LineView { get; } = new(KeyComparer);

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


	/// <inheritdoc cref="Dictionary{TKey, TValue}.TryAdd(TKey, TValue)"/>
	public bool TryAdd(HouseDigitIdentifier key, HashSet<(AlmostLockedSetPattern, House)> value)
	{
		if (ContainsKey(key))
		{
			return false;
		}

		Add(key, value);
		return true;
	}

	/// <inheritdoc cref="SortedDictionary{TKey, TValue}.Add(TKey, TValue)"/>
	public new void Add(HouseDigitIdentifier key, HashSet<(AlmostLockedSetPattern, House)> value)
	{
		base.Add(key, value);
		(key.House < 9 ? BlockView : LineView).Add(key, value);
	}
}
