using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
    /// <summary>Менеджер запросов к данным по карточке</summary>
    public interface ISheetManager : IManagerBase<Sheet,SheetRequest>
    {
    }
}
