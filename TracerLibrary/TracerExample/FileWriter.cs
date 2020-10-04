using System;
using System.IO;

namespace TracerExample
{
    public class FileWriter : IWriter
    {
        public FileWriter()
        {
           
        }

        public void WriteData(Stream data, TextWriter stream)
        {
            StreamReader reader = new StreamReader(data);

            try
            {
                Console.SetOut(stream);
                Console.Write(reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
