using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Domain.Implementation
{
    public class ClientManager : IClientManager
    {
        public Client GetItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
