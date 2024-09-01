using Microsoft.EntityFrameworkCore;
using TasksManagement.Core.Entities;
using TasksManagement.Core.Exceptions;
using TasksManagement.Core.RepositoryContracts;
using TasksManagement.Infrastructure.DatabaseContext;

namespace TasksManagement.Infrastructure.Repositories
{
	public class PeopleRepository : IPeopleRepository
	{
		private readonly TasksDbContext _dbContext;

		public PeopleRepository(TasksDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Person>> GetAllAsync()
			=> await _dbContext.People.Include(person => person.Tickets).ToListAsync();

		public async Task<Person?> GetByIdAsync(PersonId id)
			=> await _dbContext.People.Include(person => person.Tickets).FirstOrDefaultAsync(person => person.Id == id);

		public async Task AddAsync(Person personToAdd)
		{
			await _dbContext.People.AddAsync(personToAdd);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(Person personToUpdate)
		{
			if (GetByIdAsync(personToUpdate.Id) is null)
			{
				throw new PersonNotFoundException("Person with given id to update was not found");
			}

			_dbContext.People.Update(personToUpdate);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(PersonId id)
		{
			Person? personToDelete = await GetByIdAsync(id) ?? throw new PersonNotFoundException("Person with given id to delete was not found");
			_dbContext.People.Remove(personToDelete);
			await _dbContext.SaveChangesAsync();
		}
	}
}
