namespace System;

/// <summary>
/// Provides with extension methods on <see cref="ReadOnlySpan{T}"/>.
/// </summary>
public static class ReadOnlySpanUnsafeExtensions
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/>.
	/// </summary>
	extension<T>(ReadOnlySpan<T> span)
	{
		/// <summary>
		/// Creates a <see cref="ReadOnlySpan{T}"/> instance.
		/// </summary>
		/// <param name="reference">The reference to the first element.</param>
		/// <param name="length">The length.</param>
		/// <returns><see cref="ReadOnlySpan{T}"/> instance.</returns>
		public static unsafe ReadOnlySpan<T> Create(ref readonly T reference, int length)
			=> new(Unsafe.AsPointer(ref Unsafe.AsRef(in reference)), length);
	}
}
