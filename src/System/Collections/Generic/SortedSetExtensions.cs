namespace System.Collections.Generic;

/// <summary>
/// Provides with extension methods on <see cref="SortedSet{T}"/>.
/// </summary>
/// <seealso cref="SortedSet{T}"/>
public static class SortedSetExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each value.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(SortedSet<T> @this)
	{
		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="values">The elements to be added.</param>
		/// <returns>The number of elements successfully to be added.</returns>
		public int AddRange(params ReadOnlySpan<T> values)
		{
			var result = 0;
			foreach (var element in values)
			{
				if (@this.Add(element))
				{
					result++;
				}
			}
			return result;
		}

		/// <summary>
		/// Try to convert the current instance into an array.
		/// </summary>
		/// <returns>An array of <typeparamref name="T"/> elements.</returns>
		public T[] ToArray()
		{
			var result = new T[@this.Count];
			@this.CopyTo(result);
			return result;
		}
	}
}
