using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ProcessArbiter
{
    public class ProcessManagerEngine
    {
        private Thread _loop = null;
        private bool _simulate = false;
        private bool _isRunning = false;
        private bool _run = false;
        private int _numberOfProcessors = 1;

        private ProcessPolicy _policy = null;
        private Dictionary<int, PerfManagedProcess> _managedProcesses = new Dictionary<int, PerfManagedProcess>();
        private EventLog _eventLog = null;
        private System.Timers.Timer _cleanupTimer;

        public bool Simulate
        {
            get { return _simulate; }
            set { _simulate = value; }
        }



        public ProcessManagerEngine(EventLog eventLog)
        {
            _numberOfProcessors = Environment.ProcessorCount;
            _eventLog = eventLog;
            _cleanupTimer = new System.Timers.Timer(Properties.Settings.Default.CleanupTimeInterval);
            _cleanupTimer.Elapsed += new System.Timers.ElapsedEventHandler(CleanupTimer_Elapsed);



        }

        private void CleanupTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _cleanupTimer.Stop();
            CleanupManagedProcesses();
            _cleanupTimer.Start();
        }


        private List<string> InitIgnoreProcesses(List<string> iList)
        {
           iList.Clear();

            foreach (string s in Properties.Settings.Default.IgnoreProcessList)
            {
                if (!iList.Contains(s))
                {
                    iList.Add(s);
                }
            }
            if (!iList.Contains("system idle process"))
                iList.Add("system idle process");
            if (!iList.Contains("system"))
                iList.Add("system");
            if (!iList.Contains("wininit"))
                iList.Add("wininit");
            if (!iList.Contains("processarbiterservice"))
                iList.Add("processarbiterservice");
            if (!iList.Contains("taskmgr"))
                iList.Add("taskmgr");
            return iList;

        }

        private List<string> InitIncludedProcesses(List<string> iList)
        {
            iList.Clear();

            foreach (string s in Properties.Settings.Default.IncludeProcessList)
            {
                if (!iList.Contains(s))
                {
                    iList.Add(s);
                }
            }

            return iList;
        }

        private void InitPolicy()
        {
            _policy = new ProcessPolicy();

            _policy.GovernorProcessorPercent = (int)(Properties.Settings.Default.GovernorProcessorPercent / _numberOfProcessors);
            _policy.GovernorTimeInterval = Properties.Settings.Default.GovernorTimeIntervalMilliseconds;
            _policy.RelaxProcessorPercent = (int)(Properties.Settings.Default.RelaxProcessorPercent / _numberOfProcessors);
            _policy.RelaxTimeInterval = Properties.Settings.Default.RelaxTimeIntervalMilliseconds;

            if (Properties.Settings.Default.WmiWatcherIntervalMilliseconds >= 1000)
                _policy.WmiWatcherInterval = Properties.Settings.Default.WmiWatcherIntervalMilliseconds;
            else
                _policy.WmiWatcherInterval = 1000;
            _policy.IgnoreProcesses = InitIgnoreProcesses(_policy.IgnoreProcesses);
            _policy.IncludeProcesses = InitIgnoreProcesses(_policy.IncludeProcesses);

        }





        public void StartEngine()
        {
            if (_isRunning)
                return;

            InitPolicy();

            _loop = new Thread(new ThreadStart(RunLoop));
            _loop.Name = "PPO_Thread";
            _loop.Start();

            _cleanupTimer.Start();


        }

        public void StopEngine()
        {
            _run = false;

            while (_isRunning)
                Thread.Sleep(1000);


            _cleanupTimer.Stop();

            ResetAllProcessPriorities();

            if (_managedProcesses != null)
            {
                _managedProcesses.Clear();
            }
            if (_policy.IgnoreProcesses != null)
            {
                _policy.IgnoreProcesses.Clear();
            }
            if (_policy.IncludeProcesses != null)
            {
                _policy.IncludeProcesses.Clear();
            }
        }

        public string DumpEngine()
        {
            string governorTimeIntervalStr = string.Empty;
            if (_policy.GovernorTimeInterval == 0)
                governorTimeIntervalStr = "1000";
            else
                governorTimeIntervalStr = _policy.GovernorTimeInterval.ToString();

            StringBuilder log = new StringBuilder();
            log.Append("Process Policy:");
            log.Append("\r\n-----------------");
            log.Append("\r\nNumberOfLogicalProcessors: " + _numberOfProcessors.ToString());
            log.Append("\r\nThe base priority of each process, which uses more than " + _policy.GovernorProcessorPercent.ToString() + "% CPU resources ");
            log.Append("for more than " + governorTimeIntervalStr + "ms, will be decreased.");
            log.Append("\r\nThe base priority of each process will go step by step back to its original state, if the process stays below " + _policy.RelaxProcessorPercent.ToString() + "% CPU usage ");
            log.Append("for more than " + _policy.RelaxTimeInterval.ToString() + "ms.");
            log.Append("\r\nThe policy above is applied every " + _policy.WmiWatcherInterval.ToString() + "ms.");
            log.Append("\r\n");
            log.Append("\r\nIncluded Processes:");
            log.Append("\r\n----------------------");
            foreach (string IncludedProcess in _policy.IncludeProcesses)
            {
                log.Append("\r\n" + IncludedProcess);
            }
            log.Append("\r\n");
            log.Append("\r\nIgnored Processes:");
            log.Append("\r\n----------------------");
            foreach (string ignoredProcess in _policy.IgnoreProcesses)
            {
                log.Append("\r\n" + ignoredProcess);
            }
            log.Append("\r\n");
            log.Append("\r\nProcesses, currently under observation:");
            log.Append("\r\n----------------------------------------------");
            log.Append("\r\n");

            log.Append("\r\nPID  |  Priority  |  Original Priority  |  Exceed Time Interval  |  Relaxed Time Interval  |  Name");
            log.Append("\r\n------------------------------------------------------------------------------------------------------------");
            lock (((System.Collections.ICollection)_managedProcesses).SyncRoot)
            {
                if (_managedProcesses.Count > 0)
                {
                    foreach (KeyValuePair<int, PerfManagedProcess> kvp in _managedProcesses)
                    {
                        log.Append("\r\n" + kvp.Key.ToString());
                        log.Append(" \t");
                        log.Append(kvp.Value.Priority.ToString());
                        log.Append(" \t\t");
                        log.Append(kvp.Value.PriorityOriginal.ToString());
                        log.Append(" \t\t");
                        log.Append(Math.Round(kvp.Value.GovernorTimeInterval, 0).ToString() + "ms");
                        log.Append("\t\t\t");
                        log.Append(Math.Round(kvp.Value.RelaxedTimeInterval, 0).ToString() + "ms");
                        log.Append("\t\t    ");
                        log.Append(kvp.Value.Name);
                        log.Append("\r\n");
                    }
                }
                else
                {
                    log.Append("\r\nCurrently there are no processes under observation.");
                }
            }

            return (log.ToString());
        }

        private void RunLoop()
        {
            _run = true;
            _isRunning = true;


            Dictionary<int, PerfProcess> procList1 = GetProcessList();


            Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();


            while (_run)
            {

                Thread.Sleep(_policy.WmiWatcherInterval); // 1 second wait

                StringBuilder sb = new StringBuilder();

                Dictionary<int, PerfProcess> procList2 = new Dictionary<int, PerfProcess>();
                Process[] plist2 = Process.GetProcesses();
                foreach (Process p2 in plist2)
                {
                    if (_policy.IncludeProcesses.Count > 0)
                    {
                        if (p2.Id == 0 || _policy.IgnoreProcesses.Contains(p2.ProcessName.ToLower()) || !_policy.IncludeProcesses.Contains(p2.ProcessName.ToLower()))
                            continue;
                    }
                    else
                    {
                        if (p2.Id == 0 || _policy.IgnoreProcesses.Contains(p2.ProcessName.ToLower()))
                            continue;
                    }

                    try
                    {
                        PerfProcess proc = new PerfProcess(p2.Id, p2.ProcessName, p2.TotalProcessorTime.TotalMilliseconds, p2.BasePriority);
                        procList2.Add(proc.Id, proc);

                    }
                    catch
                    {
                        continue;
                    }

                    double tpt1 = 0;

                    PerfProcess proc1 = null;
                    bool foundProc1 = procList1.TryGetValue(p2.Id, out proc1);

                    if (foundProc1 && proc1.Name == p2.ProcessName)
                    {
                        tpt1 = proc1.TotalProcessorTimeInMilliseconds;
                    }


                    double processUsedProcessorTimeInMilliseconds = p2.TotalProcessorTime.TotalMilliseconds - tpt1;
                    double elapsedTime = stopwatch.Elapsed.TotalMilliseconds;
                    double processUsedProcessorPercent = ((100 * processUsedProcessorTimeInMilliseconds) / elapsedTime) / _numberOfProcessors;



                    #region Begin Management Action

                    lock (((System.Collections.ICollection)_managedProcesses).SyncRoot)
                    {
                        if (processUsedProcessorPercent >= _policy.GovernorProcessorPercent)
                        {
                            PerfManagedProcess mp;
                            if (_managedProcesses.TryGetValue(p2.Id, out mp) == false)
                            {
                                mp = new PerfManagedProcess();
                                mp.GovernorTimeInterval = 0;
                                mp.RelaxedTimeInterval = 0;
                                mp.PriorityOriginal = p2.BasePriority;
                                mp.Name = p2.ProcessName;

                                _managedProcesses.Add(p2.Id, mp);
                            }
                            else
                            {
                                if (mp.Name != p2.ProcessName)
                                {
                                    mp.Name = p2.ProcessName;
                                    mp.GovernorTimeInterval = 0;
                                    mp.RelaxedTimeInterval = 0;
                                    mp.PriorityOriginal = p2.BasePriority;
                                }
                            }


                            mp.Priority = p2.BasePriority;

                            // processor auslastung ist größer als erlaubt

                            if (mp.GovernorTimeInterval >= (_policy.GovernorTimeInterval))
                            {
                                // processor auslastung ist länger als erlaubt
                                // Management Action
                                DecrementProcessPriority(p2);

                                mp.GovernorTimeInterval = 0;

                            }
                            else
                            {
                                mp.GovernorTimeInterval += elapsedTime;
                            }
                            mp.RelaxedTimeInterval = 0;

                        }
                        else
                        {

                            PerfManagedProcess mp;
                            if (_managedProcesses.TryGetValue(p2.Id, out mp))
                            {
                                mp.Priority = p2.BasePriority;

                                if (mp.PriorityOriginal > p2.BasePriority)
                                {
                                    if (processUsedProcessorPercent <= _policy.RelaxProcessorPercent)
                                    {
                                        mp.RelaxedTimeInterval += elapsedTime;

                                        if (mp.RelaxedTimeInterval >= (_policy.RelaxTimeInterval))
                                        {
                                            // Priority erhöhen
                                            IncrementProcessPriority(p2);

                                            mp.RelaxedTimeInterval = 0;
                                        }
                                    }
                                    else
                                    {
                                        mp.RelaxedTimeInterval = 0;
                                    }
                                    mp.GovernorTimeInterval = 0;
                                }
                                else
                                {

                                    _managedProcesses.Remove(p2.Id);

                                }
                            }

                        }

                    }
                    #endregion

                }


                stopwatch.Reset();
                stopwatch.Start();

                procList1 = procList2;
            }

            _isRunning = false;

        }





        public void DecrementProcessPriority(Process process)
        {
            if (_simulate)
                return;
            try
            {
                switch (process.BasePriority)
                {
                    case 5:
                        process.PriorityClass = ProcessPriorityClass.Idle;
                        break;
                    case 6:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.Idle;
                        break;
                    case 7:
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        break;
                    case 8:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        break;
                    case 9:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.Normal;
                        break;
                    case 10:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.Normal;
                        break;
                    case 11:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.AboveNormal;
                        break;
                    case 12:
                        process.PriorityClass = ProcessPriorityClass.AboveNormal;
                        break;
                    case 13:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.AboveNormal;
                        break;
                    case 14:
                        process.PriorityClass = ProcessPriorityClass.High;
                        break;
                    case 15:
                        process.PriorityClass = ProcessPriorityClass.High;
                        break;
                    case 16:
                        process.PriorityClass = ProcessPriorityClass.High;
                        break;
                    case 17:
                        process.PriorityClass = ProcessPriorityClass.High;
                        break;
                    default:
                        if (process.BasePriority > 17)
                        {
                            process.PriorityClass = ProcessPriorityClass.High;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString(), EventLogEntryType.Warning);
            }
        }
        public void IncrementProcessPriority(Process process)
        {
            if (_simulate)
                return;
            try
            {
                switch (process.BasePriority)
                {
                    case 1:
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        break;
                    case 2:
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        break;
                    case 3:
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        break;
                    case 4:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.BelowNormal;
                        break;
                    case 5:
                        process.PriorityClass = ProcessPriorityClass.Normal;
                        break;
                    case 6:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.Normal;
                        break;
                    case 7:
                        process.PriorityClass = ProcessPriorityClass.AboveNormal;
                        break;
                    case 8:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.AboveNormal;
                        break;
                    case 9:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.High;
                        break;
                    case 10:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.High;
                        break;
                    case 11:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.RealTime;
                        break;
                    case 12:
                        process.PriorityClass = ProcessPriorityClass.RealTime;
                        break;
                    case 13:
                        // Original
                        process.PriorityClass = ProcessPriorityClass.RealTime;
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString(), EventLogEntryType.Warning);
            }
        }
        public void ResetProcessPriority(int processId, int priority, int originalPriority)
        {
            if (_simulate)
                return;
            try
            {
                if (priority != originalPriority)
                {
                    switch (originalPriority)
                    {
                        case 0:
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.Idle;
                            break;
                        case 1:
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.Idle;
                            break;
                        case 2:
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.Idle;
                            break;
                        case 3:
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.Idle;
                            break;
                        case 4:
                            // Original
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.Idle;
                            break;
                        case 5:
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.BelowNormal;
                            break;
                        case 6:
                            // Original
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.BelowNormal;
                            break;
                        case 7:
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.Normal;
                            break;
                        case 8:
                            // Original
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.Normal;
                            break;
                        case 9:
                            // Original
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.AboveNormal;
                            break;
                        case 10:
                            // Original
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.AboveNormal;
                            break;
                        case 11:
                            // Original
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.High;
                            break;
                        case 12:
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.High;
                            break;
                        case 13:
                            // Original
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.High;
                            break;
                        case 14:
                            Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.RealTime;
                            break;
                        default:
                            if (originalPriority > 14)
                            {
                                Process.GetProcessById(processId).PriorityClass = ProcessPriorityClass.RealTime;
                            }
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString(), EventLogEntryType.Warning);
            }
        }


        private void ResetAllProcessPriorities()
        {
            lock (((System.Collections.ICollection)_managedProcesses).SyncRoot)
            {
                foreach (KeyValuePair<int, PerfManagedProcess> kvp in _managedProcesses)
                {
                    ResetProcessPriority(kvp.Key, kvp.Value.Priority, kvp.Value.PriorityOriginal);
                }
            }
        }

        private void CleanupManagedProcesses()
        {
            lock (((System.Collections.ICollection)_managedProcesses).SyncRoot)
            {
                Dictionary<int, PerfProcess> processList = GetProcessList();
                Process[] plist1 = Process.GetProcesses();


                try
                {
                    List<int> ids = new List<int>();
                    foreach (KeyValuePair<int, PerfManagedProcess> kvp in _managedProcesses)
                    {
                        if (!processList.ContainsKey(kvp.Key))
                        {
                            ids.Add(kvp.Key);
                        }

                    }
                    foreach (int id in ids)
                    {
                        _managedProcesses.Remove(id);
                    }
                }
                catch (Exception ex)
                {
                    WriteLog(ex.ToString(), EventLogEntryType.Error);
                }
            }
        }

        private Dictionary<int, PerfProcess> GetProcessList()
        {
            Dictionary<int, PerfProcess> procList1 = new Dictionary<int, PerfProcess>();

            Process[] plist1 = Process.GetProcesses();
            foreach (Process p in plist1)
            {
                if (_policy.IncludeProcesses.Count > 0)
                {
                    if (p.Id == 0 || _policy.IgnoreProcesses.Contains(p.ProcessName.ToLower()) || !_policy.IncludeProcesses.Contains(p.ProcessName.ToLower()))
                        continue;
                }
                else
                {
                    if (p.Id == 0 || _policy.IgnoreProcesses.Contains(p.ProcessName.ToLower()))
                        continue;
                }

                try
                {
                    PerfProcess proc = new PerfProcess(p.Id, p.ProcessName, p.TotalProcessorTime.TotalMilliseconds, p.BasePriority);
                    procList1.Add(proc.Id, proc);
                }
                catch
                {
                    continue;
                }
            }
            return procList1;
        }

        private void WriteLog(string message)
        {
            if (_eventLog != null)
            {
                _eventLog.WriteEntry(message);
            }
        }
        private void WriteLog(string message, EventLogEntryType entryType)
        {
            if (_eventLog != null)
            {
                _eventLog.WriteEntry(message, entryType);
            }
        }



    }
}
