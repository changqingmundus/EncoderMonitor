using Encoder.Core.Communication;
using Encoder.Core.Configuration;
using Encoder.Core.Data;
using Encoder.Core.Protocol;
using EncoderModbusMonitor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderMonitor
{
    public partial class MainForm : Form
    {
        private DataWindow dataWindow;   //聲明DataWindow
        private Advance_Settings advancedSettingsForm;
        private ModbusMaster modbusMaster;
        private byte currentSlaveId;
        private bool freeModeEnabled = false;   // 是否进入Free Mode
        private System.Windows.Forms.Timer freeModeTimer;
        //private System.Windows.Forms.Timer portCheckTimer; // 用于检测串口是否异常断开
        private string connectedPortName = "";

        private Task continuousReadTask;
        private CancellationTokenSource continuousCts;
        private CancellationTokenSource scanCts;
        private System.Windows.Forms.Timer continuousTimer;   // 用于连续读取的定时器
        private bool showDebugInfo = true; // 是否输出调试信息到文本框
        private bool isFreeModeReceiving = false;
        private List<byte> freeModeBuffer = new List<byte>();
        private bool isContinuousReading = false;
        private enum EncoderProtocol
        {
            Tamagawa,
            ModbusRTU,
            CANopen
        }
        private EncoderProtocol currentProtocol; //當前選擇的協議

        public MainForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Font;

            continuousTimer = new System.Windows.Forms.Timer();
            continuousTimer.Interval = 80;    //讀取間隔 80ms
            continuousTimer.Tick += ContinuousTimer_Tick;
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {
            // 获取所有可用串口名称（例如 "COM1", "COM2" 等）
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            // 将串口数组直接添加到 ComboBox 的下拉项中[reference:1]
            cmb_Port.Items.AddRange(ports);
            cmb_BaudRate.SelectedIndex = 5;
            cmb_Parity.SelectedIndex = 0;
            currentProtocol = EncoderProtocol.ModbusRTU;
            cmb_SingleTurn.SelectedItem = "24";
            cmb_MultiTurn.SelectedItem = "24";
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            continuousTimer.Stop();
        }
        private void DataWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            cb_datawindow.Checked = false;
            dataWindow = null;
        }

        private void Serial_Port_Select(object sender, EventArgs e)
        {
            // 确保用户确实选择了一个项，而不是清空了选择
            if (cmb_Port.SelectedItem != null)
            {
                string selectedPort = cmb_Port.SelectedItem.ToString();
            }
        }
        private void Serial_Port_DropDown(object sender, EventArgs e)
        {
            // 刷新串口列表
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            cmb_Port.Items.Clear();
            cmb_Port.Items.AddRange(ports);
        }
        private void Baud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Parity_Select_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Baud(object sender, EventArgs e)
        {

        }
        private async void cb_Continuous_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Continuous.Checked)
            {
                AddSystemLog("INFO", Properties.AppStrings.ContinuousReadEnabled);
            }
            else
            {
                AddSystemLog("INFO", Properties.AppStrings.ContinuousReadDisabled);
                if (isContinuousReading)
                {
                    isContinuousReading = false;
                    //directionIndicator1.UpdateDirection(0, 0);
                    continuousCts?.Cancel();
                    await StopContinuousReadingAsync();
                    btn_Readout.BackColor = SystemColors.Control;
                    btn_Readout.Text = Properties.AppStrings.StartReading;
                }
            }
        }

        /*open serial port*/
        private void btn_OpenSerial_Click(object sender, EventArgs e)
        {
            string portName = cmb_Port.Text;

            // 当前正常打开状态
            if (SerialPortManager.IsOpen)
            {
                //SetStatus(Properties.AppStrings.ConnectionClosedRescan);
                lblStatus.ForeColor = SystemColors.ControlText;

                // 这是用户主动关闭
                connectedPortName = "";

                CloseSerialPortUI();

                AddSystemLog("INFO", Properties.AppStrings.SerialPortClosed);

                return;
            }

            // 检查串口
            if (cmb_Port.SelectedItem == null)
            {
                MessageBox.Show(Properties.AppStrings.PleaseSelectSerialPort);
                return;
            }
            // 波特率
            if (!int.TryParse(cmb_BaudRate.Text, out int baudRate))
            {
                MessageBox.Show(Properties.AppStrings.InvalidBaudRate);
                return;
            }
            Parity parity = GetParity();
            try
            {
                SerialPortManager.OpenPort(portName, baudRate, parity);
                connectedPortName = portName;

                btn_OpenSerial.Text = Properties.AppStrings.Close;
                btn_OpenSerial.BackColor = Color.FromArgb(46, 125, 50);
                btn_OpenSerial.ForeColor = Color.White;

                modbusMaster = new ModbusMaster(SerialPortManager.sp);
                modbusMaster.DataLog += (type, data) =>
                {
                    AddDataLog(type, data);
                };

                cmb_Port.Enabled = false;
                AddSystemLog("PASS", string.Format(Properties.AppStrings.OpenSerialPortSuccess,
                                                   portName));
            }
            catch (SerialPortException ex)
            {
                switch (ex.Error)
                {
                    case SerialPortError.PortInUse:
                        AddSystemLog("ERR", string.Format(Properties.AppStrings.SerialPortInUse,
                                                          ex.PortName));
                        break;

                    case SerialPortError.PortNotFound:
                        AddSystemLog("ERR", string.Format(Properties.AppStrings.SerialPortNotFound,
                                                          ex.PortName));
                        break;

                    case SerialPortError.OpenFailed:
                        AddSystemLog("ERR", string.Format(Properties.AppStrings.OpenSerialPortFailed,
                                                          ex.Message));
                        break;
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

            if (!int.TryParse(cmb_BaudRate.Text, out int baudRate))
            {
                return;
            }

            Parity parity = GetParity();

            AddSystemLog("INFO", Properties.AppStrings.UpdatingSerialPort);

            SerialPortManager.ClosePort();

            try
            {
                SerialPortManager.OpenPort(port, baudRate, parity);

                // 重新绑定 ModbusMaster
                modbusMaster = new ModbusMaster(SerialPortManager.sp);

                modbusMaster.DataLog += (type, data) =>
                {
                    AddDataLog(type, data);
                };

                AddSystemLog(
                    "PASS",
                    string.Format(
                        Properties.AppStrings.SerialPortUpdateSuccess,
                        baudRate,
                        parity));
            }
            catch (SerialPortException ex)
            {
                switch (ex.Error)
                {
                    case SerialPortError.PortInUse:
                        AddSystemLog(
                            "ERR",
                            string.Format(
                                Properties.AppStrings.SerialPortInUse,
                                ex.PortName));
                        break;

                    case SerialPortError.PortNotFound:
                        AddSystemLog(
                            "ERR",
                            string.Format(
                                Properties.AppStrings.SerialPortNotFound,
                                ex.PortName));
                        break;

                    case SerialPortError.OpenFailed:
                        AddSystemLog(
                            "ERR",
                            string.Format(
                                Properties.AppStrings.OpenSerialPortFailed,
                                ex.Message));
                        break;
                }
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", ex.Message);
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
            //directionIndicator1.UpdateDirection(0, 0);

            // 关闭串口
            SerialPortManager.ClosePort();

            // 清掉 Modbus
            modbusMaster = null;

            // 恢复 UI
            cmb_Port.Enabled = true;
            cmb_BaudRate.Enabled = true;
            cmb_Parity.Enabled = true;

            btn_OpenSerial.Text = Properties.AppStrings.OpenSerialPort;
            btn_OpenSerial.BackColor = SystemColors.Control;
            btn_OpenSerial.ForeColor = SystemColors.ControlText;

            btn_Readout.BackColor = SystemColors.Control;
            btn_Readout.Text = Properties.AppStrings.StartReading;

            // 清除当前选择
            cmb_Port.SelectedIndex = -1;
            cmb_Port.Text = "";
        }
        private Parity GetParity()
        {
            switch (cmb_Parity.Text)
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
        private void Clean_Messagebox(object sender, EventArgs e)
        {
            rtbDataLog.Clear();
            Debug.WriteLine("【已清除】" + Environment.NewLine);
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

            SaveProgramLog(type, message); //保存log到文件
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
        private void SaveProgramLog(string type, string message)
        {
            try
            {
                string logDir = Path.Combine(
                    Application.StartupPath,
                    "Logs");

                Directory.CreateDirectory(logDir);

                string fileName =
                    DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                string filePath =
                    Path.Combine(logDir, fileName);

                string log =
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{type}] {message}";

                File.AppendAllText(
                    filePath,
                    log + Environment.NewLine,
                    Encoding.UTF8);


                // 删除30天以前的日志
                DeleteOldLogs();
            }
            catch
            {
                // 日志失败不能影响程序
            }
        }
        private void DeleteOldLogs()
        {
            try
            {
                string logDir = Path.Combine(
                    Application.StartupPath,
                    "Logs");

                if (!Directory.Exists(logDir))
                    return;

                string[] files =
                    Directory.GetFiles(logDir, "*.log");

                DateTime limit =
                    DateTime.Now.AddDays(-30);

                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);

                    if (info.CreationTime < limit)
                    {
                        info.Delete();
                    }
                }
            }
            catch
            {
            }
        }

        /*private void SetStatus(string text)
        {
            lblStatus.Text = text;
            tTstatus.SetToolTip(lblStatus, text);
        }*/

        private void HandleModbusException(ModbusException ex)
        {
            switch (ex.Error)
            {
                case ModbusError.Timeout:
                    AddSystemLog(
                        "ERR",
                        Properties.AppStrings.ModbusResponseTimeout);
                    break;

                case ModbusError.InvalidLength:
                    AddSystemLog(
                        "ERR",
                        Properties.AppStrings.ModbusResponseLengthError);
                    break;

                case ModbusError.InvalidSlaveId:
                    AddSystemLog(
                        "ERR",
                        Properties.AppStrings.InvalidSlaveIdFormat);
                    break;

                case ModbusError.InvalidFunctionCode:
                    AddSystemLog(
                        "ERR",
                        Properties.AppStrings.ModbusFunctionCodeError);
                    break;

                case ModbusError.InvalidAddress:
                    AddSystemLog(
                        "ERR",
                        Properties.AppStrings.ModbusAddressError);
                    break;

                case ModbusError.InvalidData:
                    AddSystemLog(
                        "ERR",
                        Properties.AppStrings.ModbusDataError);
                    break;

                case ModbusError.CrcError:
                    AddSystemLog(
                        "ERR",
                        Properties.AppStrings.ModbusCrcError);
                    break;

                default:
                    AddSystemLog("ERR", ex.Message);
                    break;
            }
        }

        /*modbusrtu start scan device*/
        private async void btn_ScanDevice_Click(object sender, EventArgs e)
        {
            if (modbusMaster == null)
            {
                AddSystemLog("ERR", Properties.AppStrings.PleaseOpenSerialPort);
                return;
            }
            AddSystemLog("INFO", Properties.AppStrings.StartScanDevice);
            btn_ScanDevice.Enabled = false;
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
                    //SetStatus(string.Format(Properties.AppStrings.EncoderConnected, id));
                    lblStatus.ForeColor = Color.Green;

                    btn_ScanDevice.Enabled = true;
                }
                else
                {
                    //SetStatus(string.Format(Properties.AppStrings.DeviceParameterReadFailed, id));
                    lblStatus.ForeColor = Color.Red;
                    AddSystemLog("ERR", Properties.AppStrings.ReadDeviceParameterFailedWithError);
                    btn_ScanDevice.Enabled = true;
                }
            }
            else
            {
                AddSystemLog("ERR", Properties.AppStrings.NoDeviceFound);
                //SetStatus(string.Format(Properties.AppStrings.EncoderNotFound, id));
                lblStatus.ForeColor = Color.Red;
                btn_ScanDevice.Enabled = true;
            }
            progressScan.Value = 247;
        }
        private void btn_StopScan_Click(object sender, EventArgs e)
        {
            if (scanCts != null)
            {
                scanCts.Cancel();
                AddSystemLog("INFO", Properties.AppStrings.StopScanning);
            }
        }

        /*modbus read device config*/
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

        /*ModbusRTU Button*/
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

                //SetStatus(Properties.AppStrings.FreeModeWarning);
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
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
                //SetStatus(Properties.AppStrings.ReconnectRequired);

                currentSlaveId = newId;   // 更新当前设备ID
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
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
                //SetStatus(Properties.AppStrings.ReconnectRequired);
                lblStatus.ForeColor = Color.Red;
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
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
                AddSystemLog("ERR", Properties.AppStrings.ParityEmpty);
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
                    AddSystemLog("ERR", Properties.AppStrings.UnknownParity);
                    return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.Parity, parityValue);
                AddSystemLog("PASS", string.Format(Properties.AppStrings.ParityChangeSuccess,
                                                   cmbCfgParity.Text));
                //SetStatus(Properties.AppStrings.ReconnectRequired);
                lblStatus.ForeColor = Color.Red;
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.ParityChangeFailed,
                                                  ex.Message));
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
                AddSystemLog("ERR", Properties.AppStrings.PleaseSelectDirection);
                return;
            }
            ushort direction = GetDirectionValue();
            if (direction == 0xffff)
            {
                AddSystemLog("ERR", Properties.AppStrings.InvalidDirection);
                return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.CountDirection, direction);
                AddSystemLog("PASS", string.Format(Properties.AppStrings.DirectionChangeSuccess,
                                                   cmbCfgDirection.Text));
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.DirectionChangeFailed,
                                                  ex.Message));
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
                AddSystemLog("ERR", Properties.AppStrings.UploadTimeEmpty);
                return;
            }
            if (!ushort.TryParse(txtCfgUploadTime.Text, out ushort uploadTime))
            {
                AddSystemLog("ERR", Properties.AppStrings.InvalidUploadTimeFormat);
                return;
            }
            if (uploadTime < 1 || uploadTime > 3000)
            {
                AddSystemLog("ERR", Properties.AppStrings.UploadTimeOutOfRange);
                return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.ReportInterval, uploadTime);
                AddSystemLog("PASS", string.Format(Properties.AppStrings.UploadTimeChangeSuccess,
                                                   uploadTime));
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.UploadTimeChangeFailed,
                                                  ex.Message));

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
                AddSystemLog("ERR", Properties.AppStrings.PleaseSelectOriginPosition);
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
                    AddSystemLog("ERR", Properties.AppStrings.UnknownOriginPosition);
                    return;
            }
            try
            {
                modbusMaster.WriteSingleRegister(currentSlaveId, ModbusRegisterMap.ZeroPositionReference, originPosition);
                AddSystemLog("PASS", string.Format(Properties.AppStrings.OriginPositionChangeSuccess,
                                                   cmbCfgOriginPosition.Text));
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.OriginPositionChangeFailed,
                                                  ex.Message));
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
                AddSystemLog("PASS", Properties.AppStrings.OriginPositionResetSuccess);
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.ResetOriginPositionFailed,
                                                  ex.Message));
            }
        }
        private void btn_FreeModeReceive_Click(object sender, EventArgs e)
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

                    btn_FreeModeReceive.Text = Properties.AppStrings.EnableFreeMode;
                    btn_FreeModeReceive.BackColor = SystemColors.Control;

                    btn_Readout.Text = Properties.AppStrings.StartReading;
                    btn_Readout.BackColor = SystemColors.Control;

                    AddSystemLog("INFO", Properties.AppStrings.ExitFreeMode);

                    return;
                }

                freeModeEnabled = true;
                SerialPortManager.sp.DiscardInBuffer();
                freeModeBuffer.Clear();

                btn_FreeModeReceive.Text = Properties.AppStrings.DisableFreeMode;
                btn_FreeModeReceive.BackColor = Color.Green;

                btn_Readout.Text = Properties.AppStrings.StartReceiving;
                btn_Readout.BackColor = Color.Green;

                AddSystemLog("INFO", Properties.AppStrings.EnterFreeMode);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", string.Format(Properties.AppStrings.FreeModeSwitchFailed,
                                                  ex.Message));
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

                    AddSystemLog("ERR", string.Format(Properties.AppStrings.SerialPortDisconnected,
                                                      lostPort));
                    //SetStatus(Properties.AppStrings.SerialPortLostReconnect);
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

            string selectedPort = cmb_Port.Text;

            cmb_Port.BeginUpdate();

            try
            {
                cmb_Port.Items.Clear();

                foreach (string port in currentPorts.Distinct())
                {
                    cmb_Port.Items.Add(port);
                }

                if (!string.IsNullOrEmpty(selectedPort) &&
                    currentPorts.Contains(selectedPort))
                {
                    cmb_Port.SelectedItem = selectedPort;
                }
                else
                {
                    cmb_Port.SelectedIndex = -1;
                    cmb_Port.Text = "";
                }
            }
            finally
            {
                cmb_Port.EndUpdate();
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
                    return Properties.AppStrings.OriginPositionMiddle;

                case 2:
                    return Properties.AppStrings.OriginPositionZero;

                default:
                    return Properties.AppStrings.UnknownOriginPosition;
            }
        }
        private string GetDirectionText(ushort value)
        {
            switch (value)
            {
                case 1:
                    return Properties.AppStrings.DirectionCW;

                case 2:
                    return Properties.AppStrings.DirectionCCW;

                default:
                    return Properties.AppStrings.InvalidDirection;
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

            //directionIndicator1.UpdateDirection(0, 0);

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

            btn_Readout.BackColor = SystemColors.Control;
            btn_Readout.Text = Properties.AppStrings.StartReading;

            // 确认连续读取彻底结束后，再恢复日志
            modbusMaster.EnableDataLog = true;

            AddSystemLog("INFO", Properties.AppStrings.StopContinuousRead);
        }

        private async void btn_Readout_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                MessageBox.Show("请先打开串口！");
                return;
            }

            EncoderData data = null;

            bool oldFlag = showDebugInfo;
            showDebugInfo = true;

            try
            {
                switch (currentProtocol)
                {
                    case EncoderProtocol.Tamagawa:
                        data = ReadTamagawaSingleTurn();
                        break;

                    case EncoderProtocol.ModbusRTU:
                        // Modbus RTU 读取逻辑
                        if (freeModeEnabled)
                        {
                            if (cb_Continuous.Checked)
                            {
                                if (!isFreeModeReceiving)
                                {
                                    isFreeModeReceiving = true;
                                    freeModeTimer.Start();

                                    btn_Readout.FlatStyle = FlatStyle.Flat;
                                    btn_Readout.FlatAppearance.BorderSize = 1;
                                    btn_Readout.FlatAppearance.BorderColor =
                                        Color.FromArgb(160, 160, 160);
                                    btn_Readout.BackColor =
                                        Color.FromArgb(240, 200, 50);
                                    btn_Readout.ForeColor = Color.Black;
                                    btn_Readout.Text =
                                        Properties.AppStrings.StopReceiving;

                                    AddSystemLog(
                                        "INFO",
                                        Properties.AppStrings.StartFreeModeContinuousReceiving);
                                }
                                else
                                {
                                    isFreeModeReceiving = false;
                                    freeModeTimer.Stop();

                                    btn_Readout.BackColor = SystemColors.Control;
                                    btn_Readout.Text =
                                        Properties.AppStrings.StartReceiving;

                                    AddSystemLog(
                                        "INFO",
                                        Properties.AppStrings.StopFreeModeReceiving);
                                }

                                return;
                            }

                            ReadFreeModeOnce();

                            btn_Readout.Text =
                                Properties.AppStrings.StartReceiving;

                            AddSystemLog(
                                "PASS",
                                Properties.AppStrings.FreeModeSingleReadComplete);

                            return;
                        }

                        if (currentSlaveId == 0)
                        {
                            AddSystemLog(
                                "ERR",
                                Properties.AppStrings.InvalidSlaveIdFormat);
                            return;
                        }

                        if (cb_Continuous.Checked)
                        {
                            if (!isContinuousReading)
                            {
                                isContinuousReading = true;
                                modbusMaster.EnableDataLog = false;

                                continuousCts = new CancellationTokenSource();
                                continuousReadTask =
                                    ContinuousReadLoop(continuousCts.Token);

                                btn_Readout.BackColor = Color.Yellow;
                                btn_Readout.Text =
                                    Properties.AppStrings.StopReading;

                                AddSystemLog(
                                    "INFO",
                                    Properties.AppStrings.StartContinuousReading);
                            }
                            else
                            {
                                isContinuousReading = false;
                                continuousCts?.Cancel();

                                btn_Readout.BackColor = SystemColors.Control;
                                //directionIndicator1.UpdateDirection(0, 0);
                                btn_Readout.Text =
                                    Properties.AppStrings.ReadData;

                                AddSystemLog(
                                    "INFO",
                                    Properties.AppStrings.StopReading);
                            }

                            return;
                        }

                        DeviceData deviceData = await Task.Run(() => ReadDeviceData());

                        if (deviceData == null)
                        {
                            AddSystemLog(
                                "ERR",
                                Properties.AppStrings.DeviceDataReadFailed);
                            return;
                        }

                        UpdateDeviceUI(deviceData);

                        AddSystemLog(
                            "PASS",
                            Properties.AppStrings.EncoderDataReadSuccess);

                        return;

                    case EncoderProtocol.CANopen:
                        // data = ReadCANopenSingleTurn();
                        break;

                    default:
                        MessageBox.Show("不支持的编码器协议！");
                        return;
                }
            }
            catch (ModbusException ex)
            {
                HandleModbusException(ex);
            }
            catch (Exception ex)
            {
                AddSystemLog("ERR", ex.Message);
            }
            finally
            {
                showDebugInfo = oldFlag;
            }
        }

        private void ContinuousTimer_Tick(object sender, EventArgs e)
        {
            if (isContinuousReading)
                return;
            if (SerialPortManager.sp == null ||
                !SerialPortManager.sp.IsOpen)
                return;
            isContinuousReading = true;

            bool oldShowFlag = showDebugInfo;
            try
            {
                showDebugInfo = false;

                EncoderData data = null;
                switch (currentProtocol)
                {
                    case EncoderProtocol.Tamagawa:

                        data = ReadTamagawaAll();

                        break;

                    case EncoderProtocol.ModbusRTU:

                        if (chkShowSpeed.Checked || chkShowDirection.Checked)
                        {
                            // 讀取 0x0009~0x000C
                            data = ReadModbusRTU_Monitor();
                        }
                        else
                        {
                            // 原來讀單圈、多圈
                            data = ReadModbusRTUAll();
                        }

                        break;

                    case EncoderProtocol.CANopen:

                        break;
                }
                if (data != null)
                {
                    // 單圈
                    tb_CfgSingleTurn.Text =
                        data.SingleTurn.ToString();

                    // 多圈
                    tb_CfgMultiTurn.Text =
                        data.MultiTurn.ToString();

                    // 速度
                    if (chkShowSpeed.Checked)
                    {
                        lbl_CfgSpeed.Text =
                            data.Speed.ToString()
                            + " rpm";
                    }

                    // 方向
                    if (chkShowDirection.Checked)
                    {
                        switch (data.Direction)
                        {
                            case 0:
                                lbl_CfgRtDirection.Text = "Stop";
                                break;

                            case 1:
                                lbl_CfgRtDirection.Text = "CCW";
                                break;

                            case 2:
                                lbl_CfgRtDirection.Text = "CW";
                                break;

                            default:
                                lbl_CfgRtDirection.Text = "Unknown";
                                break;
                        }
                    }

                    if (dataWindow != null && !dataWindow.IsDisposed)
                    {
                        dataWindow.UpdateEncoderData(new EncoderData
                        {
                            SingleTurn = (uint)data.SingleTurn,
                            MultiTurn = (uint)data.MultiTurn,
                            Direction = data.Direction,
                            Speed = data.Speed
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "Continuous Read Error: "
                    + ex.Message);
            }
            finally
            {
                showDebugInfo = oldShowFlag;

                isContinuousReading = false;
            }
        }
        private void Model_Select(object sender, EventArgs e)
        {
            if (tb_select_protocol.SelectedTab == null)
                return;

            string protocol = tb_select_protocol.SelectedTab.Text;
            switch (protocol)
            {
                case "Tamagawa":
                    currentProtocol = EncoderProtocol.Tamagawa;
                    break;

                case "Modbus RTU":
                    currentProtocol = EncoderProtocol.ModbusRTU;
                    break;

                case "CANopen":
                    currentProtocol = EncoderProtocol.CANopen;
                    break;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncoderConfig.MultiTurnBits = int.Parse(cmb_MultiTurn.SelectedItem.ToString());
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncoderConfig.SingleTurnBits =
        int.Parse(cmb_SingleTurn.SelectedItem.ToString());
        }

        private void Data_Dispaly_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_datawindow.Checked)
            {
                // 勾選，打開窗口
                if (dataWindow == null || dataWindow.IsDisposed)
                {
                    dataWindow = new DataWindow();
                    dataWindow.FormClosed += DataWindow_FormClosed;
                    dataWindow.Show();
                }
                else
                {
                    dataWindow.Show();
                }
            }
            else
            {
                // 取消勾選，關閉窗口
                if (dataWindow != null)
                {
                    dataWindow.Close();
                    dataWindow = null;
                }
            }
        }

        private byte TamagawaCalcCRC(byte[] data)
        {
            byte crc = 0;
            foreach (byte b in data)
            {
                crc ^= b;
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x80) != 0)
                        crc = (byte)(((crc << 1) ^ 0x01) & 0xFF);
                    else
                        crc = (byte)((crc << 1) & 0xFF);
                }
            }
            return crc;
        }

        private EncoderData ReadTamagawaSingleTurn()
        {
            EncoderData data = new EncoderData();
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                return null;
            }
            try
            {
                SerialPortManager.sp.DiscardInBuffer();
                byte[] cmd = new byte[] { 0x02 };
                SerialPortManager.Send(cmd);
                Thread.Sleep(50);
                int count = SerialPortManager.sp.BytesToRead;
                if (count < 6)
                {
                    return null;
                }
                byte[] rx = new byte[6];
                SerialPortManager.sp.Read(rx, 0, 6);
                uint SingleTurn =
                    ((uint)rx[2] << 16) |
                    ((uint)rx[3] << 8) |
                    rx[4];
                SingleTurn &= EncoderConfig.SingleTurnMax;
                byte recvCrc = rx[5];
                byte calcCrc =
                    TamagawaCalcCRC(new byte[]
                    {rx[0], rx[1],rx[2],rx[3],rx[4]});
                data.SingleTurn = SingleTurn;
                data.Angle =
                    SingleTurn * 360.0 / Math.Pow(2, EncoderConfig.SingleTurnBits);
                data.CRC_OK = recvCrc == calcCrc;
                return data;
            }

            catch (Exception ex)
            {
                if (showDebugInfo)
                    MessageBox.Show(ex.Message);
                return null;
            }
        }
        private EncoderData ReadTamagawaMultiTurn()
        {
            EncoderData data = new EncoderData();
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                if (showDebugInfo)
                    MessageBox.Show("请先打开串口！");

                return null;
            }
            try
            {
                SerialPortManager.sp.DiscardInBuffer();
                byte[] cmd = new byte[] { 0x8A };
                SerialPortManager.Send(cmd);
                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "TX: " +
                        BitConverter.ToString(cmd) +
                        Environment.NewLine);
                }
                System.Threading.Thread.Sleep(50);
                int count = SerialPortManager.sp.BytesToRead;
                if (count < 6)
                {
                    if (showDebugInfo)
                    {
                        rtbDataLog.AppendText(
                            "接收數據錯誤" +
                            Environment.NewLine);
                    }
                    return null;
                }
                byte[] rx = new byte[6];
                SerialPortManager.sp.Read(rx, 0, 6);
                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "RX: " +
                        BitConverter.ToString(rx) +
                        Environment.NewLine);
                }
                uint abm =
                    ((uint)rx[2] << 16) |
                    ((uint)rx[3] << 8) |
                    rx[4];
                abm >>= 8;
                abm &= EncoderConfig.MultiTurnMax;
                byte recvCrc = rx[5];
                byte calcCrc = TamagawaCalcCRC(new byte[]
                {rx[0],rx[1],rx[2],rx[3],rx[4]});
                data.MultiTurn = abm;
                data.CRC_OK =
                    recvCrc == calcCrc;
                return data;
            }
            catch (Exception ex)
            {
                if (showDebugInfo)
                    MessageBox.Show("通讯错误：" + ex.Message);

                return null;
            }
        }
        private EncoderData ReadTamagawaAll()
        {
            EncoderData data = new EncoderData();


            byte[] cmd = new byte[] { 0x1A };

            SerialPortManager.Send(cmd);


            System.Threading.Thread.Sleep(100);


            int count = SerialPortManager.sp.BytesToRead;

            if (count < 11)
            {
                return null;
            }
            byte[] rx = new byte[count];
            SerialPortManager.sp.Read(rx, 0, count);
            // CRC校驗
            byte recvCrc = rx[10];
            byte calcCrc = TamagawaCalcCRC(new byte[]
            {rx[0],rx[1],rx[2],rx[3],rx[4],rx[5],rx[6],rx[7],rx[8],rx[9]});
            data.CRC_OK = (recvCrc == calcCrc);
            if (!data.CRC_OK)
            {
                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "CRC FAIL" + Environment.NewLine);
                }
                return null;
            }
            uint SingleTurn =
                ((uint)rx[2] << 16) |
                ((uint)rx[3] << 8) |
                rx[4];
            SingleTurn &= EncoderConfig.SingleTurnMax;
            uint abm =
                ((uint)rx[6] << 16) |
                ((uint)rx[7] << 8) |
                rx[8];
            abm >>= 8;
            abm &= EncoderConfig.MultiTurnMax;
            data.SingleTurn = SingleTurn;
            data.MultiTurn = abm;
            data.EnID = rx[5];
            data.Angle =
                SingleTurn * 360.0 / Math.Pow(2, EncoderConfig.SingleTurnBits);

            return data;
        }

        private EncoderData ReadModbusRTUSingleTurn()
        {
            EncoderData data = new EncoderData();


            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                if (showDebugInfo)
                    MessageBox.Show("请先打开串口！");

                return null;
            }
            try
            {
                SerialPortManager.sp.DiscardInBuffer();

                byte[] cmd =
               {
                  EncoderConfig.Modbus.SlaveID,

                  EncoderConfig.Modbus.FunctionCode,

                  (byte)(EncoderConfig.Modbus.SingleTurnAddress >> 8),
                  (byte)(EncoderConfig.Modbus.SingleTurnAddress),

                  (byte)(EncoderConfig.Modbus.SingleTurnCount >> 8),
                  (byte)(EncoderConfig.Modbus.SingleTurnCount)
               };
                // 添加CRC
                ushort crc = ModbusCRC.Calculate(cmd);
                byte[] tx = new byte[]
                {cmd[0],cmd[1],cmd[2],cmd[3],cmd[4],cmd[5],
                (byte)(crc & 0xFF),(byte)(crc >> 8)};
                SerialPortManager.Send(tx);
                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "TX: " +
                        BitConverter.ToString(tx) +
                        Environment.NewLine);
                }
                Thread.Sleep(50);
                int count = SerialPortManager.sp.BytesToRead;
                if (count < 7)
                {
                    if (showDebugInfo)
                        rtbDataLog.AppendText(
                            "接收數據錯誤\r\n");

                    return null;
                }
                byte[] rx = new byte[count];
                SerialPortManager.sp.Read(rx, 0, count);
                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "RX: " +
                        BitConverter.ToString(rx) +
                        Environment.NewLine);
                }
                // CRC校验
                ushort recvCRC =
                    (ushort)(rx[count - 2] |
                    (rx[count - 1] << 8));
                ushort calcCRC =
                       ModbusCRC.Calculate(rx.Take(count - 2).ToArray());
                if (recvCRC != calcCRC)
                {
                    data.CRC_OK = false;

                    if (showDebugInfo)
                        rtbDataLog.AppendText(
                            "CRC FAIL\r\n");
                    return null;
                }
                data.CRC_OK = true;
                // Modbus正常返回
                if (rx.Length >= 5 &&
                    rx[1] == EncoderConfig.Modbus.FunctionCode)
                {
                    int byteCount = EncoderConfig.Modbus.SingleTurnCount * 2;

                    // 檢查返回數據長度
                    if (rx[2] != byteCount)
                    {
                        return null;
                    }
                    uint raw = 0;
                    // 根據寄存器數量自動組合數據
                    for (int i = 0; i < byteCount; i++)
                    {
                        raw = (raw << 8) | rx[3 + i];
                    }
                    uint SingleTurn = raw & EncoderConfig.SingleTurnMax;
                    data.SingleTurn = SingleTurn;
                    data.Angle =
                        SingleTurn * 360.0 /
                        Math.Pow(2, EncoderConfig.SingleTurnBits);
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                if (showDebugInfo)
                {
                    MessageBox.Show(
                        "Modbus通讯错误：" + ex.Message);
                }
                return null;
            }
        }
        private EncoderData ReadModbusRTUMultiTurn()
        {
            if (SerialPortManager.sp == null ||
                !SerialPortManager.sp.IsOpen)
            {
                return null;
            }
            try
            {
                EncoderData data = new EncoderData();
                SerialPortManager.sp.DiscardInBuffer();
                byte[] cmd =
                {
            EncoderConfig.Modbus.SlaveID,
            0x03,

            (byte)(EncoderConfig.Modbus.MultiTurnAddress >> 8),
            (byte)(EncoderConfig.Modbus.MultiTurnAddress),

            0x00,
            0x01};
                ushort crc =
                    ModbusCRC.Calculate(cmd);


                byte[] tx =
                {
            cmd[0],
            cmd[1],
            cmd[2],
            cmd[3],
            cmd[4],
            cmd[5],

            (byte)(crc & 0xFF),
            (byte)(crc >> 8)};
                SerialPortManager.Send(tx);

                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "TX: " +
                        BitConverter.ToString(tx)
                        + "\r\n");
                }
                // 等待設備返回
                Thread.Sleep(10);

                int count =
                    SerialPortManager.sp.BytesToRead;
                if (count < 7)
                {
                    return null;
                }
                byte[] rx = new byte[count];
                SerialPortManager.sp.Read(
                    rx,
                    0,
                    count);
                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "RX: " +
                        BitConverter.ToString(rx)
                        + "\r\n");
                }
                ushort recvCRC =
                    (ushort)(rx[count - 2] |
                    (rx[count - 1] << 8));


                byte[] crcData =
                    new byte[count - 2];


                Array.Copy(
                    rx,
                    crcData,
                    count - 2);
                ushort calcCRC =
                    ModbusCRC.Calculate(crcData);
                if (recvCRC != calcCRC)
                {
                    data.CRC_OK = false;
                    return null;
                }
                data.CRC_OK = true;
                if (rx[1] == 0x03 &&
                   rx[2] == 0x02)
                {
                    data.MultiTurn = (uint)((rx[3] << 8) | rx[4]);
                    data.MultiTurn &= 0xFFF;
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                if (showDebugInfo)
                {
                    MessageBox.Show(
                        "Modbus错误:"
                        + ex.Message);
                }

                return null;
            }
        }
        private EncoderData ReadModbusRTUAll()
        {
            EncoderData data = new EncoderData();


            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                if (showDebugInfo)
                    MessageBox.Show("请先打开串口！");
                return null;
            }
            try
            {
                SerialPortManager.sp.DiscardInBuffer();
                byte[] cmd =
                {
                  EncoderConfig.Modbus.SlaveID,

                  EncoderConfig.Modbus.FunctionCode,

                  (byte)(EncoderConfig.Modbus.AllAddress >> 8),
                  (byte)(EncoderConfig.Modbus.AllAddress),

                  (byte)(EncoderConfig.Modbus.AllCount >> 8),
                  (byte)(EncoderConfig.Modbus.AllCount)
                };
                ushort crc = ModbusCRC.Calculate(cmd);
                byte[] tx = new byte[]
                {cmd[0], cmd[1],cmd[2],cmd[3],cmd[4],cmd[5],(byte)(crc & 0xFF),(byte)(crc >> 8)};
                SerialPortManager.Send(tx);
                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "TX: " +
                        BitConverter.ToString(tx) +
                        Environment.NewLine);
                }
                Thread.Sleep(50);
                int count = SerialPortManager.sp.BytesToRead;

                if (count < 7)
                {
                    if (showDebugInfo)
                        rtbDataLog.AppendText(
                            "接收數據錯誤\r\n");
                    return null;
                }
                byte[] rx = new byte[count];

                SerialPortManager.sp.Read(rx, 0, count);
                if (showDebugInfo)
                {
                    rtbDataLog.AppendText(
                        "RX: " +
                        BitConverter.ToString(rx) +
                        Environment.NewLine);
                }
                // CRC校验
                ushort recvCRC =
                    (ushort)(rx[count - 2] |
                    (rx[count - 1] << 8));
                byte[] crcData = new byte[count - 2];
                Array.Copy(rx, crcData, count - 2);
                ushort calcCRC = ModbusCRC.Calculate(crcData);
                if (recvCRC != calcCRC)
                {
                    data.CRC_OK = false;
                    if (showDebugInfo)
                        rtbDataLog.AppendText("CRC FAIL\r\n");
                    return null;
                }
                data.CRC_OK = true;
                // Modbus All 返回
                if (rx.Length >= 7 &&
                    rx[1] == EncoderConfig.Modbus.FunctionCode)
                {
                    int byteCount =
                        (EncoderConfig.Modbus.SingleTurnCount +
                         EncoderConfig.Modbus.MultiTurnCount) * 2;
                    if (rx[2] != byteCount)
                    {
                        return null;
                    }
                    int index = 3;
                    // SingleTurn
                    uint singleRaw = 0;

                    for (int i = 0;
                         i < EncoderConfig.Modbus.SingleTurnCount * 2;
                         i++)
                    {
                        singleRaw <<= 8;
                        singleRaw |= rx[index++];
                    }
                    // MultiTurn
                    uint multiRaw = 0;

                    for (int i = 0;
                         i < EncoderConfig.Modbus.MultiTurnCount * 2;
                         i++)
                    {
                        multiRaw <<= 8;
                        multiRaw |= rx[index++];
                    }
                    data.SingleTurn =
                        singleRaw & EncoderConfig.SingleTurnMax;
                    data.MultiTurn =
                        multiRaw & 0xFFF;
                    data.Angle =
                        data.SingleTurn * 360.0 /
                        Math.Pow(2, EncoderConfig.SingleTurnBits);
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                if (showDebugInfo)
                {
                    MessageBox.Show(
                        "Modbus通讯错误：" + ex.Message);
                }
                return null;
            }
        }
        private EncoderData ReadModbusRTU_Monitor()
        {
            EncoderData data = new EncoderData();
            byte[] cmd =
            {
            EncoderConfig.Modbus.SlaveID,0x03,0x00,0x09,0x00,0x04};
            cmd = ModbusCRC.AppendCRC(cmd);
            SerialPortManager.Send(cmd);
            byte[] rx = SerialPortManager.Read();
            if (rx == null)
                return null;

            // CRC檢查
            int count = rx.Length;
            ushort recvCRC =
                (ushort)(rx[count - 2] |
                (rx[count - 1] << 8));

            ushort calcCRC =
                ModbusCRC.Calculate(
                    rx.Take(count - 2)
                    .ToArray());

            if (recvCRC != calcCRC)
                return null;

            ushort high = (ushort)((rx[3] << 8) | rx[4]);
            ushort low = (ushort)((rx[5] << 8) | rx[6]);

            uint raw = ((uint)high << 16) | low;
            uint SingleTurnResolution = 1U << EncoderConfig.SingleTurnBits;
            data.MultiTurn = raw / SingleTurnResolution;
            data.SingleTurn = raw % SingleTurnResolution;

            data.Direction =
                (byte)((rx[7] << 8) | rx[8]);

            data.Speed =
                (ushort)((rx[9] << 8) | rx[10]);

            return data;
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

        /*update data to datawindow*/
        private void UpdateDeviceUI(DeviceData data)
        {
            if (data == null)
                return;

            tb_CfgEncoderValue.Text = data.EncoderValue.ToString();
            tb_CfgMultiTurn.Text = data.MultiTurn.ToString();
            tb_CfgSingleTurn.Text = data.SingleTurn.ToString();
            lbl_CfgSpeed.Text = data.Speed.ToString() + " rpm";
            switch (data.Direction)
            {
                case 0:
                    lbl_CfgRtDirection.Text = "STOP";
                    break;

                case 1:
                    lbl_CfgRtDirection.Text = "CW";
                    break;

                case 2:
                    lbl_CfgRtDirection.Text = "CCW";
                    break;

                default:
                    lbl_CfgRtDirection.Text = "UNKNOWN";
                    break;
            }

            uint resolution = 1U << EncoderConfig.SingleTurnBits;
            double angle = data.SingleTurn * 360.0 / resolution;

            // 将读取到的编码器数据传给子窗口
            if (dataWindow != null && !dataWindow.IsDisposed)
            {
                dataWindow.UpdateAngle(angle);
                dataWindow.UpdateEncoderData(new EncoderData
                {
                    SingleTurn = (uint)data.SingleTurn,
                    MultiTurn = (uint)data.MultiTurn,
                    Direction = data.Direction,
                    Speed = data.Speed
                });
            }
        }
        private void UpdateFreeModeUI(ulong encoderValue, uint multiturn, uint singleturn, double angle)
        {
            tb_CfgMultiTurn.Text = multiturn.ToString();
            tb_CfgSingleTurn.Text = singleturn.ToString();
            tb_CfgEncoderValue.Text = encoderValue.ToString();
            uint resolution = 1U << EncoderConfig.SingleTurnBits;

            /*textBox_cfgBinary.Text = Convert.ToString(singleturn, 2).PadLeft(EncoderConfig.SingleTurnBits, '0');
            textBox_cfgResolution.Text = $"{singleturn} / {resolution - 1}";
            textBox_cfgAngle.Text = angle.ToString("000.000") + " deg";
            tbCfgAngle.Text = angle.ToString("000.000") + " deg";
            dialControlAngle.Angle = angle;*/
        }

        private void advanceReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (advancedSettingsForm == null ||
        advancedSettingsForm.IsDisposed)
            {
                advancedSettingsForm = new Advance_Settings(this);
                advancedSettingsForm.Show();
            }
            else
            {
                advancedSettingsForm.Activate();
            }
        }

        private void LogToUImain(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(LogToUImain), message);
                return;
            }
            rtbDataLog.AppendText(
                message + Environment.NewLine
            );
            rtbDataLog.SelectionStart = rtbDataLog.Text.Length;
            rtbDataLog.ScrollToCaret();
        }

        public void AppendLog(string text)
        {
            if (rtbDataLog.InvokeRequired)
            {
                rtbDataLog.Invoke(new Action(() =>
                {
                    rtbDataLog.AppendText(text);
                }));
            }
            else
            {
                rtbDataLog.AppendText(text);
            }
        }

        private void chkShowSpeed_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            if (chkShowSpeed.Checked)
            {
                lbl_CfgSpeed.Visible = true;
            }
            else
            {
                lbl_CfgSpeed.Visible = false;
            }


            if (chkShowDirection.Checked)
            {
                lbl_CfgRtDirection.Visible = true;
            }
            else
            {
                lbl_CfgRtDirection.Visible = false;
            }
        }
        private void chkShowDirection_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void encoderSetupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EncoderSetup setup = new EncoderSetup(currentSlaveId);
            setup.Show();
        }
    }
}