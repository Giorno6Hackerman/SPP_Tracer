using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TracerLibrary
{
    [Serializable]
    [DataContract()]
    public class ThreadInfo
    {
        private int _id;
        private long _time;
        private List<MethodInfo> _methods;
        private Stack<MethodInfo> _stack;

        [DataMember()]
        public int Id
        {
            get
            {
                return _id;
            }

            private set {}
        }

        [DataMember()]
        public long Time
        {
            get
            {
                _time = 0;
                foreach (MethodInfo method in _methods)
                {
                    _time += method.Time;
                }
                return _time;
            }

            private set { }
        }

        [DataMember()]
        public List<MethodInfo> Methods
        {
            get
            {
                return _methods;
            }

            private set { }
        }

        public ThreadInfo()
        {
            _methods = new List<MethodInfo>();
            _stack = new Stack<MethodInfo>();
        }
        

        public ThreadInfo(int id)
        {
            _id = id;
            _methods = new List<MethodInfo>();
            _stack = new Stack<MethodInfo>();
        }

        public void AddMethod(MethodInfo method)
        {
            if (_stack.Count > 0)
            {
                _stack.Peek().AddNestedMethod(method);
            }
            else
            {
                _methods.Add(method);
            }

            _stack.Push(method);
        }

        public MethodInfo DeleteMethod()
        {
            return _stack.Pop();
        }
    }
}
