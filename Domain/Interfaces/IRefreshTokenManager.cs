using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
    public interface IRefreshTokenManager: IManagerBase<RefreshToken, RefreshTokenRequest>
    {
        Task<RefreshToken> GetItem(RefreshTokenRequest request);
        void CreateOrUpdate(RefreshToken refreshToken);
    }
}