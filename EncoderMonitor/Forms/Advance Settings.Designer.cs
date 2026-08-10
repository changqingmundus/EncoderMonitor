using System.Drawing;

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
            this.tabCommandConfig = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Copy = new System.Windows.Forms.Button();
            this.txtGeneratedCommand = new System.Windows.Forms.TextBox();
            this.panelWriteSingle = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.t_bvalue06 = new System.Windows.Forms.TextBox();
            this.txtStartAddress06 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelRead = new System.Windows.Forms.Panel();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartAddress03 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelWriteMultiple = new System.Windows.Forms.Panel();
            this.txtStartAddress10 = new System.Windows.Forms.TextBox();
            this.txtWrite10Quantity = new System.Windows.Forms.TextBox();
            this.Button_DelRegister = new System.Windows.Forms.Button();
            this.dgvWrite10Registers = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Button_AddRegister = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFunctionCode = new System.Windows.Forms.ComboBox();
            this.numSlaveID = new System.Windows.Forms.NumericUpDown();
            this.rdoDec = new System.Windows.Forms.RadioButton();
            this.rdoHex = new System.Windows.Forms.RadioButton();
            this.SendConfig = new System.Windows.Forms.Button();
            this.tabRegisterMap = new System.Windows.Forms.TabPage();
            this.dgvRegisterMap = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabCANopen = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.TabModBusRTU.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabCommandConfig.SuspendLayout();
            this.panelWriteSingle.SuspendLayout();
            this.panelRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panelWriteMultiple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWrite10Registers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlaveID)).BeginInit();
            this.tabRegisterMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterMap)).BeginInit();
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
            // tabCommandConfig
            // 
            this.tabCommandConfig.Controls.Add(this.label10);
            this.tabCommandConfig.Controls.Add(this.button_Copy);
            this.tabCommandConfig.Controls.Add(this.txtGeneratedCommand);
            this.tabCommandConfig.Controls.Add(this.panelWriteSingle);
            this.tabCommandConfig.Controls.Add(this.panelRead);
            this.tabCommandConfig.Controls.Add(this.panelWriteMultiple);
            this.tabCommandConfig.Controls.Add(this.label2);
            this.tabCommandConfig.Controls.Add(this.label1);
            this.tabCommandConfig.Controls.Add(this.cmbFunctionCode);
            this.tabCommandConfig.Controls.Add(this.numSlaveID);
            this.tabCommandConfig.Controls.Add(this.rdoDec);
            this.tabCommandConfig.Controls.Add(this.rdoHex);
            this.tabCommandConfig.Controls.Add(this.SendConfig);
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
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(687, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 375);
            this.label10.TabIndex = 26;
            this.label10.Text = "Please select the Register Map to view the currently used registers.\r\n\r\n\r\n\r\nTX an" +
    "d RX data will be displayed in the Main window.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_Copy
            // 
            this.button_Copy.Location = new System.Drawing.Point(671, 503);
            this.button_Copy.Name = "button_Copy";
            this.button_Copy.Size = new System.Drawing.Size(65, 23);
            this.button_Copy.TabIndex = 25;
            this.button_Copy.Text = "Copy";
            this.button_Copy.UseVisualStyleBackColor = true;
            this.button_Copy.Click += new System.EventHandler(this.button_Copy_Click);
            // 
            // txtGeneratedCommand
            // 
            this.txtGeneratedCommand.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtGeneratedCommand.Location = new System.Drawing.Point(9, 503);
            this.txtGeneratedCommand.Name = "txtGeneratedCommand";
            this.txtGeneratedCommand.ReadOnly = true;
            this.txtGeneratedCommand.Size = new System.Drawing.Size(656, 23);
            this.txtGeneratedCommand.TabIndex = 24;
            // 
            // panelWriteSingle
            // 
            this.panelWriteSingle.Controls.Add(this.label7);
            this.panelWriteSingle.Controls.Add(this.t_bvalue06);
            this.panelWriteSingle.Controls.Add(this.txtStartAddress06);
            this.panelWriteSingle.Controls.Add(this.label6);
            this.panelWriteSingle.Location = new System.Drawing.Point(6, 114);
            this.panelWriteSingle.Name = "panelWriteSingle";
            this.panelWriteSingle.Size = new System.Drawing.Size(659, 375);
            this.panelWriteSingle.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 13F);
            this.label7.Location = new System.Drawing.Point(363, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Value";
            // 
            // t_bvalue06
            // 
            this.t_bvalue06.Font = new System.Drawing.Font("楷体", 15F);
            this.t_bvalue06.Location = new System.Drawing.Point(341, 154);
            this.t_bvalue06.Name = "t_bvalue06";
            this.t_bvalue06.Size = new System.Drawing.Size(100, 30);
            this.t_bvalue06.TabIndex = 22;
            this.t_bvalue06.TextChanged += new System.EventHandler(this.t_bvalue06_TextChanged);
            // 
            // txtStartAddress06
            // 
            this.txtStartAddress06.Font = new System.Drawing.Font("楷体", 15F);
            this.txtStartAddress06.Location = new System.Drawing.Point(161, 154);
            this.txtStartAddress06.Name = "txtStartAddress06";
            this.txtStartAddress06.Size = new System.Drawing.Size(100, 30);
            this.txtStartAddress06.TabIndex = 20;
            this.txtStartAddress06.TextChanged += new System.EventHandler(this.txtStartAddress06_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 13F);
            this.label6.Location = new System.Drawing.Point(158, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "StartAddress";
            // 
            // panelRead
            // 
            this.panelRead.Controls.Add(this.numQuantity);
            this.panelRead.Controls.Add(this.label5);
            this.panelRead.Controls.Add(this.txtStartAddress03);
            this.panelRead.Controls.Add(this.label4);
            this.panelRead.Controls.Add(this.label3);
            this.panelRead.Location = new System.Drawing.Point(6, 114);
            this.panelRead.Name = "panelRead";
            this.panelRead.Size = new System.Drawing.Size(659, 375);
            this.panelRead.TabIndex = 21;
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("楷体", 15F);
            this.numQuantity.Location = new System.Drawing.Point(341, 154);
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
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 14);
            this.label5.TabIndex = 1;
            // 
            // txtStartAddress03
            // 
            this.txtStartAddress03.Font = new System.Drawing.Font("楷体", 15F);
            this.txtStartAddress03.Location = new System.Drawing.Point(161, 154);
            this.txtStartAddress03.Name = "txtStartAddress03";
            this.txtStartAddress03.Size = new System.Drawing.Size(100, 30);
            this.txtStartAddress03.TabIndex = 0;
            this.txtStartAddress03.TextChanged += new System.EventHandler(this.txtStartAddress03_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 13F);
            this.label4.Location = new System.Drawing.Point(348, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 13F);
            this.label3.Location = new System.Drawing.Point(158, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "StartAddress";
            // 
            // panelWriteMultiple
            // 
            this.panelWriteMultiple.Controls.Add(this.txtStartAddress10);
            this.panelWriteMultiple.Controls.Add(this.txtWrite10Quantity);
            this.panelWriteMultiple.Controls.Add(this.Button_DelRegister);
            this.panelWriteMultiple.Controls.Add(this.dgvWrite10Registers);
            this.panelWriteMultiple.Controls.Add(this.label9);
            this.panelWriteMultiple.Controls.Add(this.label8);
            this.panelWriteMultiple.Controls.Add(this.Button_AddRegister);
            this.panelWriteMultiple.Location = new System.Drawing.Point(6, 114);
            this.panelWriteMultiple.Name = "panelWriteMultiple";
            this.panelWriteMultiple.Size = new System.Drawing.Size(659, 375);
            this.panelWriteMultiple.TabIndex = 23;
            // 
            // txtStartAddress10
            // 
            this.txtStartAddress10.Font = new System.Drawing.Font("楷体", 12F);
            this.txtStartAddress10.Location = new System.Drawing.Point(161, 22);
            this.txtStartAddress10.Name = "txtStartAddress10";
            this.txtStartAddress10.Size = new System.Drawing.Size(100, 26);
            this.txtStartAddress10.TabIndex = 27;
            this.txtStartAddress10.TextChanged += new System.EventHandler(this.txtStartAddress10_TextChanged);
            // 
            // txtWrite10Quantity
            // 
            this.txtWrite10Quantity.Font = new System.Drawing.Font("楷体", 12F);
            this.txtWrite10Quantity.Location = new System.Drawing.Point(161, 53);
            this.txtWrite10Quantity.Name = "txtWrite10Quantity";
            this.txtWrite10Quantity.ReadOnly = true;
            this.txtWrite10Quantity.Size = new System.Drawing.Size(100, 26);
            this.txtWrite10Quantity.TabIndex = 26;
            // 
            // Button_DelRegister
            // 
            this.Button_DelRegister.Font = new System.Drawing.Font("楷体", 10F);
            this.Button_DelRegister.Location = new System.Drawing.Point(477, 55);
            this.Button_DelRegister.Name = "Button_DelRegister";
            this.Button_DelRegister.Size = new System.Drawing.Size(162, 31);
            this.Button_DelRegister.TabIndex = 25;
            this.Button_DelRegister.Text = "Delete Register";
            this.Button_DelRegister.UseVisualStyleBackColor = true;
            this.Button_DelRegister.Click += new System.EventHandler(this.Button_DelRegister_Click);
            // 
            // dgvWrite10Registers
            // 
            this.dgvWrite10Registers.AllowUserToAddRows = false;
            this.dgvWrite10Registers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWrite10Registers.Location = new System.Drawing.Point(3, 89);
            this.dgvWrite10Registers.Name = "dgvWrite10Registers";
            this.dgvWrite10Registers.RowHeadersWidth = 51;
            this.dgvWrite10Registers.RowTemplate.Height = 23;
            this.dgvWrite10Registers.Size = new System.Drawing.Size(653, 283);
            this.dgvWrite10Registers.TabIndex = 24;
            this.dgvWrite10Registers.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvWrite10Registers_CellBeginEdit_1);
            this.dgvWrite10Registers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWrite10Registers_CellContentClick);
            this.dgvWrite10Registers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWrite10Registers_CellEndEdit);
            this.dgvWrite10Registers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWrite10Registers_CellValueChanged);
            this.dgvWrite10Registers.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvWrite10Registers_CurrentCellDirtyStateChanged);
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
            // Button_AddRegister
            // 
            this.Button_AddRegister.Font = new System.Drawing.Font("楷体", 10F);
            this.Button_AddRegister.Location = new System.Drawing.Point(477, 17);
            this.Button_AddRegister.Name = "Button_AddRegister";
            this.Button_AddRegister.Size = new System.Drawing.Size(162, 33);
            this.Button_AddRegister.TabIndex = 0;
            this.Button_AddRegister.Text = "+ Add Register";
            this.Button_AddRegister.UseVisualStyleBackColor = true;
            this.Button_AddRegister.Click += new System.EventHandler(this.Button_AddRegister_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 13F);
            this.label2.Location = new System.Drawing.Point(269, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "FounctionCode";
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
            // cmbFunctionCode
            // 
            this.cmbFunctionCode.Font = new System.Drawing.Font("楷体", 12F);
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
            this.cmbFunctionCode.Location = new System.Drawing.Point(428, 19);
            this.cmbFunctionCode.Name = "cmbFunctionCode";
            this.cmbFunctionCode.Size = new System.Drawing.Size(454, 24);
            this.cmbFunctionCode.TabIndex = 14;
            this.cmbFunctionCode.SelectedIndexChanged += new System.EventHandler(this.cmbFunctionCode_SelectedIndexChanged);
            // 
            // numSlaveID
            // 
            this.numSlaveID.Font = new System.Drawing.Font("楷体", 15F);
            this.numSlaveID.Location = new System.Drawing.Point(134, 15);
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
            this.numSlaveID.ValueChanged += new System.EventHandler(this.numSlaveID_ValueChanged);
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
            // 
            // SendConfig
            // 
            this.SendConfig.Location = new System.Drawing.Point(768, 493);
            this.SendConfig.Name = "SendConfig";
            this.SendConfig.Size = new System.Drawing.Size(100, 39);
            this.SendConfig.TabIndex = 10;
            this.SendConfig.Text = "Send";
            this.SendConfig.UseVisualStyleBackColor = true;
            this.SendConfig.Click += new System.EventHandler(this.SendConfig_Click);
            // 
            // tabRegisterMap
            // 
            this.tabRegisterMap.Controls.Add(this.label14);
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
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(687, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 375);
            this.label11.TabIndex = 26;
            this.label11.Text = "Please select the Register Map to view the currently used registers.\r\n\r\n\r\n\r\nTX an" +
    "d RX data will be displayed in the Main window.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "label13";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label14.Location = new System.Drawing.Point(538, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(324, 522);
            this.label14.TabIndex = 1;
            this.label14.Text = resources.GetString("label14.Text");
            // 
            // Advance_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 645);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("楷体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Advance_Settings";
            this.Load += new System.EventHandler(this.Advance_Settings_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabModBusRTU.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabCommandConfig.ResumeLayout(false);
            this.tabCommandConfig.PerformLayout();
            this.panelWriteSingle.ResumeLayout(false);
            this.panelWriteSingle.PerformLayout();
            this.panelRead.ResumeLayout(false);
            this.panelRead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panelWriteMultiple.ResumeLayout(false);
            this.panelWriteMultiple.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWrite10Registers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlaveID)).EndInit();
            this.tabRegisterMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterMap)).EndInit();
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
        private System.Windows.Forms.TextBox t_bvalue06;
        private System.Windows.Forms.TextBox txtStartAddress06;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelRead;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartAddress03;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFunctionCode;
        private System.Windows.Forms.NumericUpDown numSlaveID;
        private System.Windows.Forms.RadioButton rdoDec;
        private System.Windows.Forms.RadioButton rdoHex;
        private System.Windows.Forms.Button SendConfig;
        private System.Windows.Forms.Button Button_AddRegister;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvWrite10Registers;
        private System.Windows.Forms.Button Button_DelRegister;
        private System.Windows.Forms.TextBox txtWrite10Quantity;
        private System.Windows.Forms.Button button_Copy;
        private System.Windows.Forms.TextBox txtGeneratedCommand;
        private System.Windows.Forms.TextBox txtStartAddress10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}