namespace System.Runtime.CompilerServices;

/// <summary>
/// Indicates the type is a union.
/// </summary>
public interface IUnion
{
	/// <summary>
	/// Indicates the result value.
	/// </summary>
	object? Value { get; }
}
