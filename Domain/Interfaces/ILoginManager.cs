using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Dto.Responses;

namespace TimeSheets.Domain.Interfaces
{  /// <summary> Менеджер атентификации пользователя </summary>
	public interface ILoginManager
	{
		Task<LoginResponse> Authenticate(User user);
		Task<LoginResponse> RefreshToken(RefreshTokenRequest request);
	}
}
