using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace TracerLibrary
{
    [Serializable]
    [DataContract()]
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

        [DataMember()]
        public ImmutableList<ThreadInfo> ThreadList
        {
            get
            {
                return ImmutableList<ThreadInfo>.Empty.AddRange(threads.Values);
            }

            private set { }
        }
    }
}
