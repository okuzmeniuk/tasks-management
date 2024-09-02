using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TasksManagement.Core.JsonConverter;

namespace TasksManagement.Core.Entities
{
	[JsonConverter(typeof(PersonIdJsonConverter))]
	public readonly record struct PersonId(Guid Value)
	{
		public static PersonId CreateNew() => new(Guid.NewGuid());
	}

	public class Person
	{
		public PersonId Id { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 3)]
		public string Username { get; set; } = string.Empty;

		[ForeignKey(nameof(TaskTicket.PersonId))]
		public List<TaskTicket> Tickets { get; set; } = [];
	}
}
