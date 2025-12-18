namespace Sudoku.Descriptors;

using ReaderLookupKey = (string TypeDiscriminator, Func<string, JsonSerializerOptions, Chunk?> Handler);
using WriterLookupKey = (Predicate<Chunk> TypeMatcher, Action<Utf8JsonWriter, Chunk, JsonSerializerOptions> Handler);

/// <summary>
/// Represents rendering data for displaying a element from a concept of sudoku, like a house, a cell or a candidate.
/// </summary>
/// <param name="descriptor"><inheritdoc cref="Descriptor" path="/summary"/></param>
/// <param name="field"><inheritdoc cref="_field" path="/summary"/></param>
/// <param name="flag"><inheritdoc cref="ElementType" path="/summary"/></param>
[JsonConverter(typeof(Converter))]
public abstract class Chunk(ColorDescriptor descriptor, object field, ChunkElementFlag flag) : IEnumerable, IFormattable
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
	/// Represents an array of actions to be checked in <see cref="JsonConverter{T}.Read(ref Utf8JsonReader, Type, JsonSerializerOptions)"/>.
	/// </summary>
	/// <seealso cref="JsonConverter{T}.Read(ref Utf8JsonReader, Type, JsonSerializerOptions)"/>
	internal static readonly ReaderLookupKey[] ReaderLookup = [
		(nameof(CellChunk), JsonSerializer.Deserialize<CellChunk>),
		(nameof(CandidateChunk), JsonSerializer.Deserialize<CandidateChunk>)
	];

	/// <summary>
	/// Represents an array of actions to be checked on <see cref="JsonConverter{T}.Write(Utf8JsonWriter, T, JsonSerializerOptions)"/>.
	/// </summary>
	/// <seealso cref="JsonConverter{T}.Write(Utf8JsonWriter, T, JsonSerializerOptions)"/>
	internal static readonly WriterLookupKey[] WriterLookup = [
		(
			static chunk => chunk is CellChunk,
			static (writer, value, options) => JsonSerializer.Serialize(writer, (CellChunk)value, options)
		),
		(
			static chunk => chunk is CandidateChunk,
			static (writer, value, options) => JsonSerializer.Serialize(writer, (CandidateChunk)value, options)
		)
	];


	/// <summary>
	/// Indicates the backing field.
	/// </summary>
	protected readonly object _field = field;


	/// <summary>
	/// Indicates the type of chunk.
	/// </summary>
	public abstract ChunkType Type { get; }

	/// <summary>
	/// Indicates the chunk element.
	/// </summary>
	public ChunkElementFlag ElementType { get; } = flag;

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

	/// <summary>
	/// Judge type and return its bound <see cref="ChunkElementFlag"/> field.
	/// </summary>
	/// <typeparam name="TSelf">The current type.</typeparam>
	/// <param name="value">The value.</param>
	/// <returns>The flag.</returns>
	protected static ChunkElementFlag GetFlag<TSelf>(object value) where TSelf : Chunk, IChunk<TSelf>
	{
		var valueType = value.GetType();
		if (valueType.IsGenericAssignableTo(typeof(HashSet<>)))
		{
			return ChunkElementFlag.HashSet;
		}
		if (valueType.IsGenericAssignableTo(typeof(List<>)))
		{
			return ChunkElementFlag.List;
		}
		if (value is CellMap or CandidateMap)
		{
			return ChunkElementFlag.BitStateMap;
		}
		if (value is Array)
		{
			return ChunkElementFlag.Array;
		}
		if (valueType == TSelf.SingleElementType)
		{
			return ChunkElementFlag.Single;
		}
		throw new InvalidOperationException();
	}
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
		foreach (var (typeDiscriminator, action) in Chunk.ReaderLookup)
		{
			if (typeDiscriminator == jsonElement.GetString())
			{
				return action(originalJson, options);
			}
		}
		throw new JsonException("Why here?");
	}

	/// <inheritdoc/>
	public override void Write(Utf8JsonWriter writer, Chunk value, JsonSerializerOptions options)
	{
		foreach (var (chunkTypeMatcher, action) in Chunk.WriterLookup)
		{
			if (chunkTypeMatcher(value))
			{
				action(writer, value, options);
				return;
			}
		}
		throw new JsonException("Type mismatches.");
	}
}
