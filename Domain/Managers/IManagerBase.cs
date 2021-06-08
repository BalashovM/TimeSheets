using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Domain.Managers
{
    /// <summary>Менеджер запросов к репозиториям</summary>
    public interface IManagerBase<TModel, TRequest>
    {
        Task<TModel> GetItem(Guid id);
        Task<IEnumerable<TModel>> GetItems(int skip, int take);
        Task<Guid> Create(TRequest request);
        Task Update(Guid id, TRequest request);
        Task Delete(Guid id);
    }
}
