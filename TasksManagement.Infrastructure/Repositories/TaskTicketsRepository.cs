using Microsoft.EntityFrameworkCore;
using TasksManagement.Core.Entities;
using TasksManagement.Core.Exceptions;
using TasksManagement.Core.RepositoryContracts;
using TasksManagement.Infrastructure.DatabaseContext;

namespace TasksManagement.Infrastructure.Repositories
{
	public class TaskTicketsRepository : ITaskTicketsRepository
	{
		private readonly TasksDbContext _dbContext;

		public TaskTicketsRepository(TasksDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<TaskTicket>> GetAllAsync() => await _dbContext.TaskTickets.ToListAsync();

		public async Task<TaskTicket> GetByIdAsync(TaskTicketId id) => await _dbContext.TaskTickets.FindAsync(id)
			?? throw new TaskTicketNotFoundException("Task ticket with given id to get was not found");

		public async Task<IEnumerable<TaskTicket>> GetAllByPersonIdAsync(PersonId id)
			=> await _dbContext.TaskTickets.Where(task => task.PersonId == id).ToListAsync();

		public async Task AddAsync(TaskTicket ticketToAdd)
		{
			await _dbContext.TaskTickets.AddAsync(ticketToAdd);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(TaskTicket ticketToUpdate)
		{
			if (GetByIdAsync(ticketToUpdate.Id) is null)
			{
				_dbContext.TaskTickets.Add(ticketToUpdate);
			}
			else
			{
				_dbContext.TaskTickets.Update(ticketToUpdate);
			}
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(TaskTicketId id)
		{
			TaskTicket? taskTicketToDelete = await GetByIdAsync(id)
				?? throw new TaskTicketNotFoundException("Task ticket with given id to delete was not found");
			_dbContext.TaskTickets.Remove(taskTicketToDelete);
			await _dbContext.SaveChangesAsync();
		}

	}
}
