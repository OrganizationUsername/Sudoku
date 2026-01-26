namespace System.Linq;

/// <summary>
/// Provides with extension methods on <see cref="IEnumerable{T}"/> instances.
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class EnumerableExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element.</typeparam>
	extension<T>(IEnumerable<T>)
	{
		/// <summary>
		/// Concats two collection.
		/// </summary>
		/// <param name="left">The left instance.</param>
		/// <param name="right">The right instance.</param>
		/// <returns>The result.</returns>
		[OverloadResolutionPriority(-1)]
		public static IEnumerable<T> operator +(IEnumerable<T> left, IEnumerable<T> right) => Enumerable.Concat(left, right);

		/// <summary>
		/// Performs aggregate function.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="aggregateFunc">Aggregate function.</param>
		/// <returns>The result.</returns>
		public static T operator *(IEnumerable<T> value, Func<T, T, T> aggregateFunc) => value.Aggregate(aggregateFunc);
	}
}
