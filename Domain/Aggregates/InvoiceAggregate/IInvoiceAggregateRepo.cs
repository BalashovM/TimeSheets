using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Aggregates.InvoiceAggregate
{
    public interface IInvoiceAggregateRepo: IAggregateBase<InvoiceAggregate>
    {
        Task<IEnumerable<SheetAggregate.SheetAggregate>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd);
        Task<bool> CheckItemIsDeleted(Guid id);
    }
}
