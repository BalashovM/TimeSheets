using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
            _sheetRepo = sheetRepo;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            return await _sheetRepo.GetItem(id);
        }

        public async Task<IEnumerable<Sheet>> GetItems(int skip, int take)
        {
            return await _sheetRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(SheetRequest request)
        {
            var sheet = new Sheet()
            {
                Id = Guid.NewGuid(),
                Amount = request.Amount,
                ContractId = request.ContractId,
                Date = request.Date,
                EmployeeId = request.EmployeeId,
                ServiceId = request.ServiceId,
                InvoiceId = request.InvoiceId,
                IsDeleted = false
            };

            await _sheetRepo.Add(sheet);

            return  sheet.Id;
        }

        public async Task Update(Guid id, SheetRequest request)
        {
            var sheet = await _sheetRepo.GetItem(id);
            if (sheet != null)
            {
                sheet.Amount = request.Amount;
                sheet.ContractId = request.ContractId;
                sheet.Date = request.Date;
                sheet.EmployeeId = request.EmployeeId;
                sheet.ServiceId = request.ServiceId;
                sheet.InvoiceId = request.InvoiceId;

                await _sheetRepo.Update(sheet);
            }
        }
        public async Task Delete(Guid id)
        {
            await _sheetRepo.Delete(id);
        }
    }
}
