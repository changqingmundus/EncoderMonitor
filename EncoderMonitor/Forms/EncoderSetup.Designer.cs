namespace EncoderMonitor
{
    partial class EncoderSetup
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
            this.statusLabel_Status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Factory_Parity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Factory_SlaveID = new System.Windows.Forms.NumericUpDown();
            this.Factory_CRC = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Factory_BaudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Factory_ST = new System.Windows.Forms.ComboBox();
            this.Factory_MT = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusLabel_Status.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Factory_SlaveID)).BeginInit();
            this.SuspendLayout();
            // 
            // statusLabel_Status
            // 
            this.statusLabel_Status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusLabel_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusLabel_Status.Location = new System.Drawing.Point(0, 358);
            this.statusLabel_Status.Name = "statusLabel_Status";
            this.statusLabel_Status.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusLabel_Status.Size = new System.Drawing.Size(342, 22);
            this.statusLabel_Status.TabIndex = 0;
            this.statusLabel_Status.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel1.Text = "Status: Ready";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(342, 302);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(334, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tamagawa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(62, -25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Factory Config Label !!!";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Factory_Parity);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.Factory_SlaveID);
            this.tabPage2.Controls.Add(this.Factory_CRC);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.Factory_BaudRate);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.Factory_ST);
            this.tabPage2.Controls.Add(this.Factory_MT);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(334, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ModBusRTU";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // Factory_Parity
            // 
            this.Factory_Parity.FormattingEnabled = true;
            this.Factory_Parity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.Factory_Parity.Location = new System.Drawing.Point(217, 55);
            this.Factory_Parity.Name = "Factory_Parity";
            this.Factory_Parity.Size = new System.Drawing.Size(96, 26);
            this.Factory_Parity.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label7.Location = new System.Drawing.Point(228, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "Parity";
            // 
            // Factory_SlaveID
            // 
            this.Factory_SlaveID.Location = new System.Drawing.Point(17, 57);
            this.Factory_SlaveID.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.Factory_SlaveID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Factory_SlaveID.Name = "Factory_SlaveID";
            this.Factory_SlaveID.Size = new System.Drawing.Size(66, 24);
            this.Factory_SlaveID.TabIndex = 28;
            this.Factory_SlaveID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Factory_CRC
            // 
            this.Factory_CRC.FormattingEnabled = true;
            this.Factory_CRC.Items.AddRange(new object[] {
            "6",
            "16"});
            this.Factory_CRC.Location = new System.Drawing.Point(17, 219);
            this.Factory_CRC.Name = "Factory_CRC";
            this.Factory_CRC.Size = new System.Drawing.Size(121, 26);
            this.Factory_CRC.TabIndex = 27;
            this.Factory_CRC.Text = "Default： 6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(25, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "CRC SUM";
            // 
            // Factory_BaudRate
            // 
            this.Factory_BaudRate.FormattingEnabled = true;
            this.Factory_BaudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.Factory_BaudRate.Location = new System.Drawing.Point(111, 55);
            this.Factory_BaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.Factory_BaudRate.Name = "Factory_BaudRate";
            this.Factory_BaudRate.Size = new System.Drawing.Size(93, 26);
            this.Factory_BaudRate.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(107, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "BaudRate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "SlaveID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Single Turn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Multi Turn";
            // 
            // Factory_ST
            // 
            this.Factory_ST.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Factory_ST.FormattingEnabled = true;
            this.Factory_ST.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.Factory_ST.Location = new System.Drawing.Point(195, 139);
            this.Factory_ST.Margin = new System.Windows.Forms.Padding(2);
            this.Factory_ST.Name = "Factory_ST";
            this.Factory_ST.Size = new System.Drawing.Size(120, 33);
            this.Factory_ST.TabIndex = 19;
            // 
            // Factory_MT
            // 
            this.Factory_MT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Factory_MT.FormattingEnabled = true;
            this.Factory_MT.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.Factory_MT.Location = new System.Drawing.Point(17, 139);
            this.Factory_MT.Margin = new System.Windows.Forms.Padding(2);
            this.Factory_MT.Name = "Factory_MT";
            this.Factory_MT.Size = new System.Drawing.Size(120, 33);
            this.Factory_MT.TabIndex = 18;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(334, 271);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CANopen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button2.Location = new System.Drawing.Point(223, 302);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 41);
            this.button2.TabIndex = 15;
            this.button2.Text = "Write";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnFactoryWrite_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Location = new System.Drawing.Point(116, 302);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 41);
            this.button1.TabIndex = 14;
            this.button1.Text = "Read";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EncoderSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 380);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusLabel_Status);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EncoderSetup";
            this.Text = "EncoderSetup";
            this.statusLabel_Status.ResumeLayout(false);
            this.statusLabel_Status.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Factory_SlaveID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusLabel_Status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Factory_ST;
        private System.Windows.Forms.ComboBox Factory_MT;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Factory_BaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Factory_CRC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Factory_SlaveID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Factory_Parity;
    }
}