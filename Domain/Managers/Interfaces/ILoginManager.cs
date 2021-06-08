using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.UserAggregate;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Dto.Responses;

namespace TimeSheets.Domain.Managers.Interfaces
{  /// <summary> Менеджер атентификации пользователя </summary>
	public interface ILoginManager
	{
		Task<LoginResponse> Authenticate(UserAggregate user);
		Task<LoginResponse> RefreshToken(RefreshTokenRequest request);
	}
}
