namespace System.Globalization;

/// <summary>
/// Provides extension methods on <see cref="CultureInfo"/>.
/// </summary>
/// <seealso cref="CultureInfo"/>
public static class CultureInfoExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(CultureInfo @this)
	{
		/// <summary>
		/// Indicates whether the culture is Chinese.
		/// </summary>
		public bool IsChinese => @this.Name.StartsWith(SR.ChineseLanguage, StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Indicates whether the culture is English.
		/// </summary>
		public bool IsEnglish => @this.Name.StartsWith(SR.EnglishLanguage, StringComparison.OrdinalIgnoreCase);
	}
}
