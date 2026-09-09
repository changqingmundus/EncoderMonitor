namespace EncoderModbusTool
{
    partial class ModbusMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusMainForm));
            this.lblPort = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.btnScanDevice = new System.Windows.Forms.Button();
            this.btnStopScan = new System.Windows.Forms.Button();
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
            this.textBox_cfgAngle = new System.Windows.Forms.TextBox();
            this.textBox_cfgResolution = new System.Windows.Forms.TextBox();
            this.textBox_cfgBinary = new System.Windows.Forms.TextBox();
            this.label_cfgAngle = new System.Windows.Forms.Label();
            this.label_cfgResolution = new System.Windows.Forms.Label();
            this.label_cfgBinary = new System.Windows.Forms.Label();
            this.elementHostcfgAngle = new System.Windows.Forms.Integration.ElementHost();
            this.tbCfgSingleTurn = new System.Windows.Forms.TextBox();
            this.tbCfgMultiTurn = new System.Windows.Forms.TextBox();
            this.tbCfgAngle = new System.Windows.Forms.TextBox();
            this.tbCfgEncoderValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCfgRtDirection = new System.Windows.Forms.Label();
            this.lblCfgSpeed = new System.Windows.Forms.Label();
            this.progressScan = new System.Windows.Forms.ProgressBar();
            this.lblCfgScanProgress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCfgClearlog = new System.Windows.Forms.Button();
            this.rtbCommLog = new System.Windows.Forms.RichTextBox();
            this.btnReadModbus = new System.Windows.Forms.Button();
            this.rtbDataLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChangeMode = new System.Windows.Forms.Button();
            this.cbContinuous = new System.Windows.Forms.CheckBox();
            this.btnRestartRead = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.directionIndicator1 = new Dashboard.UI.DirectionIndicator();
            this.cmbSingleTurn = new System.Windows.Forms.ComboBox();
            this.cmbMultiTurn = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.francisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tTstatus = new System.Windows.Forms.ToolTip(this.components);
            this.tlpCfgParameter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            resources.ApplyResources(this.lblPort, "lblPort");
            this.lblPort.Name = "lblPort";
            // 
            // lblBaudRate
            // 
            resources.ApplyResources(this.lblBaudRate, "lblBaudRate");
            this.lblBaudRate.Name = "lblBaudRate";
            // 
            // lblParity
            // 
            resources.ApplyResources(this.lblParity, "lblParity");
            this.lblParity.Name = "lblParity";
            // 
            // cmbPort
            // 
            resources.ApplyResources(this.cmbPort, "cmbPort");
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            resources.ApplyResources(this.cmbBaudRate, "cmbBaudRate");
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            resources.GetString("cmbBaudRate.Items"),
            resources.GetString("cmbBaudRate.Items1"),
            resources.GetString("cmbBaudRate.Items2"),
            resources.GetString("cmbBaudRate.Items3"),
            resources.GetString("cmbBaudRate.Items4"),
            resources.GetString("cmbBaudRate.Items5"),
            resources.GetString("cmbBaudRate.Items6"),
            resources.GetString("cmbBaudRate.Items7")});
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate_SelectedIndexChanged);
            // 
            // cmbParity
            // 
            resources.ApplyResources(this.cmbParity, "cmbParity");
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            resources.GetString("cmbParity.Items"),
            resources.GetString("cmbParity.Items1"),
            resources.GetString("cmbParity.Items2")});
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.SelectedIndexChanged += new System.EventHandler(this.cmbParity_SelectedIndexChanged);
            // 
            // btnOpenSerial
            // 
            resources.ApplyResources(this.btnOpenSerial, "btnOpenSerial");
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.UseVisualStyleBackColor = true;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnScanDevice
            // 
            resources.ApplyResources(this.btnScanDevice, "btnScanDevice");
            this.btnScanDevice.Name = "btnScanDevice";
            this.btnScanDevice.UseVisualStyleBackColor = true;
            this.btnScanDevice.Click += new System.EventHandler(this.btnScanDevice_Click);
            // 
            // btnStopScan
            // 
            resources.ApplyResources(this.btnStopScan, "btnStopScan");
            this.btnStopScan.Name = "btnStopScan";
            this.btnStopScan.UseVisualStyleBackColor = true;
            this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
            // 
            // tlpCfgParameter
            // 
            resources.ApplyResources(this.tlpCfgParameter, "tlpCfgParameter");
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
            this.tlpCfgParameter.Name = "tlpCfgParameter";
            this.tlpCfgParameter.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblcfgUploadTime
            // 
            resources.ApplyResources(this.lblcfgUploadTime, "lblcfgUploadTime");
            this.lblcfgUploadTime.Name = "lblcfgUploadTime";
            // 
            // btnCfgResetOrigin
            // 
            resources.ApplyResources(this.btnCfgResetOrigin, "btnCfgResetOrigin");
            this.btnCfgResetOrigin.Name = "btnCfgResetOrigin";
            this.btnCfgResetOrigin.UseVisualStyleBackColor = true;
            this.btnCfgResetOrigin.Click += new System.EventHandler(this.btnCfgResetOrigin_Click);
            // 
            // btnCfgChangeOrigin
            // 
            resources.ApplyResources(this.btnCfgChangeOrigin, "btnCfgChangeOrigin");
            this.btnCfgChangeOrigin.Name = "btnCfgChangeOrigin";
            this.btnCfgChangeOrigin.UseVisualStyleBackColor = true;
            this.btnCfgChangeOrigin.Click += new System.EventHandler(this.btnCfgChangeOrigin_Click);
            // 
            // btnCfgChangeUploadTime
            // 
            resources.ApplyResources(this.btnCfgChangeUploadTime, "btnCfgChangeUploadTime");
            this.btnCfgChangeUploadTime.Name = "btnCfgChangeUploadTime";
            this.btnCfgChangeUploadTime.UseVisualStyleBackColor = true;
            this.btnCfgChangeUploadTime.Click += new System.EventHandler(this.btnCfgChangeUploadTime_Click);
            // 
            // btnCfgChangeDirection
            // 
            resources.ApplyResources(this.btnCfgChangeDirection, "btnCfgChangeDirection");
            this.btnCfgChangeDirection.Name = "btnCfgChangeDirection";
            this.btnCfgChangeDirection.UseVisualStyleBackColor = true;
            this.btnCfgChangeDirection.Click += new System.EventHandler(this.btnCfgChangeDirection_Click);
            // 
            // btnCfgChangeParity
            // 
            resources.ApplyResources(this.btnCfgChangeParity, "btnCfgChangeParity");
            this.btnCfgChangeParity.Name = "btnCfgChangeParity";
            this.btnCfgChangeParity.UseVisualStyleBackColor = true;
            this.btnCfgChangeParity.Click += new System.EventHandler(this.btnCfgChangeParity_Click);
            // 
            // btnCfgChangeBaudRate
            // 
            resources.ApplyResources(this.btnCfgChangeBaudRate, "btnCfgChangeBaudRate");
            this.btnCfgChangeBaudRate.Name = "btnCfgChangeBaudRate";
            this.btnCfgChangeBaudRate.UseVisualStyleBackColor = true;
            this.btnCfgChangeBaudRate.Click += new System.EventHandler(this.btnCfgChangeBaudRate_Click);
            // 
            // btnCfgChangeSlaveID
            // 
            resources.ApplyResources(this.btnCfgChangeSlaveID, "btnCfgChangeSlaveID");
            this.btnCfgChangeSlaveID.Name = "btnCfgChangeSlaveID";
            this.btnCfgChangeSlaveID.UseVisualStyleBackColor = true;
            this.btnCfgChangeSlaveID.Click += new System.EventHandler(this.btnCfgChangeSlaveID_Click);
            // 
            // btnCfgChangeMode
            // 
            resources.ApplyResources(this.btnCfgChangeMode, "btnCfgChangeMode");
            this.btnCfgChangeMode.Name = "btnCfgChangeMode";
            this.btnCfgChangeMode.UseVisualStyleBackColor = true;
            this.btnCfgChangeMode.Click += new System.EventHandler(this.btnCfgChangeMode_Click);
            // 
            // lblcfgWorkMode
            // 
            resources.ApplyResources(this.lblcfgWorkMode, "lblcfgWorkMode");
            this.lblcfgWorkMode.Name = "lblcfgWorkMode";
            // 
            // lblcfgSlaveID
            // 
            resources.ApplyResources(this.lblcfgSlaveID, "lblcfgSlaveID");
            this.lblcfgSlaveID.Name = "lblcfgSlaveID";
            // 
            // lblcfgBaudRate
            // 
            resources.ApplyResources(this.lblcfgBaudRate, "lblcfgBaudRate");
            this.lblcfgBaudRate.Name = "lblcfgBaudRate";
            // 
            // lblcfgParameterHeader
            // 
            resources.ApplyResources(this.lblcfgParameterHeader, "lblcfgParameterHeader");
            this.lblcfgParameterHeader.Name = "lblcfgParameterHeader";
            // 
            // lblCfgCurrentValue
            // 
            resources.ApplyResources(this.lblCfgCurrentValue, "lblCfgCurrentValue");
            this.lblCfgCurrentValue.Name = "lblCfgCurrentValue";
            // 
            // lblCfgAction
            // 
            resources.ApplyResources(this.lblCfgAction, "lblCfgAction");
            this.lblCfgAction.Name = "lblCfgAction";
            // 
            // lblcfgParity
            // 
            resources.ApplyResources(this.lblcfgParity, "lblcfgParity");
            this.lblcfgParity.Name = "lblcfgParity";
            // 
            // lblcfgDirection
            // 
            resources.ApplyResources(this.lblcfgDirection, "lblcfgDirection");
            this.lblcfgDirection.Name = "lblcfgDirection";
            // 
            // lblcfgOriginPosition
            // 
            resources.ApplyResources(this.lblcfgOriginPosition, "lblcfgOriginPosition");
            this.lblcfgOriginPosition.Name = "lblcfgOriginPosition";
            // 
            // lblcfgResetOrigin
            // 
            resources.ApplyResources(this.lblcfgResetOrigin, "lblcfgResetOrigin");
            this.lblcfgResetOrigin.Name = "lblcfgResetOrigin";
            // 
            // cmbCfgWorkMode
            // 
            resources.ApplyResources(this.cmbCfgWorkMode, "cmbCfgWorkMode");
            this.cmbCfgWorkMode.FormattingEnabled = true;
            this.cmbCfgWorkMode.Items.AddRange(new object[] {
            resources.GetString("cmbCfgWorkMode.Items"),
            resources.GetString("cmbCfgWorkMode.Items1")});
            this.cmbCfgWorkMode.Name = "cmbCfgWorkMode";
            // 
            // cmbCfgBaudRate
            // 
            resources.ApplyResources(this.cmbCfgBaudRate, "cmbCfgBaudRate");
            this.cmbCfgBaudRate.FormattingEnabled = true;
            this.cmbCfgBaudRate.Items.AddRange(new object[] {
            resources.GetString("cmbCfgBaudRate.Items"),
            resources.GetString("cmbCfgBaudRate.Items1"),
            resources.GetString("cmbCfgBaudRate.Items2"),
            resources.GetString("cmbCfgBaudRate.Items3"),
            resources.GetString("cmbCfgBaudRate.Items4"),
            resources.GetString("cmbCfgBaudRate.Items5"),
            resources.GetString("cmbCfgBaudRate.Items6"),
            resources.GetString("cmbCfgBaudRate.Items7")});
            this.cmbCfgBaudRate.Name = "cmbCfgBaudRate";
            // 
            // cmbCfgParity
            // 
            resources.ApplyResources(this.cmbCfgParity, "cmbCfgParity");
            this.cmbCfgParity.FormattingEnabled = true;
            this.cmbCfgParity.Items.AddRange(new object[] {
            resources.GetString("cmbCfgParity.Items"),
            resources.GetString("cmbCfgParity.Items1"),
            resources.GetString("cmbCfgParity.Items2")});
            this.cmbCfgParity.Name = "cmbCfgParity";
            // 
            // cmbCfgDirection
            // 
            resources.ApplyResources(this.cmbCfgDirection, "cmbCfgDirection");
            this.cmbCfgDirection.FormattingEnabled = true;
            this.cmbCfgDirection.Items.AddRange(new object[] {
            resources.GetString("cmbCfgDirection.Items"),
            resources.GetString("cmbCfgDirection.Items1")});
            this.cmbCfgDirection.Name = "cmbCfgDirection";
            // 
            // cmbCfgOriginPosition
            // 
            resources.ApplyResources(this.cmbCfgOriginPosition, "cmbCfgOriginPosition");
            this.cmbCfgOriginPosition.FormattingEnabled = true;
            this.cmbCfgOriginPosition.Items.AddRange(new object[] {
            resources.GetString("cmbCfgOriginPosition.Items"),
            resources.GetString("cmbCfgOriginPosition.Items1")});
            this.cmbCfgOriginPosition.Name = "cmbCfgOriginPosition";
            // 
            // txtCfgUploadTime
            // 
            resources.ApplyResources(this.txtCfgUploadTime, "txtCfgUploadTime");
            this.txtCfgUploadTime.Name = "txtCfgUploadTime";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtCfgSlaveID
            // 
            resources.ApplyResources(this.txtCfgSlaveID, "txtCfgSlaveID");
            this.txtCfgSlaveID.Name = "txtCfgSlaveID";
            // 
            // textBox_cfgAngle
            // 
            resources.ApplyResources(this.textBox_cfgAngle, "textBox_cfgAngle");
            this.textBox_cfgAngle.Name = "textBox_cfgAngle";
            this.textBox_cfgAngle.ReadOnly = true;
            // 
            // textBox_cfgResolution
            // 
            resources.ApplyResources(this.textBox_cfgResolution, "textBox_cfgResolution");
            this.textBox_cfgResolution.Name = "textBox_cfgResolution";
            this.textBox_cfgResolution.ReadOnly = true;
            // 
            // textBox_cfgBinary
            // 
            resources.ApplyResources(this.textBox_cfgBinary, "textBox_cfgBinary");
            this.textBox_cfgBinary.Name = "textBox_cfgBinary";
            this.textBox_cfgBinary.ReadOnly = true;
            // 
            // label_cfgAngle
            // 
            resources.ApplyResources(this.label_cfgAngle, "label_cfgAngle");
            this.label_cfgAngle.Name = "label_cfgAngle";
            // 
            // label_cfgResolution
            // 
            resources.ApplyResources(this.label_cfgResolution, "label_cfgResolution");
            this.label_cfgResolution.Name = "label_cfgResolution";
            // 
            // label_cfgBinary
            // 
            resources.ApplyResources(this.label_cfgBinary, "label_cfgBinary");
            this.label_cfgBinary.Name = "label_cfgBinary";
            // 
            // elementHostcfgAngle
            // 
            resources.ApplyResources(this.elementHostcfgAngle, "elementHostcfgAngle");
            this.elementHostcfgAngle.Name = "elementHostcfgAngle";
            this.elementHostcfgAngle.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHostcfgAngle_ChildChanged);
            this.elementHostcfgAngle.Child = null;
            // 
            // tbCfgSingleTurn
            // 
            resources.ApplyResources(this.tbCfgSingleTurn, "tbCfgSingleTurn");
            this.tbCfgSingleTurn.Name = "tbCfgSingleTurn";
            this.tbCfgSingleTurn.ReadOnly = true;
            // 
            // tbCfgMultiTurn
            // 
            resources.ApplyResources(this.tbCfgMultiTurn, "tbCfgMultiTurn");
            this.tbCfgMultiTurn.Name = "tbCfgMultiTurn";
            this.tbCfgMultiTurn.ReadOnly = true;
            // 
            // tbCfgAngle
            // 
            resources.ApplyResources(this.tbCfgAngle, "tbCfgAngle");
            this.tbCfgAngle.Name = "tbCfgAngle";
            this.tbCfgAngle.ReadOnly = true;
            // 
            // tbCfgEncoderValue
            // 
            resources.ApplyResources(this.tbCfgEncoderValue, "tbCfgEncoderValue");
            this.tbCfgEncoderValue.Name = "tbCfgEncoderValue";
            this.tbCfgEncoderValue.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // lblCfgRtDirection
            // 
            resources.ApplyResources(this.lblCfgRtDirection, "lblCfgRtDirection");
            this.lblCfgRtDirection.Name = "lblCfgRtDirection";
            // 
            // lblCfgSpeed
            // 
            resources.ApplyResources(this.lblCfgSpeed, "lblCfgSpeed");
            this.lblCfgSpeed.Name = "lblCfgSpeed";
            // 
            // progressScan
            // 
            resources.ApplyResources(this.progressScan, "progressScan");
            this.progressScan.Name = "progressScan";
            // 
            // lblCfgScanProgress
            // 
            resources.ApplyResources(this.lblCfgScanProgress, "lblCfgScanProgress");
            this.lblCfgScanProgress.Name = "lblCfgScanProgress";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // btnCfgClearlog
            // 
            resources.ApplyResources(this.btnCfgClearlog, "btnCfgClearlog");
            this.btnCfgClearlog.Name = "btnCfgClearlog";
            this.btnCfgClearlog.UseVisualStyleBackColor = true;
            this.btnCfgClearlog.Click += new System.EventHandler(this.btnCfgClearlog_Click);
            // 
            // rtbCommLog
            // 
            resources.ApplyResources(this.rtbCommLog, "rtbCommLog");
            this.rtbCommLog.Name = "rtbCommLog";
            this.rtbCommLog.ReadOnly = true;
            // 
            // btnReadModbus
            // 
            resources.ApplyResources(this.btnReadModbus, "btnReadModbus");
            this.btnReadModbus.Name = "btnReadModbus";
            this.btnReadModbus.UseVisualStyleBackColor = true;
            this.btnReadModbus.Click += new System.EventHandler(this.btnReadModbus_Click);
            // 
            // rtbDataLog
            // 
            resources.ApplyResources(this.rtbDataLog, "rtbDataLog");
            this.rtbDataLog.Name = "rtbDataLog";
            this.rtbDataLog.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnChangeMode
            // 
            resources.ApplyResources(this.btnChangeMode, "btnChangeMode");
            this.btnChangeMode.Name = "btnChangeMode";
            this.btnChangeMode.UseVisualStyleBackColor = true;
            this.btnChangeMode.Click += new System.EventHandler(this.btnChangeMode_Click);
            // 
            // cbContinuous
            // 
            resources.ApplyResources(this.cbContinuous, "cbContinuous");
            this.cbContinuous.Name = "cbContinuous";
            this.cbContinuous.UseVisualStyleBackColor = true;
            this.cbContinuous.CheckedChanged += new System.EventHandler(this.cbContinuous_CheckedChanged);
            // 
            // btnRestartRead
            // 
            resources.ApplyResources(this.btnRestartRead, "btnRestartRead");
            this.btnRestartRead.Name = "btnRestartRead";
            this.btnRestartRead.UseVisualStyleBackColor = true;
            this.btnRestartRead.Click += new System.EventHandler(this.btnRestartRead_Click);
            // 
            // elementHost1
            // 
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Child = this.directionIndicator1;
            // 
            // cmbSingleTurn
            // 
            resources.ApplyResources(this.cmbSingleTurn, "cmbSingleTurn");
            this.cmbSingleTurn.FormattingEnabled = true;
            this.cmbSingleTurn.Items.AddRange(new object[] {
            resources.GetString("cmbSingleTurn.Items"),
            resources.GetString("cmbSingleTurn.Items1"),
            resources.GetString("cmbSingleTurn.Items2"),
            resources.GetString("cmbSingleTurn.Items3"),
            resources.GetString("cmbSingleTurn.Items4"),
            resources.GetString("cmbSingleTurn.Items5"),
            resources.GetString("cmbSingleTurn.Items6"),
            resources.GetString("cmbSingleTurn.Items7"),
            resources.GetString("cmbSingleTurn.Items8"),
            resources.GetString("cmbSingleTurn.Items9"),
            resources.GetString("cmbSingleTurn.Items10"),
            resources.GetString("cmbSingleTurn.Items11"),
            resources.GetString("cmbSingleTurn.Items12"),
            resources.GetString("cmbSingleTurn.Items13"),
            resources.GetString("cmbSingleTurn.Items14"),
            resources.GetString("cmbSingleTurn.Items15"),
            resources.GetString("cmbSingleTurn.Items16"),
            resources.GetString("cmbSingleTurn.Items17"),
            resources.GetString("cmbSingleTurn.Items18"),
            resources.GetString("cmbSingleTurn.Items19"),
            resources.GetString("cmbSingleTurn.Items20"),
            resources.GetString("cmbSingleTurn.Items21"),
            resources.GetString("cmbSingleTurn.Items22"),
            resources.GetString("cmbSingleTurn.Items23"),
            resources.GetString("cmbSingleTurn.Items24"),
            resources.GetString("cmbSingleTurn.Items25"),
            resources.GetString("cmbSingleTurn.Items26"),
            resources.GetString("cmbSingleTurn.Items27"),
            resources.GetString("cmbSingleTurn.Items28"),
            resources.GetString("cmbSingleTurn.Items29"),
            resources.GetString("cmbSingleTurn.Items30"),
            resources.GetString("cmbSingleTurn.Items31"),
            resources.GetString("cmbSingleTurn.Items32")});
            this.cmbSingleTurn.Name = "cmbSingleTurn";
            this.cmbSingleTurn.SelectedIndexChanged += new System.EventHandler(this.cmbSingleTurn_SelectedIndexChanged);
            // 
            // cmbMultiTurn
            // 
            resources.ApplyResources(this.cmbMultiTurn, "cmbMultiTurn");
            this.cmbMultiTurn.FormattingEnabled = true;
            this.cmbMultiTurn.Items.AddRange(new object[] {
            resources.GetString("cmbMultiTurn.Items"),
            resources.GetString("cmbMultiTurn.Items1"),
            resources.GetString("cmbMultiTurn.Items2"),
            resources.GetString("cmbMultiTurn.Items3"),
            resources.GetString("cmbMultiTurn.Items4"),
            resources.GetString("cmbMultiTurn.Items5"),
            resources.GetString("cmbMultiTurn.Items6"),
            resources.GetString("cmbMultiTurn.Items7"),
            resources.GetString("cmbMultiTurn.Items8"),
            resources.GetString("cmbMultiTurn.Items9"),
            resources.GetString("cmbMultiTurn.Items10"),
            resources.GetString("cmbMultiTurn.Items11"),
            resources.GetString("cmbMultiTurn.Items12"),
            resources.GetString("cmbMultiTurn.Items13"),
            resources.GetString("cmbMultiTurn.Items14"),
            resources.GetString("cmbMultiTurn.Items15"),
            resources.GetString("cmbMultiTurn.Items16"),
            resources.GetString("cmbMultiTurn.Items17"),
            resources.GetString("cmbMultiTurn.Items18"),
            resources.GetString("cmbMultiTurn.Items19"),
            resources.GetString("cmbMultiTurn.Items20"),
            resources.GetString("cmbMultiTurn.Items21"),
            resources.GetString("cmbMultiTurn.Items22"),
            resources.GetString("cmbMultiTurn.Items23"),
            resources.GetString("cmbMultiTurn.Items24"),
            resources.GetString("cmbMultiTurn.Items25"),
            resources.GetString("cmbMultiTurn.Items26"),
            resources.GetString("cmbMultiTurn.Items27"),
            resources.GetString("cmbMultiTurn.Items28"),
            resources.GetString("cmbMultiTurn.Items29"),
            resources.GetString("cmbMultiTurn.Items30"),
            resources.GetString("cmbMultiTurn.Items31"),
            resources.GetString("cmbMultiTurn.Items32")});
            this.cmbMultiTurn.Name = "cmbMultiTurn";
            this.cmbMultiTurn.SelectedIndexChanged += new System.EventHandler(this.cmbMultiTurn_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            resources.ApplyResources(this.文件ToolStripMenuItem, "文件ToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.chineseToolStripMenuItem,
            this.francisToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            resources.ApplyResources(this.chineseToolStripMenuItem, "chineseToolStripMenuItem");
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.chineseToolStripMenuItem_Click);
            // 
            // francisToolStripMenuItem
            // 
            this.francisToolStripMenuItem.Name = "francisToolStripMenuItem";
            resources.ApplyResources(this.francisToolStripMenuItem, "francisToolStripMenuItem");
            this.francisToolStripMenuItem.Click += new System.EventHandler(this.francisToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            resources.ApplyResources(this.帮助ToolStripMenuItem, "帮助ToolStripMenuItem");
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            resources.ApplyResources(this.关于ToolStripMenuItem, "关于ToolStripMenuItem");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EncoderModbusTool.Properties.Resources.ModbusMonitor;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // ModbusMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbMultiTurn);
            this.Controls.Add(this.cmbSingleTurn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.btnRestartRead);
            this.Controls.Add(this.cbContinuous);
            this.Controls.Add(this.btnChangeMode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCfgClearlog);
            this.Controls.Add(this.rtbDataLog);
            this.Controls.Add(this.btnReadModbus);
            this.Controls.Add(this.rtbCommLog);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCfgScanProgress);
            this.Controls.Add(this.progressScan);
            this.Controls.Add(this.lblCfgSpeed);
            this.Controls.Add(this.lblCfgRtDirection);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCfgEncoderValue);
            this.Controls.Add(this.tbCfgAngle);
            this.Controls.Add(this.tbCfgMultiTurn);
            this.Controls.Add(this.tbCfgSingleTurn);
            this.Controls.Add(this.elementHostcfgAngle);
            this.Controls.Add(this.textBox_cfgAngle);
            this.Controls.Add(this.textBox_cfgResolution);
            this.Controls.Add(this.textBox_cfgBinary);
            this.Controls.Add(this.label_cfgAngle);
            this.Controls.Add(this.label_cfgResolution);
            this.Controls.Add(this.label_cfgBinary);
            this.Controls.Add(this.tlpCfgParameter);
            this.Controls.Add(this.btnStopScan);
            this.Controls.Add(this.btnScanDevice);
            this.Controls.Add(this.btnOpenSerial);
            this.Controls.Add(this.cmbParity);
            this.Controls.Add(this.cmbBaudRate);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.lblParity);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ModbusMainForm";
            this.Load += new System.EventHandler(this.ModbusMainForm_Load);
            this.tlpCfgParameter.ResumeLayout(false);
            this.tlpCfgParameter.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.Button btnScanDevice;
        private System.Windows.Forms.Button btnStopScan;
        private System.Windows.Forms.TableLayoutPanel tlpCfgParameter;
        private System.Windows.Forms.Button btnCfgChangeMode;
        private System.Windows.Forms.Button btnCfgChangeBaudRate;
        private System.Windows.Forms.Button btnCfgChangeParity;
        private System.Windows.Forms.Button btnCfgChangeDirection;
        private System.Windows.Forms.Button btnCfgChangeUploadTime;
        private System.Windows.Forms.Button btnCfgChangeOrigin;
        private System.Windows.Forms.Button btnCfgResetOrigin;
        private System.Windows.Forms.Button btnCfgChangeSlaveID;
        private System.Windows.Forms.Label lblcfgUploadTime;
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
        private System.Windows.Forms.TextBox txtCfgSlaveID;
        private System.Windows.Forms.TextBox txtCfgUploadTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_cfgAngle;
        private System.Windows.Forms.TextBox textBox_cfgResolution;
        private System.Windows.Forms.TextBox textBox_cfgBinary;
        private System.Windows.Forms.Label label_cfgAngle;
        private System.Windows.Forms.Label label_cfgResolution;
        private System.Windows.Forms.Label label_cfgBinary;
        private System.Windows.Forms.Integration.ElementHost elementHostcfgAngle;
        private System.Windows.Forms.TextBox tbCfgSingleTurn;
        private System.Windows.Forms.TextBox tbCfgMultiTurn;
        private System.Windows.Forms.TextBox tbCfgAngle;
        private System.Windows.Forms.TextBox tbCfgEncoderValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCfgRtDirection;
        private System.Windows.Forms.Label lblCfgSpeed;
        private System.Windows.Forms.ProgressBar progressScan;
        private System.Windows.Forms.Label lblCfgScanProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCfgClearlog;
        private System.Windows.Forms.RichTextBox rtbCommLog;
        private System.Windows.Forms.Button btnReadModbus;
        private System.Windows.Forms.RichTextBox rtbDataLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChangeMode;
        private System.Windows.Forms.CheckBox cbContinuous;
        private System.Windows.Forms.Button btnRestartRead;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Dashboard.UI.DirectionIndicator directionIndicator1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbSingleTurn;
        private System.Windows.Forms.ComboBox cmbMultiTurn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem francisToolStripMenuItem;
        private System.Windows.Forms.ToolTip tTstatus;
    }
}

