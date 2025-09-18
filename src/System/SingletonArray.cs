namespace System;

/// <summary>
/// Represents an array with only one element.
/// </summary>
/// <typeparam name="T">The type of the only element of array.</typeparam>
/// <param name="value"><inheritdoc cref="_value" path="/summary"/></param>
public readonly struct SingletonArray<T>(T value)
{
	/// <summary>
	/// Indicates the value.
	/// </summary>
	private readonly T _value = value;


	/// <inheritdoc/>
	public override string ToString() => _value?.ToString() ?? "<null>";


	/// <summary>
	/// Creates a <see cref="ReadOnlySpan{T}"/> from the current instance without any copy operation.
	/// </summary>
	/// <param name="value">The value to be casted from.</param>
	public static implicit operator ReadOnlySpan<T>(SingletonArray<T> value)
		=> MemoryMarshal.CreateReadOnlySpan(in value._value, 1);

	/// <summary>
	/// Creates a <see cref="ReadOnlyMemory{T}"/> from the current instance without any copy operation.
	/// </summary>
	/// <param name="value">The value to be casted from.</param>
	public static implicit operator ReadOnlyMemory<T>(SingletonArray<T> value) => (T[])[value._value];
}
