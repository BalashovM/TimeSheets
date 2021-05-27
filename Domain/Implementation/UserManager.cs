using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetItem(Guid id)
        {
            return await _userRepo.GetItem(id);
        }

        public async Task<User> GetItem(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepo.GetItem(request.Login, passwordHash);

            return user;
        }

        public async Task<IEnumerable<User>> GetItems(int skip, int take)
        {
            return await _userRepo.GetItems(skip, take);
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
            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                PasswordHash = GetPasswordHash(request.Password),
                Role = request.Role,
                IsDeleted = false
            };

            await _userRepo.Add(user);

            return user.Id;
        }

        public async Task Update(Guid id, UserRequest request)
        {
            var user = await _userRepo.GetItem(id);
            if (user != null)
            {
                user.UserName = request.UserName;
                user.PasswordHash = GetPasswordHash(request.Password);
                user.Role = request.Role;

                await _userRepo.Update(user);
            }
        }

        public async Task<bool> CheckUserIsDeleted(Guid id)
        {
            return await _userRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            await _userRepo.Delete(id);
        }

    }
}
