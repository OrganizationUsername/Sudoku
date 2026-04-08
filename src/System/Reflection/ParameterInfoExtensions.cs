namespace System.Reflection;

/// <summary>
/// Provides extension members on <see cref="ParameterInfo"/> instances.
/// </summary>
/// <seealso cref="ParameterInfo"/>
public static class ParameterInfoExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(ParameterInfo @this)
	{
		/// <summary>
		/// Indicates whether the parameter is by-reference (has modifier <see langword="ref"/>) or not.
		/// </summary>
		public bool IsRef => @this.ParameterType.IsByRef;

		/// <summary>
		/// Indicates whether the parameter is by-read-only-reference (has modifiers <see langword="ref readonly"/>) or not.
		/// </summary>
		public bool IsRefReadOnly => @this.IsRef && @this.IsIn;

		/// <summary>
		/// Indicates whether the parameter has modifier <see langword="params"/> or not.
		/// </summary>
		public bool IsParams => @this.IsDefined(typeof(ParamArrayAttribute)) || @this.IsDefined(typeof(ParamCollectionAttribute));
	}
}
