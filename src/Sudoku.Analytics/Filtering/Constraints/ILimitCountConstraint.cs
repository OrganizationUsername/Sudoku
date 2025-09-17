namespace Sudoku.Filtering.Constraints;

/// <summary>
/// Represents a type that supports limit number.
/// </summary>
/// <typeparam name="TNumber">The type of the number.</typeparam>
public interface ILimitCountConstraint<TNumber> where TNumber : INumber<TNumber>
{
	/// <summary>
	/// Indicates the limit number.
	/// </summary>
	TNumber LimitCount { get; set; }


	/// <summary>
	/// Indicates the minimum value.
	/// </summary>
	static abstract TNumber Minimum { get; }

	/// <summary>
	/// Indicates the maximum value.
	/// </summary>
	static abstract TNumber Maximum { get; }
}
