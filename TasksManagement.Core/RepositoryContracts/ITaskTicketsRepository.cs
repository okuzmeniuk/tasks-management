using TasksManagement.Core.Entities;
using TasksManagement.Core.Exceptions;

namespace TasksManagement.Core.RepositoryContracts
{
	public interface ITaskTicketsRepository
	{
		/// <summary>
		/// Retrieves all records from "TaskTickets" table in database.
		/// </summary>
		/// <returns>Collection of TaskTicket objects</returns>
		Task<IEnumerable<TaskTicket>> GetAllAsync();

		/// <summary>
		/// Retrieves record by given task ticket ID.
		/// </summary>
		/// <param name="id">ID to retrieve entity by</param>
		/// <returns>Task ticket with given ID</returns>
		/// <exception cref="TaskTicketNotFoundException"></exception>
		Task<TaskTicket> GetByIdAsync(TaskTicketId id);

		/// <summary>
		/// Retrieves all records from "TaskTickets" table in database filtered by given person ID.
		/// </summary>
		/// <param name="id">Person ID to filter task tickets by</param>
		/// <returns>Collection of filtered TaskTickets objects</returns>
		Task<IEnumerable<TaskTicket>> GetAllByPersonIdAsync(PersonId id);

		/// <summary>
		/// Adds task ticket entity to database.
		/// </summary>
		/// <param name="ticketToAdd">Entity to add</param>
		/// <returns></returns>
		Task AddAsync(TaskTicket ticketToAdd);

		/// <summary>
		/// Updates task ticket entity details in database.
		/// </summary>
		/// <param name="ticketToUpdate">Entity to update</param>
		/// <returns></returns>
		Task UpdateAsync(TaskTicket ticketToUpdate);

		/// <summary>
		/// Deletes task ticket entity from database.
		/// </summary>
		/// <param name="id">ID to delete task ticket by</param>
		/// <returns></returns>
		/// <exception cref="TaskTicketNotFoundException"></exception>
		Task DeleteAsync(TaskTicketId id);
	}
}
