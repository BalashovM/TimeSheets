using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Aggregates.UserAggregate
{
    public interface IUserAggregateRepo: IAggregateBase<UserAggregate>
    {
        Task<UserAggregate> GetItem(string login, byte[] passwordHash);
    }
}
