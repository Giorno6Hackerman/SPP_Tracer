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
            try
            {
                _serializer = new DataContractSerializer(type);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Serialize(Stream data, TraceResult result)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                //settings.Encoding = Encoding.UTF8;
                //settings.IndentChars = "\t";
                //settings.NewLineChars = "\r\n";
                //settings.NewLineHandling = NewLineHandling.Replace;
                XmlWriter writer = XmlWriter.Create(data, settings);
                _serializer.WriteObject(writer, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
