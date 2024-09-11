using Microsoft.AspNetCore.Mvc;
using TasksManagement.Core.DTO;
using TasksManagement.Core.Entities;
using TasksManagement.Core.ServiceContracts;

namespace TasksManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PeopleController : ControllerBase
	{
		private readonly IPeopleService _peopleService;

		public PeopleController(IPeopleService peopleService)
		{
			_peopleService = peopleService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPeople() => Ok(await _peopleService.GetAllAsync());

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<PersonResponse>> GetPersonById(Guid id) => Ok(await _peopleService.GetByIdAsync(new PersonId(id)));

		[HttpPost]
		public async Task<ActionResult<PersonResponse>> PostPerson(PersonRequest request)
		{
			if (!ModelState.IsValid)
			{
				return ValidationProblem(ModelState);
			}

			PersonResponse response = await _peopleService.AddAsync(request);
			return Ok(response);
		}

		[HttpPut("{id:guid}")]
		public async Task<ActionResult<PersonResponse>> PutPerson(Guid id, PersonRequest request)
		{
			if (!ModelState.IsValid)
			{
				return ValidationProblem(ModelState);
			}

			PersonResponse response = await _peopleService.UpdateAsync(new PersonId(id), request);
			return Ok(response);
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult> DeletePerson(Guid id)
		{
			await _peopleService.DeleteAsync(new PersonId(id));
			return Ok();
		}
	}
}
