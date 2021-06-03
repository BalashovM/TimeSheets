using System;

namespace TimeSheets.Models.Dto.Requests
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
