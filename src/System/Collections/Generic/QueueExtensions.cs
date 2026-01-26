namespace System.Collections.Generic;

/// <summary>
/// Provides with extension methods on <see cref="Queue{T}"/>.
/// </summary>
/// <seealso cref="Queue{T}"/>
public static class QueueExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension<T>(Queue<T> @this)
	{
		/// <inheritdoc cref="Enumerable.Reverse{TSource}(IEnumerable{TSource})" />
		[Obsolete(DeprecatedMessages.ExtensionOperator_Reverse, false)]
		public Queue<T> Reverse() => ~@this;


		/// <inheritdoc cref="Enumerable.Reverse{TSource}(IEnumerable{TSource})" />
		public static Queue<T> operator ~(Queue<T> value)
		{
			var result = new Queue<T>();
			var stack = new Stack<T>(value);
			while (stack.Count != 0)
			{
				result.Enqueue(stack.Pop());
			}
			return result;
		}
	}
}
