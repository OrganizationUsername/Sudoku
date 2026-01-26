namespace System.Numerics;

/// <summary>
/// Represents an enumerator that can iterate bits over an integer.
/// </summary>
public interface IBitEnumerator : IEnumerator<int>
{
	/// <summary>
	/// Indicates the population count of the value.
	/// </summary>
	int PopulationCount { get; }

	/// <summary>
	/// Indicates the bits set.
	/// </summary>
	ReadOnlySpan<int> Bits { get; }

	/// <inheritdoc/>
	object IEnumerator.Current => Current;


	/// <inheritdoc cref="BitOperationsExtensions.SetAt(uint, int)"/>
	int this[int index] { get; }


	/// <inheritdoc/>
	[DoesNotReturn]
	void IEnumerator.Reset() => throw new NotImplementedException();
}
