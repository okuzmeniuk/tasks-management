using TasksManagement.Core.Entities;

namespace TasksManagement.Core.DTO
{
	public static class DTOExtensions
	{
		public static TaskTicketResponse ToDTO(this TaskTicket taskTicket) 
			=> new(taskTicket.Id, taskTicket.Title, taskTicket.Description, taskTicket.Status, taskTicket.PersonId);

		public static PersonResponse ToDTO(this Person person) 
			=> new(person.Id, person.Username, person.Tickets.Select(ticket => ticket.ToDTO()).ToList());
	}
}
