using System.Collections.Concurrent;
using System.Collections.Immutable;

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

        public ThreadInfo GetThread(int id)
        {
            ThreadInfo thread;
            if (!threads.TryGetValue(id, out thread))
            {
                thread = new ThreadInfo(id);
                threads.TryAdd(id, thread);
            }

            return thread;
        }

        public ImmutableList<ThreadInfo> GetThreadList()
        {
            return ImmutableList<ThreadInfo>.Empty.AddRange(threads.Values);
        }
    }
}
