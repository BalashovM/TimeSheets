using System;

namespace TimeSheets.Models.Dto.Requests
{
    /// <summary>Запрос для карточки учета затраченного времени</summary>
    public class SheetRequest
    {
        public DateTime Date { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ContractId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid? InvoiceId { get; set; }
        public int Amount { get; set; }
    }
}
