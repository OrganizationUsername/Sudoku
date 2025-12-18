namespace Sudoku.Descriptors.Chunks;

/// <summary>
/// Represents a chunk that stores a candidate or a list of candidates.
/// </summary>
[JsonConverter(typeof(Converter))]
public sealed class CandidateChunk : Chunk, IChunk<CandidateChunk>, IEnumerable<Candidate>
{
	/// <summary>
	/// Indicates digit field.
	/// </summary>
	internal readonly Digit _digit;


	/// <summary>
	/// Initializes a <see cref="CandidateChunk"/> instance.
	/// </summary>
	/// <param name="descriptor">
	/// <inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='descriptor']"/>
	/// </param>
	/// <param name="field"><inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='field']"/></param>
	public CandidateChunk(ColorDescriptor descriptor, object field) : this(descriptor, field, false)
	{
	}

	/// <summary>
	/// Initializes a <see cref="CandidateChunk"/> instance via <c>(cell, digit)</c> pair.
	/// </summary>
	/// <param name="descriptor">
	/// <inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='descriptor']"/>
	/// </param>
	/// <param name="field"><inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='field']"/></param>
	/// <param name="digit">The digit value.</param>
	public CandidateChunk(ColorDescriptor descriptor, object field, Digit digit) : this(descriptor, field, true) => _digit = digit;

	/// <summary>
	/// Initializes a <see cref="CandidateChunk"/> instance.
	/// </summary>
	/// <param name="descriptor">
	/// <inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='descriptor']"/>
	/// </param>
	/// <param name="field"><inheritdoc cref="Chunk(ColorDescriptor, object, ChunkElementFlag)" path="/param[@name='field']"/></param>
	/// <param name="isCellsDigitPattern">Indicates whether field <see cref="_digit"/> is used or not.</param>
	private CandidateChunk(ColorDescriptor descriptor, object field, bool isCellsDigitPattern) :
		base(
			descriptor,
			field,
			GetFlag<CandidateChunk>(field) | (isCellsDigitPattern ? ChunkElementFlag.CellsDigit : ChunkElementFlag.None)
		)
	{
	}


	/// <summary>
	/// Indicates the candidates.
	/// </summary>
	public CandidateMap Candidates
	{
		get
		{
			if (_field is CandidateMap value)
			{
				return value;
			}

			var result = CandidateMap.Empty;
			foreach (var candidate in this)
			{
				result += candidate;
			}
			return result;
		}
	}

	/// <inheritdoc/>
	public override ChunkType Type => ChunkType.Candidate;


	/// <inheritdoc/>
	static Type IChunk<CandidateChunk>.SingleElementType => typeof(Candidate);


	/// <inheritdoc/>
	public override IEnumerator<Candidate> GetEnumerator()
	{
		if (ElementType.HasFlag(ChunkElementFlag.CellsDigit))
		{
			// The backing field '_field' is of type 'Cell' and cell collections.
			if (ElementType == ChunkElementFlag.Single)
			{
				yield return (Cell)_field * 9 + _digit;
				yield break;
			}

			foreach (var element in (IEnumerable<Cell>)_field)
			{
				yield return element * 9 + _digit;
			}
			yield break;
		}

		// Otherwise, a candidate collection or a single candidate.
		if (ElementType == ChunkElementFlag.Single)
		{
			yield return (Candidate)_field;
			yield break;
		}

		foreach (var element in (IEnumerable<Candidate>)_field)
		{
			yield return element;
		}
	}

	/// <inheritdoc/>
	public override string ToString(IFormatProvider? formatProvider)
		=> CoordinateConverter.GetInstance(formatProvider).CandidateConverter(Candidates);
}

/// <summary>
/// Defines converter of type <see cref="CandidateChunk"/>.
/// </summary>
/// <seealso cref="CandidateChunk"/>
file sealed class Converter : JsonConverter<CandidateChunk>
{
	/// <inheritdoc/>
	public override CandidateChunk? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var descriptor = default(ColorDescriptor);
		var result = default(CandidateChunk);
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
						result = new(descriptor, CandidateMap.Parse(reader.GetString()!));
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
	public override void Write(Utf8JsonWriter writer, CandidateChunk value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();
		writer.WriteString(Chunk.TypeDiscriminatorPropertyName, nameof(CandidateChunk));
		writer.WritePropertyName(Chunk.ConvertName(options, Chunk.DescriptorPropertyName));
		JsonSerializer.Serialize(writer, value.Descriptor, options);
		writer.WritePropertyName(Chunk.ValuePropertyName);
		JsonSerializer.Serialize(writer, value.Candidates.ToString(), options);
		writer.WriteEndObject();
	}
}
