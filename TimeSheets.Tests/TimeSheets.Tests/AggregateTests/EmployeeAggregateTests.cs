using FluentAssertions;
using TimeSheets.Domain.Aggregates.EmployeeAggregate;
using Xunit;

namespace TimeSheets.Tests.AggregateTests
{
    public class EmployeeAggregateTests
    {
		[Fact]
		public void EmployeeAggregate_CreateRandomFromRequest()
		{
			var request = AggregateRequestsBuilder.CreateRandomEmployeeRequest();

			var employee = EmployeeAggregate.CreateFromRequest(request);

			employee.UserId.Should().Be(request.UserId);
			employee.IsDeleted.Should().BeFalse();
		}

		[Fact]
		public void EmployeeAggregate_ShouldBeDeleted()
		{
			var request = AggregateRequestsBuilder.CreateRandomEmployeeRequest();
			var employee = EmployeeAggregate.CreateFromRequest(request);

			employee.DeleteEmployee();

			employee.IsDeleted.Should().BeTrue();
		}
	}
}
