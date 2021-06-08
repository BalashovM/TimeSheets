using System;

namespace TimeSheets.Models.Enities
{
    /// <summary> Информация о владельце контракта </summary>
    public class Client
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public User User { get; set; }
    }
}
