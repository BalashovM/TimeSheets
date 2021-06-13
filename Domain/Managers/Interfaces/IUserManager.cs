using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.UserAggregate;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по пользователю</summary>
    public interface IUserManager:IManagerBase<UserAggregate, UserRequest>
    {
        Task<UserAggregate> GetItem(LoginRequest request);
    }
}
