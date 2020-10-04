using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;
using TracerLibrary;
using System.Text;

namespace TracerLibrary
{
    public class XMLSerializer : ISatanSerializer
    {
        private DataContractSerializer _serializer;

        public XMLSerializer(Type type)
        {
            _serializer = new DataContractSerializer(type);
        }

        public void Serialize(Stream data, TraceResult result)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            //settings.Encoding = Encoding.UTF8;
            //settings.IndentChars = "\t";
            //settings.NewLineChars = "\r\n";
            //settings.NewLineHandling = NewLineHandling.Replace;
            using (XmlWriter writer = XmlWriter.Create(data, settings)) 
            {
                _serializer.WriteObject(writer, result);
            }
        }
    }
}
