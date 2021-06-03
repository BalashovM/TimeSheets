using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по пользователю</summary>
    public interface IUserManager:IManagerBase<User, UserRequest>
    {
        Task<User> GetItem(LoginRequest request);
    }
}
