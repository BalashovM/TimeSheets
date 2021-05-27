using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Data.Interfaces
{
    public interface IUserRepo:IRepoBase<User>
    {
        Task<User> GetItem(string login, byte[] passwordHash);
    }
}
