using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates.InvoiceAggregate;

namespace TimeSheets.Domain.Managers.Interfaces
{
    /// <summary>Менеджер запросов к данным по счету</summary>
    public interface IInvoiceManager : IManagerBase<InvoiceAggregate, InvoiceRequest>
	{
	}
}
