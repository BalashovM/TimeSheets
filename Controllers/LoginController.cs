using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Dto.Responses;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IUserManager _userManager;
		private readonly ILoginManager _loginManager;

		public LoginController(ILoginManager loginManager, IUserManager userManager)
		{
			_loginManager = loginManager;
			_userManager = userManager;
		}

		[AllowAnonymous]
		[Route("Login")]
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
		[Route("Refresh")]
		[HttpPost]
		public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
		{
			var loginResponse = new LoginResponse();
			try
			{
				loginResponse = await _loginManager.Refresh(request);
			}
			catch (ArgumentException e)
			{
				return BadRequest(e.Message);
			}

			return Ok(loginResponse);
		}
	}
}
