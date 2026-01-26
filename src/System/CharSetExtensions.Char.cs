namespace System;

public partial class CharSetExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(char @this)
	{
		/// <summary>
		/// Indicates the upper-cased string to the current string.
		/// </summary>
		public char UpperCased => char.ToUpper(@this);

		/// <summary>
		/// Indicates the lower-cased string to the current string.
		/// </summary>
		public char LowerCased => char.ToLower(@this);


#if false
		/// <summary>
		/// Repeats the specified string specified times.
		/// </summary>
		/// <param name="value">The string.</param>
		/// <param name="times">The repeating times.</param>
		/// <returns>The result string.</returns>
		[OverloadResolutionPriority(1)]
		public static string operator *(char value, int times)
		{
			var result = new char[times];
			result.AsSpan().Fill(value);
			return new(result);
		}
#endif
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(ReadOnlySpan<char> @this)
	{
		/// <inheritdoc cref="op_UnaryPlus(ReadOnlySpan{char})"/>
		[Obsolete(DeprecatedMessages.ExtensionOperator_Pack, false)]
		public string Pack() => +@this;


		/// <summary>
		/// Pack characters into a string.
		/// </summary>
		/// <param name="chars">Characters.</param>
		/// <returns>A string.</returns>
		public static string operator +(ReadOnlySpan<char> chars) => new(chars);
	}
}
