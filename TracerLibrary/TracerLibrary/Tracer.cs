using System;

namespace TracerLibrary
{
    public class Tracer : ITracer
    {
        // вызывается в начале замеряемого метода
        public void StartTrace()
        { 
        
        }

        // вызывается в конце замеряемого метода 
        public void StopTrace()
        { 
        
        }

        // получить результаты измерений  
        public TraceResult GetTraceResult()
        {
            return new TraceResult();
        }
    }
}
