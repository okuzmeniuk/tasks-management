namespace TasksManagement.Core.Exceptions
{
	public class TaskTicketNotFoundException : Exception
	{
		public TaskTicketNotFoundException() { }
		public TaskTicketNotFoundException(string? message) : base(message) { }
	}
}
