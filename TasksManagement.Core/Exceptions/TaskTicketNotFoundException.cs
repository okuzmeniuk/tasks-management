namespace TasksManagement.Core.Exceptions
{
	public class TaskTicketNotFoundException : NotFoundException
	{
		public TaskTicketNotFoundException() { }
		public TaskTicketNotFoundException(string? message) : base(message) { }
	}
}
