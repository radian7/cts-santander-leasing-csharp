using Bogus;
using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderLeasing.DotnetCore.FakeServices.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()));
        }
    }
}
