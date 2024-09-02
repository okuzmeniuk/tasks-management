using TasksManagement.Core.DTO;
using TasksManagement.Core.Entities;
using TasksManagement.Core.RepositoryContracts;
using TasksManagement.Core.ServiceContracts;

namespace TasksManagement.Core.Services
{
	public class TaskTicketsService : ITaskTicketsService
	{
		private readonly ITaskTicketsRepository _taskTicketsRepository;

		public TaskTicketsService(ITaskTicketsRepository taskTicketsRepository)
		{
			_taskTicketsRepository = taskTicketsRepository;
		}

		public async Task<IEnumerable<TaskTicketResponse>> GetAllAsync()
			=> (await _taskTicketsRepository.GetAllAsync()).Select(taskTicket => taskTicket.ToDTO());

		public async Task<TaskTicketResponse> GetByIdAsync(TaskTicketId id) => (await _taskTicketsRepository.GetByIdAsync(id)).ToDTO();

		public async Task<IEnumerable<TaskTicketResponse>> GetAllByPersonIdAsync(PersonId id)
			=> (await _taskTicketsRepository.GetAllByPersonIdAsync(id)).Select(taskTicket => taskTicket.ToDTO());

		public async Task AddAsync(TaskTicketRequest addRequest)
		{
			TaskTicket taskTicket = addRequest.ToTaskTicket();
			taskTicket.Id = TaskTicketId.CreateNew();
			await _taskTicketsRepository.AddAsync(taskTicket);
		}

		public async Task UpdateAsync(TaskTicketId id, TaskTicketRequest updateRequest)
		{
			TaskTicket taskTicket = updateRequest.ToTaskTicket();
			taskTicket.Id = id;
			await _taskTicketsRepository.UpdateAsync(taskTicket);
		}

		public async Task DeleteAsync(TaskTicketId id) => await _taskTicketsRepository.DeleteAsync(id);
	}
}
