using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.ContractAggregate;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class ContractManager : IContractManager
    {
        private readonly IContractAggregateRepo _contractAggregateRepo;

        public ContractManager(IContractAggregateRepo contractAggregateRepo)
        {
            _contractAggregateRepo = contractAggregateRepo;
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            return await _contractAggregateRepo.CheckContractIsActive(id);
        }

        public async Task<ContractAggregate> GetItem(Guid id)
        {
            return await _contractAggregateRepo.GetItem(id);
        }

        public async Task<IEnumerable<ContractAggregate>> GetItems(int skip, int take)
        {
            return await _contractAggregateRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(ContractRequest request)
        {
            var contract = ContractAggregate.CreateFromRequest(request);

            await _contractAggregateRepo.Add(contract);

            return contract.Id;
        }

        public async Task Update(Guid id, ContractRequest request)
        {
            var contract = await _contractAggregateRepo.GetItem(id);
            if (contract != null)
            {
                contract.UpdateFromRequest(request);
            }
        }

        public async Task<bool> CheckContractIsDeleted(Guid id)
        {
            return await _contractAggregateRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            var contract = await _contractAggregateRepo.GetItem(id);
            contract.DeleteContract();
            await _contractAggregateRepo.Update(contract);
        }
    }
}
