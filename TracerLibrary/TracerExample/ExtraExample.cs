using System.Threading;
using TracerLibrary;

namespace TracerExample
{
    public class ExtraExample
    {
        private ITracer _tracer;

        public ExtraExample(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Life()
        {
            _tracer.StartTrace();
            Thread.Sleep(41);

            Eat();
            Thread.Sleep(10);
            Breathe();

            Thread.Sleep(5);
            _tracer.StopTrace();
        }

        public void Breathe()
        {
            _tracer.StartTrace();
            Thread.Sleep(11);

            Thread eatThread = new Thread(Eat);
            eatThread.Start();

            Thread.Sleep(4);
            Eat();

            Thread.Sleep(54);
            _tracer.StopTrace();
        }

        public void Eat()
        {
            _tracer.StartTrace();
            Thread.Sleep(1);

            Thread.Sleep(78);
            _tracer.StopTrace();
        }
    }
}
