using System;
using TimeSheets.Domain.Aggregates.SheetAggregate;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Tests.AggregateTests
{
    public class SheetAggreagteBuilder
    {
        public Guid SheetContractId = Guid.Parse("dbecaed4-ed2f-4797-9d68-b69ae04d91d0");
        public Guid SheetEmployeeId = Guid.Parse("9601412c-4884-4077-ad18-faecebbd3f76");
        public Guid SheetServiceId = Guid.Parse("d0106e3b-65b9-4f47-a33b-c7a158808cbd");

        public SheetAggregate CreateRandomSheet()
        {
            var sheetRequest = new SheetRequest()
            {
                Amount = 8,
                ContractId = SheetContractId,
                Date = DateTime.Now,
                EmployeeId = SheetEmployeeId,
                ServiceId = SheetServiceId
            };

            var result = SheetAggregate.CreateFromRequest(sheetRequest);

            return result;
        }
    }
}
