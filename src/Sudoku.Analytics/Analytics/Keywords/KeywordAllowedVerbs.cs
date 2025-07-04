namespace Sudoku.Analytics.Keywords;

/// <summary>
/// Represents an attribute that describes a keyword allowing filtering verbs.
/// </summary>
/// <param name="verbs">Indicates allowed verbs.</param>
[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public sealed class KeywordAllowedVerbsAttribute(params KeywordVerb[] verbs) : KeywordConditionAttribute
{
	/// <summary>
	/// Indicates all allowed verbs.
	/// </summary>
	public ReadOnlySpan<KeywordVerb> Verbs => verbs;
}
