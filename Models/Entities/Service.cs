using System;
using System.Collections.Generic;

namespace TimeSheets.Models.Enities
{
    /// <summary> Информация о предоставляемой услуге в рамках контракта</summary>
    public class Service
    {
        public Guid Id { get; protected set; }
        public string ServiceName { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public ICollection<Sheet> Sheets { get; set; }
    }
}
