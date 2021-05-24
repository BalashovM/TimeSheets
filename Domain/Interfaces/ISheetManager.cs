using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
    public interface ISheetManager : IManagerBase<Sheet>
    {
        //Task<Guid> Create(SheetRequest item);
        //Task<IEnumerable<Sheet>> GetItems(int skip, int take);
        Task Update(Guid id, SheetRequest sheetRequest);
    }
}
