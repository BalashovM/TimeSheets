using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Domain.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRepo _serviceRepo;

        public ServiceManager(IServiceRepo serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        public async Task<Guid> Create(Service item)
        {
            var service = new Service
            {
                Id = Guid.NewGuid(),
                Name = item.Name
            };

            await _serviceRepo.Add(service);

            return service.Id;
        }

        public async Task<Service> GetItem(Guid id)
        {
            return await _serviceRepo.GetItem(id);
        }

        public async Task<IEnumerable<Service>> GetItems(int skip, int take)
        {
            return await _serviceRepo.GetItems(skip, take);
        }
    }
}
