using SantanderLeasing.DotnetCore.Models;
using System.Collections.Generic;

namespace SantanderLeasing.DotnetCore.IServices
{
    // Interfejs generyczny (szablon)
    public interface IEntityService<TEntity> 
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
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
