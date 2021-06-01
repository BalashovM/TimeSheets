using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Data.Interfaces
{
    public interface IRefreshTokenRepo : IRepoBase<RefreshToken>
    {
        Task<RefreshToken> GetItem(string refreshToken);
    }
}