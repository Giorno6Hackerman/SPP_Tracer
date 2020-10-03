using System.IO;

namespace TracerLibrary
{
    public interface ISatanSerializer
    {
        void Serialize(Stream data, object[] graph);
    }
}
