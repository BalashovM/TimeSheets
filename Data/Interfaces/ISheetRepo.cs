using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models.Enities;

namespace TimeSheets.Data.Interfaces
{
    public interface ISheetRepo:IRepoBase<Sheet>
    {
        Task<IEnumerable<Sheet>> GetItemsForInvoice(Guid contractId, DateTime dateStart, DateTime dateEnd);
    }
}
