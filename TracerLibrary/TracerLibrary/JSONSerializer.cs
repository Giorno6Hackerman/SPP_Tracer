using System;
using System.IO;
using System.Text.Json;

namespace TracerLibrary
{
    public class JSONSerializer : ISatanSerializer
    {
        private Type _type;
        public JSONSerializer(Type type)
        {
            _type = type;
        }

        public void Serialize(Stream data, object[] graph)
        {
            JsonSerializer.SerializeAsync(data, graph, _type);
        }

    }
}
