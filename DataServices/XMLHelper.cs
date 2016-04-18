using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Framework.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace DataServices
{
    /// <summary>
    /// This class provides functionalties for XML Serialization/Deserialization
    /// </summary>
    public static class XMLHelper
    {
        #region Public Methods

        /// <summary>
        /// Deserialize xml data from file path provided.
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="xmlFilePath">XML Filepath</param>
        /// <returns>Deseriazed object of type T</returns>
        public static T DeSerialize<T>(string xmlFilePath)
        {
            T xmlList = default(T);
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
                {
                    xmlList = (T)xmlSerializer.Deserialize(fileStream);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return xmlList;
        }

        /// <summary>
        /// Serialize xml data to the file path provided.
        /// </summary>
        /// <typeparam name="T">Type to serialize</typeparam>
        /// <param name="xmlFilePath">XML Filepath</param>
        /// <param name="objectTobeSerialized">Object to be serialized</param>
        /// <returns>boolean flag</returns>
        public static bool Serialize<T>(string xmlFilePath, T objectTobeSerialized)
        {
            T objectToSerialize = objectTobeSerialized;
            bool flag = false;
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var streamWriter = new StreamWriter(xmlFilePath))
                {
                    serializer.Serialize(streamWriter, objectToSerialize);
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        #endregion
    }
}
