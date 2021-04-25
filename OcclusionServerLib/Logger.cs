using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib
{
    public class Logger
    {
        public string Prefix { get; set; }

        public Logger(string prefix)
        {
            Prefix = prefix;
        }

        public void Log(string str)
        {
            Console.WriteLine(Prefix + " " + str);
        }
    }
}
