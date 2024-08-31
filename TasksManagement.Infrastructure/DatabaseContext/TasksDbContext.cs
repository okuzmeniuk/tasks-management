using Microsoft.EntityFrameworkCore;
using TasksManagement.Core.Entities;

namespace TasksManagement.Infrastructure.DatabaseContext
{
	public class TasksDbContext(DbContextOptions options) : DbContext(options)
	{
		public DbSet<TaskTicket> TaskTickets { get; set; }
		public DbSet<Person> People { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TaskTicket>()
				.Property(ticket => ticket.Status)
				.HasConversion<string>();
		}
	}
}
