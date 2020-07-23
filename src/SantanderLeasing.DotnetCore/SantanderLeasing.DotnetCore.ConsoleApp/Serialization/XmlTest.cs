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
            //DeserializationTest();
            //SerializationTest();

            GenericSerializeToFileTest();
            GenericDeserializeFromFileTest();

            GenericSerializeToTextTest();
            GenericDeserializeFromTextTest();

      
        }

        private static void GenericSerializeToTextTest()
        {
            Product product = CreateProduct();

            XmlGenericSerializer serializer = new XmlGenericSerializer();
            string xml = serializer.Serialize(product);

            Console.WriteLine(xml);
        }

        private static void GenericSerializeToFileTest()
        {
            Product product = CreateProduct();

            XmlGenericSerializer serializer = new XmlGenericSerializer();
            serializer.Serialize(product, "products.xml");
        }

        private static void GenericDeserializeFromFileTest()
        {
            XmlGenericSerializer serializer = new XmlGenericSerializer();
            Product product = serializer.DeserializeFile<Product>("products.xml");
        }

        private static void GenericDeserializeFromTextTest()
        {
            string xml = "<Produkt color=\"Red\"><Id>1</Id><Name>Product 1</Name><UnitPrice>1.99</UnitPrice></Produkt>";
            XmlGenericSerializer serializer = new XmlGenericSerializer();
            Product product = serializer.Deserialize<Product>(xml);
        }

        public static void SerializationTest()
        {
            Product product = CreateProduct();

            XmlSerializer serializer = new XmlSerializer(typeof(Product));

            string filename = "products.xml";

            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, product);
            }  // IDisposable.Dispose()

            // ....

        }

        private static Product CreateProduct()
        {
            return new Product { Id = 1, Name = "Product 1", Color = "Red", UnitPrice = 1.99m };
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
