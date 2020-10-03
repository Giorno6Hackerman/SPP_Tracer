using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLibrary
{
    public class MethodInfo
    {
        private string _name;
        private string _className;
        private Stopwatch _time;
        private List<MethodInfo> nestedMethods;

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

        public MethodInfo(string name, string className)
        {
            Name = name;
            ClassName = className;
            _time = new Stopwatch();
            nestedMethods = new List<MethodInfo>();
        }
    }
}
