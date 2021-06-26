using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public ServicesController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[Authorize(Roles = "admin, user, client")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _serviceManager.GetItem(id);
			return Ok(result);
		}

		[Authorize(Roles = "admin, user, client")]
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			int skip = 0;
			int take = 1;

			var result = await _serviceManager.GetItems(skip, take);
			return Ok(result);
		}

		[Authorize(Roles = "admin, user")]
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ServiceRequest request)
		{
			var id = await _serviceManager.Create(request);
			return Ok(id);
		}

		[Authorize(Roles = "admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ServiceRequest request)
		{
			await _serviceManager.Update(id, request);
			return Ok();

		}

		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _serviceManager.Delete(id);
			return Ok();
		}
	}
}
