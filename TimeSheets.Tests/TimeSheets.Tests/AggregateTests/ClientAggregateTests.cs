using FluentAssertions;
using TimeSheets.Domain.Aggregates.ClientAggregate;
using Xunit;

namespace TimeSheets.Tests.AggregateTests
{
    public class ClientAggregateTests
    {
		[Fact]
		public void ClientAggregate_CreateRandomFromRequest()
		{
			var request = AggregateRequestsBuilder.CreateRandomClientRequest();

			var client = ClientAggregate.CreateFromRequest(request);

			client.UserId.Should().Be(request.UserId);
			client.IsDeleted.Should().BeFalse();
		}

		[Fact]
		public void ClientAggregate_ShouldBeDeleted()
		{
			var request = AggregateRequestsBuilder.CreateRandomClientRequest();
			var client = ClientAggregate.CreateFromRequest(request);

			client.DeleteClient();

			client.IsDeleted.Should().BeTrue();
		}
	}
}
