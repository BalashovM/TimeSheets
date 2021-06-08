using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Aggregates.SheetAggregate
{
    public interface ISheetAggregateRepo
    {
        Task<SheetAggregate> GetItem(Guid id);
        Task<IEnumerable<SheetAggregate>> GetItems(int skip, int take);
        Task<Guid> Add(SheetAggregate item);
        Task Update(SheetAggregate item);
    }
}
