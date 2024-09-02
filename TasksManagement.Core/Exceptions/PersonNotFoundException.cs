namespace TasksManagement.Core.Exceptions
{
	public class PersonNotFoundException : NotFoundException
	{
		public PersonNotFoundException() { }
		public PersonNotFoundException(string? message) : base(message) { }
	}
}
