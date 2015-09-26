

namespace ProcessArbiterStatusClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.lblDemo = new System.Windows.Forms.Label();
            this.pbSvcStateStopped = new System.Windows.Forms.PictureBox();
            this.rtxStatus = new System.Windows.Forms.RichTextBox();
            this.btnManageService = new System.Windows.Forms.Button();
            this.pbSvcStateRunning = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.runCPUResourceHogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.enterLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSvcStateStopped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSvcStateRunning)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblDemo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pbSvcStateStopped);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.rtxStatus);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnManageService);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pbSvcStateRunning);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(734, 458);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(734, 482);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // lblDemo
            // 
            this.lblDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDemo.AutoSize = true;
            this.lblDemo.Location = new System.Drawing.Point(205, 428);
            this.lblDemo.Name = "lblDemo";
            this.lblDemo.Size = new System.Drawing.Size(35, 13);
            this.lblDemo.TabIndex = 4;
            this.lblDemo.Text = "label1";
            // 
            // pbSvcStateStopped
            // 
            this.pbSvcStateStopped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbSvcStateStopped.Image = ((System.Drawing.Image)(resources.GetObject("pbSvcStateStopped.Image")));
            this.pbSvcStateStopped.Location = new System.Drawing.Point(12, 413);
            this.pbSvcStateStopped.Name = "pbSvcStateStopped";
            this.pbSvcStateStopped.Size = new System.Drawing.Size(33, 33);
            this.pbSvcStateStopped.TabIndex = 3;
            this.pbSvcStateStopped.TabStop = false;
            // 
            // rtxStatus
            // 
            this.rtxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxStatus.BackColor = System.Drawing.Color.Black;
            this.rtxStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxStatus.ForeColor = System.Drawing.Color.Cyan;
            this.rtxStatus.Location = new System.Drawing.Point(4, 4);
            this.rtxStatus.Name = "rtxStatus";
            this.rtxStatus.ReadOnly = true;
            this.rtxStatus.Size = new System.Drawing.Size(727, 403);
            this.rtxStatus.TabIndex = 2;
            this.rtxStatus.Text = "";
            // 
            // btnManageService
            // 
            this.btnManageService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnManageService.Location = new System.Drawing.Point(51, 423);
            this.btnManageService.Name = "btnManageService";
            this.btnManageService.Size = new System.Drawing.Size(148, 23);
            this.btnManageService.TabIndex = 1;
            this.btnManageService.Text = "Start Service";
            this.btnManageService.UseVisualStyleBackColor = true;
            this.btnManageService.Click += new System.EventHandler(this.btnManageService_Click);
            // 
            // pbSvcStateRunning
            // 
            this.pbSvcStateRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbSvcStateRunning.Image = ((System.Drawing.Image)(resources.GetObject("pbSvcStateRunning.Image")));
            this.pbSvcStateRunning.Location = new System.Drawing.Point(12, 413);
            this.pbSvcStateRunning.Name = "pbSvcStateRunning";
            this.pbSvcStateRunning.Size = new System.Drawing.Size(33, 33);
            this.pbSvcStateRunning.TabIndex = 0;
            this.pbSvcStateRunning.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runCPUResourceHogToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem1.Text = "&Action";
            // 
            // runCPUResourceHogToolStripMenuItem
            // 
            this.runCPUResourceHogToolStripMenuItem.Name = "runCPUResourceHogToolStripMenuItem";
            this.runCPUResourceHogToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.runCPUResourceHogToolStripMenuItem.Text = "Run new instance of CPU Resource &Hog";
            this.runCPUResourceHogToolStripMenuItem.Click += new System.EventHandler(this.runCPUResourceHogToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpContentsToolStripMenuItem,
            this.toolStripSeparator2,
            this.enterLicenseToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpContentsToolStripMenuItem
            // 
            this.helpContentsToolStripMenuItem.Name = "helpContentsToolStripMenuItem";
            this.helpContentsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.helpContentsToolStripMenuItem.Text = "&Contents";
            this.helpContentsToolStripMenuItem.Click += new System.EventHandler(this.helpContentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // enterLicenseToolStripMenuItem
            // 
            this.enterLicenseToolStripMenuItem.Name = "enterLicenseToolStripMenuItem";
            this.enterLicenseToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.enterLicenseToolStripMenuItem.Text = "Enter &License Code";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 482);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ProcessArbiter Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSvcStateStopped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSvcStateRunning)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtxStatus;
        private System.Windows.Forms.Button btnManageService;
        private System.Windows.Forms.PictureBox pbSvcStateRunning;
        private System.Windows.Forms.PictureBox pbSvcStateStopped;
        private System.Windows.Forms.Label lblDemo;
        private System.Windows.Forms.ToolStripMenuItem enterLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runCPUResourceHogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpContentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

