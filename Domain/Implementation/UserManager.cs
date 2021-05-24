using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Domain.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<Guid> Create(User item)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = item.UserName
            };

            await _userRepo.Add(user);

            return user.Id;
        }

        public async Task<User> GetItem(Guid id)
        {
            return await _userRepo.GetItem(id);
        }

        public async Task<IEnumerable<User>> GetItems(int skip, int take)
        {
            return await _userRepo.GetItems(skip, take);
        }
    }
}
