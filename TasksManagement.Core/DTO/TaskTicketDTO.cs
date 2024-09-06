using System.ComponentModel.DataAnnotations;
using TasksManagement.Core.Entities;

namespace TasksManagement.Core.DTO
{
	public record TaskTicketResponse(
		Guid Id,
		string Title,
		string Description,
		string Status,
		Guid PersonId
	);

	public record TaskTicketRequest(
		[StringLength(100, MinimumLength = 3)] string Title,
		[StringLength(1024)] string Description,
		[Required][RegularExpression(@"Open|Closed")] string Status,
		[Required] Guid PersonId
	)
	{
		public TaskTicket ToTaskTicket() => new()
		{
			Title = Title,
			Description = Description,
			Status = Status == "Open" ? Enums.Status.Open : Enums.Status.Closed,
			PersonId = new PersonId(PersonId)
		};
	}
}
