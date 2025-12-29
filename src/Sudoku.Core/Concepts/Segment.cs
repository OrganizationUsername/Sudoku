namespace Sudoku.Concepts;

/// <summary>
/// Indicates a segment (an intersection of 3 cells, by a block and a line).
/// </summary>
/// <param name="mask">The mask.</param>
/// <remarks>
/// For more information please visit <see href="http://sudopedia.enjoysudoku.com/Intersection.html">this link</see>.
/// </remarks>
public readonly struct Segment(int mask) :
	IComparable<Segment>,
	IComparisonOperators<Segment, Segment, bool>,
	IEquatable<Segment>,
	IEqualityOperators<Segment, Segment, bool>
{
	/// <summary>
	/// <para>Indicates the backing mask.</para>
	/// <para>
	/// The value contains 2 parts (block index and line index, both are in raw values),
	/// and 10 of 16 bits used, with higher 5 bits represents row or column, lower 5 bits represents block.
	/// </para>
	/// <para>
	/// Although a block index can be compressed by 4 bits instead, I don't adjust the storage rule on this,
	/// in order to keep consistency of storage.
	/// </para>
	/// </summary>
	private readonly int _mask = mask;


	/// <summary>
	/// Initializes a <see cref="Segment"/> instance via the specified block index and line index.
	/// </summary>
	/// <param name="line">The line index.</param>
	/// <param name="block">The block index.</param>
	private Segment(House line, BlockIndex block) : this(line << 5 | block)
	{
	}


	/// <summary>
	/// Indicates whether the line is a row or not.
	/// </summary>
	public bool IsRow => Line < 18;

	/// <summary>
	/// Indicates the block.
	/// </summary>
	public House Block => _mask & 31;

	/// <summary>
	/// Indicates the line (row or column).
	/// </summary>
	public House Line => _mask >> 5 & 31;


	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] object? obj) => obj is Segment comparer && Equals(comparer);

	/// <inheritdoc/>
	public bool Equals(Segment other) => _mask == other._mask;

	/// <inheritdoc/>
	public int CompareTo(Segment other) => _mask.CompareTo(other._mask);

	/// <inheritdoc cref="object.GetHashCode"/>
	public override int GetHashCode() => _mask;

	/// <inheritdoc cref="object.ToString"/>
	public override string ToString() => ToString(CoordinateConverter.InvariantCulture);

	/// <summary>
	/// Converts the current instance into <see cref="string"/> representation, via the specified converter.
	/// </summary>
	/// <param name="converter">The converter.</param>
	/// <returns>The string.</returns>
	public string ToString(CoordinateConverter converter)
		=> $"{converter.HouseConverter(1 << Line)}{converter.HouseConverter(1 << Block)}";

	/// <summary>
	/// Converts the current instance into <see cref="string"/> representation, via the specified culture.
	/// </summary>
	/// <param name="culture">The culture.</param>
	/// <returns>The string.</returns>
	public string ToString(CultureInfo culture) => ToString(CoordinateConverter.GetInstance(culture));


	/// <inheritdoc cref="TryParse(string?, CoordinateParser, out Segment)"/>
	public bool TryParse([NotNullWhen(true)] string? s, out Segment result)
		=> TryParse(s, CoordinateParser.InvariantCulture, out result);

	/// <summary>
	/// Try to parse the specified string, converting it into target instance via the specified converter.
	/// </summary>
	/// <param name="s">The string to parse.</param>
	/// <param name="converter">The converter.</param>
	/// <param name="result">The result.</param>
	/// <returns>A <see cref="bool"/> result.</returns>
	public bool TryParse([NotNullWhen(true)] string? s, CoordinateParser converter, out Segment result)
	{
		try
		{
			if (s is null)
			{
				goto ReturnFalse;
			}
			result = Parse(s, converter);
			return true;
		}
		catch (FormatException)
		{
		}

	ReturnFalse:
		result = default;
		return false;
	}

	/// <summary>
	/// Try to parse the specified string, converting it into target instance via the specified culture.
	/// </summary>
	/// <param name="s">The string to parse.</param>
	/// <param name="culture">The culture.</param>
	/// <param name="result">The result.</param>
	/// <returns>A <see cref="bool"/> result.</returns>
	public bool TryParse([NotNullWhen(true)] string? s, CultureInfo culture, out Segment result)
		=> TryParse(s, CoordinateParser.GetInstance(culture), out result);

	/// <inheritdoc cref="Parse(string, CoordinateParser)"/>
	public Segment Parse(string s) => Parse(s, CoordinateParser.InvariantCulture);

	/// <summary>
	/// Parses the specified string, converting it into target instance via the specified converter.
	/// </summary>
	/// <param name="s">The string.</param>
	/// <param name="converter">The converter.</param>
	/// <returns>The result.</returns>
	/// <exception cref="FormatException">Throws when invalid characters encountered.</exception>
	public Segment Parse(string s, CoordinateParser converter)
	{
		var chunks = s.Trim() / 2;
		return new(TrailingZeroCount(converter.HouseParser(chunks[1])), TrailingZeroCount(converter.HouseParser(chunks[0])));
	}

	/// <summary>
	/// Parses the specified string, converting it into target instance via the specified culture.
	/// </summary>
	/// <param name="s">The string.</param>
	/// <param name="culture">The culture.</param>
	/// <returns>The result.</returns>
	/// <exception cref="FormatException">Throws when invalid characters encountered.</exception>
	public Segment Parse(string s, CultureInfo culture) => Parse(s, CoordinateParser.GetInstance(culture));


	/// <inheritdoc/>
	public static bool operator ==(Segment left, Segment right) => left.Equals(right);

	/// <inheritdoc/>
	public static bool operator !=(Segment left, Segment right) => !(left == right);

	/// <inheritdoc/>
	public static bool operator >(Segment left, Segment right) => left.CompareTo(right) > 0;

	/// <inheritdoc/>
	public static bool operator <(Segment left, Segment right) => left.CompareTo(right) < 0;

	/// <inheritdoc/>
	public static bool operator >=(Segment left, Segment right) => left.CompareTo(right) >= 0;

	/// <inheritdoc/>
	public static bool operator <=(Segment left, Segment right) => left.CompareTo(right) <= 0;
}
