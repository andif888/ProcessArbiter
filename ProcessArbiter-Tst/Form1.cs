using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using ProcessArbiter;
using System.IO;
using System.Reflection;


namespace ProcessArbiter_Tst
{
    public partial class Form1 : Form
    {
        private string _dumpFile;

        EventLog evtlog;
        private ProcessManagerEngine _engine = null;
        public Form1()
        {
            _dumpFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\dump.log";
            evtlog = new EventLog("Application");
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
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
                evtlog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_engine == null)
                {

                    _engine = new ProcessManagerEngine(evtlog);

                }

                if (_engine != null)
                {
                    _engine.StartEngine();
                    _engine.DumpEngine();
                }

            }
            catch (Exception ex)
            {
                evtlog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
            }
        }
    }
}
