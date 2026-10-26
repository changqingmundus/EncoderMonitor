using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncoderMonitor
{
    public partial class PrecisionTestForm : Form
    {
        private ComboBox cmbTestMode;
        private NumericUpDown numTolerance;

        // 线性度测试参数
        private NumericUpDown numStartAngle;
        private NumericUpDown numEndAngle;
        private NumericUpDown numAngleStep;

        // 重复性测试参数
        private NumericUpDown numRepeatTargetAngle;
        private NumericUpDown numRepeatCount;

        // 两组参数的布局容器
        private FlowLayoutPanel linearityConfig;
        private FlowLayoutPanel repeatabilityConfig;

        private TextBox txtOperatorId;
        private TextBox txtProductName;
        private TextBox txtProductId;

        private Label lblMeasured;
        private Label lblError;
        private Label lblMaxError;
        private Label lblMeanError;
        private Label lblRepeatability;
        private Label lblResult;
        private Label lblStatus;

        // 右侧信息面板
        private PictureBox picLogo;
        private Label lblTheoryValue;
        private Label lblActualValue;
        private Label lblDeviationValue;
        private Label lblFinalResult;

        // 两个测试各一张表
        private DataGridView dgvLinearity;
        private DataGridView dgvRepeatability;

        // 两个测试各一个波形图（同时常驻显示）
        private ErrorPlotPanel linearityPlot;
        private ErrorPlotPanel repeatabilityPlot;

        // 两套数据独立保存
        private readonly List<Sample> linearitySamples = new List<Sample>();
        private readonly List<Sample> repeatabilitySamples = new List<Sample>();

        // 记录每个模式最近一次运行时的允许误差
        private double linearityTolerance = 0.05;
        private double repeatabilityTolerance = 0.05;

        private readonly Random random = new Random();

        public PrecisionTestForm()
        {
            InitializeComponent();
            Text = "Precision Test";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1150, 820);
            MinimumSize = new Size(900, 650);
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 9F);

            BuildUI();
            this.Load += PrecisionTestForm_Load;   // ← 补上
        }

        private void PrecisionTestForm_Load(object sender, EventArgs e)
        {
            LoadLogo();
        }

        private void LoadLogo()
        {
            try
            {
                picLogo.Image = Properties.Resources.EncoderMonitor;   // ← 直接赋值
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                picLogo.Visible = false;
            }
        }

        private bool IsLinearityMode =>
            cmbTestMode == null || cmbTestMode.SelectedIndex == 0;

        private List<Sample> ActiveSamples =>
            IsLinearityMode ? linearitySamples : repeatabilitySamples;

        private double ActiveTolerance =>
            IsLinearityMode ? linearityTolerance : repeatabilityTolerance;

        private void BuildUI()
        {
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(12)
            };

            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 220));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 115));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 205));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            Controls.Add(root);

            // 1. Test configuration
            txtOperatorId = new TextBox { Width = 80, MaxLength = 50 };
            txtProductName = new TextBox { Width = 180, MaxLength = 100 };
            txtProductId = new TextBox { Width = 120, MaxLength = 50 };

            var configGroup = new GroupBox
            {
                Text = "Test Configuration",
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // 单一 FlowLayoutPanel，字段按顺序排列
            var config = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = true,
                AutoScroll = true,
                Padding = new Padding(0)
            };

            cmbTestMode = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 155
            };
            cmbTestMode.Items.AddRange(new object[]
            {
                "线性度测试",
                "重复性测试"
            });
            cmbTestMode.SelectedIndex = 0;

            numTolerance = new NumericUpDown
            {
                DecimalPlaces = 3,
                Minimum = 0.001M,
                Maximum = 10,
                Value = 0.050M,
                Increment = 0.01M,
                Width = 100
            };

            // ===== 线性度测试参数 =====
            numStartAngle = new NumericUpDown
            {
                DecimalPlaces = 3,
                Minimum = 0,
                Maximum = 359.999M,
                Value = 0,
                Increment = 1,
                Width = 110
            };

            numEndAngle = new NumericUpDown
            {
                DecimalPlaces = 3,
                Minimum = 0.001M,
                Maximum = 359.999M,
                Value = 359.999M,
                Increment = 1,
                Width = 110
            };

            numAngleStep = new NumericUpDown
            {
                DecimalPlaces = 3,
                Minimum = 0.001M,
                Maximum = 360,
                Value = 30,
                Increment = 1,
                Width = 110
            };

            // ===== 重复性测试参数 =====
            numRepeatTargetAngle = new NumericUpDown
            {
                DecimalPlaces = 3,
                Minimum = 0,
                Maximum = 359.999M,
                Value = 180,
                Increment = 0.1M,
                Width = 110
            };

            numRepeatCount = new NumericUpDown
            {
                Minimum = 2,
                Maximum = 10000,
                Value = 100,
                Increment = 1,
                Width = 100
            };

            // 线性度参数区域
            linearityConfig = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,                 // ← 内部永远同一行
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            linearityConfig.Controls.Add(
                Field("起始角度 (°)", numStartAngle));
            linearityConfig.Controls.Add(
                Field("结束角度 (°)", numEndAngle));
            linearityConfig.Controls.Add(
                Field("角度步进 (°)", numAngleStep));

            // 重复性参数区域 —— 内部不换行
            repeatabilityConfig = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,                 // ← 内部永远同一行
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            repeatabilityConfig.Controls.Add(
                Field("固定目标角度 (°)", numRepeatTargetAngle));
            repeatabilityConfig.Controls.Add(
                Field("重复次数", numRepeatCount));

            // ===== 控件顺序 =====
            // 操作者 / 产品信息
            config.Controls.Add(Field("操作者ID", txtOperatorId));
            config.Controls.Add(Field("产品型号", txtProductName));
            config.Controls.Add(Field("产品ID", txtProductId));

            // 测试模式 + 模式相关参数
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

            config.SetFlowBreak(btnExport, true); //换行显示

            config.Controls.Add(linearityConfig);
            config.Controls.Add(repeatabilityConfig);

            // 允许误差
            config.Controls.Add(Field("允许误差 (°)", numTolerance));

            // 操作按钮组（按顺序排列）
            var btnStart = new Button
            {
                Text = "开始测试",
                Width = 130,
                Height = 32,
                Margin = new Padding(12, 24, 6, 6)
            };
            btnStart.Click += (s, e) => RunSimulation();

            var btnReset = new Button
            {
                Text = "重置",
                Width = 80,
                Height = 32,
                Margin = new Padding(6, 24, 6, 6)
            };
            btnReset.Click += (s, e) => ResetResults();

            config.Controls.Add(btnStart);
            config.Controls.Add(btnReset);


            // ===== Test Configuration 分成左右两部分 =====
            var configSplit = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(0)
            };
            // 左 70%，右 30%（按需要调整）
            configSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
            configSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            configSplit.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // 左列：原来的 config（字段顺序保持不变）
            configSplit.Controls.Add(config, 0, 0);

            // 右列：新建一个面板，放你想放的东西
            // ===== 右列：Logo + 数值 + 最终结果 =====
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
                RowCount = 5,
                Padding = new Padding(0)
            };
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));  // Logo
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));  // 理论值
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));  // 实际值
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));  // 偏差
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));  // 最终结果

            // Logo（跨两列，靠左）
            picLogo = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 6, 6)
            };
            rightLayout.Controls.Add(picLogo, 0, 0);
            rightLayout.SetColumnSpan(picLogo, 2);

            // 理论值
            rightLayout.Controls.Add(MakeKeyLabel("理论值"), 0, 1);
            lblTheoryValue = MakeValueLabel("--");
            rightLayout.Controls.Add(lblTheoryValue, 1, 1);

            // 实际值
            rightLayout.Controls.Add(MakeKeyLabel("实际值"), 0, 2);
            lblActualValue = MakeValueLabel("--");
            rightLayout.Controls.Add(lblActualValue, 1, 2);

            // 偏差
            rightLayout.Controls.Add(MakeKeyLabel("偏差"), 0, 3);
            lblDeviationValue = MakeValueLabel("--");
            rightLayout.Controls.Add(lblDeviationValue, 1, 3);

            // 最终结果（跨两列，大号显示）
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

            // ★ 关键：把 configSplit 装回 configGroup，再把 configGroup 加到 root
            configGroup.Controls.Add(configSplit);
            root.Controls.Add(configGroup, 0, 0);

            // 2. Summary cards
            var summary = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 6,
                RowCount = 1,
                Padding = new Padding(0, 5, 0, 5)
            };

            for (int i = 0; i < 6; i++)
                summary.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100f / 6));

            lblMeasured = AddMetric(summary, 0, "实测值", "--");
            lblError = AddMetric(summary, 1, "偏差值", "--");
            lblMaxError = AddMetric(summary, 2, "最大绝对偏差", "--");
            lblMeanError = AddMetric(summary, 3, "平均绝对偏差", "--");
            lblRepeatability = AddMetric(summary, 4, "重复性", "--");
            lblResult = AddMetric(summary, 5, "结果", "N/A");

            root.Controls.Add(summary, 0, 1);

            // 3. Error plots —— 两个波形图并排常驻显示
            var plotsPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(0)
            };
            plotsPanel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));
            plotsPanel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));
            plotsPanel.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            var linearityPlotGroup = new GroupBox
            {
                Text = "Error Curve - 线性度 (°)",
                Dock = DockStyle.Fill,
                Padding = new Padding(8),
                Margin = new Padding(0, 0, 4, 0)
            };
            linearityPlot = new ErrorPlotPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            linearityPlotGroup.Controls.Add(linearityPlot);
            plotsPanel.Controls.Add(linearityPlotGroup, 0, 0);

            var repeatabilityPlotGroup = new GroupBox
            {
                Text = "Error Curve - 重复性 (°)",
                Dock = DockStyle.Fill,
                Padding = new Padding(8),
                Margin = new Padding(4, 0, 0, 0)
            };
            repeatabilityPlot = new ErrorPlotPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            repeatabilityPlotGroup.Controls.Add(repeatabilityPlot);
            plotsPanel.Controls.Add(repeatabilityPlotGroup, 1, 0);

            root.Controls.Add(plotsPanel, 0, 2);

            // 4. Sample records —— 两个表格并排常驻显示
            var recordsPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(0)
            };
            recordsPanel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));
            recordsPanel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));
            recordsPanel.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            var linearityRecordsGroup = new GroupBox
            {
                Text = "线性度测试记录（Linearity）",
                Dock = DockStyle.Fill,
                Padding = new Padding(8),
                Margin = new Padding(0, 0, 4, 0)
            };
            dgvLinearity = new DataGridView();
            SetupSampleGrid(dgvLinearity);
            linearityRecordsGroup.Controls.Add(dgvLinearity);
            recordsPanel.Controls.Add(linearityRecordsGroup, 0, 0);

            var repeatabilityRecordsGroup = new GroupBox
            {
                Text = "重复性测试记录（Repeatability）",
                Dock = DockStyle.Fill,
                Padding = new Padding(8),
                Margin = new Padding(4, 0, 0, 0)
            };
            dgvRepeatability = new DataGridView();
            SetupSampleGrid(dgvRepeatability);
            repeatabilityRecordsGroup.Controls.Add(dgvRepeatability);
            recordsPanel.Controls.Add(repeatabilityRecordsGroup, 1, 0);

            root.Controls.Add(recordsPanel, 0, 3);

            lblStatus = new Label
            {
                Text = "Ready - simulation mode; no hardware connected",
                Dock = DockStyle.Bottom,
                Height = 24,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.DimGray
            };

            Controls.Add(lblStatus);
            lblStatus.BringToFront();

            cmbTestMode.SelectedIndexChanged += (s, e) =>
            {
                UpdateTestModeUI();
                UpdateSummary();
            };

            UpdateTestModeUI();
        }

        private static Label MakeKeyLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 9F)
            };
        }

        private static Label MakeValueLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Black
            };
        }

        private static void SetupSampleGrid(DataGridView grid)
        {
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
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

            linearityConfig.Visible = isLinearity;
            repeatabilityConfig.Visible = !isLinearity;
        }

        private static Control Field(string title, Control input)
        {
            const int horizontalPadding = 8;   // 左右各 4px
            const int labelHeight = 23;

            var panel = new Panel
            {
                Width = input.Width + horizontalPadding,   // ← 自动跟随输入控件宽度
                Height = 60,
                Margin = new Padding(4)
            };

            var label = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = labelHeight
            };

            input.Location = new Point(horizontalPadding / 2, 25);
            panel.Controls.Add(input);
            panel.Controls.Add(label);

            return panel;
        }

        private static Label AddMetric(
            TableLayoutPanel table,
            int column,
            string title,
            string initialValue)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(3)
            };

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
                Text = initialValue,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold)
            };

            card.Controls.Add(valueLabel);
            card.Controls.Add(titleLabel);
            table.Controls.Add(card, column, 0);

            return valueLabel;
        }

        private void RunSimulation()
        {
            bool isLinearity = IsLinearityMode;
            var list = isLinearity ? linearitySamples : repeatabilitySamples;
            var grid = isLinearity ? dgvLinearity : dgvRepeatability;

            var references = BuildReferences(isLinearity);
            if (references == null)
                return;

            double tolerance = (double)numTolerance.Value;
            if (isLinearity)
                linearityTolerance = tolerance;
            else
                repeatabilityTolerance = tolerance;

            list.Clear();
            grid.Rows.Clear();

            for (int i = 0; i < references.Count; i++)
            {
                double reference = references[i];

                // Demo data only; not from an encoder.
                double error = (random.NextDouble() - 0.5)
                               * tolerance * 1.4;

                double measured = reference + error;
                measured = (measured + 360.0) % 360.0;

                double wrappedError = measured - reference;
                if (wrappedError > 180.0)
                    wrappedError -= 360.0;
                else if (wrappedError < -180.0)
                    wrappedError += 360.0;

                var sample = new Sample
                {
                    Index = i + 1,
                    Reference = reference,
                    Measured = measured,
                    Error = wrappedError,
                    Passed = Math.Abs(wrappedError) <= tolerance
                };

                list.Add(sample);

                grid.Rows.Add(
                    sample.Index,
                    sample.Reference.ToString("F3"),
                    sample.Measured.ToString("F3"),
                    sample.Error.ToString("+0.000;-0.000;0.000"),
                    sample.Passed ? "PASS" : "FAIL");
            }

            UpdateSummary();
            UpdatePlot();

            lblStatus.Text = isLinearity
                ? $"线性度测试完成：共 {list.Count} 个角度位置"
                : $"重复性测试完成：共 {list.Count} 次重复测量";
        }

        private List<double> BuildReferences(bool isLinearity)
        {
            var references = new List<double>();

            if (isLinearity)
            {
                double start = (double)numStartAngle.Value;
                double end = (double)numEndAngle.Value;
                double step = (double)numAngleStep.Value;

                if (end < start)
                {
                    MessageBox.Show(
                        "结束角度必须大于或等于起始角度。",
                        "参数错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return null;
                }

                if (step <= 0)
                {
                    MessageBox.Show(
                        "角度步进必须大于 0。",
                        "参数错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return null;
                }

                int pointCount =
                    (int)Math.Floor((end - start) / step + 1e-9) + 1;

                if (pointCount > 50000)
                {
                    MessageBox.Show(
                        $"按当前参数将生成 {pointCount} 个测试点，" +
                        "超过 50000 上限，请增大步进或缩小范围。",
                        "参数错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return null;
                }

                for (int i = 0; i < pointCount; i++)
                    references.Add(start + i * step);
            }
            else
            {
                double target = (double)numRepeatTargetAngle.Value;
                int count = (int)numRepeatCount.Value;

                for (int i = 0; i < count; i++)
                    references.Add(target);
            }

            return references;
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
        }

        private void UpdatePlot()
        {
            linearityPlot.Samples = linearitySamples;
            linearityPlot.Tolerance = linearityTolerance;
            linearityPlot.Invalidate();

            repeatabilityPlot.Samples = repeatabilitySamples;
            repeatabilityPlot.Tolerance = repeatabilityTolerance;
            repeatabilityPlot.Invalidate();
        }

        private void ResetResults()
        {
            linearitySamples.Clear();
            repeatabilitySamples.Clear();
            dgvLinearity.Rows.Clear();
            dgvRepeatability.Rows.Clear();

            linearityTolerance = 0.05;
            repeatabilityTolerance = 0.05;

            UpdateSummary();
            UpdatePlot();

            lblStatus.Text = "Results cleared";
        }

        private void ExportCsv()
        {
            bool isLinearity = IsLinearityMode;
            var list = isLinearity ? linearitySamples : repeatabilitySamples;

            if (list.Count == 0)
            {
                MessageBox.Show(
                    isLinearity
                        ? "线性度测试暂无数据可导出。"
                        : "重复性测试暂无数据可导出。",
                    "Precision Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.FileName = isLinearity
                    ? "LinearityTest.csv"
                    : "RepeatabilityTest.csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                using (var writer = new StreamWriter(
                    dialog.FileName, false, Encoding.UTF8))
                {
                    writer.WriteLine(
                        "Index,ReferenceAngle,MeasuredAngle,Error,Status");

                    foreach (var sample in list)
                    {
                        writer.WriteLine(string.Join(",",
                            sample.Index,
                            sample.Reference.ToString(
                                "F6", CultureInfo.InvariantCulture),
                            sample.Measured.ToString(
                                "F6", CultureInfo.InvariantCulture),
                            sample.Error.ToString(
                                "F6", CultureInfo.InvariantCulture),
                            sample.Passed ? "PASS" : "FAIL"));
                    }
                }

                MessageBox.Show("CSV exported successfully.");
            }
        }

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
            public IList<Sample> Samples { get; set; }
                = new List<Sample>();

            public double Tolerance { get; set; } = 0.05;

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                Graphics g = e.Graphics;
                g.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int left = 55;
                int right = Width - 15;
                int top = 15;
                int bottom = Height - 30;

                if (right <= left || bottom <= top)
                    return;

                using (var axisPen = new Pen(Color.Gray, 1))
                using (var gridPen = new Pen(Color.LightGray, 1))
                using (var linePen = new Pen(Color.Teal, 2))
                using (var zeroPen = new Pen(Color.Gray, 1))
                using (var font = new Font("Segoe UI", 8F))
                using (var brush = new SolidBrush(Color.DimGray))
                {
                    g.DrawLine(axisPen, left, top, left, bottom);
                    g.DrawLine(axisPen, left, bottom, right, bottom);

                    g.DrawLine(zeroPen, left, (top + bottom) / 2,
                        right, (top + bottom) / 2);

                    g.DrawString("+Tolerance", font, brush, 2, top);
                    g.DrawString("0", font, brush, 25,
                        (top + bottom) / 2 - 7);
                    g.DrawString("-Tolerance", font, brush, 2, bottom - 12);

                    if (Samples == null || Samples.Count == 0)
                    {
                        g.DrawString(
                            "暂无数据 - 点击“开始测试”",
                            font, brush, left + 10, top + 10);
                        return;
                    }

                    double range = Math.Max(Tolerance * 1.2, 0.001);

                    PointF? previous = null;

                    for (int i = 0; i < Samples.Count; i++)
                    {
                        double x = left +
                            (right - left) * i /
                            (double)Math.Max(1, Samples.Count - 1);

                        double normalized =
                            Samples[i].Error / range;

                        normalized = Math.Max(-1.0,
                            Math.Min(1.0, normalized));

                        float y = (float)(
                            (top + bottom) / 2.0 -
                            normalized * (bottom - top) / 2.0);

                        var point = new PointF((float)x, y);

                        if (previous.HasValue)
                        {
                            g.DrawLine(linePen, previous.Value, point);
                        }

                        previous = point;
                    }
                }
            }
        }
    }
}