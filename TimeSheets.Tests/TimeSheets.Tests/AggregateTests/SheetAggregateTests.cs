using FluentAssertions;
using System;
using TimeSheets.Domain.Aggregates.SheetAggregate;
using Xunit;

namespace TimeSheets.Tests.AggregateTests
{
	public class SheetAggregateTests
	{
		[Fact]
		public void SheetAggregate_CreateRandomFromRequest()
		{
			var request = AggregateRequestsBuilder.CreateRandomSheetRequest();

			var sheet = SheetAggregate.CreateFromRequest(request);

			sheet.Amount.Should().Be(request.Amount);
			sheet.ContractId.Should().Be(request.ContractId);
			sheet.EmployeeId.Should().Be(request.EmployeeId);
			sheet.ServiceId.Should().Be(request.ServiceId);
			sheet.Date.Should().Be(request.Date);
		}

		[Fact]
		public void SheetAggregate_ShouldBeApproved()
		{
			var request = AggregateRequestsBuilder.CreateRandomSheetRequest();
			var sheet = SheetAggregate.CreateFromRequest(request);

			sheet.ApproveSheet();

			sheet.IsApproved.Should().BeTrue();
			sheet.ApprovedDate.Should().BeCloseTo(DateTime.Now);
		}

		[Fact]
		public void SheetAggregate_ShouldBeDeleted()
		{
			var request = AggregateRequestsBuilder.CreateRandomSheetRequest();
			var sheet = SheetAggregate.CreateFromRequest(request);

			sheet.DeleteSheet();

			sheet.IsDeleted.Should().BeTrue();
		}
	}
}
