using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRepo _serviceRepo;

        public ServiceManager(IServiceRepo serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }
        public async Task<Service> GetItem(Guid id)
        {
            return await _serviceRepo.GetItem(id);
        }

        public async Task<IEnumerable<Service>> GetItems(int skip, int take)
        {
            return await _serviceRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(ServiceRequest request)
        {
            var service = new Service()
            {
                Id = Guid.NewGuid(),
                ServiceName = request.ServiceName,
                IsDeleted = false
            };

            await _serviceRepo.Add(service);

            return service.Id;
        }

        public async Task Update(Guid id, ServiceRequest request)
        {
            var service = await _serviceRepo.GetItem(id);
            if (service != null)
            {
                service.ServiceName = request.ServiceName;

                await _serviceRepo.Update(service);
            }
        }

        public async Task<bool> CheckServiceIsDeleted(Guid id)
        {
            return await _serviceRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {
            await _serviceRepo.Delete(id);
        }

    }
}
