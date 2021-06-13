using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Aggregates.ContractAggregate
{
    public class ContractAggregate: Contract 
    {
        private ContractAggregate() { }

		public static ContractAggregate CreateFromRequest(ContractRequest request)
		{
			return new ContractAggregate()
			{
				Id = Guid.NewGuid(),
				Title = request.Title,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
				Description = request.Description,
				IsDeleted = false,
			};
		}

		public void UpdateFromRequest(ContractRequest request)
		{
			Title = request.Title;
			Description = request.Description;
		}

		public void DeleteContract()
		{
			IsDeleted = true;
		}
	}
}
