using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Implementation
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

        public async Task<Contract> GetItem(Guid id)
        {
            return await _contractRepo.GetItem(id);
        }

        public async Task<IEnumerable<Contract>> GetItems(int skip, int take)
        {
            return await _contractRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(ContractRequest request)
        {
            var contract = new Contract()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                DateStart = request.DateStart,
                DateEnd = request.DateEnd,
                Description = request.Description,
                IsDeleted = false
            };

            await _contractRepo.Add(contract);

            return contract.Id;
        }

        public async Task Update(Guid id, ContractRequest request)
        {
            var contract = await _contractRepo.GetItem(id);
            if (contract != null)
            {
                contract.Title = request.Title;
                contract.DateStart = request.DateStart;
                contract.DateEnd = request.DateEnd;
                contract.Description = request.Description;

                await _contractRepo.Update(contract);
            }
        }

        public async Task<bool> CheckContractIsDeleted(Guid id)
        {
            return await _contractRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            await _contractRepo.Delete(id);
        }
    }
}
