using System;
using System.IO;

namespace TracerExample
{
    public class FileWriter : IWriter
    {
        public void WriteData(Stream data, TextWriter stream)
        {
            StreamWriter writer = new StreamWriter(data);
            try
            {
                Console.SetOut(stream);
                Console.Write(writer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
