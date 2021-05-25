using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
    /// <summary>Менеджер запросов к данным по сотрднику</summary>
    public interface IEmployeeManager:IManagerBase<Employee,EmployeeRequest>
    {
    }
}
