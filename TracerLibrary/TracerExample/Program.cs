using System;
using System.IO;
using System.Threading;
using TracerLibrary;

namespace TracerExample
{
    class Program
    {
        private static Tracer _tracer;

        static void Main(string[] args)
        {
            _tracer = new Tracer();
            MainExample first = new MainExample(_tracer);
            first.Execution();

            Thread thread = new Thread(first.Death);
            thread.Start();

            ExtraExample second = new ExtraExample(_tracer);
            second.Life();

            TraceResult result = _tracer.GetTraceResult();
            OutputResults(result);
        }

        private static void OutputResults(TraceResult result)
        {
            MemoryStream xmlStream = new MemoryStream();
            XMLSerializer xmlSerial = new XMLSerializer(typeof(TraceResult));
            xmlSerial.Serialize(xmlStream, result);

            IWriter writer = new ResultWriter();
            writer.WriteData(xmlStream, Console.Out);

            MemoryStream jsonStream = new MemoryStream();
            JSONSerializer jsonSerial = new JSONSerializer(typeof(TraceResult));
            jsonSerial.Serialize(jsonStream, result);

            writer.WriteData(jsonStream, Console.Out);

            StreamWriter xmlFile = new StreamWriter(File.Create("traceresult.xml"));
            writer.WriteData(xmlStream, xmlFile);

            xmlStream.Close();
            xmlFile.Close();

            StreamWriter jsonFile = new StreamWriter(File.Create("traceresult.json"));
            writer.WriteData(jsonStream, jsonFile);

            jsonStream.Close();
            jsonFile.Close();
        }
    }
}
