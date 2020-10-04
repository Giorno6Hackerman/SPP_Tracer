﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace TracerLibrary
{
    [Serializable]
    public class MethodInfo
    {
        private string _name;
        private string _className;
        private Stopwatch _timer;
        private List<MethodInfo> _nestedMethods;

        [XmlAttribute]
        public string Name
        {
            get
            {
                return _name;
            }

            private set { }
        }

        [XmlAttribute]
        public string ClassName
        {
            get
            {
                return _className;
            }

            private set { }
        }

        [XmlAttribute]
        public long Time
        {
            get
            {
                return _timer.ElapsedMilliseconds;
            }
        }

        
        public MethodInfo()
        {
            _timer = new Stopwatch();
            _nestedMethods = new List<MethodInfo>();
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
