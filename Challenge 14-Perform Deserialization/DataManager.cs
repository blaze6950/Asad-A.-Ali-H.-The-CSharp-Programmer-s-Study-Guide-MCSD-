using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Challenge_14_Perform_Deserialization
{
    class DataManager<T>
    {
        public void SerializeCollection(List<T> collection, string path = "ListOfCountries.xml")
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<T>));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(stream, collection);
            }
        }

        public List<T> DeserializeCollection(string path = "ListOfCountries.xml")
        {
            List<T> list;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                list = (List<T>)xml.Deserialize(stream);
            }
            return list;
        }

        public void SerializeObject(T item, string path = "Country.xml")
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(stream, item);
            }
        }

        public T DeserializeObject(string path = "Country.xml")
        {
            T newT;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                newT = (T)xml.Deserialize(stream);
            }
            return newT;
        }
    }
}
