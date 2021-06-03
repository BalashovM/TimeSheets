using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по сотрднику</summary>
    public interface IEmployeeManager:IManagerBase<Employee,EmployeeRequest>
    {
    }
}
