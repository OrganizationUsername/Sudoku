namespace Sudoku.Descriptors;

/// <summary>
/// Represents rendering data for displaying a element from a concept of sudoku, like a house, a cell or a candidate.
/// </summary>
/// <param name="descriptor"><inheritdoc cref="Descriptor" path="/summary"/></param>
/// <param name="field"><inheritdoc cref="_field" path="/summary"/></param>
/// <param name="flag"><inheritdoc cref="ElementType" path="/summary"/></param>
[JsonConverter(typeof(Converter))]
public abstract class Chunk(ColorDescriptor descriptor, object field, ChunkElementFlag flag) : IChunk
{
	/// <summary>
	/// Indicates the name of value property on serialization.
	/// </summary>
	protected internal const string ValuePropertyName = "Value";

	/// <summary>
	/// Indicates the type discriminator property name.
	/// </summary>
	protected internal const string TypeDiscriminatorPropertyName = "$type";

	/// <summary>
	/// Indicates the name of property <see cref="Descriptor"/>.
	/// </summary>
	/// <seealso cref="Descriptor"/>
	protected internal const string DescriptorPropertyName = nameof(Descriptor);


	/// <summary>
	/// Indicates the backing field.
	/// </summary>
	protected readonly object _field = field;


	/// <summary>
	/// Indicates the type of chunk.
	/// </summary>
	public abstract ChunkType Type { get; }

	/// <inheritdoc/>
	public ChunkElementFlag ElementType { get; } = flag;

	/// <inheritdoc/>
	public abstract ChunkElementFlag SupportedElementTypes { get; }

	/// <summary>
	/// Indicates the descriptor of chunk.
	/// </summary>
	public ColorDescriptor Descriptor { get; } = descriptor;


	/// <inheritdoc/>
	public sealed override string ToString() => ToString(null);

	/// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
	public abstract string ToString(IFormatProvider? formatProvider);

	/// <summary>
	/// Enumerates elements of the chunk.
	/// </summary>
	/// <returns>An enumerator that can iterate on each element in the chunk.</returns>
	public abstract IEnumerator GetEnumerator();

	/// <inheritdoc/>
	string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => ToString(formatProvider);


	/// <summary>
	/// Converts name.
	/// </summary>
	/// <param name="options">The options to provide naming policy.</param>
	/// <param name="original">The original name to convert.</param>
	/// <returns>The converted name.</returns>
	protected internal static string ConvertName(JsonSerializerOptions options, string original)
		=> options.PropertyNamingPolicy?.ConvertName(original) ?? original;
}

/// <summary>
/// Represents converter of <see cref="Chunk"/> type.
/// </summary>
/// <seealso cref="Chunk"/>
file sealed class Converter : JsonConverter<Chunk>
{
	/// <inheritdoc/>
	public override Chunk? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		// Temporarily construct a document.
		using var document = JsonDocument.ParseValue(ref reader);
		var root = document.RootElement;

		// Read for required property '$type'.
		if (!root.TryGetProperty(Chunk.TypeDiscriminatorPropertyName, out var jsonElement))
		{
			throw new JsonException($"Missing required property name '{Chunk.TypeDiscriminatorPropertyName}'.");
		}

		// Locate type to be initialized and deserialized.
		var originalJson = root.GetRawText();
		return jsonElement.GetString() switch
		{
			nameof(CellChunk) => JsonSerializer.Deserialize<CellChunk>(originalJson, options),
		};
	}

	/// <inheritdoc/>
	public override void Write(Utf8JsonWriter writer, Chunk value, JsonSerializerOptions options)
	{
		foreach (var (matcher, action) in new (Predicate<Chunk>, Action<Chunk>)[]
		{
			(static chunk => chunk is CellChunk, chunk => JsonSerializer.Serialize(writer, (CellChunk)chunk, options))
		})
		{
			if (matcher(value))
			{
				action(value);
				return;
			}
		}
		throw new JsonException("Type mismatches.");
	}
}
