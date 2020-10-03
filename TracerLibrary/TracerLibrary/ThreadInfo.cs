using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLibrary
{
    public class ThreadInfo
    {
        private int _id;
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

        public ThreadInfo(int id)
        {
            Id = id;
            methods = new List<MethodInfo>();
            stack = new Stack<MethodInfo>();
        }
    }
}
