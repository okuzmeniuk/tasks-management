using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagement.Core.Enums;

namespace TasksManagement.Core.Entities
{
	public readonly record struct PersonId(Guid Value)
	{
		public static PersonId CreateNew() => new(Guid.NewGuid());
	}

	public class Person
	{
		public PersonId Id { get; set; }

		[StringLength(20, MinimumLength = 3)]
		public string Username { get; set; } = string.Empty;

		[ForeignKey(nameof(TaskTicket.PersonId))]
		public List<TaskTicket> Tickets { get; set; } = [];
	}
}
