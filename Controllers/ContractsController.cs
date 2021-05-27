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
	public class ContractsController : ControllerBase
	{
		private readonly IContractManager _contractManager;

		public ContractsController(IContractManager contractManager)
		{
			_contractManager = contractManager;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _contractManager.GetItem(id);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			int skip = 0;
			int take = 1;

			var result = await _contractManager.GetItems(skip, take);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ContractRequest request)
		{
			var id = await _contractManager.Create(request);
			return Ok(id);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ContractRequest request)
		{
			await _contractManager.Update(id, request);
			return Ok();

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _contractManager.Delete(id);
			return Ok();
		}
	}
}
