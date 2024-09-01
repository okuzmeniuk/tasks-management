using TasksManagement.Core.Entities;

namespace TasksManagement.Core.RepositoryContracts
{
	public interface ITaskTicketsRepository
	{
		Task<IEnumerable<TaskTicket>> GetAllAsync();
		Task<TaskTicket?> GetByIdAsync(TaskTicketId id);
		Task<IEnumerable<TaskTicket>> GetAllByPersonIdAsync(PersonId id);
		Task AddAsync(TaskTicket ticketToAdd);
		Task UpdateAsync(TaskTicket ticketToUpdate);
		Task DeleteAsync(TaskTicketId id);
	}
}
