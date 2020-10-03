using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics;

namespace TracerLibrary
{
    public class TraceResult
    {
        // Thread's id and info.
        private ConcurrentDictionary<int, ThreadInfo> threads;

        public TraceResult()
        {
            threads = new ConcurrentDictionary<int, ThreadInfo>();
        }

        public ThreadInfo GetThread(int id, ThreadInfo thread)
        {
            return threads.GetOrAdd(id, thread);
        }

        public ImmutableList<ThreadInfo> GetThreadList()
        {
            return ImmutableList<ThreadInfo>.Empty.AddRange(threads.Values);
        }
    }
}
