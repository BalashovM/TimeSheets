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
		private readonly IRefreshTokenManager _refreshTokenManager;

		public LoginController(ILoginManager loginManager, IUserManager userManager, IRefreshTokenManager refreshTokenManager)
		{
			_loginManager = loginManager;
			_userManager = userManager;
			_refreshTokenManager = refreshTokenManager;
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

		[HttpPost("/refreshtoken")]
		public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
		{
			//var refreshToket = await _refreshTokenManager.CreateOrUpdate(request);
			var token = await _refreshTokenManager. .GetItem(request.Token);
			//if (token == null) return Unauthorized();

			//var user = await _userManager.GetItem(token.UserId);
			//if (user == null) return Unauthorized();

			//var loginResponse = _loginManager.Authenticate(user);

			return Ok();
		}

	}
}
