using System.Collections.Generic;

namespace TracerLibrary
{
    public class ThreadInfo
    {
        private int _id;
        private long _time;
        private List<MethodInfo> methods;
        private Stack<MethodInfo> stack;

        public int Id
        {
            get
            {
                return _id;
            }

            private set {}
        }

        public long Time
        {
            get
            {
                _time = 0;
                foreach (MethodInfo method in methods)
                {
                    _time += method.Time;
                }
                return _time;
            }
        }

        public ThreadInfo(int id)
        {
            Id = id;
            methods = new List<MethodInfo>();
            stack = new Stack<MethodInfo>();
        }

        public void AddMethod(MethodInfo method)
        {
            if (stack.Count > 0)
            {
                stack.Peek().AddNestedMethod(method);
            }
            else
            {
                methods.Add(method);
            }

            stack.Push(method);
        }

        public MethodInfo DeleteMethod()
        {
            return stack.Pop();
        }
    }
}
