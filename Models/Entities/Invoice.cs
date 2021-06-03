﻿using System;
using System.Collections.Generic;
using TimeSheets.Domain.ValueObjects;

namespace TimeSheets.Models.Enities
{
    /// <summary>Счета выставляемые клиентам</summary>
    public class Invoice
	{
		public Guid Id { get; protected set; }
		public Guid ContractId { get; protected set; }
		public DateTime DateStart { get; protected set; }
		public DateTime DateEnd { get; protected set; }
		//public decimal Sum { get; protected set; }
		public Money Sum { get; protected set; }
		public bool IsDeleted { get; protected set; }

		public Contract Contract { get; protected set; }
		public List<Sheet> Sheets { get; set; } = new List<Sheet>();

		protected Invoice() {}
	}
}