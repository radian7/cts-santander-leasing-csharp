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


    /* separacja interfejsów
    public interface IEntityService<TEntity> : IReadEntityService<TEntity>, IWriteEntityService<TEntity>
    {
    }

    public interface IReadEntityService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
    }

    public interface IWriteEntityService<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }

    */
}
