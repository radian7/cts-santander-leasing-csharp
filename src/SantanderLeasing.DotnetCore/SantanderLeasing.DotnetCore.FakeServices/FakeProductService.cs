using Bogus;
using SantanderLeasing.DotnetCore.IServices;
using SantanderLeasing.DotnetCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace SantanderLeasing.DotnetCore.FakeServices
{

    public class FakeProductService : IProductService
    {
        private readonly ICollection<Product> products;

        public FakeProductService(Faker<Product> faker)
        {
            products = faker.Generate(100);
        }

        public void Add(Product entity)
        {
            products.Add(entity);
        }

        public IEnumerable<Product> Get()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetByColor(string color)
        {
            return products.Where(p => p.Color == color);
        }

        public void Remove(int id)
        {
            products.Remove(Get(id));
        }

        public void Update(Product entity)
        {
            Remove(entity.Id);
            Add(entity);
        }
    }
}
