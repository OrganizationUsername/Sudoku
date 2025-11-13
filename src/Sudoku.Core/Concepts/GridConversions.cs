namespace Sudoku.Concepts;

/// <summary>
/// Provides with conversion rules on <see cref="Grid"/> from <see cref="string"/> values.
/// </summary>
/// <seealso cref="Grid"/>
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
public static class GridConversions
{
	/// <summary>
	/// Provides extension members on <see cref="Grid"/>.
	/// </summary>
	/// <param name="this">The current instance.</param>
	extension(string @this)
	{
		/// <summary>
		/// Converts the string and parses it into <see cref="Grid"/> instance, or throws exceptions if invalid.
		/// </summary>
		/// <exception cref="FormatException">Throws when input string is invalid.</exception>
		public Grid grid => Grid.Parse(@this);

		/// <summary>
		/// Converts the string and parses it into <see cref="Grid"/> instance as pencilmark grid,
		/// or throws exceptions if invalid.
		/// </summary>
		/// <exception cref="FormatException">Throws when input string is invalid.</exception>
		public Grid pencilmark => Grid.Parse(@this, new PencilmarkGridFormatInfo());
	}
}
