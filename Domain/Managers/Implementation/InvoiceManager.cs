﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class InvoiceManager : IInvoiceManager
	{
		private readonly ISheetRepo _sheetRepo;
		private readonly IInvoiceRepo _invoiceRepo;
		private const int Rate = 100;

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
			var sheets = await _sheetRepo.GetItemsForInvoice(request.ContractId, request.DateStart, request.DateEnd);

			var invoice = new Invoice()
			{
				Id = Guid.NewGuid(),
				ContractId = request.ContractId,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
				//Sum = request.Sum,
				IsDeleted = false
			};

			invoice.Sheets.AddRange(sheets);
			invoice.Sum = invoice.Sheets.Sum(x => x.Amount * Rate);

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