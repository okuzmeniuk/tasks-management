using TasksManagement.Core.DTO;
using TasksManagement.Core.Entities;
using TasksManagement.Core.Exceptions;
using TasksManagement.Core.RepositoryContracts;
using TasksManagement.Core.ServiceContracts;

namespace TasksManagement.Core.Services
{
	public class TaskTicketsService : ITaskTicketsService
	{
		private readonly ITaskTicketsRepository _taskTicketsRepository;
		private readonly IPeopleRepository _peopleRepository;

		public TaskTicketsService(ITaskTicketsRepository taskTicketsRepository, IPeopleRepository peopleRepository)
		{
			_taskTicketsRepository = taskTicketsRepository;
			_peopleRepository = peopleRepository;
		}

		public async Task<IEnumerable<TaskTicketResponse>> GetAllAsync()
			=> (await _taskTicketsRepository.GetAllAsync()).Select(taskTicket => taskTicket.ToDTO());

		public async Task<TaskTicketResponse> GetByIdAsync(TaskTicketId id) => (await _taskTicketsRepository.GetByIdAsync(id)).ToDTO();

		public async Task<TaskTicketResponse> AddAsync(TaskTicketRequest addRequest) => await UpdateAsync(TaskTicketId.CreateNew(), addRequest);

		public async Task<TaskTicketResponse> UpdateAsync(TaskTicketId id, TaskTicketRequest updateRequest)
		{
			try
			{
				await _peopleRepository.GetByIdAsync(new(updateRequest.PersonId));
				TaskTicket taskTicket = updateRequest.ToTaskTicket();
				taskTicket.Id = id;
				await _taskTicketsRepository.UpdateAsync(taskTicket);
				return taskTicket.ToDTO();
			}
			catch (PersonNotFoundException)
			{
				throw new PersonNotFoundException("Person with given ID does not exist");
			}
		}

		public async Task DeleteAsync(TaskTicketId id) => await _taskTicketsRepository.DeleteAsync(id);
	}
}
