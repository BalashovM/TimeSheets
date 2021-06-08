using System;
using System.Collections.Generic;

namespace TimeSheets.Models.Enities
{
    /// <summary> Информация о договоре с клиентом </summary>
    public class Contract
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected  set; }
        public DateTime DateStart { get; protected set; }
        public DateTime DateEnd { get; protected set; }
        public string Description { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public ICollection<Sheet> Sheets { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
