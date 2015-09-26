

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;
using System.Reflection;
using ProcessArbiter;

namespace ProcessArbiterService
{
    public partial class Service1 : ServiceBase
    {
        private string _dumpFile;
       

        private ProcessManagerEngine _engine = null;

        public Service1()
        {
            _dumpFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\dump.log";

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                if (_engine == null)
                {
                    
                        _engine = new ProcessManagerEngine(this.EventLog);
                   
                }

                if (_engine != null)
                {
                    _engine.StartEngine();
                    _engine.DumpEngine();
                }
                
            }
            catch(Exception ex)
            {
                this.EventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            try
            {
                if (_engine != null)
                {
                    _engine.StopEngine();
                }
            }
            catch (Exception ex)
            {
                this.EventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
            }
        }
        protected override void OnCustomCommand(int command)
        {
            try
            {
                switch (command)
                {
                    case 128:
                        if (_engine != null)
                        {
                            File.WriteAllText(_dumpFile, _engine.DumpEngine());
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                this.EventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
            }
        }

        
    }
}
