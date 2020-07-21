using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SantanderLeasing.DotnetCore.ConsoleApp.LinqSamples
{
    public class LinqTest
    {
        public static void Test()
        {
            IEnumerable<Product> products = new Collection<Product>
            {
                new Product { Id = 1, Color = "Red", Name = "Produkt 1", UnitPrice = 50.09m },
                new Product { Id = 2, Color = "Blue", Name = "Produkt 2", UnitPrice = 150.09m },
                new Product { Id = 3, Color = "Blue", Name = "Produkt 3", UnitPrice = 150.09m },
                new Product { Id = 4, Color = "Red", Name = "Produkt 4", UnitPrice = 40.09m },
                new Product { Id = 5, Color = "Black", Name = "Produkt 5", UnitPrice = 310.09m },
            };

            string color = "Red";

            //ICollection<Product> redProducts = new Collection<Product>();

            //foreach (Product product in products)
            //{
            //    if (product.Color == color)
            //    {
            //        redProducts.Add(product);
            //    }
            //}

            ICollection<Product> redProducts = products
                .Where(p => p.Color == "Red")
                .OrderBy(p => p.UnitPrice)
                .ToList();

            // TODO: pobierz produkty, których cena jednostkowa wynosi powyżej 100 zł
            ICollection<Product> overUnitPriceProducts = products
                .Where(x => x.UnitPrice > 100.0m)
                .OrderByDescending(x => x.UnitPrice)
                .Skip(1)
                .Take(2)
                .ToList();

            bool isAllOverUnitPrice = products.All(p => p.UnitPrice > 10);

            bool hasBlackProduct = products.Any(p => p.Color == "Black");

            ICollection<Product> query1 = products
              .Where(p => p.Color == "Red")
              .OrderBy(p => p.UnitPrice)
              //.Select(p => p.Name)   // *
              .ToList();

            // SQL: SELECT Name, Color, UnitPrice from dbo.Products WHERE Color = 'Red'
            ICollection<ProductInfo> query2 = products
            .Where(p => p.Color == "Red")
            .OrderBy(p => p.UnitPrice)
            .Select(p => new ProductInfo { Name = p.Name, UnitPrice = p.UnitPrice } )   // Projekcja
            .ToList();

            foreach (ProductInfo productInfo in query2)
            {
                Console.WriteLine(productInfo.Name);
            }


            var x = 10;

            // Typ anonimowy
            var person = new { FirstName = "John", LastName = "Smith", Age = 18 };

            //class __anonymouse_4342347983qedbae8vx82348723482
            //{
            //    public string FirstName { get; }
            //    public string LastName { get; }
            //    public int Age { get; }
            //}


            // SQL: SELECT Name as Nazwa, UnitPrice as Cena from dbo.Products WHERE Color = 'Red'
            var query3 = products
            .Where(p => p.Color == "Red")
            .OrderBy(p => p.UnitPrice)
            .Select(p => new { Nazwa = p.Name, Cena = p.UnitPrice })   // Projekcja do typu anonimowego
            .ToList();

            foreach (var productInfo in query3)
            {
                Console.WriteLine(productInfo.Nazwa);
            }

            var query4 = products
                .GroupBy(p => p.Color)
                .ToList();

            var query5 = products
             .GroupBy(p => p.Color)
             .Select(g => new { Color = g.Key, Quantity = g.Count() })
             .ToList();

            var query6 = products
            .GroupBy(p => new { p.Color, p.UnitPrice })
            .Select(g => new { Color = g.Key.Color, UnitPrice = g.Key.UnitPrice, Quantity = g.Count() })
            .ToList();

            foreach (Product redProduct in redProducts)
            {
                Console.WriteLine(redProduct);
            }

        }
    }

    public class ProductInfo
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
