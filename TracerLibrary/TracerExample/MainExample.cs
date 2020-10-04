using System;
using System.Threading;
using TracerLibrary;

namespace TracerExample
{
    public class MainExample
    {
        private ITracer _tracer;
        private ExtraExample _extra;
        private Random rand;

        public MainExample(ITracer tracer)
        {
            _tracer = tracer;
            _extra = new ExtraExample(tracer);
            rand = new Random();
        }

        public void Execution()
        {
            _tracer.StartTrace();
            Thread.Sleep(rand.Next(1, 200));

            Thread.Sleep(rand.Next(1, 200));
            _extra.Eat();

            Thread.Sleep(rand.Next(1, 200));
            _tracer.StopTrace();
        }

        public void Death()
        {
            _tracer.StartTrace();
            Thread.Sleep(rand.Next(1, 200));

            Thread.Sleep(666);

            _tracer.StopTrace();
        }

        public void Suffering()
        {
            _tracer.StartTrace();
            Thread.Sleep(rand.Next(1, 200));

            _extra.Breathe();
            Thread.Sleep(rand.Next(1, 200));

            _tracer.StopTrace();
        }
    }
}
