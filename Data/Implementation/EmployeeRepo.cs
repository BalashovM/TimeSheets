using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models.Enities;

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
            await _dbContext.Employees.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckItemIsDeleted(Guid id)
        {
            var item = await _dbContext.Employees.FindAsync(id);
            return item.IsDeleted;
        }
        public async Task Delete(Guid id)
        {
            /*var item = await _dbContext.Employees.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _dbContext.Employees.Update(item);
                await _dbContext.SaveChangesAsync();
            }*/
        }

        public async Task<Employee> GetItem(Guid id)
        {
            var result = await _dbContext.Employees.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetItems(int skip, int take)
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task Update(Employee item)
        {
            _dbContext.Employees.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
