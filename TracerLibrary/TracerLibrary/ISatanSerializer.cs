using System.IO;

namespace TracerLibrary
{
    public interface ISatanSerializer
    {
        void Serialize(Stream data, TraceResult result);
    }
}
