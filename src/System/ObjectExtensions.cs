namespace System;

/// <summary>
/// Provides with extension methods on <see cref="object"/>.
/// </summary>
public static class ObjectExtensions
{
	/// <summary>
	/// Provides extension members on <see cref="object"/>?.
	/// </summary>
	extension(object?)
	{
#if EXTENSION_OPERATORS
		/// <summary>
		/// Determines whether the current value is non-<see langword="null"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public static bool operator true(object? value) => value is not null;

		/// <summary>
		/// Determines whether the current value is <see langword="null"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public static bool operator false(object? value) => value is null;
#endif
	}
}
