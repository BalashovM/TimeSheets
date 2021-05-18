using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Domain.Interfaces
{
    public interface ISheetManager : IManagerBase<Sheet>
    {
    }
}
