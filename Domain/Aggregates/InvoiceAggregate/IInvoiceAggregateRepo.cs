using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Aggregates.InvoiceAggregate
{
    public interface IInvoiceAggregateRepo
    {
        Task<InvoiceAggregate> GetItem(Guid id);
        Task<IEnumerable<InvoiceAggregate>> GetItems(int skip, int take);
        Task<Guid> Add(InvoiceAggregate item);
        Task Update(InvoiceAggregate item);
        Task<IEnumerable<SheetAggregate.SheetAggregate>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd);
        Task<bool> CheckItemIsDeleted(Guid id);
    }
}
