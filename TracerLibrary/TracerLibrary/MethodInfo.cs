using System.Collections.Generic;
using System.Diagnostics;

namespace TracerLibrary
{
    public class MethodInfo
    {
        private string _name;
        private string _className;
        private Stopwatch _timer;
        private List<MethodInfo> _nestedMethods;

        public string ClassName
        {
            get
            {
                return _className;
            }

            private set { }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            private set { }
        }

        public long Time
        {
            get
            {
                return _timer.ElapsedMilliseconds;
            }
        }

        public MethodInfo(string name, string className)
        {
            Name = name;
            ClassName = className;
            _timer = new Stopwatch();
            _nestedMethods = new List<MethodInfo>();
        }

        public void StartTimer()
        {
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        public void AddNestedMethod(MethodInfo method)
        {
            _nestedMethods.Add(method);
        }
    }
}
