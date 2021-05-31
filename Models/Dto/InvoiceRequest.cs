using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto
{
	/// <summary>Запрос для счета</summary>
	public class InvoiceRequest
	{
		public Guid ContractId { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public decimal Sum { get; set; }

	}
}
