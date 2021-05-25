using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly TimesheetDbContext _dbContext;
        public UserRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User item)
        {
            await _dbContext.Users.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckItemIsDeleted(Guid id)
        {
            var item = await _dbContext.Users.FindAsync(id);
            return item.IsDeleted;
        }

        public async Task Delete(Guid id)
        {
            var item = await _dbContext.Users.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _dbContext.Users.Update(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetItem(Guid id)
        {
            var result = await _dbContext.Users.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<User>> GetItems(int skip, int take)
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task Update(User item)
        {
            _dbContext.Users.Update(item);
            await _dbContext.SaveChangesAsync();
        }

    }
}
