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
	public class ClientsController : ControllerBase
	{
		private readonly IClientManager _clientManager;

		public ClientsController(IClientManager clientManager)
		{
			_clientManager = clientManager;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _clientManager.GetItem(id);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			int skip = 0;
			int take = 1;

			var result = await _clientManager.GetItems(skip, take);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ClientRequest request)
		{
			var id = await _clientManager.Create(request);
			return Ok(id);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ClientRequest request)
		{
			await _clientManager.Update(id, request);
			return Ok();

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _clientManager.Delete(id);
			return Ok();
		}
	}
}
