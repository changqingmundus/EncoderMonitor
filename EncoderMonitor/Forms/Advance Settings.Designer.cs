namespace EncoderMonitor
{
    partial class Advance_Settings
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
            this.SetSlaveID = new System.Windows.Forms.NumericUpDown();
            this.SetFunctionCode = new System.Windows.Forms.ComboBox();
            this.SetAddress = new System.Windows.Forms.TextBox();
            this.SetRegisterCount = new System.Windows.Forms.NumericUpDown();
            this.SlaveID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ModBusRTUMode = new System.Windows.Forms.Label();
            this.LoadConfig = new System.Windows.Forms.Button();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SetSlaveID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetRegisterCount)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetSlaveID
            // 
            this.SetSlaveID.Location = new System.Drawing.Point(179, 234);
            this.SetSlaveID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetSlaveID.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.SetSlaveID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SetSlaveID.Name = "SetSlaveID";
            this.SetSlaveID.Size = new System.Drawing.Size(61, 30);
            this.SetSlaveID.TabIndex = 0;
            this.SetSlaveID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SetFunctionCode
            // 
            this.SetFunctionCode.FormattingEnabled = true;
            this.SetFunctionCode.Items.AddRange(new object[] {
            "01 Read Coil",
            "02 Read Discrete Input",
            "03 Read Holding Register",
            "04 Read Input Register",
            "06 Write Single Register",
            "16 Write Multiple Register"});
            this.SetFunctionCode.Location = new System.Drawing.Point(322, 236);
            this.SetFunctionCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetFunctionCode.Name = "SetFunctionCode";
            this.SetFunctionCode.Size = new System.Drawing.Size(100, 28);
            this.SetFunctionCode.TabIndex = 1;
            // 
            // SetAddress
            // 
            this.SetAddress.Location = new System.Drawing.Point(483, 234);
            this.SetAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetAddress.Name = "SetAddress";
            this.SetAddress.Size = new System.Drawing.Size(75, 30);
            this.SetAddress.TabIndex = 2;
            // 
            // SetRegisterCount
            // 
            this.SetRegisterCount.Location = new System.Drawing.Point(605, 234);
            this.SetRegisterCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetRegisterCount.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.SetRegisterCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SetRegisterCount.Name = "SetRegisterCount";
            this.SetRegisterCount.Size = new System.Drawing.Size(61, 30);
            this.SetRegisterCount.TabIndex = 3;
            this.SetRegisterCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // SlaveID
            // 
            this.SlaveID.AutoSize = true;
            this.SlaveID.Font = new System.Drawing.Font("楷体", 12F);
            this.SlaveID.Location = new System.Drawing.Point(176, 185);
            this.SlaveID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SlaveID.Name = "SlaveID";
            this.SlaveID.Size = new System.Drawing.Size(63, 16);
            this.SlaveID.TabIndex = 4;
            this.SlaveID.Text = "SlaveID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 12F);
            this.label2.Location = new System.Drawing.Point(319, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "FunctionCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 12F);
            this.label3.Location = new System.Drawing.Point(480, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 12F);
            this.label4.Location = new System.Drawing.Point(619, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Count";
            // 
            // ModBusRTUMode
            // 
            this.ModBusRTUMode.AutoSize = true;
            this.ModBusRTUMode.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ModBusRTUMode.Location = new System.Drawing.Point(354, 51);
            this.ModBusRTUMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModBusRTUMode.Name = "ModBusRTUMode";
            this.ModBusRTUMode.Size = new System.Drawing.Size(147, 27);
            this.ModBusRTUMode.TabIndex = 8;
            this.ModBusRTUMode.Text = "ModBusRTU";
            // 
            // LoadConfig
            // 
            this.LoadConfig.Location = new System.Drawing.Point(508, 713);
            this.LoadConfig.Name = "LoadConfig";
            this.LoadConfig.Size = new System.Drawing.Size(100, 80);
            this.LoadConfig.TabIndex = 9;
            this.LoadConfig.Text = "Laod";
            this.LoadConfig.UseVisualStyleBackColor = true;
            this.LoadConfig.Click += new System.EventHandler(this.LoadConfig_Click);
            // 
            // SaveConfig
            // 
            this.SaveConfig.Location = new System.Drawing.Point(688, 713);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(100, 80);
            this.SaveConfig.TabIndex = 10;
            this.SaveConfig.Text = "Save";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 658);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(910, 628);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tamagawa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.ModBusRTUMode);
            this.tabPage2.Controls.Add(this.SetSlaveID);
            this.tabPage2.Controls.Add(this.SetFunctionCode);
            this.tabPage2.Controls.Add(this.SetAddress);
            this.tabPage2.Controls.Add(this.SetRegisterCount);
            this.tabPage2.Controls.Add(this.SlaveID);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(910, 628);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ModbusRTU";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(910, 628);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CANopen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 180);
            this.label1.TabIndex = 9;
            this.label1.Text = "Description:(Default Config)\r\n\r\nSlaveID:01\r\n\r\nFunctionCode:0x03\r\n\r\nRegisterCount:" +
    "02\r\n\r\nStartAddress:0x00";
            // 
            // Advance_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 873);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.SaveConfig);
            this.Controls.Add(this.LoadConfig);
            this.Font = new System.Drawing.Font("楷体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Advance_Settings";
            this.Text = "Advance Settings";
            this.Load += new System.EventHandler(this.Advance_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SetSlaveID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetRegisterCount)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown SetSlaveID;
        private System.Windows.Forms.ComboBox SetFunctionCode;
        private System.Windows.Forms.TextBox SetAddress;
        private System.Windows.Forms.NumericUpDown SetRegisterCount;
        private System.Windows.Forms.Label SlaveID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ModBusRTUMode;
        private System.Windows.Forms.Button LoadConfig;
        private System.Windows.Forms.Button SaveConfig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
    }
}