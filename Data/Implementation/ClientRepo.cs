using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models.Enities;

namespace TimeSheets.Data.Implementations
{
    public class ClientRepo : IClientRepo
    {
        private readonly TimesheetDbContext _dbContext;
        public ClientRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Client item)
        {
            await _dbContext.Clients.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckItemIsDeleted(Guid id)
        {
            var item = await _dbContext.Clients.FindAsync(id);
            return item.IsDeleted;
        }

        public async Task Delete(Guid id)
        {
            var item = await _dbContext.Clients.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _dbContext.Clients.Update(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Client> GetItem(Guid id)
        {
            var result = await _dbContext.Clients.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Client>> GetItems(int skip, int take)
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task Update(Client item)
        {
            _dbContext.Clients.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
