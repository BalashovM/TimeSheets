using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.SheetAggregate;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetAggregateRepo _sheetAggregateRepo;

        public SheetManager(ISheetAggregateRepo sheetAggregateRepo)
        {
            _sheetAggregateRepo = sheetAggregateRepo;
        }

        public async Task<SheetAggregate> GetItem(Guid id)
        {
            return await _sheetAggregateRepo.GetItem(id);
        }

        public async Task<IEnumerable<SheetAggregate>> GetItems(int skip, int take)
        {
            return await _sheetAggregateRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(SheetRequest request)
        {
            var sheet = SheetAggregate.CreateFromRequest(request);

            await _sheetAggregateRepo.Add(sheet);

            return  sheet.Id;
        }

        public async Task Approve(Guid sheetId)
        {
            var sheet = await _sheetAggregateRepo.GetItem(sheetId);
            sheet.ApproveSheet();
            await _sheetAggregateRepo.Update(sheet);
        }

        public async Task Update(Guid id, SheetRequest request)
        {
            var sheet = await _sheetAggregateRepo.GetItem(id);
            if (sheet != null)
            {
                sheet.UpdateFromRequest(request);
            }
        }

        public async Task<bool> CheckInvoiceIsDeleted(Guid id)
        {
            return await _sheetAggregateRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid sheetId)
        {
            var sheet = await _sheetAggregateRepo.GetItem(sheetId);
            sheet.DeleteSheet();
            await _sheetAggregateRepo.Update(sheet);
        }
    }
}
