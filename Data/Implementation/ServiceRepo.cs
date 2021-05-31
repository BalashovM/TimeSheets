using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementations
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly TimesheetDbContext _dbContext;
        public ServiceRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Service item)
        {
            await _dbContext.Services.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckItemIsDeleted(Guid id)
        {
            var item = await _dbContext.Services.FindAsync(id);
            return item.IsDeleted;
        }

        public async Task Delete(Guid id)
        {
            var item = await _dbContext.Services.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _dbContext.Services.Update(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Service> GetItem(Guid id)
        {
            var result = await _dbContext.Services.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Service>> GetItems(int skip, int take)
        {
            return await _dbContext.Services.ToListAsync();
        }

        public async Task Update(Service item)
        {
            _dbContext.Services.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
