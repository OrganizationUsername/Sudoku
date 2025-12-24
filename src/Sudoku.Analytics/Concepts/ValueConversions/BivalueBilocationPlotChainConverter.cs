namespace Sudoku.Concepts.ValueConversions;

/// <summary>
/// Represents a B/B Plot-formatted chain converter.
/// </summary>
public sealed class BivalueBilocationPlotChainConverter : IChainConverter
{
	/// <summary>
	/// The backing implementation instance.
	/// </summary>
	private readonly IChainConverter _impl = new CustomizedChainConverter
	{
		InlineDigitsInLink = true,
		DefaultSeparator = "|",
		InlinedDigitsSeparator = "|",
		StrongLinkConnector = "=",
		WeakLinkConnector = "-",
		NotationBracket = NotationBracket.Square
	};


	/// <inheritdoc/>
	public bool TryFormat(Chain value, IFormatProvider? provider, [NotNullWhen(true)] out string? result)
		=> _impl.TryFormat(value, provider, out result);

	/// <inheritdoc/>
	/// <exception cref="NotSupportedException">Not supported. Always thrown.</exception>
	[DoesNotReturn]
	bool IChainConverter.TryParse(ReadOnlySpan<char> text, IFormatProvider? provider, [NotNullWhen(true)] out Chain? result)
		=> throw new NotSupportedException();
}
