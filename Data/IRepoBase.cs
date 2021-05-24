 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Data
{
    public interface IRepoBase<T>
    {
        Task<T> GetItem(Guid id);
        Task<IEnumerable<T>> GetItems(int skip, int take);
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}
