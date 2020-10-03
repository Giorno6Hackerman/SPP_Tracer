using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace TracerLibrary
{
    public class TraceResult
    {
        // thread's id and info
        private ConcurrentDictionary<int, ThreadInfo> threads;

        public TraceResult()
        {
            threads = new ConcurrentDictionary<int, ThreadInfo>();
        }
    }
}
