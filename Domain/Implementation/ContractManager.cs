using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Domain.Implementation
{
    public class ContractManager : IContractManager
    {
        private readonly IContractRepo _contractRepo;

        public ContractManager(IContractRepo contractRepo)
        {
            _contractRepo = contractRepo;
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            return await _contractRepo.CheckContractIsActive(id);
        }

        public async Task<Guid> Create(Contract item)
        {
            var contract = new Contract
            {
                Id = Guid.NewGuid(),
                Title = item.Title,
                DateStart = item.DateStart,
                DateEnd = item.DateEnd,
                Description = item.Description
            };

            await _contractRepo.Add(contract);

            return contract.Id;
        }

        public async Task<Contract> GetItem(Guid id)
        {
            return await _contractRepo.GetItem(id);
        }

        public async Task<IEnumerable<Contract>> GetItems(int skip, int take)
        {
            return await _contractRepo.GetItems(skip, take);
        }
    }
}
