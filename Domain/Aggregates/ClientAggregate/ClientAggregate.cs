using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Aggregates.ClientAggregate
{
    public class ClientAggregate: Client
    {
		private ClientAggregate() { }

		public static ClientAggregate CreateFromRequest(ClientRequest request)
		{
			return new ClientAggregate()
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				IsDeleted = false,
			};
		}

		public void UpdateFromRequest(ClientRequest request)
		{
			UserId = request.UserId;
		}

		public void DeleteClient()
		{
			IsDeleted = true;
		}
	}
}
