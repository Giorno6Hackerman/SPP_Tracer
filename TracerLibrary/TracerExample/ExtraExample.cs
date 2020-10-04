using System;
using System.Threading;
using TracerLibrary;

namespace TracerExample
{
    public class ExtraExample
    {
        private ITracer _tracer;
        private Random rand;

        public ExtraExample(ITracer tracer)
        {
            _tracer = tracer;
            rand = new Random();
        }

        public void Life()
        {
            _tracer.StartTrace();
            Thread.Sleep(rand.Next(1, 200));

            Eat();
            Thread.Sleep(rand.Next(1, 200));
            Breathe();

            Thread.Sleep(rand.Next(1, 200));
            _tracer.StopTrace();
        }

        public void Breathe()
        {
            _tracer.StartTrace();
            Thread.Sleep(rand.Next(1, 200));

            Thread.Sleep(rand.Next(1, 200));
            Eat();

            Thread.Sleep(rand.Next(1, 200));
            _tracer.StopTrace();
        }

        public void Eat()
        {
            _tracer.StartTrace();
            Thread.Sleep(rand.Next(1, 200));

            Thread.Sleep(rand.Next(1, 200));
            _tracer.StopTrace();
        }
    }
}
