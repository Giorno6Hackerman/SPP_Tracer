using System;
using System.IO;

namespace TracerExample
{
    public class ResultWriter : IWriter
    {
        public ResultWriter()
        {
           
        }

        public void WriteData(Stream data, TextWriter stream)
        {
            data.Position = 0;
            StreamReader reader = new StreamReader(data);
            
            try
            {
                Console.SetOut(stream);
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
