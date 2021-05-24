using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Domain.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeManager(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Guid> Create(Employee item)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                UserId = item.UserId
            };

            await _employeeRepo.Add(employee);

            return employee.Id;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            return await _employeeRepo.GetItem(id);
        }

        public async Task<IEnumerable<Employee>> GetItems(int skip, int take)
        {
            return await _employeeRepo.GetItems(skip, take);
        }
    }
}
