namespace System.Runtime.CompilerServices;

/// <summary>
/// Provides with extension methods on <see cref="ITuple"/>.
/// </summary>
/// <seealso cref="ITuple"/>
public static class TupleExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(ITuple @this)
	{
		/// <summary>
		/// Converts the tuple elements into a valid span of elements of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The unified type for all elements.</typeparam>
		/// <returns>A <see cref="ReadOnlySpan{T}"/> instance.</returns>
		public ReadOnlySpan<T> AsSpan<T>()
		{
			var result = new T[@this.Length];
			var i = 0;
			foreach (var element in @this)
			{
				result[i++] = (T)element!;
			}
			return result;
		}
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TTuple">The type of instance.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<TTuple>(TTuple @this) where TTuple : ITuple?, allows ref struct
	{
		/// <summary>
		/// Converts the <see cref="ITuple"/> instance into an array of objects.
		/// </summary>
		/// <returns>The array of elements.</returns>
		public object?[] ToArray()
		{
			if (@this is not { Length: var length and not 0 })
			{
				return [];
			}

			var result = new object?[length];
			var i = 0;
			foreach (var element in @this)
			{
				result[i++] = element;
			}
			return result;
		}

		/// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
		public TupleEnumerator<TTuple> GetEnumerator() => new(@this);
	}
}
