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
                new Product { Id = 3, Color = "Blue", Name = "Produkt 3", UnitPrice = 250.09m },
                new Product { Id = 4, Color = "Red", Name = "Produkt 4", UnitPrice = 40.09m },
                new Product { Id = 5, Color = "Black", Name = "Produkt 5", UnitPrice = 10.09m },
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

            // TODO: pobierz produkty, których cena jednostkowa jest powyżej 100 zł



            // SQL: SELECT Name, Color, UnitPrice from dbo.Products WHERE Color = 'Red'

            foreach (Product redProduct in redProducts)
            {
                Console.WriteLine(redProduct);
            }

        }
    }
}
