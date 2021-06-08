using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Aggregates.SheetAggregate
{
    public class SheetAggregate: Sheet
    {
        private SheetAggregate() { }

        public static SheetAggregate Create(int amount, Guid contractId, DateTime date, Guid employeeId, Guid serviceId)
        {
            return new SheetAggregate()
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                ContractId = contractId,
                Date = date,
                EmployeeId = employeeId,
                ServiceId = serviceId
            };
        }

        public static SheetAggregate CreateFromRequest(SheetRequest request)
        {
            return new SheetAggregate()
            {
                Id = Guid.NewGuid(),
                Amount = request.Amount,
                ContractId = request.ContractId,
                Date = request.Date,
                EmployeeId = request.EmployeeId,
                ServiceId = request.ServiceId
            };
        }

        public void UpdateFromRequest(SheetRequest request)
        {
            Amount = request.Amount;
            ContractId = request.ContractId;
            Date = request.Date;
            EmployeeId = request.EmployeeId;
            ServiceId = request.ServiceId;
        }

        public void ApproveSheet()
        {
            IsApproved = true;
            ApprovesDate = DateTime.Now;
        }

        public void ChangeEmployee(Guid newEmployee) 
        {
            EmployeeId = newEmployee;
        }

        public void DeleteSheet()
        {
            IsDeleted = true;
        }
    }
}
