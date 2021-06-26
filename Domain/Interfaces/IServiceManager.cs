using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
    /// <summary>Менеджер запросов к данным по услуге</summary>
    public interface IServiceManager :IManagerBase<Service,ServiceRequest>
    {
    }
}
