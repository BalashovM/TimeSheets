using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
	public class EmployeesController : TimesheetBaseController
	{
		private readonly IEmployeeManager _employeeManager;

		public EmployeesController(IEmployeeManager employeeManager)
		{
			_employeeManager = employeeManager;
		}

		[Authorize(Roles = "admin, user")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _employeeManager.GetItem(id);
			return Ok(result);
		}

		[Authorize(Roles = "admin, user")]
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			int skip = 0;
			int take = 1;

			var result = await _employeeManager.GetItems(skip, take);
			return Ok(result);
		}

		[Authorize(Roles = "admin")]
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] EmployeeRequest request)
		{
			var id = await _employeeManager.Create(request);
			return Ok(id);
		}

		[Authorize(Roles = "admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeRequest request)
		{
			await _employeeManager.Update(id, request);
			return Ok();

		}

		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _employeeManager.Delete(id);
			return Ok();
		}
	}
}
