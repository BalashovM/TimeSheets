using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Aggregates.InvoiceAggregate
{
    public class InvoiceAggregate: Invoice
    {
        private readonly decimal _rate = 150;
        private InvoiceAggregate() { }

        public static InvoiceAggregate Create(Guid contractId, DateTime dateStart, DateTime dateEnd) 
        {
            return new InvoiceAggregate()
            {
                Id = Guid.NewGuid(),
                ContractId = contractId,
                DateStart = dateStart,
                DateEnd = dateEnd,
                IsDeleted = false
            };
        }
        public static InvoiceAggregate CreateFromRequest(InvoiceRequest request)
        {
            return new InvoiceAggregate()
            {
                Id = Guid.NewGuid(),
                ContractId = request.ContractId,
                DateStart = request.DateStart,
                DateEnd = request.DateEnd,
                IsDeleted = false
            };
        }

        public static InvoiceAggregate UpdateFromRequest(Guid id, InvoiceRequest request)
        {
            return new InvoiceAggregate()
            {
                Id = id,
                ContractId = request.ContractId,
                DateStart = request.DateStart,
                DateEnd = request.DateEnd,
                IsDeleted = false
            };
        }

        public void IncludeSheets(IEnumerable<Sheet> sheets)
        {
            Sheets.AddRange(sheets);
            CalculateSum();
        }

        private void CalculateSum()
        {
            var amount = Sheets.Sum(x => x.Amount * _rate);
            Sum = Money.FromDecimal(amount);
        }

        public void DeleteInvoice()
        {
            IsDeleted = true;
        }
    }
}
