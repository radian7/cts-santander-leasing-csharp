using System.IO;
using System.Xml.Serialization;

namespace SantanderLeasing.DotnetCore.ConsoleApp.Serialization
{
    // Zastosowanie metod generycznych
    public class XmlGenericSerializer
    {
        public void Serialize<T>(T item, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, item);
            }
        }

        public string Serialize<T>(T item)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, item);

                return writer.ToString();
            }
        }

        public T DeserializeFile<T>(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamReader reader = new StreamReader(filename))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }


    }

    
}
