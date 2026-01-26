namespace System;

public partial class FloatingPointExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="T">The type of value.</typeparam>
	/// <param name="this">The current instance.</param>
	extension<T>(T @this) where T : IFloatingPoint<T>, IFloatingPointIeee754<T>
	{
		/// <summary>
		/// Indicates whether the specified value is nearly equals to the current value.
		/// </summary>
		/// <param name="other">The other value.</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public bool NearlyEquals(T other) => @this.NearlyEquals(other, T.Epsilon);

		/// <summary>
		/// Indicates whether the specified value is nearly equals to the current value.
		/// If the differ of two values to compare is lower than the specified epsilon value,
		/// the method will return <see langword="true"/>.
		/// </summary>
		/// <param name="other">The other value to compare.</param>
		/// <param name="epsilon">The epsilon value (the minimal differ).</param>
		/// <returns>A <see cref="bool"/> result indicating that.</returns>
		public bool NearlyEquals(T other, T epsilon) => T.Abs(@this - other) < epsilon;
	}
}
