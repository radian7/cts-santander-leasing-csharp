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

        public T Deserialize<T>(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamReader reader = new StreamReader(filename))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }

    
}
