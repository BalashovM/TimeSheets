using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SheetController:ControllerBase
    {
        private readonly ISheetManager _sheetManager;

        public SheetController(ISheetManager sheetManager)
        {
            _sheetManager = sheetManager;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var result =_sheetManager.GetItem(id);

            return Ok(result);
        }
    }
}
