using FluentAssertions;
using TimeSheets.Domain.Aggregates.ServiceAggregate;
using Xunit;

namespace TimeSheets.Tests.AggregateTests
{
    public class ServiceAggregateTests
    {
		[Fact]
		public void ServiceAggregate_CreateRandomFromRequest()
		{
			var request = AggregateRequestsBuilder.CreateRandomServiceRequest();

			var service = ServiceAggregate.CreateFromRequest(request);

			service.ServiceName.Should().Be(request.ServiceName);
			service.IsDeleted.Should().BeFalse();
		}

		[Fact]
		public void ServiceAggregate_UpdateRandomFromRequest()
		{
			var createRequest = AggregateRequestsBuilder.CreateRandomServiceRequest();
			var service = ServiceAggregate.CreateFromRequest(createRequest);
			var updateRequest = AggregateRequestsBuilder.CreateRandomServiceRequest();

			service.UpdateFromRequest(updateRequest);

			service.ServiceName.Should().Be(updateRequest.ServiceName);
		}

		[Fact]
		public void ServiceAggregate_ShouldBeDeleted()
		{
			var request = AggregateRequestsBuilder.CreateRandomServiceRequest();
			var service = ServiceAggregate.CreateFromRequest(request);

			service.DeleteService();

			service.IsDeleted.Should().BeTrue();
		}
	}
}
