﻿using Microsoft.AspNetCore.Mvc;
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
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeManager _employeeManager;

		public EmployeesController(IEmployeeManager employeeManager)
		{
			_employeeManager = employeeManager;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _employeeManager.GetItem(id);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			int skip = 0;
			int take = 1;

			var result = await _employeeManager.GetItems(skip, take);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] EmployeeRequest request)
		{
			var id = await _employeeManager.Create(request);
			return Ok(id);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeRequest request)
		{
			await _employeeManager.Update(id, request);
			return Ok();

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _employeeManager.Delete(id);
			return Ok();
		}
	}
}
