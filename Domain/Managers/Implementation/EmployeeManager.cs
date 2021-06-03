using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeManager(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<Employee> GetItem(Guid id)
        {
            return await _employeeRepo.GetItem(id);
        }

        public async Task<IEnumerable<Employee>> GetItems(int skip, int take)
        {
            return await _employeeRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(EmployeeRequest request)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                IsDeleted = false
            };

            await _employeeRepo.Add(employee);

            return employee.Id;
        }

        public async Task Update(Guid id, EmployeeRequest request)
        {
            var employee = await _employeeRepo.GetItem(id);
            if (employee != null)
            {
                employee.UserId = request.UserId;

                await _employeeRepo.Update(employee);
            }
        }

        public async Task<bool> CheckEmployeeIsDeleted(Guid id)
        {
            return await _employeeRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            await _employeeRepo.Delete(id);
        }
    }
}
