using System;
using System.Collections.Generic;
using TimeSheets.Models;

namespace TimeSheets.Models
{
	/// <summary>Счета выставляемые клиентам</summary>
	public class Invoice
	{
		public Guid Id { get; set; }
		public Guid ContractId { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public decimal Sum { get; set; }
		public bool IsDeleted { get; set; }

		public Contract Contract { get; set; }
		public ICollection<Sheet> Sheets { get; set; }
	}
}