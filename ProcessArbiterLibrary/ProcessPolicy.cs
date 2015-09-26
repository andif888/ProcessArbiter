

using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessArbiter
{
    internal class ProcessPolicy
    {
        internal int RelaxProcessorPercent;
        internal double RelaxTimeInterval;
        internal int GovernorProcessorPercent;
        internal double GovernorTimeInterval;
        internal int WmiWatcherInterval;
    }
}
