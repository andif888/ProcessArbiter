

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProcessArbiterStatusClient
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.Text = " " + this.Owner.Text;
            this.Icon = this.Owner.Icon;
            this.pbIcon.Image = this.Owner.Icon.ToBitmap();
            llbWeb.LinkArea = new LinkArea(0, llbWeb.Text.Length);
            this.lblVersion.Text = Application.ProductVersion;
		
        }

        private void llbWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(this.llbWeb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
