using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по услуге</summary>
    public interface IServiceManager :IManagerBase<Service,ServiceRequest>
    {
    }
}
