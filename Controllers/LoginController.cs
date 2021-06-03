using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Dto.Responses;

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

		[AllowAnonymous]
		[Route("login")]
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

		[AllowAnonymous]
		[Route("refresh")]
		[HttpPost("/refresh")]
		public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
		{
			var loginResponse = new LoginResponse();
			try
			{
				loginResponse = await _loginManager.RefreshToken(request);
			}
			catch (ArgumentException e)
			{
				return BadRequest(e.Message);
			}

			return Ok(loginResponse);
		}
	}
}
