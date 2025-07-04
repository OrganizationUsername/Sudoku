namespace Sudoku.Analytics.Keywords;

/// <summary>
/// Represents a verb of keyword filtering rule.
/// </summary>
public enum KeywordVerb
{
	/// <summary>
	/// The placeholder of the verb enumeration type.
	/// </summary>
	None = 0,

	/// <summary>
	/// Indicates the verb is to compare string equality.
	/// </summary>
	StringEquality = 101,

	/// <summary>
	/// Indicates the verb is to check regular expression pattern of a string.
	/// </summary>
	StringPattern,

	/// <summary>
	/// Indicates the verb is to compare Number equality.
	/// </summary>
	NumberEquality = 201,

	/// <summary>
	/// Indicates the verb is to compare Number inequality.
	/// </summary>
	NumberInequality,

	/// <summary>
	/// Indicates the verb is to check whether a Number is in a range.
	/// </summary>
	NumberRange
}
