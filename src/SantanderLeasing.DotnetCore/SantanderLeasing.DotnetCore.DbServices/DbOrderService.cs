using Microsoft.EntityFrameworkCore;
using SantanderLeasing.DotnetCore.DbServices.Model;
using System.Collections.Generic;
using System.Linq;

namespace SantanderLeasing.DotnetCore.DbServices
{
    public class DbOrderService : IOrderService
    {
        private readonly AdventureWorksLT2016Context context;

        public DbOrderService(AdventureWorksLT2016Context context)
        {
            this.context = context;
        }

        private DbSet<SalesOrderHeader> orders => context.SalesOrderHeader;


        public void Add(SalesOrderHeader entity)
        {
            orders.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<SalesOrderHeader> Get()
        {
            return orders.Include(p=>p.Customer).ToList();
        }

        public SalesOrderHeader Get(int id)
        {
            return orders.SingleOrDefault(o => o.SalesOrderId == id);
        }

        public void Remove(int id)
        {
            context.Remove(Get(id));
            context.SaveChanges();
        }

        public void Update(SalesOrderHeader entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
