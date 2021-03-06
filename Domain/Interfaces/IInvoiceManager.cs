using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
    /// <summary>Менеджер запросов к данным по счету</summary>
    public interface IInvoiceManager : IManagerBase<Invoice, InvoiceRequest>
	{
	}
}
