using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates.ClientAggregate;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по клиенту</summary>
    public interface IClientManager:IManagerBase<ClientAggregate, ClientRequest>
    {
    }
}
