namespace Sudoku.Generating;

/// <summary>
/// Represents data that will be reported in progress, invoked by <see cref="IProgress{T}.Report(T)"/>.
/// </summary>
/// <typeparam name="TSelf"><include file="../../global-doc-comments.xml" path="/g/self-type-constraint"/></typeparam>
/// <seealso cref="IProgress{T}.Report(T)"/>
public interface IProgressDataProvider<TSelf>
	where TSelf : struct, IEquatable<TSelf>, IProgressDataProvider<TSelf>, allows ref struct
{
	/// <summary>
	/// Indicates the number of puzzles having been generated.
	/// </summary>
	int Count { get; init; }


	/// <summary>
	/// Try to fetch display string for the current instance.
	/// </summary>
	/// <returns>The display string.</returns>
	string ToDisplayString();


	/// <summary>
	/// Try to create a <typeparamref name="TSelf"/> instance.
	/// </summary>
	/// <param name="count">The number of puzzles generated.</param>
	/// <param name="succeeded">The number of puzzles has passed the checking.</param>
	/// <returns>A <typeparamref name="TSelf"/> instance.</returns>
	static abstract TSelf Create(int count, int succeeded);
}
