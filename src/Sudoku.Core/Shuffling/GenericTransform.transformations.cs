namespace Sudoku.Shuffling;

public partial record struct GenericTransform
{
	/// <summary>
	/// Creates a <see cref="GenericTransform"/> with two digits swapped.
	/// </summary>
	/// <param name="digit1">Indicates the digit 1 to be swapped.</param>
	/// <param name="digit2">Indicates the digit 2 to be swapped.</param>
	/// <returns>The <see cref="GenericTransform"/> instance that swapped the digits.</returns>
	public static GenericTransform SwapDigit(Digit digit1, Digit digit2)
	{
		var baseOrder = (Digit[])[0, 1, 2, 3, 4, 5, 6, 7, 8];
		var digits = baseOrder[..].AsSpan();
		Unsafe.Swap(ref digits[digit1], ref digits[digit2]);
		return new(0, 0, 0, CantorExpansion.RankRelabeledDigits(digits, baseOrder));
	}
}
