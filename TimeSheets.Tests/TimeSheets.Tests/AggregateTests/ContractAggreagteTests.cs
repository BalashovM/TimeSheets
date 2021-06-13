using FluentAssertions;
using TimeSheets.Domain.Aggregates.ContractAggregate;
using Xunit;

namespace TimeSheets.Tests.AggregateTests
{
    public class ContractAggreagteTests
    {
		[Fact]
		public void ContractAggregate_CreateRandomFromRequest()
		{
			var request = AggregateRequestsBuilder.CreateRandomContractRequest();

			var contract = ContractAggregate.CreateFromRequest(request);

			contract.Title.Should().Be(request.Title);
			contract.DateStart.Should().Be(request.DateStart);
			contract.DateEnd.Should().Be(request.DateEnd);
			contract.Description.Should().Be(request.Description);
			contract.IsDeleted.Should().BeFalse();
		}

		[Fact]
		public void ContractAggregate_UpdateRandomFromRequest()
		{
			var createRequest = AggregateRequestsBuilder.CreateRandomContractRequest();
			var contract = ContractAggregate.CreateFromRequest(createRequest);
			var updateRequest = AggregateRequestsBuilder.CreateRandomContractUpdateRequest();

			contract.UpdateFromRequest(updateRequest);

			contract.Title.Should().Be(updateRequest.Title);
			contract.Description.Should().Be(updateRequest.Description);
		}


		[Fact]
		public void ContractAggregate_ShouldBeDeleted()
		{
			var request = AggregateRequestsBuilder.CreateRandomContractRequest();
			var contract = ContractAggregate.CreateFromRequest(request);

			contract.DeleteContract();

			contract.IsDeleted.Should().BeTrue();
		}
	}
}
