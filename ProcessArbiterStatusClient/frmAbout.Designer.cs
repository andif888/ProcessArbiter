/* 
 * $URL: http://svn.dev.s-inn.de/svn/repos001/projects/fs.processpriorityobserver/trunk/ProcessPriorityObserverStatusClient/frmAbout.Designer.cs $
 * $Author: andi $
 * $Date: 2009-06-12 00:02:31 +0200 (Fr, 12 Jun 2009) $
 * $Rev: 231 $
 * $Id: frmAbout.Designer.cs 231 2009-06-11 22:02:31Z andi $
 */

namespace ProcessArbiterStatusClient
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llbWeb = new System.Windows.Forms.LinkLabel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.llbWeb);
            this.groupBox1.Controls.Add(this.pbIcon);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblVersion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(492, 196);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // llbWeb
            // 
            this.llbWeb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llbWeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llbWeb.LinkArea = new System.Windows.Forms.LinkArea(0, 35);
            this.llbWeb.Location = new System.Drawing.Point(149, 69);
            this.llbWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbWeb.Name = "llbWeb";
            this.llbWeb.Size = new System.Drawing.Size(335, 28);
            this.llbWeb.TabIndex = 33;
            this.llbWeb.TabStop = true;
            this.llbWeb.Text = "https://github.com/andif888/processarbiter";
            this.llbWeb.UseCompatibleTextRendering = true;
            this.llbWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbWeb_LinkClicked);
            // 
            // pbIcon
            // 
            this.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbIcon.Location = new System.Drawing.Point(21, 39);
            this.pbIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(41, 38);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcon.TabIndex = 23;
            this.pbIcon.TabStop = false;
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(85, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 28);
            this.label3.TabIndex = 28;
            this.label3.Text = "Web:";
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(85, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 28);
            this.label1.TabIndex = 26;
            this.label1.Text = "Version:";
            // 
            // lblVersion
            // 
            this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVersion.Location = new System.Drawing.Point(149, 39);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(335, 28);
            this.lblVersion.TabIndex = 24;
            this.lblVersion.Text = "Application Version";
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(21, 148);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(463, 28);
            this.label5.TabIndex = 32;
            this.label5.Text = "Copyright 2011 Andreas Fleischmann. All rights reserved.";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdOK.Location = new System.Drawing.Point(409, 223);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 28);
            this.cmdOK.TabIndex = 35;
            this.cmdOK.Text = "&OK";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 266);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAbout";
            this.Text = "frmAbout";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel llbWeb;
        internal System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button cmdOK;
    }
}