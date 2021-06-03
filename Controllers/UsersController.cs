using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
    public class UsersController: TimesheetBaseController
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userManager.GetItem(id);
            return Ok(user);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            int skip = 0;
            int take = 1;

            var users = await _userManager.GetItems(skip, take);

            return Ok(users);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            var id = await _userManager.Create(request);
            return Ok(id);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserRequest request)
        {
            await _userManager.Update(id, request);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userManager.Delete(id);
            return Ok();
        }
    }
}
