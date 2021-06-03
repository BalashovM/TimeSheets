using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Aggregates.SheetAggregate
{
    interface ISheetAggregateRepo
    {
        Task<SheetAggregate> GetItem(Guid id);
        Task<IEnumerable<SheetAggregate>> GetItems();
        Task<Guid> Add(SheetAggregate item);
        Task Update(SheetAggregate item);
    }
}
