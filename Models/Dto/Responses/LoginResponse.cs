using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Responses
{
	/// <summary>Результат аутентификации пользователя</summary>
	public class LoginResponse
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public long ExpiresIn { get; set; }
	}
}
