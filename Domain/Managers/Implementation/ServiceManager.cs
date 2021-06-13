using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.ServiceAggregate;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceAggregateRepo _serviceAggregateRepo;

        public ServiceManager(IServiceAggregateRepo serviceAggregateRepo)
        {
            _serviceAggregateRepo = serviceAggregateRepo;
        }
        public async Task<ServiceAggregate> GetItem(Guid id)
        {
            return await _serviceAggregateRepo.GetItem(id);
        }

        public async Task<IEnumerable<ServiceAggregate>> GetItems(int skip, int take)
        {
            return await _serviceAggregateRepo.GetItems(skip, take);
        }

        public async Task<Guid> Create(ServiceRequest request)
        {

            var service = ServiceAggregate.CreateFromRequest(request);
            
            await _serviceAggregateRepo.Add(service);

            return service.Id;
        }

        public async Task Update(Guid id, ServiceRequest request)
        {
            var item = await _serviceAggregateRepo.GetItem(id);
            item.UpdateFromRequest(request);
        }

        public async Task<bool> CheckServiceIsDeleted(Guid id)
        {
            return await _serviceAggregateRepo.CheckItemIsDeleted(id);
        }

        public async Task Delete(Guid id)
        {

            var service = await _serviceAggregateRepo.GetItem(id);
            service.DeleteService();
            await _serviceAggregateRepo.Update(service);
        }

    }
}
