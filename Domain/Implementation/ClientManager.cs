using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Implementation
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepo _clientRepo;

        public ClientManager(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task<Client> GetItem(Guid id)
        {
            return await _clientRepo.GetItem(id);
        }

        public async Task<IEnumerable<Client>> GetItems(int skip, int take)
        {
            return await _clientRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(ClientRequest request)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                IsDeleted = false
            };

            await _clientRepo.Add(client);

            return client.Id;
        }

        public async Task Update(Guid id, ClientRequest request)
        {
            var client = await _clientRepo.GetItem(id);
            if (client != null)
            {
                client.UserId = request.UserId;

                await _clientRepo.Update(client);
            }
        }

        public async Task<bool> CheckClientIsDeleted(Guid id)
        {
            return await _clientRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            await _clientRepo.Delete(id);
        }
    }
}
