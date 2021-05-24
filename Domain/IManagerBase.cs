using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Domain
{
    public interface IManagerBase<T>
    {
        Task<T> GetItem(Guid id);
        Task<IEnumerable<T>> GetItems(int skip, int take);
        Task<Guid> Create(T item);
        //Task Update(Guid id, T sheetRequest);

    }
}
