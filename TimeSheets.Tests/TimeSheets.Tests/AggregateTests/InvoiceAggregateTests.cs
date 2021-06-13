using FluentAssertions;
using System.Collections.Generic;
using TimeSheets.Domain.Aggregates.InvoiceAggregate;
using TimeSheets.Domain.Aggregates.SheetAggregate;
using Xunit;

namespace TimeSheets.Tests.AggregateTests
{
    public class InvoiceAggregateTests
    {
		[Fact]
		public void InvoiceAggregate_CreateFromRequest()
		{
			var request = AggregateRequestsBuilder.CreateRandomInvoiceRequest();

			var invoice = InvoiceAggregate.CreateFromRequest(request);

			invoice.ContractId.Should().Be(request.ContractId);
			invoice.DateStart.Should().Be(request.DateStart);
			invoice.DateEnd.Should().Be(request.DateEnd);
			invoice.IsDeleted.Should().BeFalse();
		}

		[Fact]
		public void InvoiceAggregate_CalculateSomeSum_AfterIncludeSomeSheets()
		{
			var invoiceRequest = AggregateRequestsBuilder.CreateRandomInvoiceRequest();
			var invoice = InvoiceAggregate.CreateFromRequest(invoiceRequest);

			var sheets = new List<SheetAggregate>();
			var sheetsCount = 3;
			for (int i = 0; i < sheetsCount; i++)
			{
				var sheetRequest = AggregateRequestsBuilder.CreateRandomSheetRequest();
				sheets.Add(SheetAggregate.CreateFromRequest(sheetRequest));
			}

			invoice.IncludeSheets(sheets);

			invoice.Sum.Amount.Should().BeGreaterThan(0);
			invoice.Sheets.Count.Should().Be(sheetsCount);
		}

		[Fact]
		public void InvoiceAggregate_ShouldBeDeleted()
		{
			var request = AggregateRequestsBuilder.CreateRandomInvoiceRequest();
			var invoice = InvoiceAggregate.CreateFromRequest(request);

			invoice.DeleteInvoice();

			invoice.IsDeleted.Should().BeTrue();
		}
	}
}
