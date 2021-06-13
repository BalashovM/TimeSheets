using System;
using System.Security.Cryptography;
using System.Text;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Enities;

namespace TimeSheets.Domain.Aggregates.UserAggregate
{
    public class UserAggregate: User
    {
        private UserAggregate() { }

        public static UserAggregate CreateFromRequest(UserRequest request)
        {
            return new UserAggregate()
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                PasswordHash = GetPasswordHash(request.Password),
                Role = request.Role,
                RefreshToken = String.Empty,
                IsDeleted = false,
            };
        }

        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }

        public void UpdateFromRequest(UserRequest request)
        {
            UserName = request.UserName;
            PasswordHash = GetPasswordHash(request.Password);
            Role = request.Role;
        }

        public void DeleteUser()
        {
            IsDeleted = true;
        }

        public void UpdateRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
