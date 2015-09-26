

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Threading;
using System.IO;
using System.Reflection;


namespace ProcessArbiterStatusClient
{
    public partial class Form1 : Form
    {
        #region Licensing 
               
        
        private void EnableFullFeatues()
        {
            helpToolStripMenuItem.DropDownItems.Remove(enterLicenseToolStripMenuItem);
            helpToolStripMenuItem.DropDownItems.Remove(toolStripSeparator1);
            lblDemo.Visible = false;
        }

        

        #endregion

        private const string CPUResourceHogExeFileName = "ProcessArbiterResourceHog.exe";
        private System.Threading.Timer _checkServiceTimer;
        private System.Threading.Timer _dumpServiceTimer;
        
        public Form1()
        {
            InitializeComponent();
            EnableFullFeatues();
        }


        private string _serviceName = "ProcessArbiterService";

        private void btnManageService_Click(object sender, EventArgs e)
        {
            btnManageService.Enabled = false;
            try
            {
                ServiceController sc = new ServiceController(_serviceName);
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                }
                else if(sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _checkServiceTimer = new System.Threading.Timer(new TimerCallback(CheckService), null, 250, 1000);
            _dumpServiceTimer = new System.Threading.Timer(new TimerCallback(DumpService), null, 500, 1000);

        }

        private delegate void TimerDelegate(object stateInfo);
        private void CheckService(object stateInfo)
        {            
            try
            {
                ServiceController sc = new ServiceController(_serviceName);
                ServiceControllerStatus scStatus = sc.Status;

                if (InvokeRequired)
                    Invoke(new DisplayCheckServiceResultDelegate(DisplayCheckServiceResult),
                        new object[] { scStatus });
                else
                    DisplayCheckServiceResult(scStatus);

            }
            catch
            {
                if (InvokeRequired)
                    Invoke(new MethodInvoker(delegate() { btnManageService.Enabled = false; }));
                else
                    btnManageService.Enabled = false;
            }
            
        }
        
        private void DumpService(object stateInfo)
        {
            string text = string.Empty;
            try
            {
                ServiceController sc = new ServiceController(_serviceName);
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    sc.ExecuteCommand(128);
                    System.Threading.Thread.Sleep(500);

                    string assemblyPath = this.GetType().Assembly.Location;
                    string filePath = System.IO.Path.GetDirectoryName(assemblyPath) + "\\dump.log";
                    if (File.Exists(filePath))
                        text = File.ReadAllText(filePath);
                    else
                        text = "Server does not produce any output.\r\nThe following file is missting:\r\n" + filePath;


                }
                else if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    text = "Service is stopped.";

                }
                else
                {
                    text = "Service state: " + sc.Status.ToString();
                }
            }
            catch (Exception ex)
            {
                text = "Service error: " + ex.Message;
            }

            if (InvokeRequired)
                Invoke(new DisplayDumpServiceResultDelegate(DisplayDumpServiceResult),
                    new object[] { text });
            else
                DisplayDumpServiceResult(text);
            
        }

        private delegate void DisplayCheckServiceResultDelegate(ServiceControllerStatus scStatus);
        private void DisplayCheckServiceResult(ServiceControllerStatus scStatus)
        {
            if (scStatus == ServiceControllerStatus.Stopped)
            {
                pbSvcStateStopped.Visible = true;
                pbSvcStateRunning.Visible = false;
                btnManageService.Text = "Start Service";
                btnManageService.Enabled = true;
            }
            else if (scStatus == ServiceControllerStatus.Running)
            {
                pbSvcStateStopped.Visible = false;
                pbSvcStateRunning.Visible = true;
                btnManageService.Text = "Stop Service";
                btnManageService.Enabled = true;
            }
            else
            {
                pbSvcStateStopped.Visible = false;
                pbSvcStateRunning.Visible = false;
                btnManageService.Text = "Stop Service";
                btnManageService.Enabled = false;
            }
            pbSvcStateRunning.Refresh();
            pbSvcStateStopped.Refresh();
            btnManageService.Refresh();
        }

        private delegate void DisplayDumpServiceResultDelegate(string text);
        private void DisplayDumpServiceResult(string text)
        {
            rtxStatus.Text = text;
            rtxStatus.Refresh();            
        }

        private void ShowHelpContents()
        {
            try
            {
                string helpfile = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "ProcessArbiterHelp.chm";
                System.Diagnostics.Process.Start(helpfile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dumpServiceTimer.Dispose();
            _checkServiceTimer.Dispose();            
        }

        private void runCPUResourceHogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toolPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + 
                Path.DirectorySeparatorChar + CPUResourceHogExeFileName;
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(toolPath);
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error running CPU Resource Hog", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void helpContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHelpContents();
        }

        
    }
}
