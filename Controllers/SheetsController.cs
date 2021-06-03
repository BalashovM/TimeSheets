using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
    public class SheetsController : TimesheetBaseController
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contracManager;

        public SheetsController(ISheetManager sheetManager, IContractManager contracManager)
        {
            _sheetManager = sheetManager;
            _contracManager = contracManager;
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _sheetManager.GetItem(id);

            return Ok(result);
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            int skip = 0;
            int take = 1;

            var result = await _sheetManager.GetItems(skip, take);

            return Ok(result);
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SheetRequest sheet)
        {
            var isAllowedToCreate = await _contracManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate !=null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found.");  
            }
            
            var id = await _sheetManager.Create(sheet);

            return Ok(id);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] SheetRequest sheet)
        {

            var isAllowedToCreate = await _contracManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found.");
            }

            await _sheetManager.Update(id, sheet);
            return Ok(id);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _sheetManager.Delete(id);
            return Ok();
        }
    }
}
