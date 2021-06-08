namespace TimeSheets.Models.Dto.Requests
{
    /// <summary> Запрос на аутентификацию пользователя по логину и паролю </summary>
    public class LoginRequest
	{
		public string Login { get; set; }
		public string Password { get; set; }
	}
}
