using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates.UserAggregate;
using TimeSheets.Models.Enities;

namespace TimeSheets.Data.Interfaces
{
    public interface IUserRepo:IRepoBase<User>
    {
        Task<User> GetItem(string login, byte[] passwordHash);
    }
}
