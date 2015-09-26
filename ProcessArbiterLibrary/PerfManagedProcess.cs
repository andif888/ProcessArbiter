
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessArbiter
{
    internal class PerfManagedProcess
    {
        internal double GovernorTimeInterval;
        internal double RelaxedTimeInterval;
        internal int Priority;
        internal int PriorityOriginal;
        internal string Name;
        
    }

    internal class PerfProcess
    {
        internal int Id;
        internal string Name;
        internal double TotalProcessorTimeInMilliseconds;
        internal int BasePriority;

        internal PerfProcess(int id, string name, double totalProcessorTimeInMilliseconds, int basePriority)
        {
            Id = id;
            Name = name;
            TotalProcessorTimeInMilliseconds = totalProcessorTimeInMilliseconds;
            BasePriority = basePriority;
        }
    }
}
