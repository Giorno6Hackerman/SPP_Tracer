using System.Threading;
using TracerLibrary;

namespace TracerExample
{
    public class MainExample
    {
        private ITracer _tracer;
        private ExtraExample _extra;

        public MainExample(ITracer tracer)
        {
            _tracer = tracer;
            _extra = new ExtraExample(tracer);
        }

        public void Execution()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);

            Thread deathThread = new Thread(Death);
            deathThread.Start();

            Thread.Sleep(6);
            lock (_extra)
            {
                _extra.Eat();
            }

            Thread sufferingThread = new Thread(Suffering);
            sufferingThread.Start();

            Thread.Sleep(666);
            _tracer.StartTrace();
        }

        public void Death()
        {
            _tracer.StartTrace();
            Thread.Sleep(10);

            lock (_extra)
            {
                Thread extraThread = new Thread(_extra.Life);
                extraThread.Start();
            }


            Thread.Sleep(66);
            _tracer.StartTrace();
        }

        public void Suffering()
        {
            _tracer.StartTrace();
            Thread.Sleep(54);

            lock (_extra)
            {
                _extra.Breathe();
                Thread.Sleep(2);
            }

            Thread.Sleep(61);
            _tracer.StartTrace();
        }
    }
}
