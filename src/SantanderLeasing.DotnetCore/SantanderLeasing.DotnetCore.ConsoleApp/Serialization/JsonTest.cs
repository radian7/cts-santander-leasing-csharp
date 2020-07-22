using SantanderLeasing.DotnetCore.Models;
using System;
using System.IO;
using System.Text.Json;

namespace SantanderLeasing.DotnetCore.ConsoleApp.Serialization
{
    public class JsonTest
    {
        public static void Test()
        {
            DeserializationTest();
            SerializationTest();
        }

        private static void SerializationTest()
        {
            Product product = new Product { Id = 1, Name = "Product 1", Color = "Red", UnitPrice = 1.99m };

            string json = JsonSerializer.Serialize(product);

            string filename = "products.json";

            File.WriteAllText(filename, json);
        }

        private static void DeserializationTest()
        {
            string filename = "products.json";

            string json = File.ReadAllText(filename);

            Product product = JsonSerializer.Deserialize<Product>(json);

            Console.WriteLine(product.Name);


        }
    }
}
