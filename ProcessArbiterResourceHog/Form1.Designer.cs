
namespace ProcessArbiterResourceHog
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
            this._nupSleepCycles = new System.Windows.Forms.NumericUpDown();
            this._btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._chkRunForever = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._nupSleep = new System.Windows.Forms.NumericUpDown();
            this._nupCycles = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._lblPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._nupSleepCycles)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nupSleep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nupCycles)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _nupSleepCycles
            // 
            this._nupSleepCycles.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._nupSleepCycles.Location = new System.Drawing.Point(178, 71);
            this._nupSleepCycles.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this._nupSleepCycles.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._nupSleepCycles.Name = "_nupSleepCycles";
            this._nupSleepCycles.Size = new System.Drawing.Size(57, 20);
            this._nupSleepCycles.TabIndex = 3;
            this._nupSleepCycles.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(227, 208);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 23);
            this._btnStart.TabIndex = 2;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._chkRunForever);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._nupSleepCycles);
            this.groupBox1.Controls.Add(this._nupSleep);
            this.groupBox1.Controls.Add(this._nupCycles);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(290, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cycles and Sleep Configuration";
            // 
            // _chkRunForever
            // 
            this._chkRunForever.AutoSize = true;
            this._chkRunForever.Location = new System.Drawing.Point(9, 22);
            this._chkRunForever.Name = "_chkRunForever";
            this._chkRunForever.Size = new System.Drawing.Size(213, 17);
            this._chkRunForever.TabIndex = 8;
            this._chkRunForever.Text = "Run forever, until I hit Start-Stop button.";
            this._chkRunForever.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "cycles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "every";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "ms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "sleep for";
            // 
            // _nupSleep
            // 
            this._nupSleep.Location = new System.Drawing.Point(60, 71);
            this._nupSleep.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this._nupSleep.Name = "_nupSleep";
            this._nupSleep.Size = new System.Drawing.Size(47, 20);
            this._nupSleep.TabIndex = 2;
            // 
            // _nupCycles
            // 
            this._nupCycles.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._nupCycles.Location = new System.Drawing.Point(60, 45);
            this._nupCycles.Maximum = new decimal(new int[] {
            -1539607552,
            11,
            0,
            0});
            this._nupCycles.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this._nupCycles.Name = "_nupCycles";
            this._nupCycles.Size = new System.Drawing.Size(175, 20);
            this._nupCycles.TabIndex = 1;
            this._nupCycles.Value = new decimal(new int[] {
            200000000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cycles";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "This is a tool, which cause high CPU utilization.";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 238);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(314, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _progressBar
            // 
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(310, 16);
            this._progressBar.Step = 1;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(16, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(286, 28);
            this.label7.TabIndex = 4;
            this.label7.Text = "By changing the number of cycles, you can control how long the CPU utilization wi" +
    "ll take.";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(16, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(286, 34);
            this.label8.TabIndex = 5;
            this.label8.Text = "By changing the \"sleep for X milliseconds every X cycles\" you can control how muc" +
    "h the CPU utilization will be.";
            // 
            // _lblPercent
            // 
            this._lblPercent.AutoSize = true;
            this._lblPercent.Location = new System.Drawing.Point(12, 213);
            this._lblPercent.Name = "_lblPercent";
            this._lblPercent.Size = new System.Drawing.Size(0, 13);
            this._lblPercent.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 260);
            this.Controls.Add(this._lblPercent);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ProcessArbiter Resource Hog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this._nupSleepCycles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nupSleep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nupCycles)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _nupSleep;
        private System.Windows.Forms.NumericUpDown _nupCycles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar _progressBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox _chkRunForever;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.NumericUpDown _nupSleepCycles;
        private System.Windows.Forms.Label _lblPercent;
    }
}

