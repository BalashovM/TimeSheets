using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace TimeSheets.Tests
{
    public class SheetAggregateTests
    {
        public static Guid EmployeeId1 = Guid.Parse("dbecaed4-ed2f-4797-9d68-b69ae04d91d0");
        [Fact]
        public void SheetAggregate_CreateRandomFromSheetRequest()
        {
            var builder = new SheetAggreagteBuilder();
            var sheet = builder.CreateRandomSheet();

            sheet.Amount.Should().Be(8);
            sheet.ContractId.Should().Be(builder.SheetContractId);
            sheet.ServiceId.Should().Be(builder.SheetServiceId);
            sheet.EmployeeId.Should().Be(builder.SheetEmployeeId);
            sheet.Date.Should().BeExactly(TimeSpan.FromSeconds(DateTimeOffset.Now.ToUnixTimeSeconds()));
        }

        [Fact]
        public void SheetAggregate_WhenApproved_IsApprovedIsTrue()
        { 
            var builder = new SheetAggreagteBuilder();
            var sheet = builder.CreateRandomSheet();

            sheet.ApproveSheet();

            sheet.IsApproved.Should().BeTrue();
            sheet.ApprovesDate.Should().BeExactly(TimeSpan.FromSeconds(DateTimeOffset.Now.ToUnixTimeSeconds()));
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void SheetAggreagte_Changing_EmployeeId(Guid newEmployeeId)
        {
            var builder = new SheetAggreagteBuilder();
            var sheet = builder.CreateRandomSheet();

            sheet.ChangeEmployee(newEmployeeId);

            sheet.EmployeeId.Should().Be(newEmployeeId);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {EmployeeId1};
        }
    }
}
