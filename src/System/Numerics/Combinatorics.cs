namespace System.Numerics;

/// <summary>
/// Extracts the type that includes the methods that operates with combinatorial values.
/// </summary>
public static class Combinatorics
{
	/// <summary>
	/// Indicates the <see href="https://en.wikipedia.org/wiki/Pascal%27s_triangle">Pascal's Triangle</see>
	/// (in Chinese: Yang Hui's Triangle), i.e. the combinatorial numbers from <c>C(1, 1)</c> to <c>C(30, 30)</c>.
	/// </summary>
	public static readonly int[][] PascalTriangle = Generate(30);


	/// <summary>
	/// The backing method to generate pascal triangle.
	/// </summary>
	/// <param name="rows">The desired number of rows to be generated.</param>
	/// <returns>A list of arrays indicating pascal triangle, with the first element ignored for each row.</returns>
	private static int[][] Generate(int rows)
	{
		Debug.Assert(rows > 0);

		var result = new int[rows][];
		var previous = Array.Empty<BigInteger>();
		for (var r = 0; r < rows + 1; r++)
		{
			var currentRow = new BigInteger[r + 1];
			currentRow[0] = 1;
			currentRow[r] = 1;
			for (var i = 1; i < r; i++)
			{
				currentRow[i] = previous[i - 1] + previous[i];
			}

			if (r >= 1)
			{
				var eachRow = new int[r];
				for (var i = 1; i < currentRow.Length; i++)
				{
					eachRow[i - 1] = (int)currentRow[i];
				}
				result[r - 1] = eachRow;
			}
			previous = currentRow;
		}
		return result;
	}

	/// <summary>
	/// Returns the combination of (n, m).
	/// </summary>
	/// <param name="n">The number of all values.</param>
	/// <param name="m">The number of values to get.</param>
	/// <returns>An <see cref="int"/> of result.</returns>
	/// <exception cref="OverflowException">Throws when the result value is too large.</exception>
	public static int CombinationOf(int n, int m) => checked((int)(Factorial(n) / (Factorial(m) * Factorial(n - m))));

	/// <summary>
	/// Returns the permutation of (n, m).
	/// </summary>
	/// <param name="n">The number of all values.</param>
	/// <param name="m">The number of values to get.</param>
	/// <returns>An <see cref="int"/> of result.</returns>
	/// <exception cref="OverflowException">Throws when the result value is too large.</exception>
	public static int PermutationOf(int n, int m) => checked((int)(Factorial(n) / Factorial(n - m)));

	/// <summary>
	/// Returns the factorial of <paramref name="n"/> (n!).
	/// </summary>
	/// <param name="n">The value.</param>
	/// <returns>The result.</returns>
	private static BigInteger Factorial(int n)
	{
		var result = (BigInteger)1;
		for (var i = 2; i <= n; i++)
		{
			result *= i;
		}
		return result;
	}
}
