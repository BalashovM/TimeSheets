using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Aggregates.EmployeeAggregate
{
    public class EmployeeAggregate: Employee
    {
        private EmployeeAggregate() { }

		public static EmployeeAggregate CreateFromRequest(EmployeeRequest request)
		{
			return new EmployeeAggregate()
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				IsDeleted = false,
			};
		}

		public void UpdateFromRequest(EmployeeRequest request)
		{
			UserId = request.UserId;
		}

		public void DeleteEmployee()
		{
			IsDeleted = true;
		}
	}
}
