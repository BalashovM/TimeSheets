using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Aggregates
{
    public interface IAggregateBase<T>
    {
        Task<T> GetItem(Guid id);
        Task<IEnumerable<T>> GetItems(int skip, int take);
        Task<Guid> Add(T item);
        Task Update(T item);
        Task<bool> CheckItemIsDeleted(Guid id);
    }
}
