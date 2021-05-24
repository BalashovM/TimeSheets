using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementations
{
    public class ContractRepo : IContractRepo
    {
        private readonly TimesheetDbContext _dbContext;
        public ContractRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Contract item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            var contract = await _dbContext.Contracts.FindAsync(id);
            var now = DateTime.Now;
            var isActive = now <= contract?.DateEnd && now >= contract?.DateStart;

            return isActive;
        }

        public async Task Delete(Contract item)
        {
            throw new NotImplementedException();
        }

        public async Task<Contract> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contract>> GetItems(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Contract item)
        {
            _dbContext.Contracts.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
