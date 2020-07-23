using Microsoft.EntityFrameworkCore;
using SantanderLeasing.DotnetCore.IServices;
using System.Collections.Generic;
using System.Linq;

namespace SantanderLeasing.DotnetCore.DbServices
{

    public class DbEntityService<T, TContext> : IEntityService<T>
        where T : class
        where TContext : DbContext
    {
        protected readonly TContext context;

        public DbEntityService(TContext context)
        {
            this.context = context;
        }

        protected DbSet<T> entities => context.Set<T>();

        public virtual void Add(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public virtual IEnumerable<T> Get()
        {
            return entities.ToList();
        }

        public virtual T Get(int id)
        {
            return entities.Find(id);
        }

        public void Remove(int id)
        {
            entities.Remove(Get(id));
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Attach(entity);
            context.SaveChanges();
        }
    }
}
