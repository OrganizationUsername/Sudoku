namespace Sudoku.Analytics.Dependency;

/// <summary>
/// Provides a way to compare equality on two <see cref="DependencyNode"/> instances.
/// </summary>
/// <seealso cref="DependencyNode"/>
public enum DependencyNodeComparison
{
	/// <summary>
	/// Indicates only for the current instance will be checked.
	/// </summary>
	Default,

	/// <summary>
	/// Indicates the current instance and its all ancestors will be checked.
	/// </summary>
	AllAncestors
}
