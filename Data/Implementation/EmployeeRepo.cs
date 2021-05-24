using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementations
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly TimesheetDbContext _dbContext;
        public EmployeeRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Employee item)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Employee item)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetItems(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Employee item)
        {
            _dbContext.Employees.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
