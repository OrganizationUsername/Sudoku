namespace Sudoku.Analytics.Construction.Components;

/// <summary>
/// Represents the base dictionary type of <see cref="AlmostLockedSetLookup"/>.
/// </summary>
/// <param name="comparer"><inheritdoc cref="SortedDictionary{TKey, TValue}(IComparer{TKey}?)" path="/param[@name='comparer']"/></param>
/// <seealso cref="AlmostLockedSetLookup"/>
public sealed class AlmostLockedSetLookupBase(IComparer<HouseDigitIdentifier>? comparer) :
	SortedDictionary<HouseDigitIdentifier, HashSet<(AlmostLockedSetPattern Pattern, House SharedHouse)>>(comparer);
