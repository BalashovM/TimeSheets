using System;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Aggregates.ContractAggregate
{
    public interface IContractAggregateRepo: IAggregateBase<ContractAggregate>
    {
        Task<bool?> CheckContractIsActive(Guid id);
    }
}
