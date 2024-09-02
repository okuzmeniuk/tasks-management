using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TasksManagement.Core.Enums;
using TasksManagement.Core.JsonConverter;

namespace TasksManagement.Core.Entities
{
	[JsonConverter(typeof(TaskTicketIdJsonConverter))]
	public readonly record struct TaskTicketId(Guid Value)
	{
		public static TaskTicketId CreateNew() => new(Guid.NewGuid());
	}

	public class TaskTicket
	{
		public TaskTicketId Id { get; set; }

		[StringLength(100, MinimumLength = 3)]
		public string Title { get; set; } = string.Empty;

		[StringLength(1024)]
		public string Description { get; set; } = string.Empty;

		[Required]
		public Status Status { get; set; }

		[Required]
		public PersonId PersonId { get; set; }
	}
}
