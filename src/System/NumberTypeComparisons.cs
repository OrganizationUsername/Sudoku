namespace System;

/// <summary>
/// Provides comparison operations for number types.
/// </summary>
public static class NumberTypeComparisons
{
	/// <summary>
	/// Provides extension members on <typeparamref name="T"/>,
	/// where <typeparamref name="T"/> satisfies <see cref="INumber{TSelf}"/> constraint.
	/// </summary>
	/// <typeparam name="T">The type of instance.</typeparam>
	extension<T>(T) where T : INumber<T>
	{
		/// <summary>
		/// Provides a transparent encapsulation on <c><typeparamref name="T"/>.CompareTo</c> method.
		/// </summary>
		/// <param name="left">The first instance to be compared.</param>
		/// <param name="right">The second instance to be compared.</param>
		/// <returns>An <see cref="int"/> result indicating which is greater.</returns>
		public static int CompareTo(T left, T right) => left.CompareTo(right);

		/// <summary>
		/// Provides a transparent encapsulation on <c><typeparamref name="T"/>.Equals</c> method.
		/// </summary>
		/// <param name="left">The first instance to be compared.</param>
		/// <param name="right">The second instance to be compared.</param>
		/// <returns>A <see cref="bool"/> result indicating whether they are same.</returns>
		public static bool Equals(T left, T right) => left.Equals(right);
	}
}
