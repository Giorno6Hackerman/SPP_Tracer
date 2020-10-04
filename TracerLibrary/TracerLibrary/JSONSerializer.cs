using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace TracerLibrary
{
    public class JSONSerializer : ISatanSerializer
    {
        DataContractJsonSerializer _serializer;

        public JSONSerializer(Type type)
        {
            _serializer = new DataContractJsonSerializer(type);
        }

        public void Serialize(Stream data, TraceResult result)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            using (XmlDictionaryWriter writer = JsonReaderWriterFactory.CreateJsonWriter(data, Encoding.UTF8, false, true))
            {
                _serializer.WriteObject(writer, result);
            }
        }

    }
}
