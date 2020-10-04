using System;
using System.IO;

namespace TracerExample
{
    public class FileWriter : IWriter
    {
        public void WriteData(Stream data, TextWriter stream)
        {
            Console.SetOut(stream);
            StreamWriter writer = new StreamWriter(data);
            Console.Write(writer);
        }
    }
}
