using System.Collections.Generic;
using System.Threading.Tasks;

namespace SantanderLeasing.DotnetCore.IServices
{
    public interface IEntityServiceAsync<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
    }
}
