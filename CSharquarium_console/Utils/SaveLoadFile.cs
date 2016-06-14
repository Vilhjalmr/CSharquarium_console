using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharquarium_console.Utils
{
    public static class SaveLoadFile<T>
    {
        /// <summary>
        /// Use this to save an object to a file.
        /// </summary>
        /// <param name="T">Type of the object you want to serialize. Class must be Serializable</param>
        /// <param name="path">Path of the file you want to save to. Needs not exist yet.</param>
        /// <param name="obj">A reference to the object you want to serialize.</param>
        public static void SaveToXML(Type T, string path, T obj)
        {
            XmlSerializer serializer = new XmlSerializer(T);

            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, obj);
            }
        }

        /// <summary>
        /// Use this to load an object previously saved as XML file.
        /// </summary>
        /// <param name="T">Type of the object you want to serialize. Class must be Serializable</param>
        /// <param name="path">Path of the file you want to save to. Needs not exist yet.</param>
        /// <returns></returns>
        public static T LoadFromXML(Type T, string path)
        {
            T result;
            XmlSerializer serializer = new XmlSerializer(T);

            using (StreamReader reader = new StreamReader(path))
            {
                result = (T)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
