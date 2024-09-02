using TasksManagement.Core.DTO;
using TasksManagement.Core.Entities;

namespace TasksManagement.Core.ServiceContracts
{
	public interface IPeopleService
	{
		Task<IEnumerable<PersonResponse>> GetAllAsync();
		Task<PersonResponse> GetByIdAsync(PersonId id);
		Task AddAsync(PersonRequest addRequest);
		Task UpdateAsync(PersonId id, PersonRequest updateRequest);
		Task DeleteAsync(PersonId id);
	}
}
