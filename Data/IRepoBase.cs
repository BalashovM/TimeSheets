 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Data
{
    public interface IRepoBase<T>
    {
        T GetItem(Guid id);
        IEnumerable<T> GetItems();
        void Add();
        void Update(Guid id);
        void Delete(Guid id);
    }
}
