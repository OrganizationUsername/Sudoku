namespace Sudoku.Analytics.Keywords;

/// <summary>
/// Represents default value of a keyword condition.
/// </summary>
/// <typeparam name="TSelf">The type of keyword condition attribute.</typeparam>
public interface IKeywordConditionDefaultValue<TSelf>
	where TSelf : KeywordConditionAttribute, IKeywordConditionDefaultValue<TSelf>
{
	/// <summary>
	/// Indicates the default value of the instance.
	/// </summary>
	public static abstract TSelf DefaultValue { get; }
}
