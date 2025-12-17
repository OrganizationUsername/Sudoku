namespace Sudoku.Descriptors.Chunks;

/// <summary>
/// Represents a chunk that stores a cell or a list of cells.
/// </summary>
/// <param name="descriptor">
/// <inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='descriptor']"/>
/// </param>
/// <param name="field"><inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='field']"/></param>
/// <param name="flag"><inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='flag']"/></param>
[JsonConverter(typeof(Converter))]
public sealed class CellChunk(ColorDescriptor descriptor, object field, ChunkElementFlag flag) :
	Chunk(descriptor, field, flag),
	IEnumerable<Cell>,
	IChunk<CellChunk, CellMap, Cell>
{
	/// <summary>
	/// Indicates the cells.
	/// </summary>
	public CellMap Cells
	{
		get
		{
			var result = CellMap.Empty;
			foreach (var cell in this)
			{
				result += cell;
			}
			return result;
		}
	}

	/// <inheritdoc/>
	public override ChunkType Type => ChunkType.Cell;

	/// <inheritdoc/>
	public override ChunkElementFlag SupportedElementTypes
		=> ChunkElementFlag.Single | ChunkElementFlag.Array | ChunkElementFlag.List | ChunkElementFlag.HashSet | ChunkElementFlag.BitStateMap;


	/// <inheritdoc/>
	public override IEnumerator<Cell> GetEnumerator()
	{
		if (ElementType == ChunkElementFlag.Single)
		{
			yield return (Cell)_field;
			yield break;
		}

		foreach (var element in (IEnumerable<Cell>)_field)
		{
			yield return element;
		}
	}

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
		=> CoordinateConverter.GetInstance(formatProvider).CellConverter(Cells);


	/// <inheritdoc/>
	public static CellChunk Create(ColorDescriptor descriptor, Cell value) => new(descriptor, value, ChunkElementFlag.Single);

	/// <inheritdoc/>
	public static CellChunk Create(ColorDescriptor descriptor, Cell[] array) => new(descriptor, array, ChunkElementFlag.Array);

	/// <inheritdoc/>
	public static CellChunk Create(ColorDescriptor descriptor, in CellMap map) => new(descriptor, map, ChunkElementFlag.BitStateMap);

	/// <inheritdoc/>
	public static CellChunk Create(ColorDescriptor descriptor, List<Cell> list) => new(descriptor, list, ChunkElementFlag.List);

	/// <inheritdoc/>
	public static CellChunk Create(ColorDescriptor descriptor, HashSet<Cell> hashSet)
		=> new(descriptor, hashSet, ChunkElementFlag.HashSet);
}

/// <summary>
/// Defines converter of type <see cref="CellChunk"/>.
/// </summary>
/// <seealso cref="CellChunk"/>
file sealed class Converter : JsonConverter<CellChunk>
{
	/// <inheritdoc/>
	public override CellChunk? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var descriptor = default(ColorDescriptor);
		var result = default(CellChunk);
		while (reader.Read())
		{
			switch (reader.TokenType)
			{
				case JsonTokenType.EndObject:
				{
					return result ?? throw new JsonException();
				}
				case JsonTokenType.PropertyName:
				{
					var propertyName = reader.GetString()!;
					if (Chunk.ConvertName(options, propertyName) == Chunk.ConvertName(options, Chunk.DescriptorPropertyName))
					{
						descriptor = JsonSerializer.Deserialize<ColorDescriptor>(ref reader, options);
					}
					if (Chunk.ConvertName(options, propertyName) == Chunk.ConvertName(options, Chunk.ValuePropertyName))
					{
						reader.Read();
						result = CellChunk.Create(descriptor, CellMap.Parse(reader.GetString()!));
					}
					if (Chunk.ConvertName(options, propertyName) == Chunk.ConvertName(options, Chunk.TypeDiscriminatorPropertyName))
					{
						reader.Skip();
					}
					break;
				}
			}
		}
		throw new JsonException();
	}

	/// <inheritdoc/>
	public override void Write(Utf8JsonWriter writer, CellChunk value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();
		writer.WriteString(Chunk.TypeDiscriminatorPropertyName, nameof(CellChunk));
		writer.WritePropertyName(Chunk.ConvertName(options, Chunk.DescriptorPropertyName));
		JsonSerializer.Serialize(writer, value.Descriptor, options);
		writer.WritePropertyName(Chunk.ValuePropertyName);
		JsonSerializer.Serialize(writer, value.Cells.ToString(), options);
		writer.WriteEndObject();
	}
}
