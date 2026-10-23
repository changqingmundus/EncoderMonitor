namespace EncoderMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_Readout = new System.Windows.Forms.Button();
            this.ClearReceive = new System.Windows.Forms.Button();
            this.cmb_Port = new System.Windows.Forms.ComboBox();
            this.btn_OpenSerial = new System.Windows.Forms.Button();
            this.cmb_BaudRate = new System.Windows.Forms.ComboBox();
            this.cb_Continuous = new System.Windows.Forms.CheckBox();
            this.cb_datawindow = new System.Windows.Forms.CheckBox();
            this.cmb_SingleTurn = new System.Windows.Forms.ComboBox();
            this.cmb_MultiTurn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_CfgMultiTurn = new System.Windows.Forms.TextBox();
            this.tb_CfgSingleTurn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advanceReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encoderSetupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.precisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encoderSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutEncoderMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_FreeModeReceive = new System.Windows.Forms.Button();
            this.cmb_Parity = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.chkShowSpeed = new System.Windows.Forms.CheckBox();
            this.chkShowDirection = new System.Windows.Forms.CheckBox();
            this.lbl_CfgSpeed = new System.Windows.Forms.Label();
            this.lbl_CfgRtDirection = new System.Windows.Forms.Label();
            this.lblSpeedTitle = new System.Windows.Forms.Label();
            this.lblDirectionTitle = new System.Windows.Forms.Label();
            this.rtbCommLog = new System.Windows.Forms.RichTextBox();
            this.rtbDataLog = new System.Windows.Forms.RichTextBox();
            this.tb_CfgEncoderValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tb_select_protocol = new System.Windows.Forms.TabControl();
            this.tp_modbusrtu = new System.Windows.Forms.TabPage();
            this.btn_StopScan = new System.Windows.Forms.Button();
            this.btn_RestartRead = new System.Windows.Forms.Button();
            this.lblCfgScanProgress = new System.Windows.Forms.Label();
            this.progressScan = new System.Windows.Forms.ProgressBar();
            this.tlpCfgParameter = new System.Windows.Forms.TableLayoutPanel();
            this.lblcfgUploadTime = new System.Windows.Forms.Label();
            this.btnCfgResetOrigin = new System.Windows.Forms.Button();
            this.btnCfgChangeOrigin = new System.Windows.Forms.Button();
            this.btnCfgChangeUploadTime = new System.Windows.Forms.Button();
            this.btnCfgChangeDirection = new System.Windows.Forms.Button();
            this.btnCfgChangeParity = new System.Windows.Forms.Button();
            this.btnCfgChangeBaudRate = new System.Windows.Forms.Button();
            this.btnCfgChangeSlaveID = new System.Windows.Forms.Button();
            this.btnCfgChangeMode = new System.Windows.Forms.Button();
            this.lblcfgWorkMode = new System.Windows.Forms.Label();
            this.lblcfgSlaveID = new System.Windows.Forms.Label();
            this.lblcfgBaudRate = new System.Windows.Forms.Label();
            this.lblcfgParameterHeader = new System.Windows.Forms.Label();
            this.lblCfgCurrentValue = new System.Windows.Forms.Label();
            this.lblCfgAction = new System.Windows.Forms.Label();
            this.lblcfgParity = new System.Windows.Forms.Label();
            this.lblcfgDirection = new System.Windows.Forms.Label();
            this.lblcfgOriginPosition = new System.Windows.Forms.Label();
            this.lblcfgResetOrigin = new System.Windows.Forms.Label();
            this.cmbCfgWorkMode = new System.Windows.Forms.ComboBox();
            this.cmbCfgBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbCfgParity = new System.Windows.Forms.ComboBox();
            this.cmbCfgDirection = new System.Windows.Forms.ComboBox();
            this.cmbCfgOriginPosition = new System.Windows.Forms.ComboBox();
            this.txtCfgUploadTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCfgSlaveID = new System.Windows.Forms.TextBox();
            this.btn_ScanDevice = new System.Windows.Forms.Button();
            this.tp_tamagawa = new System.Windows.Forms.TabPage();
            this.tp_canopen = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tb_select_protocol.SuspendLayout();
            this.tp_modbusrtu.SuspendLayout();
            this.tlpCfgParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Readout
            // 
            this.btn_Readout.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Readout.Location = new System.Drawing.Point(382, 180);
            this.btn_Readout.Name = "btn_Readout";
            this.btn_Readout.Size = new System.Drawing.Size(138, 38);
            this.btn_Readout.TabIndex = 0;
            this.btn_Readout.Text = "开始读取";
            this.btn_Readout.UseVisualStyleBackColor = true;
            this.btn_Readout.Click += new System.EventHandler(this.btn_Readout_Click);
            // 
            // ClearReceive
            // 
            this.ClearReceive.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClearReceive.Location = new System.Drawing.Point(531, 735);
            this.ClearReceive.Name = "ClearReceive";
            this.ClearReceive.Size = new System.Drawing.Size(149, 34);
            this.ClearReceive.TabIndex = 11;
            this.ClearReceive.Text = "Clear";
            this.ClearReceive.UseVisualStyleBackColor = true;
            this.ClearReceive.Click += new System.EventHandler(this.Clean_Messagebox);
            // 
            // cmb_Port
            // 
            this.cmb_Port.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.cmb_Port.FormattingEnabled = true;
            this.cmb_Port.Location = new System.Drawing.Point(69, 54);
            this.cmb_Port.Name = "cmb_Port";
            this.cmb_Port.Size = new System.Drawing.Size(103, 31);
            this.cmb_Port.TabIndex = 12;
            this.cmb_Port.Text = "串口号";
            this.cmb_Port.DropDown += new System.EventHandler(this.Serial_Port_DropDown);
            this.cmb_Port.SelectedIndexChanged += new System.EventHandler(this.Serial_Port_Select);
            // 
            // btn_OpenSerial
            // 
            this.btn_OpenSerial.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OpenSerial.Location = new System.Drawing.Point(7, 182);
            this.btn_OpenSerial.Name = "btn_OpenSerial";
            this.btn_OpenSerial.Size = new System.Drawing.Size(294, 36);
            this.btn_OpenSerial.TabIndex = 13;
            this.btn_OpenSerial.Text = "打开串口";
            this.btn_OpenSerial.UseVisualStyleBackColor = true;
            this.btn_OpenSerial.Click += new System.EventHandler(this.btn_OpenSerial_Click);
            // 
            // cmb_BaudRate
            // 
            this.cmb_BaudRate.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.cmb_BaudRate.FormattingEnabled = true;
            this.cmb_BaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "500000",
            "921600",
            "1000000",
            "1500000",
            "2000000",
            "2500000"});
            this.cmb_BaudRate.Location = new System.Drawing.Point(69, 101);
            this.cmb_BaudRate.Name = "cmb_BaudRate";
            this.cmb_BaudRate.Size = new System.Drawing.Size(103, 31);
            this.cmb_BaudRate.TabIndex = 14;
            this.cmb_BaudRate.Text = "波特率";
            this.cmb_BaudRate.SelectedIndexChanged += new System.EventHandler(this.Baud_SelectedIndexChanged);
            this.cmb_BaudRate.Click += new System.EventHandler(this.Baud);
            // 
            // cb_Continuous
            // 
            this.cb_Continuous.AutoSize = true;
            this.cb_Continuous.Font = new System.Drawing.Font("宋体", 12F);
            this.cb_Continuous.Location = new System.Drawing.Point(531, 200);
            this.cb_Continuous.Name = "cb_Continuous";
            this.cb_Continuous.Size = new System.Drawing.Size(106, 20);
            this.cb_Continuous.TabIndex = 18;
            this.cb_Continuous.Text = "Continuous";
            this.cb_Continuous.UseVisualStyleBackColor = true;
            this.cb_Continuous.CheckedChanged += new System.EventHandler(this.cb_Continuous_CheckedChanged);
            // 
            // cb_datawindow
            // 
            this.cb_datawindow.AutoSize = true;
            this.cb_datawindow.Font = new System.Drawing.Font("宋体", 12F);
            this.cb_datawindow.Location = new System.Drawing.Point(531, 182);
            this.cb_datawindow.Name = "cb_datawindow";
            this.cb_datawindow.Size = new System.Drawing.Size(122, 20);
            this.cb_datawindow.TabIndex = 19;
            this.cb_datawindow.Text = "Data Dispaly";
            this.cb_datawindow.UseVisualStyleBackColor = true;
            this.cb_datawindow.CheckedChanged += new System.EventHandler(this.Data_Dispaly_CheckedChanged);
            // 
            // cmb_SingleTurn
            // 
            this.cmb_SingleTurn.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmb_SingleTurn.FormattingEnabled = true;
            this.cmb_SingleTurn.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
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
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "32",
            "31",
            "32"});
            this.cmb_SingleTurn.Location = new System.Drawing.Point(196, 104);
            this.cmb_SingleTurn.Name = "cmb_SingleTurn";
            this.cmb_SingleTurn.Size = new System.Drawing.Size(105, 27);
            this.cmb_SingleTurn.TabIndex = 20;
            this.cmb_SingleTurn.Text = "單圈位數";
            this.cmb_SingleTurn.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // cmb_MultiTurn
            // 
            this.cmb_MultiTurn.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmb_MultiTurn.FormattingEnabled = true;
            this.cmb_MultiTurn.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
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
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "32",
            "31",
            "32"});
            this.cmb_MultiTurn.Location = new System.Drawing.Point(196, 152);
            this.cmb_MultiTurn.Name = "cmb_MultiTurn";
            this.cmb_MultiTurn.Size = new System.Drawing.Size(105, 27);
            this.cmb_MultiTurn.TabIndex = 21;
            this.cmb_MultiTurn.Text = "多圈位數";
            this.cmb_MultiTurn.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(213, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "多圈位数";
            // 
            // tb_CfgMultiTurn
            // 
            this.tb_CfgMultiTurn.Font = new System.Drawing.Font("宋体", 15F);
            this.tb_CfgMultiTurn.Location = new System.Drawing.Point(382, 68);
            this.tb_CfgMultiTurn.Name = "tb_CfgMultiTurn";
            this.tb_CfgMultiTurn.ReadOnly = true;
            this.tb_CfgMultiTurn.Size = new System.Drawing.Size(298, 30);
            this.tb_CfgMultiTurn.TabIndex = 24;
            this.tb_CfgMultiTurn.Text = "MultiTurn";
            this.tb_CfgMultiTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_CfgSingleTurn
            // 
            this.tb_CfgSingleTurn.Font = new System.Drawing.Font("宋体", 15F);
            this.tb_CfgSingleTurn.Location = new System.Drawing.Point(382, 108);
            this.tb_CfgSingleTurn.Name = "tb_CfgSingleTurn";
            this.tb_CfgSingleTurn.ReadOnly = true;
            this.tb_CfgSingleTurn.Size = new System.Drawing.Size(298, 30);
            this.tb_CfgSingleTurn.TabIndex = 25;
            this.tb_CfgSingleTurn.Text = "SingleTurn";
            this.tb_CfgSingleTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(346, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "MT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(346, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "ST";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.advanceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.encoderSetupToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(684, 25);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveConfigToolStripMenuItem,
            this.loadConfigToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.configurationToolStripMenuItem.Text = "File";
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveConfigToolStripMenuItem.Text = "Save Config";
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.loadConfigToolStripMenuItem.Text = "Load Config";
            // 
            // advanceToolStripMenuItem
            // 
            this.advanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advanceReadToolStripMenuItem});
            this.advanceToolStripMenuItem.Name = "advanceToolStripMenuItem";
            this.advanceToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.advanceToolStripMenuItem.Text = "Advanced";
            // 
            // advanceReadToolStripMenuItem
            // 
            this.advanceReadToolStripMenuItem.Name = "advanceReadToolStripMenuItem";
            this.advanceReadToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.advanceReadToolStripMenuItem.Text = "Advanced Mode";
            this.advanceReadToolStripMenuItem.Click += new System.EventHandler(this.advanceReadToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encoderSetupToolStripMenuItem1,
            this.precisionTestToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // encoderSetupToolStripMenuItem1
            // 
            this.encoderSetupToolStripMenuItem1.Name = "encoderSetupToolStripMenuItem1";
            this.encoderSetupToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.encoderSetupToolStripMenuItem1.Text = "EncoderSetup";
            this.encoderSetupToolStripMenuItem1.Click += new System.EventHandler(this.encoderSetupToolStripMenuItem1_Click);
            // 
            // precisionTestToolStripMenuItem
            // 
            this.precisionTestToolStripMenuItem.Name = "precisionTestToolStripMenuItem";
            this.precisionTestToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.precisionTestToolStripMenuItem.Text = "Precision Test";
            // 
            // encoderSetupToolStripMenuItem
            // 
            this.encoderSetupToolStripMenuItem.Name = "encoderSetupToolStripMenuItem";
            this.encoderSetupToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.encoderSetupToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.releaseNotesToolStripMenuItem,
            this.aboutEncoderMonitorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // releaseNotesToolStripMenuItem
            // 
            this.releaseNotesToolStripMenuItem.Name = "releaseNotesToolStripMenuItem";
            this.releaseNotesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.releaseNotesToolStripMenuItem.Text = "Release Notes";
            // 
            // aboutEncoderMonitorToolStripMenuItem
            // 
            this.aboutEncoderMonitorToolStripMenuItem.Name = "aboutEncoderMonitorToolStripMenuItem";
            this.aboutEncoderMonitorToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.aboutEncoderMonitorToolStripMenuItem.Text = "About EncoderMonitor";
            // 
            // btn_FreeModeReceive
            // 
            this.btn_FreeModeReceive.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_FreeModeReceive.Location = new System.Drawing.Point(11, 43);
            this.btn_FreeModeReceive.Margin = new System.Windows.Forms.Padding(2);
            this.btn_FreeModeReceive.Name = "btn_FreeModeReceive";
            this.btn_FreeModeReceive.Size = new System.Drawing.Size(122, 34);
            this.btn_FreeModeReceive.TabIndex = 29;
            this.btn_FreeModeReceive.Text = "开启自由模式";
            this.btn_FreeModeReceive.UseVisualStyleBackColor = true;
            this.btn_FreeModeReceive.Click += new System.EventHandler(this.btn_FreeModeReceive_Click);
            // 
            // cmb_Parity
            // 
            this.cmb_Parity.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.cmb_Parity.FormattingEnabled = true;
            this.cmb_Parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark"});
            this.cmb_Parity.Location = new System.Drawing.Point(69, 148);
            this.cmb_Parity.Name = "cmb_Parity";
            this.cmb_Parity.Size = new System.Drawing.Size(103, 31);
            this.cmb_Parity.TabIndex = 31;
            this.cmb_Parity.Text = "校驗位";
            this.cmb_Parity.SelectedIndexChanged += new System.EventHandler(this.Parity_Select_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("楷体", 15F);
            this.button5.Location = new System.Drawing.Point(332, 735);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(149, 34);
            this.button5.TabIndex = 32;
            this.button5.Text = "SendData";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // chkShowSpeed
            // 
            this.chkShowSpeed.AutoSize = true;
            this.chkShowSpeed.Font = new System.Drawing.Font("宋体", 12F);
            this.chkShowSpeed.Location = new System.Drawing.Point(11, 6);
            this.chkShowSpeed.Name = "chkShowSpeed";
            this.chkShowSpeed.Size = new System.Drawing.Size(122, 20);
            this.chkShowSpeed.TabIndex = 33;
            this.chkShowSpeed.Text = "Enable Speed";
            this.chkShowSpeed.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkShowSpeed.UseVisualStyleBackColor = true;
            this.chkShowSpeed.CheckedChanged += new System.EventHandler(this.chkShowSpeed_CheckedChanged);
            // 
            // chkShowDirection
            // 
            this.chkShowDirection.AutoSize = true;
            this.chkShowDirection.Font = new System.Drawing.Font("宋体", 12F);
            this.chkShowDirection.Location = new System.Drawing.Point(11, 24);
            this.chkShowDirection.Name = "chkShowDirection";
            this.chkShowDirection.Size = new System.Drawing.Size(106, 20);
            this.chkShowDirection.TabIndex = 34;
            this.chkShowDirection.Text = "Enable Dir";
            this.chkShowDirection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkShowDirection.UseVisualStyleBackColor = true;
            this.chkShowDirection.CheckedChanged += new System.EventHandler(this.chkShowDirection_CheckedChanged);
            // 
            // lbl_CfgSpeed
            // 
            this.lbl_CfgSpeed.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CfgSpeed.Location = new System.Drawing.Point(428, 32);
            this.lbl_CfgSpeed.Name = "lbl_CfgSpeed";
            this.lbl_CfgSpeed.Size = new System.Drawing.Size(88, 23);
            this.lbl_CfgSpeed.TabIndex = 35;
            this.lbl_CfgSpeed.Text = "0 rpm";
            this.lbl_CfgSpeed.Visible = false;
            // 
            // lbl_CfgRtDirection
            // 
            this.lbl_CfgRtDirection.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CfgRtDirection.Location = new System.Drawing.Point(592, 32);
            this.lbl_CfgRtDirection.Name = "lbl_CfgRtDirection";
            this.lbl_CfgRtDirection.Size = new System.Drawing.Size(56, 23);
            this.lbl_CfgRtDirection.TabIndex = 36;
            this.lbl_CfgRtDirection.Text = "Stop";
            this.lbl_CfgRtDirection.Visible = false;
            // 
            // lblSpeedTitle
            // 
            this.lblSpeedTitle.AutoSize = true;
            this.lblSpeedTitle.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lblSpeedTitle.Location = new System.Drawing.Point(345, 28);
            this.lblSpeedTitle.Name = "lblSpeedTitle";
            this.lblSpeedTitle.Size = new System.Drawing.Size(77, 27);
            this.lblSpeedTitle.TabIndex = 37;
            this.lblSpeedTitle.Text = "Speed:";
            // 
            // lblDirectionTitle
            // 
            this.lblDirectionTitle.AutoSize = true;
            this.lblDirectionTitle.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lblDirectionTitle.Location = new System.Drawing.Point(533, 28);
            this.lblDirectionTitle.Name = "lblDirectionTitle";
            this.lblDirectionTitle.Size = new System.Drawing.Size(45, 27);
            this.lblDirectionTitle.TabIndex = 38;
            this.lblDirectionTitle.Text = "Dir:";
            // 
            // rtbCommLog
            // 
            this.rtbCommLog.Location = new System.Drawing.Point(7, 612);
            this.rtbCommLog.Name = "rtbCommLog";
            this.rtbCommLog.ReadOnly = true;
            this.rtbCommLog.Size = new System.Drawing.Size(319, 157);
            this.rtbCommLog.TabIndex = 44;
            this.rtbCommLog.Text = "";
            // 
            // rtbDataLog
            // 
            this.rtbDataLog.Location = new System.Drawing.Point(332, 612);
            this.rtbDataLog.Name = "rtbDataLog";
            this.rtbDataLog.ReadOnly = true;
            this.rtbDataLog.Size = new System.Drawing.Size(348, 117);
            this.rtbDataLog.TabIndex = 45;
            this.rtbDataLog.Text = "";
            // 
            // tb_CfgEncoderValue
            // 
            this.tb_CfgEncoderValue.Font = new System.Drawing.Font("宋体", 15F);
            this.tb_CfgEncoderValue.Location = new System.Drawing.Point(382, 146);
            this.tb_CfgEncoderValue.Name = "tb_CfgEncoderValue";
            this.tb_CfgEncoderValue.ReadOnly = true;
            this.tb_CfgEncoderValue.Size = new System.Drawing.Size(298, 30);
            this.tb_CfgEncoderValue.TabIndex = 46;
            this.tb_CfgEncoderValue.Text = "All Data";
            this.tb_CfgEncoderValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 27);
            this.label5.TabIndex = 47;
            this.label5.Text = "COM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label7.Location = new System.Drawing.Point(4, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 24);
            this.label7.TabIndex = 48;
            this.label7.Text = "波特率";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label8.Location = new System.Drawing.Point(3, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 49;
            this.label8.Text = "校验位";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(346, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 20);
            this.label9.TabIndex = 50;
            this.label9.Text = "All";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(307, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(33, 203);
            this.panel1.TabIndex = 51;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(7, 224);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 10);
            this.panel2.TabIndex = 52;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStatus.Location = new System.Drawing.Point(7, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(294, 23);
            this.lblStatus.TabIndex = 53;
            this.lblStatus.Text = "开始使用";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_select_protocol
            // 
            this.tb_select_protocol.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tb_select_protocol.Controls.Add(this.tp_modbusrtu);
            this.tb_select_protocol.Controls.Add(this.tp_tamagawa);
            this.tb_select_protocol.Controls.Add(this.tp_canopen);
            this.tb_select_protocol.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_select_protocol.Location = new System.Drawing.Point(8, 240);
            this.tb_select_protocol.Multiline = true;
            this.tb_select_protocol.Name = "tb_select_protocol";
            this.tb_select_protocol.SelectedIndex = 0;
            this.tb_select_protocol.Size = new System.Drawing.Size(668, 354);
            this.tb_select_protocol.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tb_select_protocol.TabIndex = 54;
            this.tb_select_protocol.SelectedIndexChanged += new System.EventHandler(this.Model_Select);
            // 
            // tp_modbusrtu
            // 
            this.tp_modbusrtu.AutoScroll = true;
            this.tp_modbusrtu.Controls.Add(this.btn_StopScan);
            this.tp_modbusrtu.Controls.Add(this.btn_RestartRead);
            this.tp_modbusrtu.Controls.Add(this.lblCfgScanProgress);
            this.tp_modbusrtu.Controls.Add(this.progressScan);
            this.tp_modbusrtu.Controls.Add(this.tlpCfgParameter);
            this.tp_modbusrtu.Controls.Add(this.chkShowSpeed);
            this.tp_modbusrtu.Controls.Add(this.btn_ScanDevice);
            this.tp_modbusrtu.Controls.Add(this.chkShowDirection);
            this.tp_modbusrtu.Controls.Add(this.btn_FreeModeReceive);
            this.tp_modbusrtu.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.tp_modbusrtu.Location = new System.Drawing.Point(31, 4);
            this.tp_modbusrtu.Name = "tp_modbusrtu";
            this.tp_modbusrtu.Padding = new System.Windows.Forms.Padding(3);
            this.tp_modbusrtu.Size = new System.Drawing.Size(633, 346);
            this.tp_modbusrtu.TabIndex = 0;
            this.tp_modbusrtu.Text = "ModbusRTU";
            this.tp_modbusrtu.UseVisualStyleBackColor = true;
            // 
            // btn_StopScan
            // 
            this.btn_StopScan.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_StopScan.Location = new System.Drawing.Point(11, 118);
            this.btn_StopScan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StopScan.Name = "btn_StopScan";
            this.btn_StopScan.Size = new System.Drawing.Size(122, 34);
            this.btn_StopScan.TabIndex = 47;
            this.btn_StopScan.Text = "停止扫描";
            this.btn_StopScan.UseVisualStyleBackColor = true;
            this.btn_StopScan.Click += new System.EventHandler(this.btn_StopScan_Click);
            // 
            // btn_RestartRead
            // 
            this.btn_RestartRead.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_RestartRead.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_RestartRead.Location = new System.Drawing.Point(11, 223);
            this.btn_RestartRead.Name = "btn_RestartRead";
            this.btn_RestartRead.Size = new System.Drawing.Size(122, 35);
            this.btn_RestartRead.TabIndex = 46;
            this.btn_RestartRead.Text = "重新读取参数";
            this.btn_RestartRead.UseVisualStyleBackColor = true;
            // 
            // lblCfgScanProgress
            // 
            this.lblCfgScanProgress.AutoSize = true;
            this.lblCfgScanProgress.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lblCfgScanProgress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCfgScanProgress.Location = new System.Drawing.Point(25, 287);
            this.lblCfgScanProgress.Name = "lblCfgScanProgress";
            this.lblCfgScanProgress.Size = new System.Drawing.Size(92, 27);
            this.lblCfgScanProgress.TabIndex = 45;
            this.lblCfgScanProgress.Text = "扫描进度";
            // 
            // progressScan
            // 
            this.progressScan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressScan.Location = new System.Drawing.Point(11, 317);
            this.progressScan.Name = "progressScan";
            this.progressScan.Size = new System.Drawing.Size(122, 23);
            this.progressScan.TabIndex = 44;
            // 
            // tlpCfgParameter
            // 
            this.tlpCfgParameter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpCfgParameter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpCfgParameter.ColumnCount = 3;
            this.tlpCfgParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCfgParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpCfgParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCfgParameter.Controls.Add(this.lblcfgUploadTime, 0, 6);
            this.tlpCfgParameter.Controls.Add(this.btnCfgResetOrigin, 2, 8);
            this.tlpCfgParameter.Controls.Add(this.btnCfgChangeOrigin, 2, 7);
            this.tlpCfgParameter.Controls.Add(this.btnCfgChangeUploadTime, 2, 6);
            this.tlpCfgParameter.Controls.Add(this.btnCfgChangeDirection, 2, 5);
            this.tlpCfgParameter.Controls.Add(this.btnCfgChangeParity, 2, 4);
            this.tlpCfgParameter.Controls.Add(this.btnCfgChangeBaudRate, 2, 3);
            this.tlpCfgParameter.Controls.Add(this.btnCfgChangeSlaveID, 2, 2);
            this.tlpCfgParameter.Controls.Add(this.btnCfgChangeMode, 2, 1);
            this.tlpCfgParameter.Controls.Add(this.lblcfgWorkMode, 0, 1);
            this.tlpCfgParameter.Controls.Add(this.lblcfgSlaveID, 0, 2);
            this.tlpCfgParameter.Controls.Add(this.lblcfgBaudRate, 0, 3);
            this.tlpCfgParameter.Controls.Add(this.lblcfgParameterHeader, 0, 0);
            this.tlpCfgParameter.Controls.Add(this.lblCfgCurrentValue, 1, 0);
            this.tlpCfgParameter.Controls.Add(this.lblCfgAction, 2, 0);
            this.tlpCfgParameter.Controls.Add(this.lblcfgParity, 0, 4);
            this.tlpCfgParameter.Controls.Add(this.lblcfgDirection, 0, 5);
            this.tlpCfgParameter.Controls.Add(this.lblcfgOriginPosition, 0, 7);
            this.tlpCfgParameter.Controls.Add(this.lblcfgResetOrigin, 0, 8);
            this.tlpCfgParameter.Controls.Add(this.cmbCfgWorkMode, 1, 1);
            this.tlpCfgParameter.Controls.Add(this.cmbCfgBaudRate, 1, 3);
            this.tlpCfgParameter.Controls.Add(this.cmbCfgParity, 1, 4);
            this.tlpCfgParameter.Controls.Add(this.cmbCfgDirection, 1, 5);
            this.tlpCfgParameter.Controls.Add(this.cmbCfgOriginPosition, 1, 7);
            this.tlpCfgParameter.Controls.Add(this.txtCfgUploadTime, 1, 6);
            this.tlpCfgParameter.Controls.Add(this.label12, 1, 8);
            this.tlpCfgParameter.Controls.Add(this.txtCfgSlaveID, 1, 2);
            this.tlpCfgParameter.Location = new System.Drawing.Point(139, 6);
            this.tlpCfgParameter.Name = "tlpCfgParameter";
            this.tlpCfgParameter.RowCount = 9;
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCfgParameter.Size = new System.Drawing.Size(491, 337);
            this.tlpCfgParameter.TabIndex = 42;
            // 
            // lblcfgUploadTime
            // 
            this.lblcfgUploadTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgUploadTime.AutoSize = true;
            this.lblcfgUploadTime.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lblcfgUploadTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgUploadTime.Location = new System.Drawing.Point(35, 229);
            this.lblcfgUploadTime.Name = "lblcfgUploadTime";
            this.lblcfgUploadTime.Size = new System.Drawing.Size(78, 23);
            this.lblcfgUploadTime.TabIndex = 10;
            this.lblcfgUploadTime.Text = "上传时间";
            // 
            // btnCfgResetOrigin
            // 
            this.btnCfgResetOrigin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgResetOrigin.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnCfgResetOrigin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCfgResetOrigin.Location = new System.Drawing.Point(356, 301);
            this.btnCfgResetOrigin.Name = "btnCfgResetOrigin";
            this.btnCfgResetOrigin.Size = new System.Drawing.Size(120, 30);
            this.btnCfgResetOrigin.TabIndex = 7;
            this.btnCfgResetOrigin.Text = "重设原点";
            this.btnCfgResetOrigin.UseVisualStyleBackColor = true;
            this.btnCfgResetOrigin.Click += new System.EventHandler(this.btnCfgResetOrigin_Click);
            // 
            // btnCfgChangeOrigin
            // 
            this.btnCfgChangeOrigin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgChangeOrigin.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnCfgChangeOrigin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCfgChangeOrigin.Location = new System.Drawing.Point(356, 264);
            this.btnCfgChangeOrigin.Name = "btnCfgChangeOrigin";
            this.btnCfgChangeOrigin.Size = new System.Drawing.Size(120, 28);
            this.btnCfgChangeOrigin.TabIndex = 6;
            this.btnCfgChangeOrigin.Text = "更改原点位置";
            this.btnCfgChangeOrigin.UseVisualStyleBackColor = true;
            this.btnCfgChangeOrigin.Click += new System.EventHandler(this.btnCfgChangeOrigin_Click);
            // 
            // btnCfgChangeUploadTime
            // 
            this.btnCfgChangeUploadTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgChangeUploadTime.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnCfgChangeUploadTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCfgChangeUploadTime.Location = new System.Drawing.Point(356, 227);
            this.btnCfgChangeUploadTime.Name = "btnCfgChangeUploadTime";
            this.btnCfgChangeUploadTime.Size = new System.Drawing.Size(120, 28);
            this.btnCfgChangeUploadTime.TabIndex = 5;
            this.btnCfgChangeUploadTime.Text = "更改上传时间";
            this.btnCfgChangeUploadTime.UseVisualStyleBackColor = true;
            this.btnCfgChangeUploadTime.Click += new System.EventHandler(this.btnCfgChangeUploadTime_Click);
            // 
            // btnCfgChangeDirection
            // 
            this.btnCfgChangeDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgChangeDirection.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnCfgChangeDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCfgChangeDirection.Location = new System.Drawing.Point(356, 190);
            this.btnCfgChangeDirection.Name = "btnCfgChangeDirection";
            this.btnCfgChangeDirection.Size = new System.Drawing.Size(120, 28);
            this.btnCfgChangeDirection.TabIndex = 4;
            this.btnCfgChangeDirection.Text = "更改计数方向";
            this.btnCfgChangeDirection.UseVisualStyleBackColor = true;
            this.btnCfgChangeDirection.Click += new System.EventHandler(this.btnCfgChangeDirection_Click);
            // 
            // btnCfgChangeParity
            // 
            this.btnCfgChangeParity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgChangeParity.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnCfgChangeParity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCfgChangeParity.Location = new System.Drawing.Point(356, 153);
            this.btnCfgChangeParity.Name = "btnCfgChangeParity";
            this.btnCfgChangeParity.Size = new System.Drawing.Size(120, 28);
            this.btnCfgChangeParity.TabIndex = 3;
            this.btnCfgChangeParity.Text = "更改校验位";
            this.btnCfgChangeParity.UseVisualStyleBackColor = true;
            this.btnCfgChangeParity.Click += new System.EventHandler(this.btnCfgChangeParity_Click);
            // 
            // btnCfgChangeBaudRate
            // 
            this.btnCfgChangeBaudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgChangeBaudRate.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnCfgChangeBaudRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCfgChangeBaudRate.Location = new System.Drawing.Point(356, 116);
            this.btnCfgChangeBaudRate.Name = "btnCfgChangeBaudRate";
            this.btnCfgChangeBaudRate.Size = new System.Drawing.Size(120, 28);
            this.btnCfgChangeBaudRate.TabIndex = 2;
            this.btnCfgChangeBaudRate.Text = "更改波特率";
            this.btnCfgChangeBaudRate.UseVisualStyleBackColor = true;
            this.btnCfgChangeBaudRate.Click += new System.EventHandler(this.btnCfgChangeBaudRate_Click);
            // 
            // btnCfgChangeSlaveID
            // 
            this.btnCfgChangeSlaveID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgChangeSlaveID.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnCfgChangeSlaveID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCfgChangeSlaveID.Location = new System.Drawing.Point(356, 79);
            this.btnCfgChangeSlaveID.Name = "btnCfgChangeSlaveID";
            this.btnCfgChangeSlaveID.Size = new System.Drawing.Size(120, 28);
            this.btnCfgChangeSlaveID.TabIndex = 1;
            this.btnCfgChangeSlaveID.Text = "更改地址";
            this.btnCfgChangeSlaveID.UseVisualStyleBackColor = true;
            this.btnCfgChangeSlaveID.Click += new System.EventHandler(this.btnCfgChangeSlaveID_Click);
            // 
            // btnCfgChangeMode
            // 
            this.btnCfgChangeMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgChangeMode.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnCfgChangeMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCfgChangeMode.Location = new System.Drawing.Point(356, 42);
            this.btnCfgChangeMode.Name = "btnCfgChangeMode";
            this.btnCfgChangeMode.Size = new System.Drawing.Size(120, 28);
            this.btnCfgChangeMode.TabIndex = 0;
            this.btnCfgChangeMode.Text = "更改模式";
            this.btnCfgChangeMode.UseVisualStyleBackColor = true;
            this.btnCfgChangeMode.Click += new System.EventHandler(this.btnCfgChangeMode_Click);
            // 
            // lblcfgWorkMode
            // 
            this.lblcfgWorkMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgWorkMode.AutoSize = true;
            this.lblcfgWorkMode.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lblcfgWorkMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgWorkMode.Location = new System.Drawing.Point(35, 44);
            this.lblcfgWorkMode.Name = "lblcfgWorkMode";
            this.lblcfgWorkMode.Size = new System.Drawing.Size(78, 23);
            this.lblcfgWorkMode.TabIndex = 8;
            this.lblcfgWorkMode.Text = "工作模式";
            // 
            // lblcfgSlaveID
            // 
            this.lblcfgSlaveID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgSlaveID.AutoSize = true;
            this.lblcfgSlaveID.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lblcfgSlaveID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgSlaveID.Location = new System.Drawing.Point(35, 81);
            this.lblcfgSlaveID.Name = "lblcfgSlaveID";
            this.lblcfgSlaveID.Size = new System.Drawing.Size(78, 23);
            this.lblcfgSlaveID.TabIndex = 9;
            this.lblcfgSlaveID.Text = "从机地址";
            // 
            // lblcfgBaudRate
            // 
            this.lblcfgBaudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgBaudRate.AutoSize = true;
            this.lblcfgBaudRate.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lblcfgBaudRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgBaudRate.Location = new System.Drawing.Point(43, 118);
            this.lblcfgBaudRate.Name = "lblcfgBaudRate";
            this.lblcfgBaudRate.Size = new System.Drawing.Size(61, 23);
            this.lblcfgBaudRate.TabIndex = 10;
            this.lblcfgBaudRate.Text = "波特率";
            // 
            // lblcfgParameterHeader
            // 
            this.lblcfgParameterHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgParameterHeader.AutoSize = true;
            this.lblcfgParameterHeader.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblcfgParameterHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgParameterHeader.Location = new System.Drawing.Point(35, 7);
            this.lblcfgParameterHeader.Name = "lblcfgParameterHeader";
            this.lblcfgParameterHeader.Size = new System.Drawing.Size(78, 24);
            this.lblcfgParameterHeader.TabIndex = 11;
            this.lblcfgParameterHeader.Text = "参数列表";
            // 
            // lblCfgCurrentValue
            // 
            this.lblCfgCurrentValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCfgCurrentValue.AutoSize = true;
            this.lblCfgCurrentValue.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblCfgCurrentValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCfgCurrentValue.Location = new System.Drawing.Point(180, 7);
            this.lblCfgCurrentValue.Name = "lblCfgCurrentValue";
            this.lblCfgCurrentValue.Size = new System.Drawing.Size(129, 24);
            this.lblCfgCurrentValue.TabIndex = 12;
            this.lblCfgCurrentValue.Text = "当前编码器配置";
            // 
            // lblCfgAction
            // 
            this.lblCfgAction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCfgAction.AutoSize = true;
            this.lblCfgAction.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblCfgAction.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCfgAction.Location = new System.Drawing.Point(377, 7);
            this.lblCfgAction.Name = "lblCfgAction";
            this.lblCfgAction.Size = new System.Drawing.Size(78, 24);
            this.lblCfgAction.TabIndex = 13;
            this.lblCfgAction.Text = "更改参数";
            // 
            // lblcfgParity
            // 
            this.lblcfgParity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgParity.AutoSize = true;
            this.lblcfgParity.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lblcfgParity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgParity.Location = new System.Drawing.Point(43, 155);
            this.lblcfgParity.Name = "lblcfgParity";
            this.lblcfgParity.Size = new System.Drawing.Size(61, 23);
            this.lblcfgParity.TabIndex = 14;
            this.lblcfgParity.Text = "校验位";
            // 
            // lblcfgDirection
            // 
            this.lblcfgDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgDirection.AutoSize = true;
            this.lblcfgDirection.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lblcfgDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgDirection.Location = new System.Drawing.Point(35, 192);
            this.lblcfgDirection.Name = "lblcfgDirection";
            this.lblcfgDirection.Size = new System.Drawing.Size(78, 23);
            this.lblcfgDirection.TabIndex = 15;
            this.lblcfgDirection.Text = "计数方向";
            // 
            // lblcfgOriginPosition
            // 
            this.lblcfgOriginPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgOriginPosition.AutoSize = true;
            this.lblcfgOriginPosition.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lblcfgOriginPosition.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgOriginPosition.Location = new System.Drawing.Point(35, 266);
            this.lblcfgOriginPosition.Name = "lblcfgOriginPosition";
            this.lblcfgOriginPosition.Size = new System.Drawing.Size(78, 23);
            this.lblcfgOriginPosition.TabIndex = 16;
            this.lblcfgOriginPosition.Text = "原点位置";
            // 
            // lblcfgResetOrigin
            // 
            this.lblcfgResetOrigin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgResetOrigin.AutoSize = true;
            this.lblcfgResetOrigin.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lblcfgResetOrigin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblcfgResetOrigin.Location = new System.Drawing.Point(35, 305);
            this.lblcfgResetOrigin.Name = "lblcfgResetOrigin";
            this.lblcfgResetOrigin.Size = new System.Drawing.Size(78, 23);
            this.lblcfgResetOrigin.TabIndex = 17;
            this.lblcfgResetOrigin.Text = "重设原点";
            // 
            // cmbCfgWorkMode
            // 
            this.cmbCfgWorkMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgWorkMode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbCfgWorkMode.FormattingEnabled = true;
            this.cmbCfgWorkMode.Items.AddRange(new object[] {
            "ModBus RTU",
            "FreeMode"});
            this.cmbCfgWorkMode.Location = new System.Drawing.Point(161, 41);
            this.cmbCfgWorkMode.Name = "cmbCfgWorkMode";
            this.cmbCfgWorkMode.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgWorkMode.TabIndex = 18;
            // 
            // cmbCfgBaudRate
            // 
            this.cmbCfgBaudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgBaudRate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbCfgBaudRate.FormattingEnabled = true;
            this.cmbCfgBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbCfgBaudRate.Location = new System.Drawing.Point(161, 115);
            this.cmbCfgBaudRate.Name = "cmbCfgBaudRate";
            this.cmbCfgBaudRate.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgBaudRate.TabIndex = 20;
            // 
            // cmbCfgParity
            // 
            this.cmbCfgParity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgParity.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbCfgParity.FormattingEnabled = true;
            this.cmbCfgParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbCfgParity.Location = new System.Drawing.Point(161, 152);
            this.cmbCfgParity.Name = "cmbCfgParity";
            this.cmbCfgParity.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgParity.TabIndex = 21;
            // 
            // cmbCfgDirection
            // 
            this.cmbCfgDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgDirection.DropDownWidth = 200;
            this.cmbCfgDirection.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.cmbCfgDirection.FormattingEnabled = true;
            this.cmbCfgDirection.Items.AddRange(new object[] {
            "CW(顺时针递增)",
            "CCW(逆时针递增)"});
            this.cmbCfgDirection.Location = new System.Drawing.Point(161, 190);
            this.cmbCfgDirection.Name = "cmbCfgDirection";
            this.cmbCfgDirection.Size = new System.Drawing.Size(168, 28);
            this.cmbCfgDirection.TabIndex = 22;
            // 
            // cmbCfgOriginPosition
            // 
            this.cmbCfgOriginPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgOriginPosition.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbCfgOriginPosition.FormattingEnabled = true;
            this.cmbCfgOriginPosition.Items.AddRange(new object[] {
            "中间值",
            " 0 值"});
            this.cmbCfgOriginPosition.Location = new System.Drawing.Point(161, 263);
            this.cmbCfgOriginPosition.Name = "cmbCfgOriginPosition";
            this.cmbCfgOriginPosition.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgOriginPosition.TabIndex = 23;
            // 
            // txtCfgUploadTime
            // 
            this.txtCfgUploadTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCfgUploadTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtCfgUploadTime.Location = new System.Drawing.Point(159, 226);
            this.txtCfgUploadTime.Name = "txtCfgUploadTime";
            this.txtCfgUploadTime.Size = new System.Drawing.Size(171, 29);
            this.txtCfgUploadTime.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(217, 303);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 27);
            this.label12.TabIndex = 26;
            this.label12.Text = "0xFF";
            // 
            // txtCfgSlaveID
            // 
            this.txtCfgSlaveID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCfgSlaveID.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtCfgSlaveID.Location = new System.Drawing.Point(160, 78);
            this.txtCfgSlaveID.Name = "txtCfgSlaveID";
            this.txtCfgSlaveID.Size = new System.Drawing.Size(169, 29);
            this.txtCfgSlaveID.TabIndex = 24;
            // 
            // btn_ScanDevice
            // 
            this.btn_ScanDevice.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_ScanDevice.Location = new System.Drawing.Point(11, 81);
            this.btn_ScanDevice.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ScanDevice.Name = "btn_ScanDevice";
            this.btn_ScanDevice.Size = new System.Drawing.Size(122, 34);
            this.btn_ScanDevice.TabIndex = 43;
            this.btn_ScanDevice.Text = "扫描设备";
            this.btn_ScanDevice.UseVisualStyleBackColor = true;
            this.btn_ScanDevice.Click += new System.EventHandler(this.btn_ScanDevice_Click);
            // 
            // tp_tamagawa
            // 
            this.tp_tamagawa.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.tp_tamagawa.Location = new System.Drawing.Point(31, 4);
            this.tp_tamagawa.Name = "tp_tamagawa";
            this.tp_tamagawa.Padding = new System.Windows.Forms.Padding(3);
            this.tp_tamagawa.Size = new System.Drawing.Size(633, 346);
            this.tp_tamagawa.TabIndex = 1;
            this.tp_tamagawa.Text = "Tamagawa";
            this.tp_tamagawa.UseVisualStyleBackColor = true;
            // 
            // tp_canopen
            // 
            this.tp_canopen.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.tp_canopen.Location = new System.Drawing.Point(31, 4);
            this.tp_canopen.Name = "tp_canopen";
            this.tp_canopen.Size = new System.Drawing.Size(633, 346);
            this.tp_canopen.TabIndex = 2;
            this.tp_canopen.Text = "CANopen";
            this.tp_canopen.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Location = new System.Drawing.Point(7, 596);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(673, 10);
            this.panel3.TabIndex = 53;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EncoderMonitor.Properties.Resources.EncoderMonitor;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(196, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.Location = new System.Drawing.Point(213, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "单圈位数";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 771);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmb_SingleTurn);
            this.Controls.Add(this.cmb_MultiTurn);
            this.Controls.Add(this.tb_CfgEncoderValue);
            this.Controls.Add(this.tb_CfgSingleTurn);
            this.Controls.Add(this.tb_CfgMultiTurn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tb_select_protocol);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbDataLog);
            this.Controls.Add(this.rtbCommLog);
            this.Controls.Add(this.lblDirectionTitle);
            this.Controls.Add(this.lblSpeedTitle);
            this.Controls.Add(this.lbl_CfgRtDirection);
            this.Controls.Add(this.lbl_CfgSpeed);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cmb_Parity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_datawindow);
            this.Controls.Add(this.cb_Continuous);
            this.Controls.Add(this.cmb_BaudRate);
            this.Controls.Add(this.btn_OpenSerial);
            this.Controls.Add(this.cmb_Port);
            this.Controls.Add(this.ClearReceive);
            this.Controls.Add(this.btn_Readout);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "EncoderMonitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tb_select_protocol.ResumeLayout(false);
            this.tp_modbusrtu.ResumeLayout(false);
            this.tp_modbusrtu.PerformLayout();
            this.tlpCfgParameter.ResumeLayout(false);
            this.tlpCfgParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Readout;
        private System.Windows.Forms.Button ClearReceive;
        private System.Windows.Forms.ComboBox cmb_Port;
        private System.Windows.Forms.Button btn_OpenSerial;
        private System.Windows.Forms.ComboBox cmb_BaudRate;
        private System.Windows.Forms.CheckBox cb_Continuous;
        private System.Windows.Forms.CheckBox cb_datawindow;
        private System.Windows.Forms.ComboBox cmb_SingleTurn;
        private System.Windows.Forms.ComboBox cmb_MultiTurn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_CfgMultiTurn;
        private System.Windows.Forms.TextBox tb_CfgSingleTurn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutEncoderMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advanceReadToolStripMenuItem;
        private System.Windows.Forms.Button btn_FreeModeReceive;
        private System.Windows.Forms.ComboBox cmb_Parity;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox chkShowSpeed;
        private System.Windows.Forms.CheckBox chkShowDirection;
        private System.Windows.Forms.Label lbl_CfgSpeed;
        private System.Windows.Forms.Label lbl_CfgRtDirection;
        private System.Windows.Forms.Label lblSpeedTitle;
        private System.Windows.Forms.Label lblDirectionTitle;
        private System.Windows.Forms.RichTextBox rtbCommLog;
        private System.Windows.Forms.RichTextBox rtbDataLog;
        private System.Windows.Forms.TextBox tb_CfgEncoderValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabControl tb_select_protocol;
        private System.Windows.Forms.TabPage tp_modbusrtu;
        private System.Windows.Forms.TabPage tp_tamagawa;
        private System.Windows.Forms.TabPage tp_canopen;
        private System.Windows.Forms.TableLayoutPanel tlpCfgParameter;
        private System.Windows.Forms.Label lblcfgUploadTime;
        private System.Windows.Forms.Button btnCfgResetOrigin;
        private System.Windows.Forms.Button btnCfgChangeOrigin;
        private System.Windows.Forms.Button btnCfgChangeUploadTime;
        private System.Windows.Forms.Button btnCfgChangeDirection;
        private System.Windows.Forms.Button btnCfgChangeParity;
        private System.Windows.Forms.Button btnCfgChangeBaudRate;
        private System.Windows.Forms.Button btnCfgChangeSlaveID;
        private System.Windows.Forms.Button btnCfgChangeMode;
        private System.Windows.Forms.Label lblcfgWorkMode;
        private System.Windows.Forms.Label lblcfgSlaveID;
        private System.Windows.Forms.Label lblcfgBaudRate;
        private System.Windows.Forms.Label lblcfgParameterHeader;
        private System.Windows.Forms.Label lblCfgCurrentValue;
        private System.Windows.Forms.Label lblCfgAction;
        private System.Windows.Forms.Label lblcfgParity;
        private System.Windows.Forms.Label lblcfgDirection;
        private System.Windows.Forms.Label lblcfgOriginPosition;
        private System.Windows.Forms.Label lblcfgResetOrigin;
        private System.Windows.Forms.ComboBox cmbCfgWorkMode;
        private System.Windows.Forms.ComboBox cmbCfgBaudRate;
        private System.Windows.Forms.ComboBox cmbCfgParity;
        private System.Windows.Forms.ComboBox cmbCfgDirection;
        private System.Windows.Forms.ComboBox cmbCfgOriginPosition;
        private System.Windows.Forms.TextBox txtCfgUploadTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCfgSlaveID;
        private System.Windows.Forms.Button btn_ScanDevice;
        private System.Windows.Forms.ProgressBar progressScan;
        private System.Windows.Forms.Label lblCfgScanProgress;
        private System.Windows.Forms.Button btn_RestartRead;
        private System.Windows.Forms.Button btn_StopScan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem encoderSetupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem encoderSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precisionTestToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
    }
}

