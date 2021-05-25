using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
	/// <summary>Менеджер запросов к данным по счету</summary>
	public interface IInvoiceManager : IManagerBase<Invoice, InvoiceRequest>
	{
	}
}
