using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Aggregates.ServiceAggregate
{
    public interface IServiceAggregateRepo:IAggregateBase<ServiceAggregate>
    {
    }
}
