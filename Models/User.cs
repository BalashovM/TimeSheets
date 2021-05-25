using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    /// <summary> Информация о пользователе</summary>
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }

        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}
