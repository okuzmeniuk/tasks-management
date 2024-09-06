using TasksManagement.Core.Entities;

namespace TasksManagement.Core.DTO
{
	public static class DTOExtensions
	{
		public static TaskTicketResponse ToDTO(this TaskTicket taskTicket) 
			=> new(taskTicket.Id.Value, taskTicket.Title, taskTicket.Description, taskTicket.Status.ToString(), taskTicket.PersonId.Value);

		public static PersonResponse ToDTO(this Person person) 
			=> new(person.Id.Value, person.Username, person.Tickets.Select(ticket => ticket.ToDTO()).ToList());
	}
}
