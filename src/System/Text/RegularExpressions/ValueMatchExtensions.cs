namespace System.Text.RegularExpressions;

/// <summary>
/// Provides with extension methdos on <see cref="ValueMatch"/>.
/// </summary>
/// <seealso cref="ValueMatch"/>
public static class ValueMatchExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(ValueMatch @this)
	{
		/// <summary>
		/// Try to get the target match string at the specified position the current instance specified.
		/// </summary>
		/// <param name="originalString">The original string.</param>
		/// <returns>The target string.</returns>
		public ReadOnlySpan<char> MatchString(ReadOnlySpan<char> originalString)
			=> originalString.Slice(@this.Index, @this.Length);
	}
}
