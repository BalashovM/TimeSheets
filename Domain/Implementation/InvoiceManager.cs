using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Implementation
{
    public class InvoiceManager : IInvoiceManager
	{
		private readonly IInvoiceRepo _invoiceRepo;

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
			var invoice = new Invoice()
			{
				Id = Guid.NewGuid(),
				ContractId = request.ContractId,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
				Sum = request.Sum,
				IsDeleted = false
			};

			await _invoiceRepo.Add(invoice);

			return invoice.Id;
		}

		public async Task Update(Guid id, InvoiceRequest request)
		{
			var invoice = await _invoiceRepo.GetItem(id);
			if (invoice != null)
			{
				invoice.ContractId = request.ContractId;
				invoice.DateStart = request.DateStart;
				invoice.DateEnd = request.DateEnd;
				invoice.Sum = request.Sum;

				await _invoiceRepo.Update(invoice);
			}
		}

		public async Task<bool> CheckInvoiceIsDeleted(Guid id)
		{
			return await _invoiceRepo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _invoiceRepo.Delete(id);
		}
	}
}
