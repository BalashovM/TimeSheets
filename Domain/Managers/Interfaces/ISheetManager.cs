using TimeSheets.Domain.Aggregates.SheetAggregate;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по карточке</summary>
    public interface ISheetManager : IManagerBase<SheetAggregate,SheetRequest>
    {
    }
}
