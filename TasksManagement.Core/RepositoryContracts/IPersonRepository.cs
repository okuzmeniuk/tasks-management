using TasksManagement.Core.Entities;

namespace TasksManagement.Core.RepositoryContracts
{
	public interface IPersonRepository
	{
		Task<IEnumerable<Person>> GetAllAsync();
		Task<Person?> GetByIdAsync(PersonId id);
		Task AddAsync(Person personToAdd);
		Task UpdateAsync(Person personToUpdate);
		Task DeleteAsync(PersonId id);
	}
}
