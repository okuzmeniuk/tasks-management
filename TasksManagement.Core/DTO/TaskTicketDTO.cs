using System.ComponentModel.DataAnnotations;
using TasksManagement.Core.Entities;
using TasksManagement.Core.Enums;

namespace TasksManagement.Core.DTO
{
	public record TaskTicketResponse(
		TaskTicketId Id,
		string Title,
		string Description,
		Status Status,
		PersonId PersonId
	);

	public record TaskTicketRequest(
		[StringLength(100, MinimumLength = 3)] string Title,
		[StringLength(1024)] string Description,
		[Required] Status Status,
		[Required] PersonId PersonId
	);
}
