using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates.InvoiceAggregate;
using TimeSheets.Domain.Aggregates.SheetAggregate;
using TimeSheets.Models.Enities;

namespace TimeSheets.Data.Implementation
{
    public class InvoiceRepo : IInvoiceRepo
	{
		private readonly TimesheetDbContext _dbContext;

		public InvoiceRepo(TimesheetDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(Invoice item)
		{
			await _dbContext.Invoices.AddAsync(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _dbContext.Invoices.FindAsync(id);
			return item.IsDeleted;
		}
		public async Task Delete(Guid id)
		{
			/*var item = await _dbContext.Invoices.FindAsync(id);
			if (item != null)
			{
				item.IsDeleted = true;
				_dbContext.Invoices.Update(item);
				await _dbContext.SaveChangesAsync();
			}*/
		}

		public async Task<Invoice> GetItem(Guid id)
		{
			var result = await _dbContext.Invoices.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<Invoice>> GetItems(int skip, int take)
		{
			return await _dbContext.Invoices.ToListAsync();
		}

       
        public async Task Update(Invoice item)
		{
			_dbContext.Invoices.Update(item);
			await _dbContext.SaveChangesAsync();
		}
    }
}
