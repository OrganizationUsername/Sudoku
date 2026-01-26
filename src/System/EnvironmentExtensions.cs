namespace System;

/// <summary>
/// Provides with extension methods on <see cref="Environment"/>.
/// </summary>
/// <seealso cref="Environment"/>
public static class EnvironmentExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	extension(Environment)
	{
		/// <summary>
		/// Indicates the desktop path.
		/// </summary>
		public static string DesktopPath => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	}
}
