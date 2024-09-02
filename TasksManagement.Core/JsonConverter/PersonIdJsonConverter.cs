using System.Text.Json;
using System.Text.Json.Serialization;
using TasksManagement.Core.Entities;

namespace TasksManagement.Core.JsonConverter
{
	public class PersonIdJsonConverter : JsonConverter<PersonId>
	{
		public override PersonId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> new(reader.GetGuid());

		public override void Write(Utf8JsonWriter writer, PersonId value, JsonSerializerOptions options)
			=> writer.WriteStringValue(value.Value);
	}
}
