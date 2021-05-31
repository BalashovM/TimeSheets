using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementations
{
    public class SheetRepo : ISheetRepo
    {
        private readonly TimesheetDbContext _dbContext;
        public SheetRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

         public async Task Add(Sheet item)
        {
            await _dbContext.Sheets.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckItemIsDeleted(Guid id)
        {
            var item = await _dbContext.Sheets.FindAsync(id);
            return item.IsDeleted;
        }

        public async Task Delete(Guid id)
        {
            var item = await _dbContext.Sheets.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _dbContext.Sheets.Update(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            var result = await _dbContext.Sheets.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItems(int skip, int take)
        {
            return await _dbContext.Sheets.ToListAsync();
        }

        public async Task Update(Sheet item)
        {
            _dbContext.Sheets.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
