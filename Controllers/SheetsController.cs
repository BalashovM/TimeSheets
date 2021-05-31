using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SheetsController : ControllerBase
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contracManager;

        public SheetsController(ISheetManager sheetManager, IContractManager contracManager)
        {
            _sheetManager = sheetManager;
            _contracManager = contracManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _sheetManager.GetItem(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetItems(int skip, int take)
        {
            var result = await _sheetManager.GetItems(skip, take);

            return Ok(result);
        }

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

        /// <summary> ОБновляет запись табеля </summary>
        /// <param name="id"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        /// 
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


    }
}
