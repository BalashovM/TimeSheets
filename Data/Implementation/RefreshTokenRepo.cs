using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace Timesheets.Data.Implementation
{
    public class RefreshTokenRepo : IRefreshTokenRepo
    {
        private readonly TimesheetDbContext _dbContext;

        public RefreshTokenRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task Add(RefreshToken token)
        {
            await _dbContext.RefreshToken.AddAsync(token);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> CheckItemIsDeleted(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshToken> GetItem(Guid id)
        {
            var tokenFromBase = await _dbContext.RefreshToken.FindAsync(id);
            return tokenFromBase;
        }

        public async Task<RefreshToken> GetItem(string refreshToken)
        {
            var tokenFromBase = await _dbContext.RefreshToken.FindAsync(refreshToken);
            return tokenFromBase;
        }

        public Task<IEnumerable<RefreshToken>> GetItems(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task Update(RefreshToken token)
        {
            _dbContext.RefreshToken.Update(token);
            await _dbContext.SaveChangesAsync();
        }
    }
}