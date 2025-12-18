namespace Sudoku.Descriptors.Chunks;

/// <summary>
/// Represents a chunk that stores a cell or a list of cells.
/// </summary>
[JsonConverter(typeof(Converter))]
public sealed class CellChunk : Chunk, IChunk<CellChunk>, IEnumerable<Cell>
{
	/// <summary>
	/// Initializes a <see cref="CellChunk"/> instance.
	/// </summary>
	/// <param name="descriptor">
	/// <inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='descriptor']"/>
	/// </param>
	/// <param name="field"><inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='field']"/></param>
	[SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]
	public CellChunk(ColorDescriptor descriptor, object field) : base(descriptor, field, GetFlag<CellChunk>(field))
	{
	}


	/// <summary>
	/// Indicates the cells.
	/// </summary>
	public CellMap Cells
	{
		get
		{
			if (_field is CellMap value)
			{
				return value;
			}

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
	static Type IChunk<CellChunk>.SingleElementType => typeof(Cell);


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
						result = new(descriptor, CellMap.Parse(reader.GetString()!));
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
