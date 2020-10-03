using System;
using System.Diagnostics;
using System.Threading;

namespace TracerLibrary
{
    public class Tracer : ITracer
    {
        private TraceResult result;

        public Tracer()
        {
            result = new TraceResult();
        }

        public void StartTrace()
        {
            var trace = new StackTrace();
            string methodName = trace.GetFrame(trace.FrameCount - 1).GetMethod().Name;
            string className = trace.GetFrame(trace.FrameCount - 1).GetMethod().DeclaringType.Name;
            var method = new MethodInfo(methodName, className);
            result.GetThread(Thread.CurrentThread.ManagedThreadId).AddMethod(method);
            method.StartTimer();
        }

        public void StopTrace()
        {
            result.GetThread(Thread.CurrentThread.ManagedThreadId).DeleteMethod().StopTimer();
        }

        public TraceResult GetTraceResult()
        {
            return result;
        }
    }
}
