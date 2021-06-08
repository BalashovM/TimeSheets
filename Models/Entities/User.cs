using System;

namespace TimeSheets.Models.Enities
{
    /// <summary> Информация о пользователе</summary>
    public class User
    {
        public Guid Id { get; protected set; }
        public string UserName { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public string Role { get; protected set; }
        public bool IsDeleted { get; protected  set; }
        public string RefreshToken { get; protected set; }

        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}
