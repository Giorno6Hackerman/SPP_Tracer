using System;
using System.IO;
using Newtonsoft.Json;

namespace TracerLibrary
{
    public class JSONSerializer : ISatanSerializer
    {
        JsonSerializer _serializer;

        public JSONSerializer(Type type)
        {
            _serializer = new JsonSerializer();
        }

        public void Serialize(Stream data, TraceResult result)
        {
            try
            {
                StreamWriter writer = new StreamWriter(data);
                _serializer.Serialize(writer, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
