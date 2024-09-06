using Microsoft.AspNetCore.Mvc;
using TasksManagement.Core.DTO;
using TasksManagement.Core.Entities;
using TasksManagement.Core.ServiceContracts;

namespace TasksManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskTicketsController : ControllerBase
	{
		private readonly ITaskTicketsService _taskTicketsService;

		public TaskTicketsController(ITaskTicketsService taskTicketsService)
		{
			_taskTicketsService = taskTicketsService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TaskTicketResponse>>> GetTaskTickets()
			=> Ok(await _taskTicketsService.GetAllAsync());

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<TaskTicketResponse>> GetByTaskTicketId(Guid id)
			=> Ok(await _taskTicketsService.GetByIdAsync(new TaskTicketId(id)));

		[HttpGet("byPersonId/{id:guid}")]
		public async Task<ActionResult<IEnumerable<TaskTicketResponse>>> GetByAuthorId(Guid id)
			=> Ok(await _taskTicketsService.GetAllByPersonIdAsync(new PersonId(id)));

		[HttpPost]
		public async Task<ActionResult> PostTaskTicket(TaskTicketRequest request)
		{
			await _taskTicketsService.AddAsync(request);
			return Ok();
		}

		[HttpPut("{id:guid}")]
		public async Task<ActionResult> PutTaskTicket(Guid id, TaskTicketRequest request)
		{
			await _taskTicketsService.UpdateAsync(new TaskTicketId(id), request);
			return Ok();
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult> DeleteTaskTicket(Guid id)
		{
			await _taskTicketsService.DeleteAsync(new TaskTicketId(id));
			return Ok();
		}
	}
}
