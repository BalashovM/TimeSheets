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
            throw new NotImplementedException();
        }

        public async Task Delete(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetItems(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task Update(User item)
        {
            _dbContext.Users.Update(item);
            await _dbContext.SaveChangesAsync();
        }

    }
}
