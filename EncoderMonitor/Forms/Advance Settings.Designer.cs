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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Advance_Settings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabTamagawa = new System.Windows.Forms.TabPage();
            this.TabModBusRTU = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabRegisterMap = new System.Windows.Forms.TabPage();
            this.dgvRegisterMap = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabCANopen = new System.Windows.Forms.TabPage();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.rdoHex = new System.Windows.Forms.RadioButton();
            this.rdoDec = new System.Windows.Forms.RadioButton();
            this.numSlaveID = new System.Windows.Forms.NumericUpDown();
            this.cmbFunctionCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelRead = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.panelWriteSingle = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelWriteMultiple = new System.Windows.Forms.Panel();
            this.tabCommandConfig = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvWrite10Registers = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.TabModBusRTU.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabRegisterMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlaveID)).BeginInit();
            this.panelRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panelWriteSingle.SuspendLayout();
            this.panelWriteMultiple.SuspendLayout();
            this.tabCommandConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWrite10Registers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabTamagawa);
            this.tabControl1.Controls.Add(this.TabModBusRTU);
            this.tabControl1.Controls.Add(this.TabCANopen);
            this.tabControl1.Font = new System.Drawing.Font("楷体", 15F);
            this.tabControl1.Location = new System.Drawing.Point(12, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(928, 639);
            this.tabControl1.TabIndex = 14;
            // 
            // TabTamagawa
            // 
            this.TabTamagawa.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabTamagawa.Location = new System.Drawing.Point(4, 30);
            this.TabTamagawa.Name = "TabTamagawa";
            this.TabTamagawa.Padding = new System.Windows.Forms.Padding(3);
            this.TabTamagawa.Size = new System.Drawing.Size(920, 605);
            this.TabTamagawa.TabIndex = 0;
            this.TabTamagawa.Text = "Tamagawa";
            this.TabTamagawa.UseVisualStyleBackColor = true;
            // 
            // TabModBusRTU
            // 
            this.TabModBusRTU.Controls.Add(this.tabControl2);
            this.TabModBusRTU.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.TabModBusRTU.Location = new System.Drawing.Point(4, 30);
            this.TabModBusRTU.Name = "TabModBusRTU";
            this.TabModBusRTU.Padding = new System.Windows.Forms.Padding(3);
            this.TabModBusRTU.Size = new System.Drawing.Size(920, 605);
            this.TabModBusRTU.TabIndex = 1;
            this.TabModBusRTU.Text = "ModbusRTU";
            this.TabModBusRTU.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabCommandConfig);
            this.tabControl2.Controls.Add(this.tabRegisterMap);
            this.tabControl2.Font = new System.Drawing.Font("楷体", 12F);
            this.tabControl2.Location = new System.Drawing.Point(6, 23);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(908, 568);
            this.tabControl2.TabIndex = 0;
            // 
            // tabRegisterMap
            // 
            this.tabRegisterMap.Controls.Add(this.dgvRegisterMap);
            this.tabRegisterMap.Font = new System.Drawing.Font("楷体", 15F);
            this.tabRegisterMap.Location = new System.Drawing.Point(4, 26);
            this.tabRegisterMap.Name = "tabRegisterMap";
            this.tabRegisterMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegisterMap.Size = new System.Drawing.Size(900, 538);
            this.tabRegisterMap.TabIndex = 1;
            this.tabRegisterMap.Text = "Register Map";
            this.tabRegisterMap.UseVisualStyleBackColor = true;
            // 
            // dgvRegisterMap
            // 
            this.dgvRegisterMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisterMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colAddress});
            this.dgvRegisterMap.Location = new System.Drawing.Point(16, 6);
            this.dgvRegisterMap.Name = "dgvRegisterMap";
            this.dgvRegisterMap.RowHeadersWidth = 51;
            this.dgvRegisterMap.RowTemplate.Height = 24;
            this.dgvRegisterMap.Size = new System.Drawing.Size(494, 522);
            this.dgvRegisterMap.TabIndex = 0;
            this.dgvRegisterMap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegisterMap_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 125;
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Address";
            this.colAddress.MinimumWidth = 6;
            this.colAddress.Name = "colAddress";
            this.colAddress.Width = 125;
            // 
            // TabCANopen
            // 
            this.TabCANopen.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.TabCANopen.Location = new System.Drawing.Point(4, 30);
            this.TabCANopen.Name = "TabCANopen";
            this.TabCANopen.Padding = new System.Windows.Forms.Padding(3);
            this.TabCANopen.Size = new System.Drawing.Size(920, 605);
            this.TabCANopen.TabIndex = 2;
            this.TabCANopen.Text = "CANopen";
            this.TabCANopen.UseVisualStyleBackColor = true;
            // 
            // SaveConfig
            // 
            this.SaveConfig.Location = new System.Drawing.Point(768, 493);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(100, 39);
            this.SaveConfig.TabIndex = 10;
            this.SaveConfig.Text = "Send";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // rdoHex
            // 
            this.rdoHex.AutoSize = true;
            this.rdoHex.Font = new System.Drawing.Font("楷体", 10F);
            this.rdoHex.Location = new System.Drawing.Point(690, 87);
            this.rdoHex.Name = "rdoHex";
            this.rdoHex.Size = new System.Drawing.Size(46, 18);
            this.rdoHex.TabIndex = 11;
            this.rdoHex.TabStop = true;
            this.rdoHex.Text = "Hex";
            this.rdoHex.UseVisualStyleBackColor = true;
            this.rdoHex.CheckedChanged += new System.EventHandler(this.rdoHex_CheckedChanged);
            // 
            // rdoDec
            // 
            this.rdoDec.AutoSize = true;
            this.rdoDec.Font = new System.Drawing.Font("楷体", 10F);
            this.rdoDec.Location = new System.Drawing.Point(794, 87);
            this.rdoDec.Name = "rdoDec";
            this.rdoDec.Size = new System.Drawing.Size(74, 18);
            this.rdoDec.TabIndex = 12;
            this.rdoDec.TabStop = true;
            this.rdoDec.Text = "Decimal";
            this.rdoDec.UseVisualStyleBackColor = true;
            this.rdoDec.CheckedChanged += new System.EventHandler(this.rdoDec_CheckedChanged);
            // 
            // numSlaveID
            // 
            this.numSlaveID.Font = new System.Drawing.Font("楷体", 15F);
            this.numSlaveID.Location = new System.Drawing.Point(167, 15);
            this.numSlaveID.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.numSlaveID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSlaveID.Name = "numSlaveID";
            this.numSlaveID.Size = new System.Drawing.Size(100, 30);
            this.numSlaveID.TabIndex = 13;
            this.numSlaveID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbFunctionCode
            // 
            this.cmbFunctionCode.Font = new System.Drawing.Font("楷体", 15F);
            this.cmbFunctionCode.FormattingEnabled = true;
            this.cmbFunctionCode.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "0F",
            "10"});
            this.cmbFunctionCode.Location = new System.Drawing.Point(451, 19);
            this.cmbFunctionCode.Name = "cmbFunctionCode";
            this.cmbFunctionCode.Size = new System.Drawing.Size(431, 28);
            this.cmbFunctionCode.TabIndex = 14;
            this.cmbFunctionCode.SelectedIndexChanged += new System.EventHandler(this.cmbFunctionCode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 13F);
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "SlaveID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 13F);
            this.label2.Location = new System.Drawing.Point(301, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "FounctionCode";
            // 
            // panelRead
            // 
            this.panelRead.Controls.Add(this.numQuantity);
            this.panelRead.Controls.Add(this.label5);
            this.panelRead.Controls.Add(this.txtStartAddress);
            this.panelRead.Controls.Add(this.label4);
            this.panelRead.Controls.Add(this.label3);
            this.panelRead.Location = new System.Drawing.Point(20, 150);
            this.panelRead.Name = "panelRead";
            this.panelRead.Size = new System.Drawing.Size(292, 120);
            this.panelRead.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 13F);
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "StartAddress";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 13F);
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Quantity";
            // 
            // txtStartAddress
            // 
            this.txtStartAddress.Font = new System.Drawing.Font("楷体", 15F);
            this.txtStartAddress.Location = new System.Drawing.Point(147, 17);
            this.txtStartAddress.Name = "txtStartAddress";
            this.txtStartAddress.Size = new System.Drawing.Size(100, 30);
            this.txtStartAddress.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 14);
            this.label5.TabIndex = 1;
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("楷体", 15F);
            this.numQuantity.Location = new System.Drawing.Point(147, 76);
            this.numQuantity.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(100, 30);
            this.numQuantity.TabIndex = 20;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panelWriteSingle
            // 
            this.panelWriteSingle.Controls.Add(this.label7);
            this.panelWriteSingle.Controls.Add(this.textBox4);
            this.panelWriteSingle.Controls.Add(this.textBox3);
            this.panelWriteSingle.Controls.Add(this.label6);
            this.panelWriteSingle.Location = new System.Drawing.Point(20, 292);
            this.panelWriteSingle.Name = "panelWriteSingle";
            this.panelWriteSingle.Size = new System.Drawing.Size(292, 100);
            this.panelWriteSingle.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 13F);
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "StartAddress";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("楷体", 15F);
            this.textBox3.Location = new System.Drawing.Point(147, 10);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 30);
            this.textBox3.TabIndex = 20;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("楷体", 15F);
            this.textBox4.Location = new System.Drawing.Point(147, 58);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 30);
            this.textBox4.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 13F);
            this.label7.Location = new System.Drawing.Point(6, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Value";
            // 
            // panelWriteMultiple
            // 
            this.panelWriteMultiple.Controls.Add(this.dgvWrite10Registers);
            this.panelWriteMultiple.Controls.Add(this.numericUpDown1);
            this.panelWriteMultiple.Controls.Add(this.label9);
            this.panelWriteMultiple.Controls.Add(this.textBox1);
            this.panelWriteMultiple.Controls.Add(this.label8);
            this.panelWriteMultiple.Controls.Add(this.button1);
            this.panelWriteMultiple.Location = new System.Drawing.Point(373, 150);
            this.panelWriteMultiple.Name = "panelWriteMultiple";
            this.panelWriteMultiple.Size = new System.Drawing.Size(495, 337);
            this.panelWriteMultiple.TabIndex = 23;
            // 
            // tabCommandConfig
            // 
            this.tabCommandConfig.Controls.Add(this.panelWriteMultiple);
            this.tabCommandConfig.Controls.Add(this.panelWriteSingle);
            this.tabCommandConfig.Controls.Add(this.panelRead);
            this.tabCommandConfig.Controls.Add(this.label2);
            this.tabCommandConfig.Controls.Add(this.label1);
            this.tabCommandConfig.Controls.Add(this.cmbFunctionCode);
            this.tabCommandConfig.Controls.Add(this.numSlaveID);
            this.tabCommandConfig.Controls.Add(this.rdoDec);
            this.tabCommandConfig.Controls.Add(this.rdoHex);
            this.tabCommandConfig.Controls.Add(this.SaveConfig);
            this.tabCommandConfig.Font = new System.Drawing.Font("楷体", 10F);
            this.tabCommandConfig.Location = new System.Drawing.Point(4, 26);
            this.tabCommandConfig.Name = "tabCommandConfig";
            this.tabCommandConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommandConfig.Size = new System.Drawing.Size(900, 538);
            this.tabCommandConfig.TabIndex = 0;
            this.tabCommandConfig.Text = "Command Config";
            this.tabCommandConfig.UseVisualStyleBackColor = true;
            this.tabCommandConfig.Click += new System.EventHandler(this.tabCommandConfig_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 12F);
            this.button1.Location = new System.Drawing.Point(317, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Register";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("楷体", 15F);
            this.textBox1.Location = new System.Drawing.Point(161, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 30);
            this.textBox1.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("楷体", 13F);
            this.label8.Location = new System.Drawing.Point(20, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "StartAddress";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("楷体", 15F);
            this.numericUpDown1.Location = new System.Drawing.Point(161, 53);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 30);
            this.numericUpDown1.TabIndex = 22;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("楷体", 13F);
            this.label9.Location = new System.Drawing.Point(20, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "Quantity";
            // 
            // dgvWrite10Registers
            // 
            this.dgvWrite10Registers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWrite10Registers.Location = new System.Drawing.Point(3, 89);
            this.dgvWrite10Registers.Name = "dgvWrite10Registers";
            this.dgvWrite10Registers.RowTemplate.Height = 23;
            this.dgvWrite10Registers.Size = new System.Drawing.Size(489, 245);
            this.dgvWrite10Registers.TabIndex = 24;
            // 
            // Advance_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 645);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("楷体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Advance_Settings";
            this.Text = "Advanced Settings";
            this.Load += new System.EventHandler(this.Advance_Settings_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabModBusRTU.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabRegisterMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlaveID)).EndInit();
            this.panelRead.ResumeLayout(false);
            this.panelRead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panelWriteSingle.ResumeLayout(false);
            this.panelWriteSingle.PerformLayout();
            this.panelWriteMultiple.ResumeLayout(false);
            this.panelWriteMultiple.PerformLayout();
            this.tabCommandConfig.ResumeLayout(false);
            this.tabCommandConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWrite10Registers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabTamagawa;
        private System.Windows.Forms.TabPage TabModBusRTU;
        private System.Windows.Forms.TabPage TabCANopen;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabRegisterMap;
        private System.Windows.Forms.DataGridView dgvRegisterMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.TabPage tabCommandConfig;
        private System.Windows.Forms.Panel panelWriteMultiple;
        private System.Windows.Forms.Panel panelWriteSingle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelRead;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFunctionCode;
        private System.Windows.Forms.NumericUpDown numSlaveID;
        private System.Windows.Forms.RadioButton rdoDec;
        private System.Windows.Forms.RadioButton rdoHex;
        private System.Windows.Forms.Button SaveConfig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvWrite10Registers;
    }
}