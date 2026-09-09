using Encoder.Core.Communication;
using Encoder.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderModbusTool
{
    public partial class ModbusMainForm : Form
    {
        public ModbusMainForm()
        {
            InitializeComponent();

            tTstatus.AutoPopDelay = 10000;
            tTstatus.InitialDelay = 500;
            tTstatus.ReshowDelay = 100;
            tTstatus.ShowAlways = true;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            freeModeTimer = new System.Windows.Forms.Timer();

            freeModeTimer.Interval = 10;

            freeModeTimer.Tick += (s, e) =>
            {
                if (freeModeEnabled && isFreeModeReceiving)
                {
                    ReadFreeModeFromSerial();
                }
            };

            portCheckTimer = new System.Windows.Forms.Timer();
            portCheckTimer.Interval = 1000; // 1秒检测一次
            portCheckTimer.Tick += portCheckTimer_Tick;
        }
        private bool isContinuousReading = false;
        private bool freeModeEnabled = false;   // 是否进入Free Mode
        private bool isFreeModeReceiving = false; // 是否正在接收
        private List<byte> freeModeBuffer = new List<byte>();
        private System.Windows.Forms.Timer freeModeTimer;
        private System.Windows.Forms.Timer portCheckTimer; // 用于检测串口是否异常断开
        private string connectedPortName = "";

        private Task continuousReadTask;
        private CancellationTokenSource continuousCts;
        private Dashboard.UI.DialControl dialControlAngle;
        private CancellationTokenSource scanCts;
        private ModbusMaster modbusMaster;
        private byte currentSlaveId;

        private void ModbusMainForm_Load(object sender, EventArgs e)
        {
            UpdateSerialPortList();
            portCheckTimer.Start();

            dialControlAngle = new Dashboard.UI.DialControl();        //调用角度盘
            elementHostcfgAngle.Child = dialControlAngle;

            cmbBaudRate.SelectedIndex = 3;
            cmbParity.SelectedIndex = 0;

            cmbSingleTurn.SelectedItem = EncoderConfig.SingleTurnBits.ToString();
            cmbMultiTurn.SelectedItem = EncoderConfig.MultiTurnBits.ToString();

            cmbCfgWorkMode.SelectedIndex = 0;
            cmbCfgBaudRate.SelectedIndex = 3;
            cmbCfgParity.SelectedIndex = 0;
            cmbCfgDirection.SelectedIndex = 0;
            cmbCfgOriginPosition.SelectedIndex = 0;
        }

        /*open serial port*/
        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            string portName = cmbPort.Text;

            // 当前正常打开状态
            if (SerialPortManager.IsOpen)
            {
                SetStatus(Properties.AppStrings.ConnectionClosedRescan);
                lblStatus.ForeColor = SystemColors.ControlText;

                // 这是用户主动关闭
                connectedPortName = "";

                CloseSerialPortUI();

                AddSystemLog("INFO", Properties.AppStrings.SerialPortClosed);

                return;
            }

            // 检查串口
            if (cmbPort.SelectedItem == null)
            {
                MessageBox.Show(Properties.AppStrings.PleaseSelectSerialPort);
                return;
            }
            // 波特率
            if (!int.TryParse(cmbBaudRate.Text, out int baudRate))
            {
                MessageBox.Show(Properties.AppStrings.InvalidBaudRate);
                return;
            }
            Parity parity = GetParity();
            try
            {
                bool result = SerialPortManager.OpenPort(portName, baudRate, parity);
                if (result)
                {
                    connectedPortName = portName;

                    btnOpenSerial.Text = Properties.AppStrings.Close;
                    btnOpenSerial.BackColor = Color.FromArgb(46, 125, 50);
                    btnOpenSerial.ForeColor = Color.White;

                    modbusMaster = new ModbusMaster(SerialPortManager.sp);
                    modbusMaster.DataLog += (type, data) =>
                    {
                        AddDataLog(type, data);
                    };

                    cmbPort.Enabled = false;
                    AddSystemLog("PASS", string.Format(Properties.AppStrings.OpenSerialPortSuccess,
                                                       portName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Properties.AppStrings.Prompt,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                AddSystemLog("ERR", ex.Message);
            }
        }
        private void RestartSerialPort()
        {
            if (!SerialPortManager.IsOpen)
                return;

            isContinuousReading = false;
            continuousCts?.Cancel();

            string port = SerialPortManager.sp.PortName;
            if (!int.TryParse(cmbBaudRate.Text, out int baudRate))
            {
                return;
            }
            Parity parity = GetParity();

            AddSystemLog("INFO", "正在更新串口参数...");

            SerialPortManager.ClosePort();
            bool result = SerialPortManager.OpenPort(port, baudRate, parity);

            if (result)
            {
                // 关键：重新绑定ModbusMaster
                modbusMaster = new ModbusMaster(SerialPortManager.sp);
                modbusMaster.DataLog += (type, data) =>
                {
                    AddDataLog(type, data);
                };
                AddSystemLog("PASS", $"串口参数更新成功: {baudRate},{parity}");
            }
            else
            {
                AddSystemLog("ERR", "串口参数更新失败");
            }
        }
        private void CloseSerialPortUI()
        {
            // 停止连续读取
            isContinuousReading = false;
            continuousCts?.Cancel();
            continuousCts = null;

            // 停止 Free Mode
            isFreeModeReceiving = false;
            freeModeTimer?.Stop();

            // 停止方向显示
            directionIndicator1.UpdateDirection(0, 0);

            // 关闭串口
            SerialPortManager.ClosePort();

            // 清掉 Modbus
            modbusMaster = null;

            // 恢复 UI
            cmbPort.Enabled = true;
            cmbBaudRate.Enabled = true;
            cmbParity.Enabled = true;

            btnOpenSerial.Text = "打开串口";
            btnOpenSerial.BackColor = SystemColors.Control;
            btnOpenSerial.ForeColor = SystemColors.ControlText;

            btnReadModbus.BackColor = SystemColors.Control;
            btnReadModbus.Text = "开始读取";

            // 清除当前选择
            cmbPort.SelectedIndex = -1;
            cmbPort.Text = "";
        }
        private Parity GetParity()
        {
            switch (cmbParity.Text)
            {
                case "Odd":
                    return Parity.Odd;

                case "Even":
                    return Parity.Even;

                case "Mark":
                    return Parity.Mark;

                case "Space":
                    return Parity.Space;

                default:
                    return Parity.None;
            }
        }
        private ushort GetBaudRateValue()
        {
            switch (cmbCfgBaudRate.Text)
            {
                case "1200": return 8;
                case "2400": return 7;
                case "4800": return 6;
                case "9600": return 1;
                case "19200": return 2;
                case "38400": return 3;
                case "57600": return 4;
                case "115200": return 5;

                default:
                    return 0xffff;
            }
        }
        private ushort GetDirectionValue()
        {
            switch (cmbCfgDirection.SelectedIndex)
            {
                case 0:
                    return 1;

                case 1:
                    return 2;

                default:
                    return 0xffff;
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void elementHostcfgAngle_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        /* show system log*/
        private void AddSystemLog(string type, string message)
        {
            string log = DateTime.Now.ToString("HH:mm:ss") + " ";

            switch (type)
            {
                case "PASS":
                    log += $"[PASS] {message}";
                    rtbCommLog.SelectionColor = Color.Green;
                    break;

                case "ERR":
                    log += $"[ERR ] {message}";
                    rtbCommLog.SelectionColor = Color.Red;
                    break;

                case "INFO":
                default:
                    log += $"[INFO] {message}";
                    rtbCommLog.SelectionColor = Color.Blue;
                    break;
            }
            rtbCommLog.AppendText(log + Environment.NewLine);
            rtbCommLog.SelectionColor = Color.Black;
            rtbCommLog.ScrollToCaret();
        }
        private void AddDataLog(string type, byte[] data)
        {
            if (rtbDataLog.InvokeRequired)
            {
                rtbDataLog.Invoke(new Action(() =>
                {
                    AddDataLog(type, data);
                }));
                return;
            }
            string hex = BitConverter.ToString(data).Replace("-", " ");
            //string log = $"{DateTime.Now:HH:mm:ss.fff} {type}: {hex}\r\n";
            string log = $"{type}: {hex}\r\n";

            if (type == "TX")
            {
                rtbDataLog.SelectionColor = Color.Black;
            }
            else if (type == "RX")
            {
                rtbDataLog.SelectionColor = Color.Blue;
            }

            rtbDataLog.AppendText(log);
            rtbDataLog.SelectionColor = Color.Black;
            rtbDataLog.ScrollToCaret();
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = text;
            tTstatus.SetToolTip(lblStatus, text);
        }

        private void cmbSingleTurn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSingleTurn.SelectedItem != null)
            {
                EncoderConfig.SingleTurnBits =
                    int.Parse(cmbSingleTurn.SelectedItem.ToString());

                AddSystemLog("INFO", string.Format(Properties.AppStrings.SingleTurnBitsSet,
                                                   EncoderConfig.SingleTurnBits));
            }
        }

        private void cmbMultiTurn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMultiTurn.SelectedItem != null)
            {
                EncoderConfig.MultiTurnBits =
                    int.Parse(cmbMultiTurn.SelectedItem.ToString());

                AddSystemLog("INFO", string.Format(Properties.AppStrings.MultiTurnBitsSet,
                                                   EncoderConfig.MultiTurnBits));
            }
        }

        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPort.SelectedItem != null)
            {
                string selectedPort = cmbPort.SelectedItem.ToString();
            }
        }
        private void cmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            RestartSerialPort();
        }
        private void cmbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            RestartSerialPort();
        }

        /*start scan device*/
        private async void btnScanDevice_Click(object sender, EventArgs e)
        {
            if (modbusMaster == null)
            {
                AddSystemLog("ERR", Properties.AppStrings.PleaseOpenSerialPort);
                return;
            }
            AddSystemLog("INFO", Properties.AppStrings.StartScanDevice);
            btnScanDevice.Enabled = false;
            progressScan.Minimum = 0;
            progressScan.Maximum = 247;
            progressScan.Value = 0;

            scanCts = new CancellationTokenSource();
            ModbusScanner scanner = new ModbusScanner(modbusMaster, scanCts.Token);

            // 订阅扫描进度
            scanner.ScanProgress += value =>
            {
                Invoke(new Action(() =>
                {
                    progressScan.Value = value;

                    AddSystemLog("INFO", string.Format(Properties.AppStrings.ScanningSlaveId, value));
                }));
            };
            int id = await Task.Run(() =>
            {
                return scanner.Scan();
            });
            if (id > 0)
            {
                AddSystemLog("PASS", string.Format(Properties.AppStrings.DeviceFound, id));
                bool ok = await Task.Run(() =>
                {
                    return ReadDeviceConfig((byte)id);
                });
                if (ok)
                {
                    currentSlaveId = (byte)id;
                    SetStatus(string.Format(Properties.AppStrings.EncoderConnected, id));
                    lblStatus.ForeColor = Color.Green;

                    btnScanDevice.Enabled = true;
                }
                else
                {
                    SetStatus(string.Format(Properties.AppStrings.DeviceParameterReadFailed, id));
                    lblStatus.ForeColor = Color.Red;
                    AddSystemLog("ERR", Properties.AppStrings.ReadDeviceParameterFailedWithError);
                    btnScanDevice.Enabled = true;
                }
            }
            else
            {
                AddSystemLog("ERR", Properties.AppStrings.NoDeviceFound);
                SetStatus(string.Format(Properties.AppStrings.EncoderNotFound, id));
                lblStatus.ForeColor = Color.Red;
                btnScanDevice.Enabled = true;
            }
            progressScan.Value = 247;
        }
        private void btnStopScan_Click(object sender, EventArgs e)
        {
            if (scanCts != null)
            {
                scanCts.Cancel();
                AddSystemLog("INFO", Properties.AppStrings.StopScanning);
            }
        }

        private void btnCfgClearlog_Click(object sender, EventArgs e)
        {
            rtbDataLog.Clear();
            AddSystemLog("INFO", Properties.AppStrings.LogCleared);
        }

        private bool ReadDeviceConfig(byte slaveId)
        {
            try
            {
                ushort workMode = modbusMaster.ReadHoldingRegisters(slaveId, ModbusRegisterMap.Protocol, 1)[0];
                ushort slaveid = modbusMaster.ReadHoldingRegisters(slaveId, ModbusRegisterMap.SlaveId, 1)[0];
                ushort baud = modbusMaster.ReadHoldingRegisters(slaveId, ModbusRegisterMap.BaudRate, 1)[0];
                ushort parity = modbusMaster.ReadHoldingRegisters(slaveId, ModbusRegisterMap.Parity, 1)[0];
                ushort direction = modbusMaster.ReadHoldingRegisters(slaveId, ModbusRegisterMap.CountDirection, 1)[0];
                ushort uploadtime = modbusMaster.ReadHoldingRegisters(slaveId, ModbusRegisterMap.ReportInterval, 1)[0];
                ushort originposition = modbusMaster.ReadHoldingRegisters(slaveId, ModbusRegisterMap.ZeroPositionReference, 1)[0];
                // 更新UI
                this.Invoke(new Action(() =>
                {
                    cmbCfgWorkMode.Text = GetWorkModeText(workMode);
                    txtCfgSlaveID.Text = slaveid.ToString();
                    cmbCfgBaudRate.Text = GetBaudRateText(baud);
                    cmbCfgDirection.Text = GetDirectionText(direction);
                    cmbCfgParity.Text = GetParityText(parity);
                    txtCfgUploadTime.Text = uploadtime.ToString();
                    cmbCfgOriginPosition.Text = GetOriginPositionText(originposition);
                    AddSystemLog("PASS", Properties.AppStrings.DeviceParameterReadComplete);
                }));

                return true;
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format 
                            (Properties.AppStrings.ReadDeviceParameterFailedWithError, ex.Message));
                return false;
            }
        }
        private DeviceData ReadDeviceData()
        {
            if (SerialPortManager.sp == null ||
                !SerialPortManager.sp.IsOpen)
            {
                return null;
            }

            DeviceData data = new DeviceData();

            // =========================================================
            // 读取 Encoder Value + Rotation Direction + Speed
            // =========================================================

            ushort startAddress = ModbusRegisterMap.EncoderValueStart;

            ushort registerCount = (ushort)(ModbusRegisterMap.EncoderValueRegisterCount + 2);

            ushort[] regs = modbusMaster.ReadHoldingRegisters(
                currentSlaveId,
                startAddress,
                registerCount);

            if (regs == null || regs.Length < registerCount)
                return null;


            // =========================================================
            // 组合 Encoder Value
            // =========================================================

            ulong raw = 0;

            for (int i = 0;
                 i < ModbusRegisterMap.EncoderValueRegisterCount;
                 i++)
            {
                raw <<= 16;
                raw |= regs[i];
            }

            data.EncoderValue = raw;


            // =========================================================
            // 根据当前单圈位数拆分 SingleTurn / MultiTurn
            // =========================================================

            ulong singleResolution =
                1UL << EncoderConfig.SingleTurnBits;

            data.MultiTurn =
                raw / singleResolution;

            data.SingleTurn =
                raw % singleResolution;


            // =========================================================
            // Rotation Direction
            // =========================================================

            int directionIndex =
                ModbusRegisterMap.EncoderValueRegisterCount;

            data.Direction =
                (byte)regs[directionIndex];


            // =========================================================
            // Speed
            // =========================================================

            int speedIndex =
                ModbusRegisterMap.EncoderValueRegisterCount + 1;

            data.Speed =
                regs[speedIndex];


            return data;
        }

        private string GetWorkModeText(ushort value)
        {
            switch (value)
            {
                case 1:
                    return "ModBus RTU";

                case 2:
                    return "FreeMode";

                default:
                    return "Unknown";
            }
        }
        private string GetBaudRateText(ushort value)
        {
            switch (value)
            {
                case 8: return "1200";
                case 7: return "2400";
                case 6: return "4800";
                case 1: return "9600";
                case 2: return "19200";
                case 3: return "38400";
                case 4: return "57600";
                case 5: return "115200";

                default:
                    return "Unknown";
            }
        }
        private string GetParityText(ushort value)
        {
            switch (value)
            {
                case 1:
                    return "None";

                case 2:
                    return "Odd";

                case 3:
                    return "Even";

                default:
                    return "Unknown";
            }
        }
        private string GetOriginPositionText(ushort value)
        {
            switch (value)
            {
                case 1:
                    return "中间值";

                case 2:
                    return "0值";

                default:
                    return "Unknown";
            }
        }
        private string GetDirectionText(ushort value)
        {
            switch (value)
            {
                case 1:
                    return "CW(顺时针递增)";
                case 2:
                    return "CCW(逆时针递增)";
                default:
                    return "Unknown";
            }
        }

        private void btnCfgChangeMode_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            if (cmbCfgWorkMode.SelectedItem == null)
            {
                AddSystemLog("ERR", Properties.AppStrings.InvalidWorkMode);
                return;
            }

            ushort mode;
            switch (cmbCfgWorkMode.Text)
            {
                case "ModBus RTU":
                    mode = 1;
                    break;

                case "FreeMode":
                    mode = 2;
                    break;

                default:
                    AddSystemLog("ERR", Properties.AppStrings.UnknownMode);
                    return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.Protocol, mode);
                AddSystemLog("PASS", string.Format(Properties.AppStrings.WorkModeChangeSuccess,
                                                   cmbCfgWorkMode.Text)); ;

                SetStatus(Properties.AppStrings.FreeModeWarning);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.WorkModeChangeException,
                                                  ex.Message));
            }
        }

        private void btnCfgChangeSlaveID_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            if (!byte.TryParse(txtCfgSlaveID.Text, out byte newId))
            {
                AddSystemLog("ERR", Properties.AppStrings.InvalidSlaveIdFormat);
                return;
            }
            if (newId < 1 || newId > 127)
            {
                AddSystemLog("ERR", Properties.AppStrings.SlaveIdOutOfRange);
                return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.SlaveId, newId);
                AddSystemLog("PASS", string.Format(Properties.AppStrings.SlaveIdChangeSuccess, newId));
                SetStatus(Properties.AppStrings.ReconnectRequired);

                currentSlaveId = newId;   // 更新当前设备ID
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.SlaveIdChangeException,
                                                  ex.Message));
            }
        }
        private void btnCfgChangeBaudRate_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            if (cmbCfgBaudRate.SelectedItem == null)
            {
                AddSystemLog("ERR", Properties.AppStrings.PleaseSelectBaudRate);
                return;
            }
            ushort baudrate = GetBaudRateValue();
            if (baudrate == 0xffff)
            {
                AddSystemLog("ERR", Properties.AppStrings.InvalidBaudRate);
                return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.BaudRate, baudrate);
                AddSystemLog("PASS", string.Format(Properties.AppStrings.BaudRateChangeSuccess,
                                                   cmbCfgBaudRate.Text));
                SetStatus(Properties.AppStrings.ReconnectRequired);
                lblStatus.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.BaudRateChangeException,
                                                  ex.Message));
            }
        }
        private void btnCfgChangeParity_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            if (cmbCfgParity.SelectedItem == null)
            {
                AddSystemLog("ERR", "校验位为空");
                return;
            }
            ushort parityValue;
            switch (cmbCfgParity.Text)
            {
                case "None":
                    parityValue = 1;
                    break;
                case "Odd":
                    parityValue = 2;
                    break;
                case "Even":
                    parityValue = 3;
                    break;
                default:
                    AddSystemLog("ERR", "未知校验方式");
                    return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.Parity, parityValue);
                AddSystemLog("PASS", $"校验位修改成功: {cmbCfgParity.Text}");
                SetStatus(Properties.AppStrings.ReconnectRequired);
                lblStatus.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", "修改校验位异常: " + ex.Message);
            }
        }
        private void btnCfgChangeDirection_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            if (cmbCfgDirection.SelectedItem == null)
            {
                AddSystemLog("ERR", "请选择递增方向");
                return;
            }
            ushort direction = GetDirectionValue();
            if (direction == 0xffff)
            {
                AddSystemLog("ERR", "递增方向错误");
                return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.CountDirection, direction);
                AddSystemLog("PASS", $"递增方向修改成功: {cmbCfgDirection.Text}");
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", "修改递增方向异常: " + ex.Message);
            }
        }
        private void btnCfgChangeUploadTime_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.PleaseOpenSerialPort);
                return;
            }
            if (txtCfgUploadTime.Text == null)
            {
                AddSystemLog("ERR", "上传时间为空");
                return;
            }
            if (!ushort.TryParse(txtCfgUploadTime.Text, out ushort uploadTime))
            {
                AddSystemLog("ERR", "上传时间格式错误");
                return;
            }
            if (uploadTime < 1 || uploadTime > 3000)
            {
                AddSystemLog("ERR", "上传时间超出范围");
                return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.ReportInterval, uploadTime);
                AddSystemLog("PASS", $"上传时间修改成功: {uploadTime}");
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", "修改上传时间异常: " + ex.Message);
            }
        }
        private void btnCfgChangeOrigin_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            if (cmbCfgOriginPosition.SelectedItem == null)
            {
                AddSystemLog("ERR", "请选择原点位置");
                return;
            }
            ushort originPosition;
            switch (cmbCfgOriginPosition.SelectedIndex)
            {
                case 0:
                    originPosition = 1;
                    break;
                case 1:
                    originPosition = 2;
                    break;
                default:
                    AddSystemLog("ERR", "未知原点位置");
                    return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.ZeroPositionReference, originPosition);
                AddSystemLog("PASS", $"原点位置修改成功: {cmbCfgOriginPosition.Text}");
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", "修改原点位置异常: " + ex.Message);
            }
        }
        private void btnCfgResetOrigin_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.EncoderZero, 0xFF);
                AddSystemLog("PASS", "原点位置已重置");
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", "重置原点位置异常: " + ex.Message);
            }
        }

        private void portCheckTimer_Tick(object sender, EventArgs e)
        {
            string[] currentPorts = SerialPort.GetPortNames();

            // 当前存在连接记录
            if (!string.IsNullOrEmpty(connectedPortName))
            {
                // SerialPort 已经断开
                if (SerialPortManager.sp == null ||
                    !SerialPortManager.sp.IsOpen)
                {
                    string lostPort = connectedPortName;

                    AddSystemLog(
                        "ERR",
                        $"检测到串口 {lostPort} 已断开");

                    lblStatus.Text = "串口丢失，请重新连接编码器！";
                    lblStatus.ForeColor = Color.Red;

                    connectedPortName = "";

                    CloseSerialPortUI();

                    UpdateSerialPortList();

                    return;
                }

                // 正常连接状态，不刷新 ComboBox
                return;
            }

            // 没有打开串口，刷新列表
            UpdateSerialPortList();
        }
        private void UpdateSerialPortList()
        {
            string[] currentPorts = SerialPort.GetPortNames();

            string selectedPort = cmbPort.Text;

            cmbPort.BeginUpdate();

            try
            {
                cmbPort.Items.Clear();

                foreach (string port in currentPorts.Distinct())
                {
                    cmbPort.Items.Add(port);
                }

                if (!string.IsNullOrEmpty(selectedPort) &&
                    currentPorts.Contains(selectedPort))
                {
                    cmbPort.SelectedItem = selectedPort;
                }
                else
                {
                    cmbPort.SelectedIndex = -1;
                    cmbPort.Text = "";
                }
            }
            finally
            {
                cmbPort.EndUpdate();
            }
        }
        private async void btnReadModbus_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.PleaseOpenSerialPort);
                return;
            }

            if (freeModeEnabled)
            {
                // 连续接收模式
                if (cbContinuous.Checked)
                {
                    if (!isFreeModeReceiving)
                    {
                        isFreeModeReceiving = true;

                        freeModeTimer.Start();

                        btnReadModbus.FlatStyle = FlatStyle.Flat;
                        btnReadModbus.FlatAppearance.BorderSize = 1;
                        btnReadModbus.FlatAppearance.BorderColor = Color.FromArgb(160, 160, 160);
                        btnReadModbus.BackColor = Color.FromArgb(240, 200, 50);
                        btnReadModbus.ForeColor = Color.Black;
                        btnReadModbus.Text = "停止接收";

                        AddSystemLog("INFO", "开始Free Mode连续接收");
                    }
                    else
                    {
                        isFreeModeReceiving = false;

                        freeModeTimer.Stop();

                        btnReadModbus.BackColor = SystemColors.Control;
                        btnReadModbus.Text = "开始接收";
                        AddSystemLog("INFO", "停止Free Mode接收");
                    }

                    return;
                }

                try
                {
                    ReadFreeModeOnce();

                    btnReadModbus.Text = "开始接收";

                    AddSystemLog("PASS", "Free Mode单次读取完成");
                }
                catch (Exception ex)
                {
                    AddSystemLog("ERR", ex.Message);
                }
                return;
            }

            if (currentSlaveId == 0)
            {
                AddSystemLog("ERR", Properties.AppStrings.InvalidSlaveIdFormat);
                return;
            }
            if (cbContinuous.Checked)
            {
                if (!isContinuousReading)
                {
                    isContinuousReading = true;

                    modbusMaster.EnableDataLog = false;

                    continuousCts = new CancellationTokenSource();
                    continuousReadTask = ContinuousReadLoop(continuousCts.Token);

                    btnReadModbus.BackColor = Color.Yellow;
                    btnReadModbus.Text = "停止读取";
                    AddSystemLog("INFO", "开始连续读取");
                }
                else
                {
                    isContinuousReading = false;
                    continuousCts?.Cancel();
                    btnReadModbus.BackColor = SystemColors.Control;
                    directionIndicator1.UpdateDirection(0, 0);
                    btnReadModbus.Text = "读取数据";
                    AddSystemLog("INFO", "停止连续读取");
                }

                return;
            }
            try
            {
                DeviceData data = await Task.Run(() =>
                {
                    return ReadDeviceData();
                });
                if (data == null)
                {
                    AddSystemLog("ERR", "读取设备数据失败");
                    return;
                }
                UpdateDeviceUI(data);
                AddSystemLog("PASS", "读取编码器数据成功");
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", ex.Message);
            }
        }
        private async Task ContinuousReadLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    DeviceData data = await Task.Run(() =>
                    {
                        return ReadDeviceData();
                    });

                    // ReadDeviceData 执行期间可能已经点击了停止
                    if (token.IsCancellationRequested)
                        break;

                    if (data != null)
                    {
                        Invoke(new Action(() =>
                        {
                            UpdateDeviceUI(data);
                        }));
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    if (token.IsCancellationRequested)
                        break;

                    Invoke(new Action(() =>
                    {
                        AddSystemLog("ERR", ex.Message);
                    }));

                    try
                    {
                        await Task.Delay(50, token);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
        }
        private async Task StopContinuousReadingAsync()
        {
            // 先关闭日志，防止最后一次通信产生 RX
            modbusMaster.EnableDataLog = false;

            isContinuousReading = false;

            directionIndicator1.UpdateDirection(0, 0);

            // 请求停止
            if (continuousCts != null)
            {
                continuousCts.Cancel();
            }

            // 等待当前 ContinuousReadLoop 完全结束
            if (continuousReadTask != null)
            {
                try
                {
                    await continuousReadTask;
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    AddSystemLog("ERR", string.Format(Properties.AppStrings.StopContinuousReadFailed,
                                                      ex.Message));
                }

                continuousReadTask = null;
            }

            if (continuousCts != null)
            {
                continuousCts.Dispose();
                continuousCts = null;
            }

            btnReadModbus.BackColor = SystemColors.Control;
            btnReadModbus.Text = Properties.AppStrings.StartReading;

            // 确认连续读取彻底结束后，再恢复日志
            modbusMaster.EnableDataLog = true;

            AddSystemLog("INFO", Properties.AppStrings.StopContinuousRead);
        }

        private async void cbContinuous_CheckedChanged(object sender, EventArgs e)
        {
            if (cbContinuous.Checked)
            {
                AddSystemLog("INFO", Properties.AppStrings.ContinuousReadEnabled);
            }
            else
            {
                AddSystemLog("INFO", Properties.AppStrings.ContinuousReadDisabled);
                if (isContinuousReading)
                {
                    isContinuousReading = false;
                    directionIndicator1.UpdateDirection(0, 0);
                    continuousCts?.Cancel();
                    await StopContinuousReadingAsync();
                    btnReadModbus.BackColor = SystemColors.Control;
                    btnReadModbus.Text = Properties.AppStrings.StartReading;
                }
            }
        }

        private void UpdateDeviceUI(DeviceData data)
        {
            if (data == null)
                return;

            tbCfgEncoderValue.Text = data.EncoderValue.ToString();
            tbCfgMultiTurn.Text = data.MultiTurn.ToString();
            tbCfgSingleTurn.Text = data.SingleTurn.ToString();
            lblCfgSpeed.Text = data.Speed.ToString() + " rpm";
            switch (data.Direction)
            {
                case 0:
                    lblCfgRtDirection.Text = "STOP";
                    break;

                case 1:
                    lblCfgRtDirection.Text = "CW";
                    break;

                case 2:
                    lblCfgRtDirection.Text = "CCW";
                    break;

                default:
                    lblCfgRtDirection.Text = "UNKNOWN";
                    break;
            }

            uint resolution = 1U << EncoderConfig.SingleTurnBits;
            double angle = data.SingleTurn * 360.0 / resolution;

            dialControlAngle.Angle = angle;
            textBox_cfgBinary.Text = Convert.ToString((long)data.SingleTurn, 2)
                                    .PadLeft(EncoderConfig.SingleTurnBits, '0');
            textBox_cfgResolution.Text = $"{data.SingleTurn} / {resolution - 1}";
            textBox_cfgAngle.Text = angle.ToString("000.000") + " deg";
            tbCfgAngle.Text = angle.ToString("000.000") + " deg";

            directionIndicator1.UpdateDirection(data.Direction, data.Speed);

        }

        private async void btnRestartRead_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            if (currentSlaveId == 0)
            {
                AddSystemLog("ERR", Properties.AppStrings.InvalidSlaveIdFormat);
                return;
            }
            try
            {
                bool ok = await Task.Run(() =>
                {
                    return ReadDeviceConfig(currentSlaveId);
                });

                if (ok)
                {
                    AddSystemLog("PASS", Properties.AppStrings.ParameterReadAgainSuccess);

                }
                else
                {
                    AddSystemLog("ERR", Properties.AppStrings.ReadDeviceParameterFailedWithError);
                }
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", ex.Message);
            }
        }

        private void btnChangeMode_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                AddSystemLog("ERR", Properties.AppStrings.SerialPortNotOpen);
                return;
            }
            try
            {
                if (freeModeEnabled)
                {
                    freeModeEnabled = false;
                    isFreeModeReceiving = false;
                    freeModeTimer.Stop();

                    freeModeBuffer.Clear();

                    btnChangeMode.Text = Properties.AppStrings.EnableFreeMode;
                    btnChangeMode.BackColor = SystemColors.Control;

                    btnReadModbus.Text = Properties.AppStrings.StartReading;
                    btnReadModbus.BackColor = SystemColors.Control;

                    AddSystemLog("INFO", Properties.AppStrings.ExitFreeMode);

                    return;
                }

                freeModeEnabled = true;
                SerialPortManager.sp.DiscardInBuffer();
                freeModeBuffer.Clear();

                btnChangeMode.Text = Properties.AppStrings.DisableFreeMode;
                btnChangeMode.BackColor = Color.Green;

                btnReadModbus.Text = Properties.AppStrings.StartReceiving;

                AddSystemLog("INFO", Properties.AppStrings.EnterFreeMode);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.FreeModeSwitchFailed,
                                                  ex.Message));
            }
        }
        private void ReadFreeModeFromSerial()
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
                return;

            int cnt = SerialPortManager.sp.BytesToRead;
            if (cnt <= 0)
                return;

            byte[] rx = new byte[cnt];
            SerialPortManager.sp.Read(rx, 0, cnt);
            freeModeBuffer.AddRange(rx);

            ParseFreeModeBuffer();
        }
        private void ParseFreeModeBuffer()
        {
            while (true)
            {
                // 找 AB
                int start = freeModeBuffer.IndexOf(0xAB);
                if (start < 0)
                {
                    freeModeBuffer.Clear();
                    return;
                }
                // 移除前面垃圾
                if (start > 0)
                {
                    freeModeBuffer.RemoveRange(0, start);
                }
                // 至少要有 AB CD LEN
                if (freeModeBuffer.Count < 3)
                    return;
                // 確認 CD
                if (freeModeBuffer[1] != 0xCD)
                {
                    freeModeBuffer.RemoveAt(0);
                    continue;
                }
                // =====================================================
                // LEN 定义：
                // LEN = LEN字段自身1字节 + DATA长度
                // =====================================================

                int lenField = freeModeBuffer[2];

                if (lenField < 1)
                {
                    freeModeBuffer.RemoveAt(0);
                    continue;
                }

                // 整帧：
                //
                // AB CD + LEN + DATA + SUM + XOR + END
                //
                // 其中 LEN 已经包含 LEN 自己
                //
                // 所以：
                // frameLen = 2 + lenField + 3
                //
                // 16bit: 2 + 5 + 3 = 10
                // 32bit: 2 + 9 + 3 = 14
                int frameLen = 2 + lenField + 3;

                // 還沒收完整
                if (freeModeBuffer.Count < frameLen)
                    return;
                // 取一幀
                byte[] frame = freeModeBuffer.Take(frameLen).ToArray();
                // 移除已處理
                freeModeBuffer.RemoveRange(0, frameLen);
                // 確認尾巴
                if (frame[frame.Length - 1] != 0x3D)
                    continue;
                // 這裡才是真正一幀
                // 根据 Enable32 选择解析方式
                if (EncoderConfig.Is32BitMode)
                {
                    ReadFreeMode32Bit(frame);
                }
                else
                {
                    ReadFreeMode16Bit(frame);
                }
            }
        }
        private void ReadFreeMode16Bit(byte[] rx)
        {
            if (rx == null || rx.Length < 8)
                return;

            if (rx[0] != EncoderConfig.Modbus.FreeData1 ||
                rx[1] != EncoderConfig.Modbus.FreeData2)
                return;

            if (rx[rx.Length - 1] != EncoderConfig.Modbus.FreeData3)
                return;

            byte recvSum = rx[rx.Length - 3];
            byte recvXor = rx[rx.Length - 2];

            byte sum = 0;
            byte xor = 0;

            for (int i = 2; i < rx.Length - 3; i++)
            {
                sum += rx[i];
                xor ^= rx[i];
            }
            if (sum != recvSum ||
                xor != recvXor)
            {
                AddSystemLog("ERR", Properties.AppStrings.FreeModeCheckError);
                return;
            }

            byte dataLen = rx[2];

            int multiBits = EncoderConfig.MultiTurnBits;
            int singleBits = EncoderConfig.SingleTurnBits;
            int multiBytes = multiBits > 16 ? 3 : 2;
            int singleBytes = singleBits > 16 ? 3 : 2;
            int expectedMinLen = 3 + multiBytes + singleBytes + 3;

            int encoderDataLen = multiBytes + singleBytes;
            // 长度字段 = 自身1字节 + 编码器数据长度
            int expectedDataLen = 1 + encoderDataLen;

            if (dataLen != expectedDataLen)
            {
                AddSystemLog("ERR",
                    $"FreeMode Length Error: RX=0x{dataLen:X2}, Expected=0x{expectedDataLen:X2}");
                return;
            }

            if (rx.Length < expectedMinLen)
                return;

            int index = 3;
            uint multiturn = 0;
            if (multiBytes == 3)
            {
                multiturn = ((uint)rx[index] << 16) | ((uint)rx[index + 1] << 8) | rx[index + 2];
                index += 3;
            }
            else
            {
                multiturn = ((uint)rx[index] << 8) | rx[index + 1];
                index += 2;
            }
            uint singleturn = 0;
            if (singleBytes == 3)
            {
                singleturn = ((uint)rx[index] << 16) | ((uint)rx[index + 1] << 8) | rx[index + 2];
            }
            else
            {
                singleturn = ((uint)rx[index] << 8) | rx[index + 1];
            }
            // 5. 掩码
            uint multiMask = (1U << multiBits) - 1;
            uint singleMask = (1U << singleBits) - 1;
            uint encoderValue = (multiturn << EncoderConfig.SingleTurnBits) | singleturn;
            multiturn &= multiMask;
            singleturn &= singleMask;
            double angle = singleturn / (double)(1U << singleBits) * 360.0;

            // 6. 更新UI
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    UpdateFreeModeUI(encoderValue, multiturn, singleturn, angle);
                }));
            }
            else
            {
                UpdateFreeModeUI(encoderValue, multiturn, singleturn, angle);
            }
        }
        private void ReadFreeMode32Bit(byte[] rx)
        {
            if (rx == null || rx.Length < 5)
                return;

            // =========================================================
            // 1. 帧头 / 帧尾
            // =========================================================

            if (rx[0] != EncoderConfig.Modbus.FreeData1 ||
                rx[1] != EncoderConfig.Modbus.FreeData2)
                return;

            if (rx[rx.Length - 1] != EncoderConfig.Modbus.FreeData3)
                return;

            // =========================================================
            // 2. 数据长度
            // =========================================================

            byte dataLen = rx[2];

            // 整帧长度 = 2字节帧头 + DataLen + 2字节校验 + 1字节帧尾
            if (rx.Length != dataLen + 5)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.FreeModeLengthError,
                                                  rx.Length, dataLen.ToString("X2")));
                return;
            }

            // =========================================================
            // 3. SUM / XOR
            // =========================================================

            byte recvSum = rx[rx.Length - 3];
            byte recvXor = rx[rx.Length - 2];

            byte sum = 0;
            byte xor = 0;

            for (int i = 2; i < rx.Length - 3; i++)
            {
                sum += rx[i];
                xor ^= rx[i];
            }

            if (sum != recvSum || xor != recvXor)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.FreeModeCheckErrorDetail,
                                    sum.ToString("X2"),
                                    recvSum.ToString("X2"),
                                    xor.ToString("X2"),
                                    recvXor.ToString("X2")));
                return;
            }

            // =========================================================
            // 4. 32bit MultiTurn
            // =========================================================

            if (rx.Length < 14)
                return;

            uint multiturn =
                ((uint)rx[3] << 24) |
                ((uint)rx[4] << 16) |
                ((uint)rx[5] << 8) |
                rx[6];

            // =========================================================
            // 5. 32bit SingleTurn
            // =========================================================

            uint singleturn =
                ((uint)rx[7] << 24) |
                ((uint)rx[8] << 16) |
                ((uint)rx[9] << 8) |
                rx[10];

            // =========================================================
            // 6. Mask
            // =========================================================

            int multiBits = EncoderConfig.MultiTurnBits;
            int singleBits = EncoderConfig.SingleTurnBits;

            uint multiMask =
                multiBits >= 32
                    ? uint.MaxValue
                    : (1U << multiBits) - 1U;

            uint singleMask =
                singleBits >= 32
                    ? uint.MaxValue
                    : (1U << singleBits) - 1U;

            multiturn &= multiMask;
            singleturn &= singleMask;

            // =========================================================
            // 7. 组合绝对位置
            // =========================================================

            ulong encoderValue =
                ((ulong)multiturn << singleBits) |
                singleturn;

            // =========================================================
            // 8. 角度
            // =========================================================

            double angle =
                singleturn /
                (double)(1UL << singleBits) *
                360.0;

            // =========================================================
            // 9. UI
            // =========================================================

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    UpdateFreeModeUI(
                        encoderValue,
                        multiturn,
                        singleturn,
                        angle);
                }));
            }
            else
            {
                UpdateFreeModeUI(
                    encoderValue,
                    multiturn,
                    singleturn,
                    angle);
            }
        }
        private void ReadFreeModeOnce()
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
                return;

            DateTime start = DateTime.Now;
            while (true)
            {
                if (SerialPortManager.sp.BytesToRead > 0)
                {
                    int cnt = SerialPortManager.sp.BytesToRead;
                    byte[] rx = new byte[cnt];

                    SerialPortManager.sp.Read(rx, 0, cnt);
                    freeModeBuffer.AddRange(rx);
                    ParseFreeModeBuffer();
                    return;
                }
                if ((DateTime.Now - start).TotalMilliseconds > 300)
                {
                    throw new TimeoutException(Properties.AppStrings.FreeModeReceiveTimeout);
                }
                Application.DoEvents();
                Thread.Sleep(1);
            }
        }
        private void UpdateFreeModeUI(ulong encoderValue, uint multiturn, uint singleturn, double angle)
        {
            tbCfgMultiTurn.Text = multiturn.ToString();
            tbCfgSingleTurn.Text = singleturn.ToString();
            tbCfgEncoderValue.Text = encoderValue.ToString();
            uint resolution = 1U << EncoderConfig.SingleTurnBits;

            textBox_cfgBinary.Text = Convert.ToString(singleturn, 2).PadLeft(EncoderConfig.SingleTurnBits, '0');
            textBox_cfgResolution.Text = $"{singleturn} / {resolution - 1}";
            textBox_cfgAngle.Text = angle.ToString("000.000") + " deg";
            tbCfgAngle.Text = angle.ToString("000.000") + " deg";
            dialControlAngle.Angle = angle;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("en-GB");
        }
        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("zh-CN");
        }
        private void francisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("fr-FR");
        }

        private void SetLanguage(string cultureName)
        {
            Properties.Settings.Default.Language = cultureName;
            Properties.Settings.Default.Save();

            Thread.CurrentThread.CurrentUICulture =
                new CultureInfo(cultureName);

            Application.Restart();
        }

    }
}