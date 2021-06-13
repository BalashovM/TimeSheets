using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.UserAggregate;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserAggregateRepo _userAggregateRepo;

        public UserManager(IUserAggregateRepo userAggregateRepo)
        {
            _userAggregateRepo = userAggregateRepo;
        }

        public async Task<UserAggregate> GetItem(Guid id)
        {
            return await _userAggregateRepo.GetItem(id);
        }

        public async Task<UserAggregate> GetItem(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userAggregateRepo.GetItem(request.Login, passwordHash);

            return user;
        }

        public async Task<IEnumerable<UserAggregate>> GetItems(int skip, int take)
        {
            return await _userAggregateRepo.GetItems(skip, take);
        }

        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }

        public async Task<Guid> Create(UserRequest request)
        {
            var user = UserAggregate.CreateFromRequest(request);

            await _userAggregateRepo.Add(user);

            return user.Id;
        }

        public async Task Update(Guid id, UserRequest request)
        {
            var user = await _userAggregateRepo.GetItem(id);
            user.UpdateFromRequest(request);
        }

        public async Task<bool> CheckUserIsDeleted(Guid id)
        {
            return await _userAggregateRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            var user = await _userAggregateRepo.GetItem(id);
            user.DeleteUser();
            await _userAggregateRepo.Update(user);
        }
    }
}
