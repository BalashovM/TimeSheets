using System.Diagnostics.CodeAnalysis;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос для пользователя системы</summary>
	[ExcludeFromCodeCoverage]
	public class UserRequest
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
	}
}
