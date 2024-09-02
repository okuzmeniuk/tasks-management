using System.ComponentModel.DataAnnotations;
using TasksManagement.Core.Entities;

namespace TasksManagement.Core.DTO
{
	public record PersonResponse(
		PersonId Id,
		string Username,
		List<TaskTicketResponse> Tickets
	);

	public record PersonRequest(
		[Required][StringLength(20, MinimumLength = 3)] string Username
	)
	{
		public Person ToPerson() => new() { Username = Username };
	}
}
