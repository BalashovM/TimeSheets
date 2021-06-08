using System.Threading.Tasks;
using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates.UserAggregate;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по пользователю</summary>
    public interface IUserManager:IManagerBase<UserAggregate, UserRequest>
    {
        Task<UserAggregate> GetItem(LoginRequest request);
    }
}
