using Encoder.Core.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EncoderMonitor
{
    public partial class PrecisionTestForm : Form
    {
        // ============ 外部数据源 ============
        public Func<EncoderData> EncoderReader { get; set; }
        public int SingleTurnBits { get; set; } = 0;

        // ============ 测试模式控件 ============
        private ComboBox cmbTestMode;
        private NumericUpDown numTolerance;
        private NumericUpDown numStartAngle;
        private NumericUpDown numEndAngle;
        private NumericUpDown numAngleStep;
        private NumericUpDown numRepeatTargetAngle;
        private NumericUpDown numRepeatCount;
        private FlowLayoutPanel linearityConfig;
        private FlowLayoutPanel repeatabilityConfig;
        private TextBox txtOperatorId;
        private TextBox txtProductName;
        private TextBox txtProductId;

        // ============ 汇总卡片 ============
        private Label lblMeasured;
        private Label lblError;
        private Label lblMaxError;
        private Label lblMeanError;
        private Label lblRepeatability;
        private Label lblResult;
        private Label lblStatus;

        // ============ 右侧信息 ============
        private PictureBox picLogo;
        private Label lblTheoryValue;
        private Label lblActualValue;
        private Label lblDeviationValue;
        private Label lblFinalResult;

        // ============ 表格 & 波形 ============
        private DataGridView dgvLinearity;
        private DataGridView dgvRepeatability;
        private ErrorPlotPanel linearityPlot;
        private ErrorPlotPanel repeatabilityPlot;

        private readonly List<Sample> linearitySamples = new List<Sample>();
        private readonly List<Sample> repeatabilitySamples = new List<Sample>();

        private double linearityTolerance = 0.05;
        private double repeatabilityTolerance = 0.05;

        // ============ 伺服控制 ============
        private GroupBox servoGroup;
        private ComboBox cmbServoPort;
        private Button btnServoConnect;
        private Button btnJogForward;
        private Button btnJogReverse;
        private Button btnJogStop;
        private Label lblServoStatus;
        private bool servoConnected = false;
        private RichTextBox txtCommLog;
        private bool jogRunning = false;
        private bool jogDirection = false;

        private NumericUpDown numAccelTime;
        private NumericUpDown numLoopInterval;
        private NumericUpDown numTargetPulse;
        private Button btnMoveForward;
        private Button btnMoveReverse;
        private Button btnPosStop;

        // ============ 通用参数 ============
        private NumericUpDown numSpeed;
        private NumericUpDown numSingleTurnRes;
        private NumericUpDown numMotorPulsesPerRev;
        private NumericUpDown numMoveWaitMs;

        // ============ 测试控制 ============
        private Button btnStart;
        private Button btnStop;
        private CancellationTokenSource testCts;
        private bool testRunning = false;

        // ============ 伺服 DLL（handle 版） ============
        private const string DllName = "libMotorCore.dll";
        private static IntPtr _motorHandle = IntPtr.Zero;

        private static readonly string LogFile =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "motor_comm.log");

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Motor_Create();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint Motor_Destroy(IntPtr handle);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool Motor_ConnectPort(
            IntPtr handle,
            [MarshalAs(UnmanagedType.LPStr)] string portName,
            int baudRate, int station);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint Motor_DisconnectPort(IntPtr handle);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint Motor_JogStart(IntPtr handle,
            [MarshalAs(UnmanagedType.U1)] bool isForward, int speed);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint Motor_JogStop(IntPtr handle);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint Motor_PosStart(IntPtr handle,
            int pulse,
            [MarshalAs(UnmanagedType.U1)] bool isForward,
            int speed, int accelTime, int loopIntervalSec);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint Motor_PosStop(IntPtr handle);

        // ============================================================
        // 构造 & 生命周期
        // ============================================================
        public PrecisionTestForm()
        {
            InitializeComponent();
            Text = "Precision Test";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1150, 880);
            MinimumSize = new Size(900, 700);
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 9F);

            BuildUI();
            Load += PrecisionTestForm_Load;
        }

        private void PrecisionTestForm_Load(object sender, EventArgs e)
        {
            LoadLogo();
            UpdateTestModeUI();
        }

        private void LoadLogo()
        {
            try
            {
                picLogo.Image = Properties.Resources.EncoderMonitor;
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { picLogo.Visible = false; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            testCts?.Cancel();
            if (servoConnected)
            {
                try
                {
                    if (_motorHandle != IntPtr.Zero)
                    {
                        Motor_JogStop(_motorHandle);
                        Motor_PosStop(_motorHandle);
                        Motor_DisconnectPort(_motorHandle);
                    }
                }
                catch { }
                servoConnected = false;
            }
            if (_motorHandle != IntPtr.Zero)
            {
                try { Motor_Destroy(_motorHandle); } catch { }
                _motorHandle = IntPtr.Zero;
            }
            jogRunning = false;
            jogDirection = false;
        }

        private bool IsLinearityMode =>
            cmbTestMode == null || cmbTestMode.SelectedIndex == 0;

        private List<Sample> ActiveSamples =>
            IsLinearityMode ? linearitySamples : repeatabilitySamples;

        private double ActiveTolerance =>
            IsLinearityMode ? linearityTolerance : repeatabilityTolerance;

        // ============================================================
        // UI 构建
        // ============================================================
        private void BuildUI()
        {
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                Padding = new Padding(12)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 260));   // 伺服控制
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 250));   // 测试配置
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 110));   // 汇总卡片
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 205));   // 波形
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));    // 记录表
            Controls.Add(root);

            BuildServoGroup();
            root.Controls.Add(servoGroup, 0, 0);

            BuildConfigGroup(root, 0, 1);
            BuildSummaryGroup(root, 0, 2);
            BuildPlotsGroup(root, 0, 3);
            BuildRecordsGroup(root, 0, 4);

            lblStatus = new Label
            {
                Text = "就绪",
                Dock = DockStyle.Bottom,
                Height = 24,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.DimGray
            };
            Controls.Add(lblStatus);
            lblStatus.BringToFront();
        }

        private void BuildServoGroup()
        {
            servoGroup = new GroupBox
            {
                Text = "伺服控制",
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(0)
            };
            // 关键修改：row2 从 42 改成 72，容纳 Field 面板（60px + margin 8px）
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));   // 第一行：串口/连接/点动
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72));   // 第二行：位置移动参数
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));   // 第三行：通信日志

            // 第一行：串口 / 连接 / 点动 / 停止 / 状态
            var row1 = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, AutoSize = false };

            cmbServoPort = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 100, Margin = new Padding(4, 4, 4, 4) };
            try
            {
                var ports = SerialPort.GetPortNames().OrderBy(p => p).ToArray();
                if (ports.Length > 0) { cmbServoPort.Items.AddRange(ports); cmbServoPort.SelectedIndex = 0; }
            }
            catch { }

            btnServoConnect = new Button { Text = "连接伺服", Width = 100, Height = 32, Margin = new Padding(4, 4, 4, 4) };
            btnServoConnect.Click += (s, e) => ToggleServoConnection();

            btnJogForward = new Button { Text = "点动正转", Width = 90, Height = 32, Margin = new Padding(4, 4, 4, 4), Enabled = false };
            btnJogForward.Click += (s, e) => ToggleJog(true);

            btnJogReverse = new Button { Text = "点动反转", Width = 90, Height = 32, Margin = new Padding(4, 4, 4, 4), Enabled = false };
            btnJogReverse.Click += (s, e) => ToggleJog(false);

            btnJogStop = new Button { Text = "旋转停止", Width = 90, Height = 32, Margin = new Padding(4, 4, 4, 4), Enabled = false };
            btnJogStop.Click += (s, e) => JogStop();

            lblServoStatus = new Label { Text = "状态: 未连接", AutoSize = true, Margin = new Padding(12, 10, 4, 4), ForeColor = Color.DimGray };

            row1.Controls.Add(new Label { Text = "串口", AutoSize = true, Margin = new Padding(4, 10, 2, 4), ForeColor = Color.DimGray });
            row1.Controls.Add(cmbServoPort);
            row1.Controls.Add(btnServoConnect);
            row1.Controls.Add(btnJogForward);
            row1.Controls.Add(btnJogReverse);
            row1.Controls.Add(btnJogStop);
            row1.Controls.Add(lblServoStatus);

            // 第二行：位置移动参数
            var row2 = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = true, AutoSize = false };

            numAccelTime = new NumericUpDown { Minimum = 0, Maximum = 60000, Value = 500, Increment = 100, Width = 90 };
            numLoopInterval = new NumericUpDown { Minimum = 0, Maximum = 600, Value = 0, Increment = 1, Width = 70 };
            numTargetPulse = new NumericUpDown { Minimum = -100000000, Maximum = 100000000, Value = 10000, Increment = 1000, Width = 130 };

            btnMoveForward = new Button { Text = "位置正移", Width = 90, Height = 32, Margin = new Padding(4, 20, 4, 4), Enabled = false };
            btnMoveForward.Click += (s, e) => MoveToPosition(true);

            btnMoveReverse = new Button { Text = "位置反移", Width = 90, Height = 32, Margin = new Padding(4, 20, 4, 4), Enabled = false };
            btnMoveReverse.Click += (s, e) => MoveToPosition(false);

            btnPosStop = new Button { Text = "位置停止", Width = 90, Height = 32, Margin = new Padding(4, 20, 4, 4), Enabled = false };
            btnPosStop.Click += (s, e) => PosStop();

            row2.Controls.Add(Field("加速度(ms)", numAccelTime));
            row2.Controls.Add(Field("循环间隔(s)", numLoopInterval));
            row2.Controls.Add(Field("目标脉冲数", numTargetPulse));
            row2.Controls.Add(btnMoveForward);
            row2.Controls.Add(btnMoveReverse);
            row2.Controls.Add(btnPosStop);

            // 第三行：通信日志
            txtCommLog = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                ReadOnly = true,
                Font = new Font("Consolas", 9F),
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.LightGreen,
                Margin = new Padding(4, 4, 4, 4)
            };

            layout.Controls.Add(row1, 0, 0);
            layout.Controls.Add(row2, 0, 1);
            layout.Controls.Add(txtCommLog, 0, 2);
            servoGroup.Controls.Add(layout);
        }

        private void BuildConfigGroup(TableLayoutPanel root, int col, int row)
        {
            var configGroup = new GroupBox
            {
                Text = "Test Configuration",
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            var configSplit = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            configSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75));
            configSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

            // -------- 左：参数 --------
            var config = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = true,
                AutoScroll = true,
                Padding = new Padding(0)
            };

            txtOperatorId = new TextBox { Width = 80, MaxLength = 50 };
            txtProductName = new TextBox { Width = 180, MaxLength = 100 };
            txtProductId = new TextBox { Width = 120, MaxLength = 50 };

            cmbTestMode = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 155 };
            cmbTestMode.Items.AddRange(new object[] { "线性度测试", "重复性测试" });
            cmbTestMode.SelectedIndex = 0;
            cmbTestMode.SelectedIndexChanged += (s, e) => { UpdateTestModeUI(); UpdateSummary(); };

            numTolerance = new NumericUpDown
            {
                DecimalPlaces = 3,
                Minimum = 0.001M,
                Maximum = 10,
                Value = 0.050M,
                Increment = 0.01M,
                Width = 100
            };

            // 线性度参数
            numStartAngle = new NumericUpDown { DecimalPlaces = 3, Minimum = 0, Maximum = 359.999M, Value = 0, Increment = 1, Width = 110 };
            numEndAngle = new NumericUpDown { DecimalPlaces = 3, Minimum = 0.001M, Maximum = 359.999M, Value = 359.999M, Increment = 1, Width = 110 };
            numAngleStep = new NumericUpDown { DecimalPlaces = 3, Minimum = 0.001M, Maximum = 360, Value = 30, Increment = 1, Width = 110 };

            // 重复性参数
            numRepeatTargetAngle = new NumericUpDown { DecimalPlaces = 3, Minimum = 0, Maximum = 359.999M, Value = 180, Increment = 0.1M, Width = 110 };
            numRepeatCount = new NumericUpDown { Minimum = 2, Maximum = 10000, Value = 100, Increment = 1, Width = 100 };

            linearityConfig = new FlowLayoutPanel
            {
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            linearityConfig.Controls.Add(Field("起始角度(°)", numStartAngle));
            linearityConfig.Controls.Add(Field("结束角度(°)", numEndAngle));
            linearityConfig.Controls.Add(Field("角度步进(°)", numAngleStep));

            repeatabilityConfig = new FlowLayoutPanel
            {
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            repeatabilityConfig.Controls.Add(Field("固定目标角度(°)", numRepeatTargetAngle));
            repeatabilityConfig.Controls.Add(Field("重复次数", numRepeatCount));

            // 转速 / 单圈分辨率 / 电机每转脉冲 / 移动等待
            numSpeed = new NumericUpDown { Minimum = 1, Maximum = 10000, Value = 100, Increment = 10, Width = 90 };
            numSingleTurnRes = new NumericUpDown { Minimum = 1, Maximum = 100000000, Value = 524288, Increment = 1000, Width = 120 };
            numMotorPulsesPerRev = new NumericUpDown { Minimum = 1, Maximum = 100000000, Value = 10000, Increment = 1000, Width = 120 };
            numMoveWaitMs = new NumericUpDown { Minimum = 10, Maximum = 30000, Value = 1000, Increment = 100, Width = 100 };

            // 布局顺序
            config.Controls.Add(Field("操作者ID", txtOperatorId));
            config.Controls.Add(Field("产品型号", txtProductName));
            config.Controls.Add(Field("产品ID", txtProductId));
            config.Controls.Add(Field("测试模式", cmbTestMode));

            var btnExport = new Button
            {
                Text = "Export CSV",
                Width = 100,
                Height = 32,
                Margin = new Padding(6, 24, 6, 6)
            };
            btnExport.Click += (s, e) => ExportCsv();
            config.Controls.Add(btnExport);
            config.SetFlowBreak(btnExport, true);

            config.Controls.Add(linearityConfig);
            config.Controls.Add(repeatabilityConfig);

            config.Controls.Add(Field("转速(rpm)", numSpeed));
            config.Controls.Add(Field("单圈分辨率", numSingleTurnRes));
            config.Controls.Add(Field("电机每转脉冲", numMotorPulsesPerRev));
            config.Controls.Add(Field("移动等待(ms)", numMoveWaitMs));
            config.Controls.Add(Field("允许误差(°)", numTolerance));

            btnStart = new Button
            {
                Text = "开始测试",
                Width = 120,
                Height = 32,
                Margin = new Padding(12, 24, 6, 6)
            };
            btnStart.Click += async (s, e) => await RunTestAsync();

            btnStop = new Button
            {
                Text = "停止",
                Width = 80,
                Height = 32,
                Margin = new Padding(6, 24, 6, 6),
                Enabled = false
            };
            btnStop.Click += (s, e) => testCts?.Cancel();

            var btnReset = new Button
            {
                Text = "重置",
                Width = 80,
                Height = 32,
                Margin = new Padding(6, 24, 6, 6)
            };
            btnReset.Click += (s, e) => ResetResults();

            config.Controls.Add(btnStart);
            config.Controls.Add(btnStop);
            config.Controls.Add(btnReset);

            configSplit.Controls.Add(config, 0, 0);

            // -------- 右：Logo + 数值 --------
            var rightPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(12),
                Margin = new Padding(8, 0, 0, 0)
            };

            var rightLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 5
            };
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            picLogo = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.Transparent, Margin = new Padding(0, 0, 6, 6) };
            rightLayout.Controls.Add(picLogo, 0, 0);
            rightLayout.SetColumnSpan(picLogo, 2);

            rightLayout.Controls.Add(MakeKeyLabel("理论值"), 0, 1);
            lblTheoryValue = MakeValueLabel("--");
            rightLayout.Controls.Add(lblTheoryValue, 1, 1);

            rightLayout.Controls.Add(MakeKeyLabel("实际值"), 0, 2);
            lblActualValue = MakeValueLabel("--");
            rightLayout.Controls.Add(lblActualValue, 1, 2);

            rightLayout.Controls.Add(MakeKeyLabel("偏差"), 0, 3);
            lblDeviationValue = MakeValueLabel("--");
            rightLayout.Controls.Add(lblDeviationValue, 1, 3);

            lblFinalResult = new Label
            {
                Text = "N/A",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.Gray,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 6, 0, 0)
            };
            rightLayout.Controls.Add(lblFinalResult, 0, 4);
            rightLayout.SetColumnSpan(lblFinalResult, 2);

            rightPanel.Controls.Add(rightLayout);
            configSplit.Controls.Add(rightPanel, 1, 0);

            configGroup.Controls.Add(configSplit);
            root.Controls.Add(configGroup, 0, row);
        }

        private void BuildSummaryGroup(TableLayoutPanel root, int col, int row)
        {
            var summary = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 6,
                RowCount = 1,
                Padding = new Padding(0, 5, 0, 5)
            };
            for (int i = 0; i < 6; i++)
                summary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 6));

            lblMeasured = AddMetric(summary, 0, "实测值", "--");
            lblError = AddMetric(summary, 1, "偏差值", "--");
            lblMaxError = AddMetric(summary, 2, "最大绝对偏差", "--");
            lblMeanError = AddMetric(summary, 3, "平均绝对偏差", "--");
            lblRepeatability = AddMetric(summary, 4, "重复性", "--");
            lblResult = AddMetric(summary, 5, "结果", "N/A");

            root.Controls.Add(summary, 0, row);
        }

        private void BuildPlotsGroup(TableLayoutPanel root, int col, int row)
        {
            var plotsPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            plotsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            plotsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            linearityPlot = new ErrorPlotPanel { Dock = DockStyle.Fill, BackColor = Color.White };
            var g1 = new GroupBox { Text = "Error Curve - 线性度 (°)", Dock = DockStyle.Fill, Padding = new Padding(8), Margin = new Padding(0, 0, 4, 0) };
            g1.Controls.Add(linearityPlot);
            plotsPanel.Controls.Add(g1, 0, 0);

            repeatabilityPlot = new ErrorPlotPanel { Dock = DockStyle.Fill, BackColor = Color.White };
            var g2 = new GroupBox { Text = "Error Curve - 重复性 (°)", Dock = DockStyle.Fill, Padding = new Padding(8), Margin = new Padding(4, 0, 0, 0) };
            g2.Controls.Add(repeatabilityPlot);
            plotsPanel.Controls.Add(g2, 1, 0);

            root.Controls.Add(plotsPanel, 0, row);
        }

        private void BuildRecordsGroup(TableLayoutPanel root, int col, int row)
        {
            var recordsPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            recordsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            recordsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            dgvLinearity = new DataGridView();
            SetupSampleGrid(dgvLinearity);
            var g1 = new GroupBox { Text = "线性度测试记录", Dock = DockStyle.Fill, Padding = new Padding(8), Margin = new Padding(0, 0, 4, 0) };
            g1.Controls.Add(dgvLinearity);
            recordsPanel.Controls.Add(g1, 0, 0);

            dgvRepeatability = new DataGridView();
            SetupSampleGrid(dgvRepeatability);
            var g2 = new GroupBox { Text = "重复性测试记录", Dock = DockStyle.Fill, Padding = new Padding(8), Margin = new Padding(4, 0, 0, 0) };
            g2.Controls.Add(dgvRepeatability);
            recordsPanel.Controls.Add(g2, 1, 0);

            root.Controls.Add(recordsPanel, 0, row);
        }

        // ============================================================
        // 工具方法
        // ============================================================
        private static Label MakeKeyLabel(string text) => new Label
        {
            Text = text,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.DimGray,
            Font = new Font("Segoe UI", 9F)
        };

        private static Label MakeValueLabel(string text) => new Label
        {
            Text = text,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.Black
        };

        private static Control Field(string title, Control input)
        {
            const int pad = 8;
            var panel = new Panel
            {
                Width = input.Width + pad,
                Height = 60,
                Margin = new Padding(4)
            };
            panel.Controls.Add(new Label { Text = title, Dock = DockStyle.Top, Height = 23 });
            input.Location = new Point(pad / 2, 25);
            panel.Controls.Add(input);
            return panel;
        }

        private static void SetupSampleGrid(DataGridView grid)
        {
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.BackgroundColor = Color.White;
            grid.Columns.Add("Index", "No.");
            grid.Columns.Add("Reference", "Reference (°)");
            grid.Columns.Add("Measured", "Measured (°)");
            grid.Columns.Add("Error", "Error (°)");
            grid.Columns.Add("Status", "Status");
        }

        private void UpdateTestModeUI()
        {
            bool isLinearity = IsLinearityMode;
            if (linearityConfig != null) linearityConfig.Visible = isLinearity;
            if (repeatabilityConfig != null) repeatabilityConfig.Visible = !isLinearity;
        }

        private static Label AddMetric(TableLayoutPanel table, int column, string title, string initial)
        {
            var card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(3) };
            var titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DimGray
            };
            var valueLabel = new Label
            {
                Text = initial,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold)
            };
            card.Controls.Add(valueLabel);
            card.Controls.Add(titleLabel);
            table.Controls.Add(card, column, 0);
            return valueLabel;
        }

        private static double Wrap180(double deg)
        {
            while (deg > 180) deg -= 360;
            while (deg < -180) deg += 360;
            return deg;
        }

        private double SingleTurnToDeg(uint singleTurn)
        {
            uint res;
            if (SingleTurnBits > 0 && SingleTurnBits <= 32)
                res = (uint)(1UL << SingleTurnBits);
            else
                res = (uint)numSingleTurnRes.Value;

            if (res == 0) return 0;

            double deg = singleTurn * 360.0 / res;
            deg %= 360.0;
            if (deg < 0) deg += 360;
            return deg;
        }

        // ============================================================
        // 伺服控制
        // ============================================================
        private void LogComm(string text, Color? color = null)
        {
            string line = $"{DateTime.Now:HH:mm:ss.fff}  {text}";
            try { File.AppendAllText(LogFile, line + "\r\n"); } catch { }

            if (txtCommLog == null) return;
            if (txtCommLog.InvokeRequired)
            {
                txtCommLog.Invoke(new Action(() => LogComm(text, color)));
                return;
            }
            txtCommLog.SelectionStart = txtCommLog.TextLength;
            txtCommLog.SelectionLength = 0;
            if (color.HasValue) txtCommLog.SelectionColor = color.Value;
            txtCommLog.AppendText(line + "\r\n");
            txtCommLog.SelectionColor = txtCommLog.ForeColor;
            txtCommLog.ScrollToCaret();
            txtCommLog.Update();
        }

        private void ToggleServoConnection()
        {
            if (!servoConnected)
            {
                string portName = cmbServoPort.SelectedItem as string;
                if (portName == null) { MessageBox.Show("未选择串口。"); return; }

                try
                {
                    LogComm("[CALL] Motor_Create()", Color.Cyan);
                    _motorHandle = Motor_Create();
                    LogComm($"[RET ] Motor_Create = 0x{_motorHandle.ToInt64():X}", Color.LightGreen);
                    if (_motorHandle == IntPtr.Zero)
                    {
                        MessageBox.Show("Motor_Create 返回空句柄。");
                        return;
                    }

                    LogComm($"[CALL] Motor_ConnectPort(0x{_motorHandle.ToInt64():X}, \"{portName}\", 9600, 0)", Color.Yellow);
                    bool ok = Motor_ConnectPort(_motorHandle, portName, 9600, 0);
                    LogComm($"[RET ] Motor_ConnectPort = {ok}", ok ? Color.LightGreen : Color.Red);

                    if (ok)
                    {
                        servoConnected = true;
                        btnServoConnect.Text = "断开伺服";
                        btnJogForward.Enabled = btnJogReverse.Enabled = btnJogStop.Enabled = true;
                        btnMoveForward.Enabled = btnMoveReverse.Enabled = btnPosStop.Enabled = true;
                        lblServoStatus.Text = $"已连接 {portName}@9600 站号=0";
                        lblServoStatus.ForeColor = Color.Green;
                        lblStatus.Text = $"伺服已连接: {portName}";
                    }
                    else
                    {
                        MessageBox.Show("连接失败。检查串口/波特率/站号，或日志里的返回值。");
                    }
                }
                catch (DllNotFoundException)
                {
                    MessageBox.Show("未找到 libMotorCore.dll。");
                }
                catch (EntryPointNotFoundException ex)
                {
                    MessageBox.Show("入口点未找到: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接异常: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    if (_motorHandle != IntPtr.Zero)
                    {
                        LogComm("[CALL] Motor_JogStop(handle)", Color.Yellow);
                        Motor_JogStop(_motorHandle);
                        LogComm("[CALL] Motor_PosStop(handle)", Color.Yellow);
                        Motor_PosStop(_motorHandle);
                        LogComm("[CALL] Motor_DisconnectPort(handle)", Color.Yellow);
                        //Motor_DisconnectPort(_motorHandle);
                    }
                }
                catch (Exception ex) { LogComm("[ERR ] " + ex.Message, Color.Red); }

                servoConnected = false;
                btnServoConnect.Text = "连接伺服";
                btnJogForward.Enabled = false;
                btnJogReverse.Enabled = false;
                btnJogStop.Enabled = false;
                btnMoveForward.Enabled = false;
                btnMoveReverse.Enabled = false;
                btnPosStop.Enabled = false;
                lblServoStatus.Text = "未连接";
                lblServoStatus.ForeColor = Color.DimGray;
                lblStatus.Text = "伺服已断开";
            }
        }

        private int SpeedToDll(int rpm)
        {
            return rpm;
        }

        private void ToggleJog(bool isForward)
        {
            if (!servoConnected || _motorHandle == IntPtr.Zero)
            {
                LogComm($"[SKIP] ToggleJog({isForward}) 未连接", Color.Gray);
                return;
            }

            try
            {
                if (jogRunning && jogDirection == isForward)
                {
                    LogComm("[CALL] Motor_JogStop(handle)", Color.Yellow);
                    Motor_JogStop(_motorHandle);
                    LogComm("[OK  ] Motor_JogStop 已发送", Color.LightGreen);
                    jogRunning = false;

                    btnJogForward.Text = "点动正转";
                    btnJogReverse.Text = "点动反转";
                    lblServoStatus.Text = "已停止";
                    lblServoStatus.ForeColor = Color.Green;
                    return;
                }

                if (jogRunning && jogDirection != isForward)
                {
                    LogComm("[CALL] Motor_JogStop(handle)", Color.Yellow);
                    Motor_JogStop(_motorHandle);
                    LogComm("[OK  ] Motor_JogStop 已发送", Color.LightGreen);
                }

                int rpm = (int)numSpeed.Value;
                int dllSpeed = SpeedToDll(rpm);
                LogComm($"[CALL] Motor_JogStart(handle, forward={isForward}, speed={dllSpeed})", Color.Yellow);
                Motor_JogStart(_motorHandle, isForward, dllSpeed);
                LogComm($"[OK  ] Motor_JogStart 已发送", Color.LightGreen);

                jogRunning = true;
                jogDirection = isForward;

                btnJogForward.Text = isForward ? "正转中(点停)" : "点动正转";
                btnJogReverse.Text = !isForward ? "反转中(点停)" : "点动反转";

                lblServoStatus.Text = $"点动{(isForward ? "正转" : "反转")} @ {rpm} rpm";
                lblServoStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                LogComm("[ERR ] " + ex.Message, Color.Red);
                MessageBox.Show("点动异常: " + ex.Message, "伺服控制", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JogStop()
        {
            if (!servoConnected || _motorHandle == IntPtr.Zero)
            {
                LogComm("[SKIP] Motor_JogStop 未连接", Color.Gray);
                return;
            }
            try
            {
                LogComm("[CALL] Motor_JogStop(handle)", Color.Yellow);
                Motor_JogStop(_motorHandle);
                LogComm("[OK  ] Motor_JogStop 已发送", Color.LightGreen);

                jogRunning = false;
                btnJogForward.Text = "点动正转";
                btnJogReverse.Text = "点动反转";

                lblServoStatus.Text = "已停止";
                lblServoStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                LogComm("[ERR ] " + ex.Message, Color.Red);
                MessageBox.Show("停止异常: " + ex.Message, "伺服控制", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoveToPosition(bool isForward)
        {
            if (!servoConnected || _motorHandle == IntPtr.Zero) return;
            try
            {
                int pulse = Math.Abs((int)numTargetPulse.Value);
                int rpm = (int)numSpeed.Value;
                int accel = (int)numAccelTime.Value;
                int interval = (int)numLoopInterval.Value;
                int dllSpeed = SpeedToDll(rpm);

                LogComm($"[CALL] Motor_PosStart(handle, pulse={pulse}, forward={isForward}, speed={dllSpeed}, accel={accel}, loop={interval})", Color.Yellow);
                Motor_PosStart(_motorHandle, pulse, isForward, dllSpeed, accel, interval);
                LogComm($"[OK  ] Motor_PosStart 已发送", Color.LightGreen);

                lblServoStatus.Text = $"位置{(isForward ? "正" : "反")}移 {pulse} 脉冲 @ {rpm} rpm";
                lblServoStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show("位置移动异常: " + ex.Message, "伺服控制", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PosStop()
        {
            if (!servoConnected || _motorHandle == IntPtr.Zero) return;
            try
            {
                Motor_PosStop(_motorHandle);
                lblServoStatus.Text = "位置移动已停止";
                lblServoStatus.ForeColor = Color.Green;
            }
            catch { }
        }

        // ============================================================
        // 测试流程
        // ============================================================
        private async Task RunTestAsync()
        {
            if (testRunning) return;

            if (EncoderReader == null)
            {
                MessageBox.Show(
                    "尚未设置 EncoderReader。请在调用方设置：\r\n" +
                    "    precisionTestForm.EncoderReader = () => /* 返回 EncoderData */;",
                    "Precision Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!servoConnected)
            {
                MessageBox.Show("自动测试需要先连接伺服。", "Precision Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double tolerance = (double)numTolerance.Value;
            if (IsLinearityMode) linearityTolerance = tolerance;
            else repeatabilityTolerance = tolerance;

            testRunning = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            testCts = new CancellationTokenSource();
            var ct = testCts.Token;

            try
            {
                if (IsLinearityMode) await RunLinearityAsync(ct);
                else await RunRepeatabilityAsync(ct);

                lblStatus.Text = "测试完成";
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "测试已停止";
            }
            catch (Exception ex)
            {
                MessageBox.Show("测试异常: " + ex.Message, "Precision Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "测试异常: " + ex.Message;
            }
            finally
            {
                testRunning = false;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                testCts?.Dispose();
                testCts = null;
            }
        }

        private async Task RunLinearityAsync(CancellationToken ct)
        {
            var references = BuildLinearityReferences();
            if (references == null) return;

            linearitySamples.Clear();
            dgvLinearity.Rows.Clear();
            linearityPlot.Samples = linearitySamples;
            linearityPlot.Tolerance = linearityTolerance;

            double tolerance = linearityTolerance;
            int rpm = (int)numSpeed.Value;
            int accel = (int)numAccelTime.Value;
            int interval = (int)numLoopInterval.Value;
            int waitMs = (int)numMoveWaitMs.Value;
            double motorPulsesPerRev = (double)numMotorPulsesPerRev.Value;

            for (int i = 0; i < references.Count; i++)
            {
                ct.ThrowIfCancellationRequested();

                double targetAngle = references[i];
                lblStatus.Text = $"线性度测试 [{i + 1}/{references.Count}] 目标 {targetAngle:F3}°";

                EncoderData before = await Task.Run(() => EncoderReader(), ct);
                double currAngle = SingleTurnToDeg(before.SingleTurn);
                double delta = Wrap180(targetAngle - currAngle);
                int pulse = (int)Math.Round(Math.Abs(delta) / 360.0 * motorPulsesPerRev);

                if (pulse > 0)
                {
                    bool forward = delta > 0;
                    try
                    {
                        int dllSpeed = SpeedToDll(rpm);
                        LogComm($"[CALL] Motor_PosStart(handle, pulse={pulse}, forward={forward}, speed={dllSpeed}, accel={accel}, loop={interval})", Color.Yellow);
                        Motor_PosStart(_motorHandle, pulse, forward, dllSpeed, accel, interval);
                        LogComm($"[OK  ] Motor_PosStart 已发送", Color.LightGreen);
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = $"位置移动失败: {ex.Message}，跳过该点";
                        continue;
                    }
                    await Task.Delay(waitMs, ct);
                }

                EncoderData after = await Task.Run(() => EncoderReader(), ct);
                double actualAngle = SingleTurnToDeg(after.SingleTurn);
                double error = Wrap180(actualAngle - targetAngle);

                var sample = new Sample
                {
                    Index = i + 1,
                    Reference = targetAngle,
                    Measured = actualAngle,
                    Error = error,
                    Passed = Math.Abs(error) <= tolerance
                };
                linearitySamples.Add(sample);
                dgvLinearity.Rows.Add(
                    sample.Index,
                    sample.Reference.ToString("F3"),
                    sample.Measured.ToString("F3"),
                    sample.Error.ToString("+0.000;-0.000;0.000"),
                    sample.Passed ? "PASS" : "FAIL");

                UpdateSidePanel(targetAngle, actualAngle, error);
                UpdateSummary();
                linearityPlot.Invalidate();
            }
        }

        private async Task RunRepeatabilityAsync(CancellationToken ct)
        {
            double targetAngle = (double)numRepeatTargetAngle.Value;
            int count = (int)numRepeatCount.Value;

            repeatabilitySamples.Clear();
            dgvRepeatability.Rows.Clear();
            repeatabilityPlot.Samples = repeatabilitySamples;
            repeatabilityPlot.Tolerance = repeatabilityTolerance;

            double tolerance = repeatabilityTolerance;
            int rpm = (int)numSpeed.Value;
            int accel = (int)numAccelTime.Value;
            int interval = (int)numLoopInterval.Value;
            int waitMs = (int)numMoveWaitMs.Value;
            double motorPulsesPerRev = (double)numMotorPulsesPerRev.Value;

            for (int i = 0; i < count; i++)
            {
                ct.ThrowIfCancellationRequested();
                lblStatus.Text = $"重复性测试 [{i + 1}/{count}] 目标 {targetAngle:F3}°";

                EncoderData before = await Task.Run(() => EncoderReader(), ct);
                double currAngle = SingleTurnToDeg(before.SingleTurn);
                double delta = Wrap180(targetAngle - currAngle);
                int pulse = (int)Math.Round(Math.Abs(delta) / 360.0 * motorPulsesPerRev);

                if (pulse > 0)
                {
                    bool forward = delta > 0;
                    try
                    {
                        Motor_PosStart(_motorHandle, pulse, forward, SpeedToDll(rpm), accel, interval);
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = $"位置移动失败: {ex.Message}，跳过该点";
                        continue;
                    }
                    await Task.Delay(waitMs, ct);
                }

                EncoderData after = await Task.Run(() => EncoderReader(), ct);
                double actualAngle = SingleTurnToDeg(after.SingleTurn);
                double error = Wrap180(actualAngle - targetAngle);

                var sample = new Sample
                {
                    Index = i + 1,
                    Reference = targetAngle,
                    Measured = actualAngle,
                    Error = error,
                    Passed = Math.Abs(error) <= tolerance
                };
                repeatabilitySamples.Add(sample);
                dgvRepeatability.Rows.Add(
                    sample.Index,
                    sample.Reference.ToString("F3"),
                    sample.Measured.ToString("F3"),
                    sample.Error.ToString("+0.000;-0.000;0.000"),
                    sample.Passed ? "PASS" : "FAIL");

                UpdateSidePanel(targetAngle, actualAngle, error);
                UpdateSummary();
                repeatabilityPlot.Invalidate();
            }
        }

        private List<double> BuildLinearityReferences()
        {
            double start = (double)numStartAngle.Value;
            double end = (double)numEndAngle.Value;
            double step = (double)numAngleStep.Value;

            if (end < start)
            {
                MessageBox.Show("结束角度必须 >= 起始角度。", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (step <= 0)
            {
                MessageBox.Show("角度步进必须 > 0。", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int count = (int)Math.Floor((end - start) / step + 1e-9) + 1;
            if (count > 50000)
            {
                MessageBox.Show($"测试点 {count} 超过 50000，请调整参数。", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var list = new List<double>(count);
            for (int i = 0; i < count; i++) list.Add(start + i * step);
            return list;
        }

        private void UpdateSidePanel(double theory, double actual, double deviation)
        {
            lblTheoryValue.Text = theory.ToString("F3") + "°";
            lblActualValue.Text = actual.ToString("F3") + "°";
            lblDeviationValue.Text = deviation.ToString("+0.000;-0.000;0.000") + "°";
        }

        private void UpdateSummary()
        {
            var list = ActiveSamples;
            if (list.Count == 0)
            {
                lblMeasured.Text = "--";
                lblError.Text = "--";
                lblMaxError.Text = "--";
                lblMeanError.Text = "--";
                lblRepeatability.Text = "--";
                lblResult.Text = "N/A";
                lblResult.ForeColor = Color.Black;
                lblFinalResult.Text = "N/A";
                lblFinalResult.ForeColor = Color.Gray;
                return;
            }

            var errors = list.Select(x => x.Error).ToList();
            double maxAbs = errors.Max(x => Math.Abs(x));
            double meanAbs = errors.Average(x => Math.Abs(x));
            double repeatability = errors.Max() - errors.Min();

            Sample last = list[list.Count - 1];
            double tolerance = ActiveTolerance;

            lblMeasured.Text = last.Measured.ToString("F3") + "°";
            lblError.Text = last.Error.ToString("+0.000;-0.000;0.000") + "°";
            lblMaxError.Text = maxAbs.ToString("F3") + "°";
            lblMeanError.Text = meanAbs.ToString("F3") + "°";
            lblRepeatability.Text = repeatability.ToString("F3") + "°";

            bool pass = maxAbs <= tolerance;
            lblResult.Text = pass ? "PASS" : "FAIL";
            lblResult.ForeColor = pass ? Color.Green : Color.Red;
            lblFinalResult.Text = pass ? "PASS" : "FAIL";
            lblFinalResult.ForeColor = pass ? Color.Green : Color.Red;
        }

        private void ResetResults()
        {
            if (testRunning)
            {
                MessageBox.Show("请先停止当前测试。", "Precision Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            linearitySamples.Clear();
            repeatabilitySamples.Clear();
            dgvLinearity.Rows.Clear();
            dgvRepeatability.Rows.Clear();
            linearityTolerance = 0.05;
            repeatabilityTolerance = 0.05;
            UpdateSummary();
            linearityPlot.Invalidate();
            repeatabilityPlot.Invalidate();
            lblStatus.Text = "结果已清空";
        }

        private void ExportCsv()
        {
            bool isLinearity = IsLinearityMode;
            var list = isLinearity ? linearitySamples : repeatabilitySamples;
            if (list.Count == 0)
            {
                MessageBox.Show(isLinearity ? "线性度测试暂无数据。" : "重复性测试暂无数据。",
                    "Precision Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.FileName = isLinearity ? "LinearityTest.csv" : "RepeatabilityTest.csv";
                if (dialog.ShowDialog() != DialogResult.OK) return;

                using (var writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8))
                {
                    writer.WriteLine("Index,ReferenceAngle,MeasuredAngle,Error,Status");
                    foreach (var s in list)
                    {
                        writer.WriteLine(string.Join(",",
                            s.Index,
                            s.Reference.ToString("F6", CultureInfo.InvariantCulture),
                            s.Measured.ToString("F6", CultureInfo.InvariantCulture),
                            s.Error.ToString("F6", CultureInfo.InvariantCulture),
                            s.Passed ? "PASS" : "FAIL"));
                    }
                }
                MessageBox.Show("CSV 已导出。");
            }
        }

        // ============================================================
        // 数据结构
        // ============================================================
        private class Sample
        {
            public int Index { get; set; }
            public double Reference { get; set; }
            public double Measured { get; set; }
            public double Error { get; set; }
            public bool Passed { get; set; }
        }

        private class ErrorPlotPanel : Panel
        {
            public IList<Sample> Samples { get; set; } = new List<Sample>();
            public double Tolerance { get; set; } = 0.05;

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int left = 55;
                int right = Width - 15;
                int top = 15;
                int bottom = Height - 30;
                if (right <= left || bottom <= top) return;

                using (var axisPen = new Pen(Color.Gray, 1))
                using (var linePen = new Pen(Color.Teal, 2))
                using (var zeroPen = new Pen(Color.Gray, 1))
                using (var font = new Font("Segoe UI", 8F))
                using (var brush = new SolidBrush(Color.DimGray))
                {
                    g.DrawLine(axisPen, left, top, left, bottom);
                    g.DrawLine(axisPen, left, bottom, right, bottom);
                    g.DrawLine(zeroPen, left, (top + bottom) / 2, right, (top + bottom) / 2);

                    g.DrawString("+Tolerance", font, brush, 2, top);
                    g.DrawString("0", font, brush, 25, (top + bottom) / 2 - 7);
                    g.DrawString("-Tolerance", font, brush, 2, bottom - 12);

                    if (Samples == null || Samples.Count == 0)
                    {
                        g.DrawString("暂无数据", font, brush, left + 10, top + 10);
                        return;
                    }

                    double range = Math.Max(Tolerance * 1.2, 0.001);
                    PointF? previous = null;

                    for (int i = 0; i < Samples.Count; i++)
                    {
                        double x = left + (right - left) * i / (double)Math.Max(1, Samples.Count - 1);
                        double normalized = Samples[i].Error / range;
                        normalized = Math.Max(-1.0, Math.Min(1.0, normalized));
                        float y = (float)((top + bottom) / 2.0 - normalized * (bottom - top) / 2.0);
                        var point = new PointF((float)x, y);
                        if (previous.HasValue) g.DrawLine(linePen, previous.Value, point);
                        previous = point;
                    }
                }
            }
        }
    }
}