using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.ContractAggregate;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по контракту</summary>
    public interface IContractManager:IManagerBase<ContractAggregate,ContractRequest>
    {
        Task<bool?> CheckContractIsActive(Guid id);
    }
}
