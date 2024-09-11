using TasksManagement.Core.DTO;
using TasksManagement.Core.Entities;

namespace TasksManagement.Core.ServiceContracts
{
	public interface ITaskTicketsService
	{
		Task<IEnumerable<TaskTicketResponse>> GetAllAsync();
		Task<TaskTicketResponse> GetByIdAsync(TaskTicketId id);
		Task<TaskTicketResponse> AddAsync(TaskTicketRequest addRequest);
		Task<TaskTicketResponse> UpdateAsync(TaskTicketId id, TaskTicketRequest updateRequest);
		Task DeleteAsync(TaskTicketId id);
	}
}
