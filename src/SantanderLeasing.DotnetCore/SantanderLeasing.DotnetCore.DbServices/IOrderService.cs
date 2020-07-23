using SantanderLeasing.DotnetCore.DbServices.Model;
using SantanderLeasing.DotnetCore.IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace SantanderLeasing.DotnetCore.DbServices
{
    public interface IOrderService : IEntityService<SalesOrderHeader>
    {

    }

    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<Product> GetByListPrice(decimal from, decimal to);
    }
}
