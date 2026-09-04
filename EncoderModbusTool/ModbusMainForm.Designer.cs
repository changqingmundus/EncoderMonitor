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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbSingleTurn = new System.Windows.Forms.ComboBox();
            this.cmbMultiTurn = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tlpCfgParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lblPort.Location = new System.Drawing.Point(31, 38);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(52, 27);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "串口";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lblBaudRate.Location = new System.Drawing.Point(25, 83);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(72, 27);
            this.lblBaudRate.TabIndex = 1;
            this.lblBaudRate.Text = "波特率";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lblParity.Location = new System.Drawing.Point(25, 131);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(72, 27);
            this.lblParity.TabIndex = 2;
            this.lblParity.Text = "校验位";
            // 
            // cmbPort
            // 
            this.cmbPort.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(134, 41);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(85, 27);
            this.cmbPort.TabIndex = 3;
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(134, 83);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(85, 27);
            this.cmbBaudRate.TabIndex = 4;
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate_SelectedIndexChanged);
            // 
            // cmbParity
            // 
            this.cmbParity.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(134, 134);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(85, 27);
            this.cmbParity.TabIndex = 5;
            this.cmbParity.SelectedIndexChanged += new System.EventHandler(this.cmbParity_SelectedIndexChanged);
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnOpenSerial.Location = new System.Drawing.Point(12, 180);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(207, 44);
            this.btnOpenSerial.TabIndex = 6;
            this.btnOpenSerial.Text = "打开串口";
            this.btnOpenSerial.UseVisualStyleBackColor = true;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnScanDevice
            // 
            this.btnScanDevice.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnScanDevice.Location = new System.Drawing.Point(12, 228);
            this.btnScanDevice.Name = "btnScanDevice";
            this.btnScanDevice.Size = new System.Drawing.Size(85, 36);
            this.btnScanDevice.TabIndex = 7;
            this.btnScanDevice.Text = "扫描设备";
            this.btnScanDevice.UseVisualStyleBackColor = true;
            this.btnScanDevice.Click += new System.EventHandler(this.btnScanDevice_Click);
            // 
            // btnStopScan
            // 
            this.btnStopScan.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStopScan.Location = new System.Drawing.Point(134, 228);
            this.btnStopScan.Name = "btnStopScan";
            this.btnStopScan.Size = new System.Drawing.Size(85, 36);
            this.btnStopScan.TabIndex = 8;
            this.btnStopScan.Text = "停止扫描";
            this.btnStopScan.UseVisualStyleBackColor = true;
            this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
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
            this.tlpCfgParameter.Location = new System.Drawing.Point(355, 271);
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
            this.tlpCfgParameter.Size = new System.Drawing.Size(582, 318);
            this.tlpCfgParameter.TabIndex = 9;
            this.tlpCfgParameter.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblcfgUploadTime
            // 
            this.lblcfgUploadTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgUploadTime.AutoSize = true;
            this.lblcfgUploadTime.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgUploadTime.Location = new System.Drawing.Point(48, 216);
            this.lblcfgUploadTime.Name = "lblcfgUploadTime";
            this.lblcfgUploadTime.Size = new System.Drawing.Size(78, 23);
            this.lblcfgUploadTime.TabIndex = 10;
            this.lblcfgUploadTime.Text = "上传时间";
            // 
            // btnCfgResetOrigin
            // 
            this.btnCfgResetOrigin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCfgResetOrigin.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgResetOrigin.Location = new System.Drawing.Point(434, 284);
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
            this.btnCfgChangeOrigin.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgChangeOrigin.Location = new System.Drawing.Point(434, 249);
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
            this.btnCfgChangeUploadTime.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgChangeUploadTime.Location = new System.Drawing.Point(434, 214);
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
            this.btnCfgChangeDirection.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgChangeDirection.Location = new System.Drawing.Point(434, 179);
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
            this.btnCfgChangeParity.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgChangeParity.Location = new System.Drawing.Point(434, 144);
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
            this.btnCfgChangeBaudRate.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgChangeBaudRate.Location = new System.Drawing.Point(434, 109);
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
            this.btnCfgChangeSlaveID.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgChangeSlaveID.Location = new System.Drawing.Point(434, 74);
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
            this.btnCfgChangeMode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgChangeMode.Location = new System.Drawing.Point(434, 39);
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
            this.lblcfgWorkMode.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgWorkMode.Location = new System.Drawing.Point(48, 41);
            this.lblcfgWorkMode.Name = "lblcfgWorkMode";
            this.lblcfgWorkMode.Size = new System.Drawing.Size(78, 23);
            this.lblcfgWorkMode.TabIndex = 8;
            this.lblcfgWorkMode.Text = "工作模式";
            // 
            // lblcfgSlaveID
            // 
            this.lblcfgSlaveID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgSlaveID.AutoSize = true;
            this.lblcfgSlaveID.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgSlaveID.Location = new System.Drawing.Point(48, 76);
            this.lblcfgSlaveID.Name = "lblcfgSlaveID";
            this.lblcfgSlaveID.Size = new System.Drawing.Size(78, 23);
            this.lblcfgSlaveID.TabIndex = 9;
            this.lblcfgSlaveID.Text = "从机地址";
            // 
            // lblcfgBaudRate
            // 
            this.lblcfgBaudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgBaudRate.AutoSize = true;
            this.lblcfgBaudRate.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgBaudRate.Location = new System.Drawing.Point(57, 111);
            this.lblcfgBaudRate.Name = "lblcfgBaudRate";
            this.lblcfgBaudRate.Size = new System.Drawing.Size(61, 23);
            this.lblcfgBaudRate.TabIndex = 10;
            this.lblcfgBaudRate.Text = "波特率";
            // 
            // lblcfgParameterHeader
            // 
            this.lblcfgParameterHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgParameterHeader.AutoSize = true;
            this.lblcfgParameterHeader.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgParameterHeader.Location = new System.Drawing.Point(48, 6);
            this.lblcfgParameterHeader.Name = "lblcfgParameterHeader";
            this.lblcfgParameterHeader.Size = new System.Drawing.Size(78, 24);
            this.lblcfgParameterHeader.TabIndex = 11;
            this.lblcfgParameterHeader.Text = "参数列表";
            // 
            // lblCfgCurrentValue
            // 
            this.lblCfgCurrentValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCfgCurrentValue.AutoSize = true;
            this.lblCfgCurrentValue.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCfgCurrentValue.Location = new System.Drawing.Point(226, 6);
            this.lblCfgCurrentValue.Name = "lblCfgCurrentValue";
            this.lblCfgCurrentValue.Size = new System.Drawing.Size(129, 24);
            this.lblCfgCurrentValue.TabIndex = 12;
            this.lblCfgCurrentValue.Text = "当前编码器配置";
            // 
            // lblCfgAction
            // 
            this.lblCfgAction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCfgAction.AutoSize = true;
            this.lblCfgAction.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCfgAction.Location = new System.Drawing.Point(455, 6);
            this.lblCfgAction.Name = "lblCfgAction";
            this.lblCfgAction.Size = new System.Drawing.Size(78, 24);
            this.lblCfgAction.TabIndex = 13;
            this.lblCfgAction.Text = "更改参数";
            // 
            // lblcfgParity
            // 
            this.lblcfgParity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgParity.AutoSize = true;
            this.lblcfgParity.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgParity.Location = new System.Drawing.Point(57, 146);
            this.lblcfgParity.Name = "lblcfgParity";
            this.lblcfgParity.Size = new System.Drawing.Size(61, 23);
            this.lblcfgParity.TabIndex = 14;
            this.lblcfgParity.Text = "校验位";
            // 
            // lblcfgDirection
            // 
            this.lblcfgDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgDirection.AutoSize = true;
            this.lblcfgDirection.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgDirection.Location = new System.Drawing.Point(48, 181);
            this.lblcfgDirection.Name = "lblcfgDirection";
            this.lblcfgDirection.Size = new System.Drawing.Size(78, 23);
            this.lblcfgDirection.TabIndex = 15;
            this.lblcfgDirection.Text = "计数方向";
            // 
            // lblcfgOriginPosition
            // 
            this.lblcfgOriginPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgOriginPosition.AutoSize = true;
            this.lblcfgOriginPosition.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgOriginPosition.Location = new System.Drawing.Point(48, 251);
            this.lblcfgOriginPosition.Name = "lblcfgOriginPosition";
            this.lblcfgOriginPosition.Size = new System.Drawing.Size(78, 23);
            this.lblcfgOriginPosition.TabIndex = 16;
            this.lblcfgOriginPosition.Text = "原点位置";
            // 
            // lblcfgResetOrigin
            // 
            this.lblcfgResetOrigin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcfgResetOrigin.AutoSize = true;
            this.lblcfgResetOrigin.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcfgResetOrigin.Location = new System.Drawing.Point(48, 287);
            this.lblcfgResetOrigin.Name = "lblcfgResetOrigin";
            this.lblcfgResetOrigin.Size = new System.Drawing.Size(78, 23);
            this.lblcfgResetOrigin.TabIndex = 17;
            this.lblcfgResetOrigin.Text = "重设原点";
            // 
            // cmbCfgWorkMode
            // 
            this.cmbCfgWorkMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgWorkMode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCfgWorkMode.FormattingEnabled = true;
            this.cmbCfgWorkMode.Items.AddRange(new object[] {
            "ModBus RTU",
            "FreeMode"});
            this.cmbCfgWorkMode.Location = new System.Drawing.Point(206, 39);
            this.cmbCfgWorkMode.Name = "cmbCfgWorkMode";
            this.cmbCfgWorkMode.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgWorkMode.TabIndex = 18;
            // 
            // cmbCfgBaudRate
            // 
            this.cmbCfgBaudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgBaudRate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.cmbCfgBaudRate.Location = new System.Drawing.Point(206, 109);
            this.cmbCfgBaudRate.Name = "cmbCfgBaudRate";
            this.cmbCfgBaudRate.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgBaudRate.TabIndex = 20;
            // 
            // cmbCfgParity
            // 
            this.cmbCfgParity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgParity.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCfgParity.FormattingEnabled = true;
            this.cmbCfgParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbCfgParity.Location = new System.Drawing.Point(206, 144);
            this.cmbCfgParity.Name = "cmbCfgParity";
            this.cmbCfgParity.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgParity.TabIndex = 21;
            // 
            // cmbCfgDirection
            // 
            this.cmbCfgDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgDirection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCfgDirection.FormattingEnabled = true;
            this.cmbCfgDirection.Items.AddRange(new object[] {
            "CW(顺时针递增)",
            "CCW(逆时针递增)"});
            this.cmbCfgDirection.Location = new System.Drawing.Point(206, 179);
            this.cmbCfgDirection.Name = "cmbCfgDirection";
            this.cmbCfgDirection.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgDirection.TabIndex = 22;
            // 
            // cmbCfgOriginPosition
            // 
            this.cmbCfgOriginPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCfgOriginPosition.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCfgOriginPosition.FormattingEnabled = true;
            this.cmbCfgOriginPosition.Items.AddRange(new object[] {
            "中间值",
            " 0 值"});
            this.cmbCfgOriginPosition.Location = new System.Drawing.Point(206, 249);
            this.cmbCfgOriginPosition.Name = "cmbCfgOriginPosition";
            this.cmbCfgOriginPosition.Size = new System.Drawing.Size(168, 29);
            this.cmbCfgOriginPosition.TabIndex = 23;
            // 
            // txtCfgUploadTime
            // 
            this.txtCfgUploadTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCfgUploadTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCfgUploadTime.Location = new System.Drawing.Point(205, 214);
            this.txtCfgUploadTime.Name = "txtCfgUploadTime";
            this.txtCfgUploadTime.Size = new System.Drawing.Size(171, 29);
            this.txtCfgUploadTime.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(262, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 27);
            this.label12.TabIndex = 26;
            this.label12.Text = "0xFF";
            // 
            // txtCfgSlaveID
            // 
            this.txtCfgSlaveID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCfgSlaveID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCfgSlaveID.Location = new System.Drawing.Point(206, 74);
            this.txtCfgSlaveID.Name = "txtCfgSlaveID";
            this.txtCfgSlaveID.Size = new System.Drawing.Size(169, 29);
            this.txtCfgSlaveID.TabIndex = 24;
            // 
            // textBox_cfgAngle
            // 
            this.textBox_cfgAngle.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_cfgAngle.Location = new System.Drawing.Point(98, 693);
            this.textBox_cfgAngle.Name = "textBox_cfgAngle";
            this.textBox_cfgAngle.ReadOnly = true;
            this.textBox_cfgAngle.Size = new System.Drawing.Size(234, 30);
            this.textBox_cfgAngle.TabIndex = 15;
            this.textBox_cfgAngle.Text = "000.000 deg";
            this.textBox_cfgAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_cfgResolution
            // 
            this.textBox_cfgResolution.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_cfgResolution.Location = new System.Drawing.Point(99, 648);
            this.textBox_cfgResolution.Name = "textBox_cfgResolution";
            this.textBox_cfgResolution.ReadOnly = true;
            this.textBox_cfgResolution.Size = new System.Drawing.Size(233, 30);
            this.textBox_cfgResolution.TabIndex = 14;
            this.textBox_cfgResolution.Text = "Max Resolution";
            this.textBox_cfgResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_cfgBinary
            // 
            this.textBox_cfgBinary.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_cfgBinary.Location = new System.Drawing.Point(99, 606);
            this.textBox_cfgBinary.Name = "textBox_cfgBinary";
            this.textBox_cfgBinary.ReadOnly = true;
            this.textBox_cfgBinary.Size = new System.Drawing.Size(233, 26);
            this.textBox_cfgBinary.TabIndex = 13;
            this.textBox_cfgBinary.Text = "0000000000000000000";
            this.textBox_cfgBinary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_cfgAngle
            // 
            this.label_cfgAngle.AutoSize = true;
            this.label_cfgAngle.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_cfgAngle.Location = new System.Drawing.Point(12, 696);
            this.label_cfgAngle.Name = "label_cfgAngle";
            this.label_cfgAngle.Size = new System.Drawing.Size(64, 20);
            this.label_cfgAngle.TabIndex = 12;
            this.label_cfgAngle.Text = "Angle";
            // 
            // label_cfgResolution
            // 
            this.label_cfgResolution.AutoSize = true;
            this.label_cfgResolution.Font = new System.Drawing.Font("隶书", 13F, System.Drawing.FontStyle.Bold);
            this.label_cfgResolution.Location = new System.Drawing.Point(9, 648);
            this.label_cfgResolution.Name = "label_cfgResolution";
            this.label_cfgResolution.Size = new System.Drawing.Size(68, 36);
            this.label_cfgResolution.TabIndex = 11;
            this.label_cfgResolution.Text = "Resolu\r\ntion";
            // 
            // label_cfgBinary
            // 
            this.label_cfgBinary.AutoSize = true;
            this.label_cfgBinary.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_cfgBinary.Location = new System.Drawing.Point(8, 612);
            this.label_cfgBinary.Name = "label_cfgBinary";
            this.label_cfgBinary.Size = new System.Drawing.Size(75, 20);
            this.label_cfgBinary.TabIndex = 10;
            this.label_cfgBinary.Text = "Binary";
            // 
            // elementHostcfgAngle
            // 
            this.elementHostcfgAngle.Location = new System.Drawing.Point(12, 271);
            this.elementHostcfgAngle.Name = "elementHostcfgAngle";
            this.elementHostcfgAngle.Size = new System.Drawing.Size(320, 320);
            this.elementHostcfgAngle.TabIndex = 16;
            this.elementHostcfgAngle.Text = "elementHostAngle";
            this.elementHostcfgAngle.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHostcfgAngle_ChildChanged);
            this.elementHostcfgAngle.Child = null;
            // 
            // tbCfgSingleTurn
            // 
            this.tbCfgSingleTurn.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCfgSingleTurn.Location = new System.Drawing.Point(525, 66);
            this.tbCfgSingleTurn.Name = "tbCfgSingleTurn";
            this.tbCfgSingleTurn.ReadOnly = true;
            this.tbCfgSingleTurn.Size = new System.Drawing.Size(129, 34);
            this.tbCfgSingleTurn.TabIndex = 17;
            this.tbCfgSingleTurn.Text = "SingleTurn";
            this.tbCfgSingleTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCfgMultiTurn
            // 
            this.tbCfgMultiTurn.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCfgMultiTurn.Location = new System.Drawing.Point(660, 66);
            this.tbCfgMultiTurn.Name = "tbCfgMultiTurn";
            this.tbCfgMultiTurn.ReadOnly = true;
            this.tbCfgMultiTurn.Size = new System.Drawing.Size(107, 34);
            this.tbCfgMultiTurn.TabIndex = 18;
            this.tbCfgMultiTurn.Text = "MultiTurn";
            this.tbCfgMultiTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCfgAngle
            // 
            this.tbCfgAngle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCfgAngle.Location = new System.Drawing.Point(525, 216);
            this.tbCfgAngle.Name = "tbCfgAngle";
            this.tbCfgAngle.ReadOnly = true;
            this.tbCfgAngle.Size = new System.Drawing.Size(242, 34);
            this.tbCfgAngle.TabIndex = 19;
            this.tbCfgAngle.Text = "Angle";
            this.tbCfgAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCfgEncoderValue
            // 
            this.tbCfgEncoderValue.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCfgEncoderValue.Location = new System.Drawing.Point(525, 140);
            this.tbCfgEncoderValue.Name = "tbCfgEncoderValue";
            this.tbCfgEncoderValue.ReadOnly = true;
            this.tbCfgEncoderValue.Size = new System.Drawing.Size(242, 34);
            this.tbCfgEncoderValue.TabIndex = 20;
            this.tbCfgEncoderValue.Text = "All Data";
            this.tbCfgEncoderValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(531, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 27);
            this.label1.TabIndex = 21;
            this.label1.Text = "单圈";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(655, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 27);
            this.label2.TabIndex = 22;
            this.label2.Text = "圈数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(531, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 23;
            this.label3.Text = "总数据";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(531, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 27);
            this.label4.TabIndex = 24;
            this.label4.Text = "角度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(360, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 27);
            this.label5.TabIndex = 25;
            this.label5.Text = "旋转速度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(360, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 27);
            this.label6.TabIndex = 26;
            this.label6.Text = "旋转方向";
            // 
            // lblCfgRtDirection
            // 
            this.lblCfgRtDirection.AutoSize = true;
            this.lblCfgRtDirection.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCfgRtDirection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCfgRtDirection.Location = new System.Drawing.Point(378, 216);
            this.lblCfgRtDirection.Name = "lblCfgRtDirection";
            this.lblCfgRtDirection.Size = new System.Drawing.Size(57, 27);
            this.lblCfgRtDirection.TabIndex = 29;
            this.lblCfgRtDirection.Text = "Stop";
            // 
            // lblCfgSpeed
            // 
            this.lblCfgSpeed.AutoSize = true;
            this.lblCfgSpeed.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCfgSpeed.Location = new System.Drawing.Point(377, 73);
            this.lblCfgSpeed.Name = "lblCfgSpeed";
            this.lblCfgSpeed.Size = new System.Drawing.Size(75, 27);
            this.lblCfgSpeed.TabIndex = 30;
            this.lblCfgSpeed.Text = "0 RPM";
            // 
            // progressScan
            // 
            this.progressScan.Location = new System.Drawing.Point(355, 10);
            this.progressScan.Name = "progressScan";
            this.progressScan.Size = new System.Drawing.Size(299, 23);
            this.progressScan.TabIndex = 31;
            // 
            // lblCfgScanProgress
            // 
            this.lblCfgScanProgress.AutoSize = true;
            this.lblCfgScanProgress.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCfgScanProgress.Location = new System.Drawing.Point(660, 7);
            this.lblCfgScanProgress.Name = "lblCfgScanProgress";
            this.lblCfgScanProgress.Size = new System.Drawing.Size(92, 27);
            this.lblCfgScanProgress.TabIndex = 32;
            this.lblCfgScanProgress.Text = "扫描进度";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus.Location = new System.Drawing.Point(16, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(316, 23);
            this.lblStatus.TabIndex = 33;
            this.lblStatus.Text = "未识别到编码器，请选择参数并扫描设备！";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCfgClearlog
            // 
            this.btnCfgClearlog.AutoSize = true;
            this.btnCfgClearlog.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCfgClearlog.Location = new System.Drawing.Point(839, 686);
            this.btnCfgClearlog.Name = "btnCfgClearlog";
            this.btnCfgClearlog.Size = new System.Drawing.Size(70, 30);
            this.btnCfgClearlog.TabIndex = 34;
            this.btnCfgClearlog.Text = "清除";
            this.btnCfgClearlog.UseVisualStyleBackColor = true;
            this.btnCfgClearlog.Click += new System.EventHandler(this.btnCfgClearlog_Click);
            // 
            // rtbCommLog
            // 
            this.rtbCommLog.Location = new System.Drawing.Point(355, 595);
            this.rtbCommLog.Name = "rtbCommLog";
            this.rtbCommLog.ReadOnly = true;
            this.rtbCommLog.Size = new System.Drawing.Size(228, 128);
            this.rtbCommLog.TabIndex = 35;
            this.rtbCommLog.Text = "";
            // 
            // btnReadModbus
            // 
            this.btnReadModbus.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadModbus.Location = new System.Drawing.Point(789, 139);
            this.btnReadModbus.Name = "btnReadModbus";
            this.btnReadModbus.Size = new System.Drawing.Size(136, 34);
            this.btnReadModbus.TabIndex = 36;
            this.btnReadModbus.Text = "开始读取";
            this.btnReadModbus.UseVisualStyleBackColor = true;
            this.btnReadModbus.Click += new System.EventHandler(this.btnReadModbus_Click);
            // 
            // rtbDataLog
            // 
            this.rtbDataLog.Location = new System.Drawing.Point(589, 595);
            this.rtbDataLog.Name = "rtbDataLog";
            this.rtbDataLog.ReadOnly = true;
            this.rtbDataLog.Size = new System.Drawing.Size(348, 128);
            this.rtbDataLog.TabIndex = 37;
            this.rtbDataLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(338, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 717);
            this.panel1.TabIndex = 38;
            // 
            // btnChangeMode
            // 
            this.btnChangeMode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnChangeMode.Location = new System.Drawing.Point(789, 101);
            this.btnChangeMode.Name = "btnChangeMode";
            this.btnChangeMode.Size = new System.Drawing.Size(136, 32);
            this.btnChangeMode.TabIndex = 39;
            this.btnChangeMode.Text = "开启自由模式";
            this.btnChangeMode.UseVisualStyleBackColor = true;
            this.btnChangeMode.Click += new System.EventHandler(this.btnChangeMode_Click);
            // 
            // cbContinuous
            // 
            this.cbContinuous.AutoSize = true;
            this.cbContinuous.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.cbContinuous.Location = new System.Drawing.Point(792, 177);
            this.cbContinuous.Name = "cbContinuous";
            this.cbContinuous.Size = new System.Drawing.Size(136, 29);
            this.cbContinuous.TabIndex = 40;
            this.cbContinuous.Text = "Continuous";
            this.cbContinuous.UseVisualStyleBackColor = true;
            this.cbContinuous.CheckedChanged += new System.EventHandler(this.cbContinuous_CheckedChanged);
            // 
            // btnRestartRead
            // 
            this.btnRestartRead.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRestartRead.Location = new System.Drawing.Point(792, 229);
            this.btnRestartRead.Name = "btnRestartRead";
            this.btnRestartRead.Size = new System.Drawing.Size(133, 35);
            this.btnRestartRead.TabIndex = 41;
            this.btnRestartRead.Text = "重新读取参数";
            this.btnRestartRead.UseVisualStyleBackColor = true;
            this.btnRestartRead.Click += new System.EventHandler(this.btnRestartRead_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(236, 180);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(96, 100);
            this.elementHost1.TabIndex = 42;
            this.elementHost1.Text = "elementHostDirection";
            this.elementHost1.Child = this.directionIndicator1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(789, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // cmbSingleTurn
            // 
            this.cmbSingleTurn.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbSingleTurn.FormattingEnabled = true;
            this.cmbSingleTurn.Items.AddRange(new object[] {
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
            this.cmbSingleTurn.Location = new System.Drawing.Point(237, 83);
            this.cmbSingleTurn.Name = "cmbSingleTurn";
            this.cmbSingleTurn.Size = new System.Drawing.Size(95, 27);
            this.cmbSingleTurn.TabIndex = 44;
            this.cmbSingleTurn.SelectedIndexChanged += new System.EventHandler(this.cmbSingleTurn_SelectedIndexChanged);
            // 
            // cmbMultiTurn
            // 
            this.cmbMultiTurn.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbMultiTurn.FormattingEnabled = true;
            this.cmbMultiTurn.Items.AddRange(new object[] {
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
            this.cmbMultiTurn.Location = new System.Drawing.Point(237, 134);
            this.cmbMultiTurn.Name = "cmbMultiTurn";
            this.cmbMultiTurn.Size = new System.Drawing.Size(95, 27);
            this.cmbMultiTurn.TabIndex = 45;
            this.cmbMultiTurn.SelectedIndexChanged += new System.EventHandler(this.cmbMultiTurn_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label7.Location = new System.Drawing.Point(249, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 46;
            this.label7.Text = "单圈位数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label8.Location = new System.Drawing.Point(249, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 47;
            this.label8.Text = "多圈位数";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(9, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 10);
            this.panel2.TabIndex = 48;
            // 
            // ModbusMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 729);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModbusMainForm";
            this.Text = "Modbus Tool V1.0 Information";
            this.Load += new System.EventHandler(this.ModbusMainForm_Load);
            this.tlpCfgParameter.ResumeLayout(false);
            this.tlpCfgParameter.PerformLayout();
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
    }
}

