using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Infrastructure.Extensions;
using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Auth;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Dto.Responses;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class LoginManager : ILoginManager
	{
		private readonly JwtAccessOptions _jwtAccessOptions;
		private readonly JwtRefreshOptions _jwtRefreshOptions;
		private readonly IUserRepo _userRepo;

		public LoginManager(IOptions<JwtAccessOptions> jwtAccessOptions, IOptions<JwtRefreshOptions> jwtRefreshOptions, IUserRepo userRepo)
		{
			_jwtAccessOptions = jwtAccessOptions.Value;
			_jwtRefreshOptions = jwtRefreshOptions.Value;
			_userRepo = userRepo;
		}

		/// <summary>Аутентифицирует пользователя</summary>
		public async Task<LoginResponse> Authenticate(User user)
		{
			var loginResponse = CreateTokensPair(user);

			user.RefreshToken = loginResponse.RefreshToken;
			await _userRepo.Update(user);

			return loginResponse;
		}

		///<summary>Обновляет пару токенов для пользователя</summary>
		public async Task<LoginResponse> RefreshToken(RefreshTokenRequest request)
		{
			var securityHandler = new JwtSecurityTokenHandler();
			var refreshTokenRaw = securityHandler.ReadJwtToken(request.RefreshToken);
			var validTo = refreshTokenRaw.ValidTo;

			var userId = Guid.Parse(refreshTokenRaw.Subject);

			var user = await _userRepo.GetItem(userId);

			if (user == null || user.RefreshToken != request.RefreshToken || validTo < DateTime.Now)
			{
				throw new ArgumentException("Bad Refresh token");
			}

			var loginResponse = CreateTokensPair(user);

			user.RefreshToken = loginResponse.RefreshToken;
			await _userRepo.Update(user);

			return loginResponse;
		}

		/// <summary>Создает пару токенов для пользователя</summary>
		private LoginResponse CreateTokensPair(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
			};

			var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
			var refreshTokenRaw = _jwtRefreshOptions.GenerateToken(claims);

			var securityHandler = new JwtSecurityTokenHandler();

			var accessToken = securityHandler.WriteToken(accessTokenRaw);
			var refreshToken = securityHandler.WriteToken(refreshTokenRaw);

			var loginResponse = new LoginResponse()
			{
				AccessToken = accessToken,
				ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime(),
				RefreshToken = refreshToken,
			};

			return loginResponse;
		}
	}
}
