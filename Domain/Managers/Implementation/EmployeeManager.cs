using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.EmployeeAggregate;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeAggregateRepo _employeeAggregateRepo;

        public EmployeeManager(IEmployeeAggregateRepo employeeAggregateRepo)
        {
            _employeeAggregateRepo = employeeAggregateRepo;
        }
        public async Task<EmployeeAggregate> GetItem(Guid id)
        {
            return await _employeeAggregateRepo.GetItem(id);
        }

        public async Task<IEnumerable<EmployeeAggregate>> GetItems(int skip, int take)
        {
            return await _employeeAggregateRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(EmployeeRequest request)
        {
            var employee = EmployeeAggregate.CreateFromRequest(request);

            await _employeeAggregateRepo.Add(employee);

            return employee.Id;
        }

        public async Task Update(Guid id, EmployeeRequest request)
        {
            var employee = await _employeeAggregateRepo.GetItem(id);
            employee.UpdateFromRequest(request);
        }

        public async Task<bool> CheckEmployeeIsDeleted(Guid id)
        {
            return await _employeeAggregateRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            var employee = await _employeeAggregateRepo.GetItem(id);
            employee.DeleteEmployee();
            await _employeeAggregateRepo.Update(employee);
        }
    }
}
