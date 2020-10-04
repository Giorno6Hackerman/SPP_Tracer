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
        //private XmlSerializer _serializer;

        public XMLSerializer(Type type)
        {
            try
            {
                _serializer = new DataContractSerializer(type);
                //_serializer = new XmlSerializer(type);
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
                XmlWriter writer = new XmlTextWriter(data, Encoding.UTF8);
                _serializer.WriteObject(data, result);
                //_serializer.Serialize(data, graph);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
