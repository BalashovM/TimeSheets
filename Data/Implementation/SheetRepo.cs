using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementations
{
    public class SheetRepo : ISheetRepo
    {
        /*
        private static List<Sheet> Sheets { get; set; } = new List<Sheet>()
        {

            new Sheet
            {
                Id = Guid.Parse("E7796C0F-6F70-DF84-716F-4085F120162E"),
                EmployeeId = Guid.Parse("9052936D-414C-B132-FFAE-E53DE1A6CA18"),
                ContractId = Guid.Parse("5A7CA302-2552-7691-0F0C-290DB787FAC5"),
                ServiceId = Guid.Parse("3531E1D4-4B13-93ED-2E88-DDF9E45614DF"),
                Amount = 3
            },
            new Sheet
            {
                Id = Guid.Parse("BBDD0F6F-483A-FBF7-D9B0-BDA9B14D4180"),
                EmployeeId = Guid.Parse("D5AC7445-C472-6427-44D4-BCC58665A632"),
                ContractId = Guid.Parse("A5395F0C-D3B3-3E43-62AC-196ED7B29C15"),
                ServiceId = Guid.Parse("B1BFFEFF-1F22-4591-4D7B-9613C8E04EDC"),
                Amount = 6
            }
        };
        */

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

        public async Task Delete(Sheet item)
        {
            throw new NotImplementedException();
            //return await _context.Sheets.Remove(item);
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
