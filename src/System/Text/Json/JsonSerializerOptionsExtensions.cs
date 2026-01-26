namespace System.Text.Json;

/// <summary>
/// Provides extension methods on <see cref="JsonSerializerOptions"/>.
/// </summary>
/// <seealso cref="JsonSerializerOptions"/>
public static class JsonSerializerOptionsExtensions
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <param name="this">The current instance.</param>
	extension(JsonSerializerOptions @this)
	{
		/// <summary>
		/// Returns the converter that supports the given type, or the <typeparamref name="TConverter"/>
		/// will be used when the property <see cref="JsonSerializerOptions.Converters"/>
		/// doesn't contain any valid converters.
		/// </summary>
		/// <typeparam name="T">The type to get converter.</typeparam>
		/// <typeparam name="TConverter">
		/// The type that is the converter type to convert the instance of type <typeparamref name="T"/>.
		/// </typeparam>
		/// <returns>
		/// The converter that supports the given type, or the <typeparamref name="TConverter"/>
		/// will be used when the property <see cref="JsonSerializerOptions.Converters"/>
		/// doesn't contain any valid converters.
		/// </returns>
		/// <seealso cref="JsonSerializerOptions.Converters"/>
		public JsonConverter<T> GetConverter<T, TConverter>() where TConverter : JsonConverter<T>, new()
			=> (JsonConverter<T>?)@this.GetConverter(typeof(T)) ?? new TConverter();
	}
}
