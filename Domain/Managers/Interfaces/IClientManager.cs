using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по клиенту</summary>
    public interface IClientManager:IManagerBase<Client, ClientRequest>
    {
    }
}
