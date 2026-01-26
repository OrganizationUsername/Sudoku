namespace System.Text.Json;

/// <summary>
/// Provides extension methods on <see cref="Utf8JsonReader"/>.
/// </summary>
/// <seealso cref="Utf8JsonReader"/>
public static class Utf8JsonReaderExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(ref Utf8JsonReader @this)
	{
		/// <summary>
		/// To read as a nested object in the JSON string stream.
		/// </summary>
		/// <typeparam name="T">The type of the instance to be deserialized.</typeparam>
		/// <param name="options">The options.</param>
		public T? GetNestedObject<T>(JsonSerializerOptions? options = null) => JsonSerializer.Deserialize<T>(ref @this, options);
	}
}
