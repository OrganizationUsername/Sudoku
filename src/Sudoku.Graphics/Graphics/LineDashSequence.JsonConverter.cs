namespace Sudoku.Graphics;

public partial struct LineDashSequence
{
	/// <summary>
	/// Represents a JSON converter type.
	/// </summary>
	private sealed class JsonConverter : JsonConverter<LineDashSequence>
	{
		/// <inheritdoc/>
		public override LineDashSequence Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var sequence = new List<float>();
			while (reader.Read())
			{
				switch (reader.TokenType)
				{
					case JsonTokenType.StartArray:
					{
						break;
					}
					case JsonTokenType.EndArray:
					{
						return new(sequence.AsSpan());
					}
					case JsonTokenType.Number:
					{
						sequence.Add(reader.GetSingle());
						break;
					}
					default:
					{
						throw new JsonException();
					}
				}
			}
			throw new UnreachableException();
		}

		/// <inheritdoc/>
		public override void Write(Utf8JsonWriter writer, LineDashSequence value, JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			foreach (var element in value._intervals)
			{
				writer.WriteNumberValue(element);
			}
			writer.WriteEndArray();
		}
	}
}
