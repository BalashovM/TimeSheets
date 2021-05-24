using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public async Task Delete(Service item)
        {
            throw new NotImplementedException();
        }

        public async Task<Service> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Service>> GetItems(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Service item)
        {
            _dbContext.Services.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
