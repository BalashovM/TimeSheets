using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates.SheetAggregate;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;
        private readonly ISheetAggregateRepo _sheetAggregateRepo;

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
            var sheet = SheetAggregate.CreateFromSheetRequest(request);

            await _sheetRepo.Add(sheet);

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
            var invoice = await _sheetRepo.GetItem(id);
            if (invoice != null)
            {
                var sheet = SheetAggregate.UpdateFromSheetRequest(id,request);
                await _sheetRepo.Update(sheet);
            }
        }

        public async Task Delete(Guid sheetId)
        {
            var sheet = await _sheetAggregateRepo.GetItem(sheetId);
            sheet.DeleteSheet();
            await _sheetAggregateRepo.Update(sheet);
        }
    }
}
