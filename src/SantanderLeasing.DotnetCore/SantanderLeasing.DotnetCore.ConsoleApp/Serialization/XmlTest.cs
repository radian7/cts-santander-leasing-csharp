using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SantanderLeasing.DotnetCore.ConsoleApp.Serialization
{

    public class XmlTest
    {
        public static void Test()
        {
            DeserializationTest();
            SerializationTest();
        }

        public static void SerializationTest()
        {

            Product product = new Product { Id = 1, Name = "Product 1", Color = "Red", UnitPrice = 1.99m };

            XmlSerializer serializer = new XmlSerializer(typeof(Product));

            string filename = "products.xml";

            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, product);
            }  // IDisposable.Dispose()

            // ....

        }

        public static void DeserializationTest()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Product));
            string filename = "products.xml";

            using (StreamReader reader = new StreamReader(filename))
            {
                Product product = (Product)serializer.Deserialize(reader);

                Console.WriteLine(product.Name);
            }

        }


    }
}
