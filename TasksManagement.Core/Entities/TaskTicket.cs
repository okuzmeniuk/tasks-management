using System.ComponentModel.DataAnnotations;
using TasksManagement.Core.Enums;

namespace TasksManagement.Core.Entities
{
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
		public Status Status { get; set; }
		public PersonId PersonId { get; set; }
	}
}
