using System;
using System.IO;
using System.Threading;
using TracerLibrary;

namespace TracerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Tracer tracer = new Tracer();
            MainExample first = new MainExample(tracer);
            first.Execution();

            Thread firstThread = new Thread(first.Death);
            firstThread.Start();

            Thread secondThread = new Thread(first.Suffering);
            secondThread.Start();

            TraceResult result = tracer.GetTraceResult();
            MemoryStream xmlStream = new MemoryStream();
            XMLSerializer xmlSerial = new XMLSerializer(typeof(TraceResult));
            xmlSerial.Serialize(xmlStream, result);
            xmlStream.Position = 0;

            IWriter writer = new ResultWriter();
            writer.WriteData(xmlStream, Console.Out);
            xmlStream.Position = 0;

            MemoryStream jsonStream = new MemoryStream();
            JSONSerializer jsonSerial = new JSONSerializer(typeof(TraceResult));
            jsonSerial.Serialize(jsonStream, result);
            jsonStream.Position = 0;

            writer.WriteData(jsonStream, Console.Out);
            jsonStream.Position = 0;


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
