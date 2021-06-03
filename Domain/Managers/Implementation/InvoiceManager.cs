using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates.InvoiceAggregate;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class InvoiceManager : IInvoiceManager
	{
		private readonly IInvoiceRepo _invoiceRepo;
		private readonly IInvoiceAggregateRepo _invoiceAggregateRepo;

		public InvoiceManager(IInvoiceRepo invoiceRepo)
		{
			_invoiceRepo = invoiceRepo;
		}

		public async Task<Invoice> GetItem(Guid id)
		{
			return await _invoiceRepo.GetItem(id);
		}

		public async Task<IEnumerable<Invoice>> GetItems(int skip, int take)
		{
			return await _invoiceRepo.GetItems(skip, take);
		}

		public async Task<Guid> Create(InvoiceRequest request)
		{
			var invoice = InvoiceAggregate.Create(request.ContractId, request.DateStart, request.DateEnd);

			var sheetsToInclude = await _invoiceAggregateRepo.GetSheets(request.ContractId, request.DateStart, request.DateEnd);

			invoice.IncludeSheets(sheetsToInclude);

			await _invoiceRepo.Add(invoice);

			return invoice.Id;
		}

		public async Task Update(Guid id, InvoiceRequest request)
		{
			var invoice = await _invoiceRepo.GetItem(id);
			if (invoice != null)
			{
				InvoiceAggregate. UpdateFromInvoiceRequest(id, request);
				 await _invoiceRepo.Update(invoice);
			}
		}

		public async Task<bool> CheckInvoiceIsDeleted(Guid id)
		{
			return await _invoiceRepo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			var sheet = await _invoiceAggregateRepo.GetItem(id);
			sheet.DeleteInvoice();
			await _invoiceAggregateRepo.Update(sheet);
		}
	}
}
