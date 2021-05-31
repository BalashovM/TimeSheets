using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto
{
	/// <summary>Запрос для клиента</summary>
	public class ClientRequest
	{
		public Guid UserId { get; set; }
	}
}
