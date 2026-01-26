namespace System;

/// <summary>
/// Represents with extension methods for value tuple type set.
/// </summary>
public static class ValueTupleExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element in tuple.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(scoped in (T, T) @this)
	{
		/// <summary>
		/// Casts the current instance into a <see cref="ReadOnlySpan{T}"/>.
		/// </summary>
		/// <returns>The <see cref="ReadOnlySpan{T}"/> instance.</returns>
		public ReadOnlySpan<T> AsSpan() => (T[])[@this.Item1, @this.Item2];

		/// <summary>
		/// Gets an <see cref="ValueTupleEnumerator{T}"/> instance that can iterate for a pair of values
		/// via a value tuple <see cref="ValueTuple{T1, T2}"/> of a uniform type <typeparamref name="T"/>.
		/// </summary>
		/// <returns>An enumerator instance.</returns>
		public ValueTupleEnumerator<T> GetEnumerator() => new(@this);
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element in tuple.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(scoped in (T, T, T) @this)
	{
		/// <inheritdoc cref="AsSpan{T}(in ValueTuple{T, T})"/>
		public ReadOnlySpan<T> AsSpan() => (T[])[@this.Item1, @this.Item2, @this.Item3];

		/// <summary>
		/// Gets an <see cref="ValueTupleEnumerator{T}"/> instance that can iterate for a pair of values
		/// via a value tuple <see cref="ValueTuple{T1, T2, T3}"/> of a uniform type <typeparamref name="T"/>.
		/// </summary>
		/// <returns>An enumerator instance.</returns>
		public ValueTupleEnumerator<T> GetEnumerator() => new(@this);
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element in tuple.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(scoped in (T, T, T, T) @this)
	{
		/// <inheritdoc cref="AsSpan{T}(in ValueTuple{T, T})"/>
		public ReadOnlySpan<T> AsSpan() => (T[])[@this.Item1, @this.Item2, @this.Item3, @this.Item4];

		/// <summary>
		/// Gets an <see cref="ValueTupleEnumerator{T}"/> instance that can iterate for a pair of values
		/// via a value tuple <see cref="ValueTuple{T1, T2, T3, T4}"/> of a uniform type <typeparamref name="T"/>.
		/// </summary>
		/// <returns>An enumerator instance.</returns>
		public ValueTupleEnumerator<T> GetEnumerator() => new(@this);
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element in tuple.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(scoped in (T, T, T, T, T) @this)
	{
		/// <inheritdoc cref="AsSpan{T}(in ValueTuple{T, T})"/>
		public ReadOnlySpan<T> AsSpan() => (T[])[@this.Item1, @this.Item2, @this.Item3, @this.Item4, @this.Item5];

		/// <summary>
		/// Gets an <see cref="ValueTupleEnumerator{T}"/> instance that can iterate for a pair of values
		/// via a value tuple <see cref="ValueTuple{T1, T2, T3, T4, T5}"/> of a uniform type <typeparamref name="T"/>.
		/// </summary>
		/// <returns>An enumerator instance.</returns>
		public ValueTupleEnumerator<T> GetEnumerator() => new(@this);
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element in tuple.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(scoped in (T, T, T, T, T, T) @this)
	{
		/// <inheritdoc cref="AsSpan{T}(in ValueTuple{T, T})"/>
		public ReadOnlySpan<T> AsSpan() => (T[])[@this.Item1, @this.Item2, @this.Item3, @this.Item4, @this.Item5, @this.Item6];

		/// <summary>
		/// Gets an <see cref="ValueTupleEnumerator{T}"/> instance that can iterate for a pair of values
		/// via a value tuple <see cref="ValueTuple{T1, T2, T3, T4, T5, T6}"/> of a uniform type <typeparamref name="T"/>.
		/// </summary>
		/// <returns>An enumerator instance.</returns>
		public ValueTupleEnumerator<T> GetEnumerator() => new(@this);
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element in tuple.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(scoped in (T, T, T, T, T, T, T) @this)
	{
		/// <inheritdoc cref="AsSpan{T}(in ValueTuple{T, T})"/>
		public ReadOnlySpan<T> AsSpan()
			=> (T[])[@this.Item1, @this.Item2, @this.Item3, @this.Item4, @this.Item5, @this.Item6, @this.Item7];

		/// <summary>
		/// Gets an <see cref="ValueTupleEnumerator{T}"/> instance that can iterate for a pair of values
		/// via a value tuple <see cref="ValueTuple{T1, T2, T3, T4, T5, T6, T7}"/> of a uniform type <typeparamref name="T"/>.
		/// </summary>
		/// <returns>An enumerator instance.</returns>
		public ValueTupleEnumerator<T> GetEnumerator() => new(@this);
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of each element in tuple.</typeparam>
	/// <typeparam name="TRest">The type of value tuple, including rest elements in a tuple.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T, TRest>(scoped in ValueTuple<T, T, T, T, T, T, T, TRest> @this) where TRest : struct
	{
		/// <summary>
		/// Casts the current instance into a <see cref="ReadOnlySpan{T}"/>.
		/// </summary>
		/// <returns>The <see cref="ReadOnlySpan{T}"/> instance.</returns>
		public ReadOnlySpan<T> AsSpan()
		{
			var result = new List<T>();
			foreach (ref readonly var element in @this)
			{
				result.AddRef(element);
			}
			return result.AsSpan();
		}

		/// <summary>
		/// Gets an <see cref="ValueTupleEnumerator{T}"/> instance that can iterate for a pair of values
		/// via a value tuple <see cref="ValueTuple{T1, T2, T3, T4, T5, T6, T7, TRest}"/> of a uniform type <typeparamref name="T"/>.
		/// </summary>
		/// <returns>An enumerator instance.</returns>
		public ComplexValueTupleEnumerator<T, TRest> GetEnumerator() => new(@this);
	}
}
