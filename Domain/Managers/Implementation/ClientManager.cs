using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Enities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates.ClientAggregate;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class ClientManager : IClientManager
    {
        private readonly IClientAggregateRepo _clientAggregateRepo;

        public ClientManager(IClientAggregateRepo clientAggregateRepo)
        {
            _clientAggregateRepo = clientAggregateRepo;
        }

        public async Task<ClientAggregate> GetItem(Guid id)
        {
            return await _clientAggregateRepo.GetItem(id);
        }

        public async Task<IEnumerable<ClientAggregate>> GetItems(int skip, int take)
        {
            return await _clientAggregateRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(ClientRequest request)
        {
            var client = ClientAggregate.CreateFromRequest(request);

            await _clientAggregateRepo.Add(client);

            return client.Id;
        }

        public async Task Update(Guid id, ClientRequest request)
        {
            var client = await _clientAggregateRepo.GetItem(id);
            if (client != null)
            {
                client.UpdateFromRequest(request);
            }
        }

        public async Task<bool> CheckClientIsDeleted(Guid id)
        {
            return await _clientAggregateRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            var client = await _clientAggregateRepo.GetItem(id);
            client.DeleteClient();
            await _clientAggregateRepo.Update(client);
        }
    }
}
