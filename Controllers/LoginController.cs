using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
	public class LoginController : TimesheetBaseController
	{
		private readonly IUserManager _userManager;
		private readonly ILoginManager _loginManager;

		public LoginController(ILoginManager loginManager, IUserManager userManager)
		{
			_loginManager = loginManager;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			var user = await _userManager.GetItem(request);

			if (user == null)
			{
				return Unauthorized();
			}

			var loginResponse = await _loginManager.Authenticate(user);

			return Ok(loginResponse);
		}


	}
}
