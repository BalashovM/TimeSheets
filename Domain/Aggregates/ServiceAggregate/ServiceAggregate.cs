using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Aggregates.ServiceAggregate
{
    public class ServiceAggregate: Service
    {
        private ServiceAggregate() { }

		public static ServiceAggregate CreateFromRequest(ServiceRequest request)
		{
			return new ServiceAggregate()
			{
				Id = Guid.NewGuid(),
				ServiceName = request.ServiceName,
				IsDeleted = false
			};
		}

		public void UpdateFromRequest(ServiceRequest request)
		{
			ServiceName = request.ServiceName;
		}

		public void DeleteService()
		{
			IsDeleted = true;
		}
	}
}
