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

		[HttpPost]
		public async Task<ActionResult<TaskTicketResponse>> PostTaskTicket(TaskTicketRequest request)
		{
			if (request.PersonId == Guid.Empty)
			{
				ModelState.AddModelError("personId", "PersonId should not be empty");
			}

			if (!ModelState.IsValid)
			{
				return ValidationProblem(ModelState);
			}

			TaskTicketResponse response = await _taskTicketsService.AddAsync(request);
			return Ok(response);
		}

		[HttpPut("{id:guid}")]
		public async Task<ActionResult<TaskTicketResponse>> PutTaskTicket(Guid id, TaskTicketRequest request)
		{
			if (request.PersonId == Guid.Empty)
			{
				ModelState.AddModelError("personId", "PersonId should not be empty");
			}

			if (!ModelState.IsValid)
			{
				return ValidationProblem(ModelState);
			}

			TaskTicketResponse response = await _taskTicketsService.UpdateAsync(new TaskTicketId(id), request);
			return Ok(response);
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult> DeleteTaskTicket(Guid id)
		{
			await _taskTicketsService.DeleteAsync(new TaskTicketId(id));
			return Ok();
		}
	}
}
