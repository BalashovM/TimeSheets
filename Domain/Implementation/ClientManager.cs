using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Domain.Implementation
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepo _clientRepo;

        public ClientManager(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task<Guid> Create(Client item)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                UserId = item.UserId
            };

            await _clientRepo.Add(client);

            return client.Id;
        }

        public async Task<Client> GetItem(Guid id)
        {
            return await _clientRepo.GetItem(id);
        }

        public async Task<IEnumerable<Client>> GetItems(int skip, int take)
        {
            return await _clientRepo.GetItems(skip, take);
        }
    }
}
