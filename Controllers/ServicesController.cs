using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _serviceManager.GetItem(id);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			int skip = 0;
			int take = 1;

			var result = await _serviceManager.GetItems(skip, take);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ServiceRequest request)
		{
			var id = await _serviceManager.Create(request);
			return Ok(id);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ServiceRequest request)
		{
			await _serviceManager.Update(id, request);
			return Ok();

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _serviceManager.Delete(id);
			return Ok();
		}
	}
}
