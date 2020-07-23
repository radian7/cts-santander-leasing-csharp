using SantanderLeasing.DotnetCore.DbServices.Model;
using System.Collections.Generic;
using System.Linq;

namespace SantanderLeasing.DotnetCore.DbServices
{
    public class DbProductService : DbEntityService<Product, AdventureWorksLT2016Context>, IProductService
    {
        public DbProductService(AdventureWorksLT2016Context context) : base(context)
        {
        }

        public IEnumerable<Product> GetByListPrice(decimal from, decimal to)
        {
            return entities.Where(p => p.ListPrice >= from && p.ListPrice <= to).ToList();
        }
    }
}
