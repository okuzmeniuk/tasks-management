using TasksManagement.Core.Entities;
using TasksManagement.Core.Exceptions;

namespace TasksManagement.Core.RepositoryContracts
{
	public interface IPeopleRepository
	{
		/// <summary>
		/// Retrieves all records from "People" table in database.
		/// </summary>
		/// <returns>Collection of Person objects</returns>
		Task<IEnumerable<Person>> GetAllAsync();

		/// <summary>
		/// Retrieves record by given person ID.
		/// </summary>
		/// <param name="id">ID to retrieve person by</param>
		/// <returns>Person with given ID</returns>
		/// <exception cref="PersonNotFoundException"></exception>
		Task<Person> GetByIdAsync(PersonId id);

		/// <summary>
		/// Adds person entity to database.
		/// </summary>
		/// <param name="personToAdd">Entity to add</param>
		/// <returns></returns>
		Task AddAsync(Person personToAdd);

		/// <summary>
		/// Updates person entity details in database.
		/// </summary>
		/// <param name="personToUpdate">Entity to update</param>
		/// <returns></returns>
		Task UpdateAsync(Person personToUpdate);

		/// <summary>
		/// Deletes person entity from database.
		/// </summary>
		/// <param name="id">ID to delete person by</param>
		/// <returns></returns>
		/// <exception cref="PersonNotFoundException"></exception>
		Task DeleteAsync(PersonId id);
	}
}
