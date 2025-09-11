namespace System.Linq;

/// <summary>
/// Represents LINQ methods used by <see cref="LinkedList{T}"/>.
/// </summary>
/// <seealso cref="LinkedList{T}"/>
public static class LinkedListEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="LinkedList{T}"/> of <typeparamref name="T"/>.
	/// </summary>
	extension<T>(LinkedList<T> @this)
	{
		/// <summary>
		/// Projects each element into a new form.
		/// </summary>
		/// <typeparam name="TResult">The type of the transformed value.</typeparam>
		/// <param name="selector">The function to transform items.</param>
		/// <returns>The projected values.</returns>
		public ReadOnlySpan<TResult> Select<TResult>(Func<T, TResult> selector)
		{
			var result = new TResult[@this.Count];
			var i = 0;
			foreach (var element in @this)
			{
				result[i++] = selector(element);
			}
			return result;
		}

		/// <summary>
		/// Reverse the enumeration on <see cref="LinkedList{T}"/>.
		/// </summary>
		/// <returns>The reversed enumerator-provider instance.</returns>
		public LinkedListReversed<T> Reverse() => new(@this);
	}

	/// <summary>
	/// Provides extension members on <see cref="LinkedListReversed{T}"/> of <typeparamref name="T"/>.
	/// </summary>
	extension<T>(LinkedListReversed<T> @this)
	{
		/// <inheritdoc cref="Select{T, TResult}(LinkedList{T}, Func{T, TResult})"/>
		public ReadOnlySpan<TResult> Select<TResult>(Func<T, TResult> selector)
		{
			var result = new TResult[@this.Count];
			var i = 0;
			foreach (var element in @this)
			{
				result[i++] = selector(element);
			}
			return result;
		}
	}
}
