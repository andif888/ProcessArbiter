

using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessArbiter
{
    public class ProcessPolicy
    {
        public int RelaxProcessorPercent;
        public double RelaxTimeInterval;
        public int GovernorProcessorPercent;
        public double GovernorTimeInterval;
        public int WmiWatcherInterval;
        public List<string> IgnoreProcesses = new List<string>();
        public List<string> IncludeProcesses = new List<string>();
    }
}
