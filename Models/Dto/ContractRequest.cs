using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto
{
	/// <summary>Запрос для контракта</summary>
	public class ContractRequest
	{
		public string Title { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public string Description { get; set; }
	}
}
