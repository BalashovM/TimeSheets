using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates.EmployeeAggregate;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по сотрднику</summary>
    public interface IEmployeeManager:IManagerBase<EmployeeAggregate,EmployeeRequest>
    {
    }
}
