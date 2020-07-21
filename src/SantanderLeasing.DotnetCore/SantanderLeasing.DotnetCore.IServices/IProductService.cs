using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;

namespace SantanderLeasing.DotnetCore.IServices
{
    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<Product> GetByColor(string color);
    }

}
