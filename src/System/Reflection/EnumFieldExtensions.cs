namespace System.Reflection;

/// <summary>
/// Provides with extension methods on fields on enumeration types.
/// </summary>
public static class EnumFieldExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TEnum">The type of enumeration.</typeparam>
	extension<TEnum>(TEnum) where TEnum : Enum
	{
		/// <summary>
		/// Returns the field information of the specified field.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <returns>The <see cref="FieldInfo"/> instance.</returns>
		public static FieldInfo? FieldInfoOf(TEnum field) => typeof(TEnum).GetField(field.ToString());
	}
}
