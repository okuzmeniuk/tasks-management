using TasksManagement.Core.DTO;
using TasksManagement.Core.Entities;
using TasksManagement.Core.RepositoryContracts;
using TasksManagement.Core.ServiceContracts;

namespace TasksManagement.Core.Services
{
	public class PeopleService : IPeopleService
	{
		private readonly IPeopleRepository _peopleRepository;

		public PeopleService(IPeopleRepository peopleRepository)
		{
			_peopleRepository = peopleRepository;
		}

		public async Task<IEnumerable<PersonResponse>> GetAllAsync() 
			=> (await _peopleRepository.GetAllAsync())
			.Select(person => person.ToDTO());

		public async Task<PersonResponse> GetByIdAsync(PersonId id) => (await _peopleRepository.GetByIdAsync(id)).ToDTO();
		
		public async Task AddAsync(PersonRequest addRequest)
		{
			Person person = addRequest.ToPerson();
			person.Id = PersonId.CreateNew();
			await _peopleRepository.AddAsync(person);
		}

		public async Task UpdateAsync(PersonId id, PersonRequest updateRequest)
		{
			Person person = updateRequest.ToPerson();
			person.Id = id;
			await _peopleRepository.UpdateAsync(person);
		}
		
		public async Task DeleteAsync(PersonId id) => await _peopleRepository.DeleteAsync(id);
	}
}
