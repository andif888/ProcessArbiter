
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ProcessArbiterResourceHog
{

    public partial class Form1 : Form
    {
        Thread _hog = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            if (_btnStart.Text == "Start")
            {
                StartHog();
            }
            else
            {
                StopHog();
            }
        }

        bool _stop = false;
        private void StartHog()
        {
            _progressBar.Value = 0;
            _btnStart.Text = "Stop";
            _btnStart.Refresh();
            _stop = false;
            _nupCycles.Enabled = false;

            _hog = new Thread(new ThreadStart(RunNow));
            _hog.Name = "CPU Resource Hog Thread";
            _hog.Start();

        }
        private void StopHog()
        {
            _stop = true;

        }

        private void RunNow()
        {
            try
            {
                long maxCount = System.Convert.ToInt64(_nupCycles.Value);
                UpdateProgressDelegate updateDeleg = new UpdateProgressDelegate(UpdateProgress);
                ResetFormDelegate resetDeleg = new ResetFormDelegate(ResetForm);

                bool runForEver = _chkRunForever.Checked;
                int sleepCount = 0;
                int sleepAfter = System.Convert.ToInt32(_nupSleepCycles.Value);
                int sleepTime = System.Convert.ToInt32(_nupSleep.Value);

                long uiUpdate = System.Convert.ToInt64( Math.Round((System.Convert.ToDouble(maxCount) / 100) * 2,0));
                long uiUpdateCount = 0;

                do
                {
                    for (long i = 0; i < maxCount; i++)
                    {
                        uiUpdateCount++;

                        runForEver = _chkRunForever.Checked;
                        sleepAfter = System.Convert.ToInt32(_nupSleepCycles.Value);
                        sleepTime = System.Convert.ToInt32(_nupSleep.Value);

                        if (_stop)
                        {
                            runForEver = false;
                            break;
                        }

                        if (uiUpdateCount >= uiUpdate)
                        {
                            Invoke(updateDeleg, new object[] { i, maxCount });
                            uiUpdateCount = 0;
                        }
                        //UpdateProgress(i, maxCount);

                        if (sleepTime > 0)
                        {
                            sleepCount++;
                            if (sleepCount >= sleepAfter)
                            {
                                Thread.Sleep(sleepTime);
                                sleepCount = 0;
                            }
                        }
                    }
                }
                while (runForEver);
                Invoke(updateDeleg, new object[] { maxCount, maxCount });
                Invoke(resetDeleg, null);
                    //ResetForm();
                
            }
            catch { }
        }

        private delegate void UpdateProgressDelegate(long curCount, long maxCount);
        private void UpdateProgress(long curCount, long maxCount)
        {
            decimal d = (100 * curCount) / maxCount;
            d = Math.Round(d, 0);
            int percent = System.Convert.ToInt32(d);

            _progressBar.Value = percent;
            _lblPercent.Text = percent.ToString() + "%  (" + curCount.ToString() + "/" + maxCount.ToString() + ")";
            _lblPercent.Refresh();
        }

        private delegate void ResetFormDelegate();
        private void ResetForm()
        {
            try
            {
                if (_hog != null)
                {
                    if (_hog.ThreadState == ThreadState.Running)
                    {
                        _hog.Abort();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                _hog = null;
            }

            _btnStart.Text = "Start";
            _progressBar.Value = 0;
            _lblPercent.Text = "";
            _nupCycles.Enabled = true;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_hog != null)
                {
                    if (_hog.ThreadState == ThreadState.Running)
                    {
                        _hog.Abort();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                _hog = null;
            }
        }
     
    }
}
