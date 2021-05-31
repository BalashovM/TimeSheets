using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto
{
	/// <summary>Запрос для сотрудника</summary>
	public class EmployeeRequest
	{
		public Guid UserId { get; set; }

	}
}
