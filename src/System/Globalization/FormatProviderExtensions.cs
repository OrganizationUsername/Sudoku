namespace System.Globalization;

/// <summary>
/// Provides extension methods on <see cref="IFormatProvider"/>.
/// </summary>
/// <seealso cref="IFormatProvider"/>
public static class FormatProviderExtensions
{
	/// <summary>
	/// Provides extension members on <see cref="IFormatProvider"/>.
	/// </summary>
	/// <param name="this">The instance.</param>
	extension(IFormatProvider @this)
	{
		/// <summary>
		/// Indicates whether the format provider is Chinese culture.
		/// </summary>
		public bool IsChineseCulture
			=> (@this as CultureInfo)?.Name.StartsWith(SR.ChineseLanguage, StringComparison.OrdinalIgnoreCase) ?? false;

		/// <summary>
		/// Indicates whether the format provider is English culture.
		/// </summary>
		public bool IsEnglishCulture
			=> (@this as CultureInfo)?.Name.StartsWith(SR.EnglishLanguage, StringComparison.OrdinalIgnoreCase) ?? false;
	}
}
