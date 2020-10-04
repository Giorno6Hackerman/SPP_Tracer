using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TracerLibrary
{
    [Serializable]
    [DataContract()]
    public class MethodInfo
    {
        private string _name;
        private string _className;
        private Stopwatch _timer;
        private List<MethodInfo> _nestedMethods;

        [XmlAttribute]
        [DataMember()]
        public string Name
        {
            get
            {
                return _name;
            }

            private set { }
        }

        [XmlAttribute]
        [DataMember()]
        public string ClassName
        {
            get
            {
                return _className;
            }

            private set { }
        }

        [XmlAttribute]
        [DataMember()]
        public long Time
        {
            get
            {
                return _timer.ElapsedMilliseconds;
            }

            private set { }
        }

        [DataMember()]
        public List<MethodInfo> NestedMethods
        {
            get
            {
                return _nestedMethods;
            }

            private set { }
        }

        
        public MethodInfo()
        {
            _timer = new Stopwatch();
            _nestedMethods = new List<MethodInfo>();
        }
        

        public MethodInfo(string name, string className)
        {
            _name = name;
            _className = className;
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
