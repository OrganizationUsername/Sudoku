namespace System.Linq;

/// <summary>
/// Represents LINQ methods used by <see cref="LinkedList{T}"/>.
/// </summary>
/// <seealso cref="LinkedList{T}"/>
public static class LinkedListEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<T>(LinkedList<T> source)
	{
		/// <summary>
		/// Projects each element into a new form.
		/// </summary>
		/// <typeparam name="TResult">The type of the transformed value.</typeparam>
		/// <param name="selector">The function to transform items.</param>
		/// <returns>The projected values.</returns>
		public ReadOnlySpan<TResult> Select<TResult>(Func<T, TResult> selector)
		{
			var result = new TResult[source.Count];
			var i = 0;
			foreach (var element in source)
			{
				result[i++] = selector(element);
			}
			return result;
		}

		/// <summary>
		/// Reverse the enumeration on <see cref="LinkedList{T}"/>.
		/// </summary>
		/// <returns>The reversed enumerator-provider instance.</returns>
		public LinkedListReversed<T> Reverse() => new(source);
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<T>(LinkedListReversed<T> source)
	{
		/// <inheritdoc cref="Select{T, TResult}(LinkedList{T}, Func{T, TResult})"/>
		public ReadOnlySpan<TResult> Select<TResult>(Func<T, TResult> selector)
		{
			var result = new TResult[source.Count];
			var i = 0;
			foreach (var element in source)
			{
				result[i++] = selector(element);
			}
			return result;
		}
	}
}
