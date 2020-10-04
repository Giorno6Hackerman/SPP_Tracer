using System;
using System.IO;

namespace TracerExample
{
    public interface IWriter
    {
        void WriteData(Stream data, TextWriter stream);
    }
}
