namespace Sudoku.Analytics.Construction.Components;

using AlmostLockedSetLookupBase = SortedDictionary<(House House, Digit Digit), List<(AlmostLockedSetPattern Pattern, House SharedHouse)>>;

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
	private static IComparer<(House, Digit)> KeyComparer
		=> field ??= Comparer<(House House, Digit Digit)>.Create(
			static (left, right) =>
			{
				var l = left.House * 9 + left.Digit;
				var r = right.House * 9 + right.Digit;
				return l.CompareTo(r);
			}
		);


	/// <inheritdoc cref="Dictionary{TKey, TValue}.TryAdd(TKey, TValue)"/>
	public bool TryAdd((House, Digit) key, List<(AlmostLockedSetPattern, House)> value)
	{
		if (ContainsKey(key))
		{
			return false;
		}

		Add(key, value);
		return true;
	}

	/// <inheritdoc cref="SortedDictionary{TKey, TValue}.Add(TKey, TValue)"/>
	public new void Add((House, Digit) key, List<(AlmostLockedSetPattern, House)> value)
	{
		base.Add(key, value);
		(key.Item1 < 9 ? BlockView : LineView).Add(key, value);
	}
}
