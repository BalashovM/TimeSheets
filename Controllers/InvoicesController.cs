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
	public class InvoicesController : ControllerBase
	{
		private readonly IInvoiceManager _invoiceManager;

		public InvoicesController(IInvoiceManager invoiceManager)
		{
			_invoiceManager = invoiceManager;
		}

		[Authorize(Roles = "admin, client")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _invoiceManager.GetItem(id);
			return Ok(result);
		}

		[Authorize(Roles = "admin, client")]
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			int skip = 0;
			int take = 1;

			var result = await _invoiceManager.GetItems(skip, take);
			return Ok(result);
		}

		[Authorize(Roles = "admin")]
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] InvoiceRequest request)
		{
			var id = await _invoiceManager.Create(request);
			return Ok(id);
		}

		[Authorize(Roles = "admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] InvoiceRequest request)
		{
			await _invoiceManager.Update(id, request);
			return Ok();

		}

		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _invoiceManager.Delete(id);
			return Ok();
		}
	}
}
