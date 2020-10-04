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
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            _serializer = JsonSerializer.Create(settings);
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
