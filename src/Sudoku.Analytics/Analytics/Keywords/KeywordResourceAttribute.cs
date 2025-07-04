namespace Sudoku.Analytics.Keywords;

/// <summary>
/// Represents an attribute type that describes the resource of a keyword.
/// </summary>
/// <param name="nameResourceKey"><inheritdoc cref="NameResourceKey" path="/summary"/></param>
[AttributeUsage(AttributeTargets.Property, Inherited = false)]
[method: SetsRequiredMembers]
public sealed class KeywordResourceAttribute(string nameResourceKey) :
	KeywordConditionAttribute,
	IKeywordConditionDefaultValue<KeywordResourceAttribute>
{
	/// <summary>
	/// Indicates the name resource key.
	/// </summary>
	public required string NameResourceKey { get; init; } = nameResourceKey;

	/// <summary>
	/// Indicates the description resource key to the property. By default it's <see langword="null"/>.
	/// </summary>
	public string? DescriptionResourceKey { get; init; }


	/// <inheritdoc/>
	static KeywordResourceAttribute IKeywordConditionDefaultValue<KeywordResourceAttribute>.DefaultValue => new("DefaultName");
}
