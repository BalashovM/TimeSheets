using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Domain
{
    public interface IManagerBase<T>
    {
        T GetItem(Guid id);
    }
}
