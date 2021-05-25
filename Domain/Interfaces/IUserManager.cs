using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
    /// <summary>Менеджер запросов к данным по пользователю</summary>
    public interface IUserManager:IManagerBase<User, UserRequest>
    {
    }
}
