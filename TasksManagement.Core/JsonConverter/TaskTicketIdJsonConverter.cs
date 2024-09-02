using System.Text.Json;
using System.Text.Json.Serialization;
using TasksManagement.Core.Entities;

namespace TasksManagement.Core.JsonConverter
{
	public class TaskTicketIdJsonConverter : JsonConverter<TaskTicketId>
	{
		public override TaskTicketId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> new(reader.GetGuid());

		public override void Write(Utf8JsonWriter writer, TaskTicketId value, JsonSerializerOptions options)
			=> writer.WriteStringValue(value.Value);
	}
}
