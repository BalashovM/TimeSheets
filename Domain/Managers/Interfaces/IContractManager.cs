using System;
using System.Threading.Tasks;
using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по контракту</summary>
    public interface IContractManager:IManagerBase<Contract,ContractRequest>
    {
        Task<bool?> CheckContractIsActive(Guid id);
    }
}
