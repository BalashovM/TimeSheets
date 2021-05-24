using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

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
            throw new NotImplementedException();
        }

        public async Task Delete(Client item)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetItems(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Client item)
        {
            _dbContext.Clients.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
