﻿using Microsoft.EntityFrameworkCore;
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
			=> await _dbContext.People.AsNoTracking().Include(person => person.Tickets).ToListAsync();

		public async Task<Person> GetByIdAsync(PersonId id)
			=> await _dbContext.People.AsNoTracking().Include(person => person.Tickets).FirstOrDefaultAsync(person => person.Id == id)
			?? throw new PersonNotFoundException("Person with given id was not found");

		public async Task AddAsync(Person personToAdd)
		{
			await _dbContext.People.AddAsync(personToAdd);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(Person personToUpdate)
		{
			try
			{
				await GetByIdAsync(personToUpdate.Id);
				_dbContext.People.Update(personToUpdate);
			}
			catch (PersonNotFoundException)
			{
				await _dbContext.People.AddAsync(personToUpdate);
			}

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
