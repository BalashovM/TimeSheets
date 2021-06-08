using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models.Enities;

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
            await _dbContext.Contracts.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            var contract = await _dbContext.Contracts.FindAsync(id);
            var now = DateTime.Now;
            var isActive = now <= contract?.DateEnd && now >= contract?.DateStart;

            return isActive;
        }
        public async Task<bool> CheckItemIsDeleted(Guid id)
        {
            var item = await _dbContext.Contracts.FindAsync(id);
            return item.IsDeleted;
        }

        public async Task Delete(Guid id)
        {
            /*var item = await _dbContext.Contracts.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _dbContext.Contracts.Update(item);
                await _dbContext.SaveChangesAsync();
            }*/
        }

        public async Task<Contract> GetItem(Guid id)
        {
            var result = await _dbContext.Contracts.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Contract>> GetItems(int skip, int take)
        {
            return await _dbContext.Contracts.ToListAsync();
        }

        public async Task Update(Contract item)
        {
            _dbContext.Contracts.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
