using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Markup;
using WPF;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EncoderMonitor
{
    public partial class btnClickThis : Form
    {
        private DataWindow dataWindow;   //聲明DataWindow
        private System.Windows.Forms.Timer continuousTimer;   // 用于连续读取的定时器
        private bool showDebugInfo = true; // 是否输出调试信息到文本框
        private enum EncoderProtocol
        {
            Tamagawa,
            ModbusRTU,
            CANopen
        }
        private EncoderProtocol currentProtocol; //當前選擇的協議
        public uint Abs;
        public uint MultiTurn;
        public byte EnID;
        public byte Status;
        public bool CRC_OK;
        public double Angle;
        public btnClickThis()
        {
            InitializeComponent();
            // 根据你的需要调整（毫秒）
            continuousTimer = new System.Windows.Forms.Timer();
            continuousTimer.Interval = 1; 
            continuousTimer.Tick += ContinuousTimer_Tick;
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {
            // 获取所有可用串口名称（例如 "COM1", "COM2" 等）
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            // 将串口数组直接添加到 ComboBox 的下拉项中[reference:1]
            comboBox1.Items.AddRange(ports);
            // 協議選擇
            ModelSelect.Items.Add("Tamagawa");
            ModelSelect.Items.Add("Modbus RTU");
            ModelSelect.Items.Add("CANopen");

            ModelSelect.SelectedIndex = 0;
            currentProtocol = EncoderProtocol.Tamagawa;
            comboBox4.SelectedItem = "24";
            comboBox5.SelectedItem = "24";
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            continuousTimer.Stop();
        }
        private void DataWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            checkBox2.Checked = false;
            dataWindow = null;
        }

        private void Serial_Port_Select(object sender, EventArgs e)
        {
            // 确保用户确实选择了一个项，而不是清空了选择
            if (comboBox1.SelectedItem != null)
            {
                string selectedPort = comboBox1.SelectedItem.ToString();
            }
        }
        private void Serial_Port_DropDown(object sender, EventArgs e)
        {
            // 刷新串口列表
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ports);
        }
        private void Baud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Baud(object sender, EventArgs e)
        {

        }
        private void Continous_Read(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // 开启连续读取
                showDebugInfo = false;           // 连续模式下不输出文本
                continuousTimer.Start();
            }
            else
            {
                // 关闭连续读取
                continuousTimer.Stop();
                showDebugInfo = true;            // 恢复显示
            }
        }

        private void Open_SerialPort(object sender, EventArgs e)
        {
            // 判断当前串口是否已经打开
            if (SerialPortManager.sp != null && SerialPortManager.sp.IsOpen)
            {
                // === 关闭串口 ===
                SerialPortManager.ClosePort();
                // 更新按钮文本和状态
                button4.Text = "打开串口";
                button4.BackColor = SystemColors.Control;
                // 启用下拉框选择
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
            }
            else
            {
                // === 打开串口 ===
                // 检查是否选择了串口
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("请先选择串口", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 安全获取波特率
                if (!int.TryParse(comboBox2.Text, out int baudRate))
                {
                    MessageBox.Show("波特率无效", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string comPort = comboBox1.SelectedItem.ToString();
                bool success = SerialPortManager.OpenPort(comPort, baudRate, null);
                if (success)
                {
                    button4.Text = "关闭串口";
                    button4.BackColor = Color.LightGreen;
                    // 禁用下拉框
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"串口 {comPort} 打开失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Clean_Messagebox(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.AppendText("【已清除】" + Environment.NewLine);
        }
        private void Read_Singleturn(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                MessageBox.Show("请先打开串口！");
                return;
            }
            EncoderData data = null;
            // 临时保存并覆盖显示标志，确保这次读取会输出信息
            bool oldFlag = showDebugInfo;
            showDebugInfo = true;
            switch (currentProtocol)
            {
                case EncoderProtocol.Tamagawa:
                    data = ReadTamagawaSingleTurn();
                    break;


                case EncoderProtocol.ModbusRTU:
                    data = ReadModbusRTUSingleTurn();
                    break;


                case EncoderProtocol.CANopen:
                    // data = ReadCAN();
                    break;
            }
            if (data != null)
            {
                textBox1.AppendText(
                    $"SingleTurn: {data.Abs}\r\n" +
                    $"Angle: {data.Angle:F4}°\r\n" +
                    $"CRC: {(data.CRC_OK ? "PASS" : "FAIL")}\r\n\r\n"
                );
                if (data != null)
                {
                    dataWindow.UpdateEncoderData(data.Abs);
                }
            }
            showDebugInfo = oldFlag;
        }
        private void Read_Multiturn(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                MessageBox.Show("请先打开串口！");
                return;
            }
            EncoderData data = null;
            switch (currentProtocol)
            {
                case EncoderProtocol.Tamagawa:
                    data = ReadTamagawaMultiTurn();
                    break;


                case EncoderProtocol.ModbusRTU:
                    data = ReadModbusRTUMultiTurn();
                    break;


                case EncoderProtocol.CANopen:
                    // data = ReadCAN();
                    break;
            }

            if (data != null)
            {
                textBox1.AppendText(
                    $"ABM:{data.MultiTurn}/4095 " +
                    $"CRC:{(data.CRC_OK ? "PASS" : "FAIL")}" +
                    Environment.NewLine);
            }
        }
        private void Read_Alldata(object sender, EventArgs e)
        {
            if (SerialPortManager.sp == null || !SerialPortManager.sp.IsOpen)
            {
                MessageBox.Show("请先打开串口！");
                return;
            }
            EncoderData data = null;

            switch (currentProtocol)
            {
                case EncoderProtocol.Tamagawa:
                    data = ReadTamagawaAll();
                    break;


                case EncoderProtocol.ModbusRTU:
                    data = ReadModbusRTUAll();
                    break;


                case EncoderProtocol.CANopen:
                   // data = ReadCAN();
                    break;
            }
            if (data != null)
            {
                textBox1.AppendText(
                    $"ABS: {data.Abs}\r\n" +
                    $"MultiTurn: {data.MultiTurn}\r\n" +
                    $"Angle: {data.Angle:F4}°\r\n" +
                    $"CRC: {(data.CRC_OK ? "PASS" : "FAIL")}\r\n\r\n"
                );
                // 更新顯示窗口
                if (data != null && dataWindow != null)
                {
                    dataWindow.UpdateEncoderData(data.Abs);
                }
            }
        }

        private void Messagesbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContinuousTimer_Tick(object sender, EventArgs e)
        {
            bool oldShowFlag = showDebugInfo;
            showDebugInfo = false;
            EncoderData data = null;
            switch (currentProtocol)
            {
                case EncoderProtocol.Tamagawa:
                    data = ReadTamagawaAll();
                    break;

                case EncoderProtocol.ModbusRTU:

                    data = ReadModbusRTUAll();
                    break;

                case EncoderProtocol.CANopen:
                    break;
            }
            if (data != null)
            {
                // MainForm顯示
                SingleTurnShow.Text =
                    data.Abs.ToString();
                MultiTurnShow.Text =
                    data.MultiTurn.ToString();
                // DataWindow顯示
                if (dataWindow != null &&
                   !dataWindow.IsDisposed)
                {
                    dataWindow.UpdateEncoderData(data.Abs);
                }
            }
            showDebugInfo = oldShowFlag;
        }
        private void Model_Select(object sender, EventArgs e)
        {
            switch (ModelSelect.SelectedItem.ToString())
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
            EncoderConfig.MultiTurnBits =
        int.Parse(comboBox5.SelectedItem.ToString());
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncoderConfig.SingleTurnBits =
        int.Parse(comboBox4.SelectedItem.ToString());
        }

        private void Data_Dispaly_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
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
        private ushort ModbusCalcCRC(byte[] data)
        {
            ushort crc = 0xFFFF;
            foreach (byte b in data)
            {
                crc ^= b;
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
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
                SerialPortManager.WriteData(cmd);
                Thread.Sleep(50);
                int count = SerialPortManager.sp.BytesToRead;
                if (count < 6)
                {
                    return null;
                }
                byte[] rx = new byte[6];
                SerialPortManager.sp.Read(rx, 0, 6);
                uint abs =
                    ((uint)rx[2] << 16) |
                    ((uint)rx[3] << 8) |
                    rx[4];
                abs &= EncoderConfig.SingleTurnMax;
                byte recvCrc = rx[5];
                byte calcCrc =
                    TamagawaCalcCRC(new byte[]
                    {rx[0], rx[1],rx[2],rx[3],rx[4]});
                data.Abs = abs;
                data.Angle =
                    abs * 360.0 / Math.Pow(2, EncoderConfig.SingleTurnBits);
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
                SerialPortManager.WriteData(cmd);
                if (showDebugInfo)
                {
                    textBox1.AppendText(
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
                        textBox1.AppendText(
                            "接受数据错误" +
                            Environment.NewLine);
                    }
                    return null;
                }
                byte[] rx = new byte[6];
                SerialPortManager.sp.Read(rx, 0, 6);
                if (showDebugInfo)
                {
                    textBox1.AppendText(
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

            SerialPortManager.WriteData(cmd);


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
                    textBox1.AppendText(
                        "CRC FAIL" + Environment.NewLine);
                }
                return null;
            }
            uint abs =
                ((uint)rx[2] << 16) |
                ((uint)rx[3] << 8) |
                rx[4];
            abs &= EncoderConfig.SingleTurnMax;
            uint abm =
                ((uint)rx[6] << 16) |
                ((uint)rx[7] << 8) |
                rx[8];
            abm >>= 8;
            abm &= EncoderConfig.MultiTurnMax;
            data.Abs = abs;
            data.MultiTurn = abm;
            data.EnID = rx[5];
            data.Angle =
                abs * 360.0 / Math.Pow(2, EncoderConfig.SingleTurnBits);

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
                // Modbus RTU
                // Slave ID: 01
                // Function: 03
                // Address: 0000H
                // Length: 2 Registers (32bit)

                byte[] cmd = new byte[]
                {0x01,0x03,0x00,0x00,0x00,0x02};
                // 添加CRC
                ushort crc = ModbusCalcCRC(cmd);
                byte[] tx = new byte[]
                {cmd[0],cmd[1],cmd[2],cmd[3],cmd[4],cmd[5],
                (byte)(crc & 0xFF),(byte)(crc >> 8)};
                SerialPortManager.WriteData(tx);
                if (showDebugInfo)
                {
                    textBox1.AppendText(
                        "TX: " +
                        BitConverter.ToString(tx) +
                        Environment.NewLine);
                }
                Thread.Sleep(50);
                int count = SerialPortManager.sp.BytesToRead;
                // 01 03 04 + 4byte数据 + CRC16
                if (count < 9)
                {
                    if (showDebugInfo)
                        textBox1.AppendText(
                            "接受数据错误\r\n");

                    return null;
                }
                byte[] rx = new byte[count];
                SerialPortManager.sp.Read(rx, 0, count);
                if (showDebugInfo)
                {
                    textBox1.AppendText(
                        "RX: " +
                        BitConverter.ToString(rx) +
                        Environment.NewLine);
                }
                // CRC校验
                ushort recvCRC =
                    (ushort)(rx[count - 2] |
                    (rx[count - 1] << 8));
                ushort calcCRC =
                    ModbusCalcCRC(rx.Take(count - 2).ToArray());
                if (recvCRC != calcCRC)
                {
                    data.CRC_OK = false;

                    if (showDebugInfo)
                        textBox1.AppendText(
                            "CRC FAIL\r\n");
                    return null;
                }
                data.CRC_OK = true;
                // Modbus正常返回
                if (rx.Length >= 7 &&
                    rx[1] == 0x03 &&
                    rx[2] == 0x04)
                {
                    uint raw =((uint)rx[3] << 8) | rx[4];
                    raw = raw << 16 | ((uint)rx[5] << 8) | rx[6];
                    uint abs =
                        raw & EncoderConfig.SingleTurnMax;
                    data.Abs = abs;
                    data.Angle =
                        abs * 360.0 / Math.Pow(2, EncoderConfig.SingleTurnBits);
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


                // Modbus RTU
                // Slave ID: 01
                // Function: 03
                // Address: 0002H
                // Length: 2 Registers (32bit)

                byte[] cmd = new byte[]
                {
            0x01,
            0x03,
            0x00,
            0x02,
            0x00,
            0x02
                };


                ushort crc = ModbusCalcCRC(cmd);


                byte[] tx = new byte[]
                {
            cmd[0],
            cmd[1],
            cmd[2],
            cmd[3],
            cmd[4],
            cmd[5],
            (byte)(crc & 0xFF),
            (byte)(crc >> 8)
                };


                SerialPortManager.WriteData(tx);


                if (showDebugInfo)
                {
                    textBox1.AppendText(
                        "TX: " +
                        BitConverter.ToString(tx) +
                        Environment.NewLine);
                }


                Thread.Sleep(50);



                int count = SerialPortManager.sp.BytesToRead;


                // 01 03 04 + 4byte数据 + CRC16
                if (count < 9)
                {
                    if (showDebugInfo)
                        textBox1.AppendText(
                            "接受数据错误\r\n");

                    return null;
                }



                byte[] rx = new byte[count];

                SerialPortManager.sp.Read(rx, 0, count);



                if (showDebugInfo)
                {
                    textBox1.AppendText(
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


                ushort calcCRC =
                    ModbusCalcCRC(crcData);



                if (recvCRC != calcCRC)
                {
                    data.CRC_OK = false;


                    if (showDebugInfo)
                        textBox1.AppendText(
                            "CRC FAIL\r\n");


                    return null;
                }


                data.CRC_OK = true;



                // Modbus正常返回
                if (rx.Length >= 7 &&
                   rx[1] == 0x03 &&
                   rx[2] == 0x04)
                {

                    uint raw =
                        ((uint)rx[3] << 24) |
                        ((uint)rx[4] << 16) |
                        ((uint)rx[5] << 8) |
                        rx[6];



                    // MultiTurn有效12bit
                    uint multi =
                        raw & 0xFFF;



                    data.MultiTurn = multi;


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
                // Modbus RTU
                // Slave ID: 01
                // Function: 03
                // Address: 0000H
                // Length: 4 Registers
                //
                // 0000~0001 SingleTurn
                // 0002~0003 MultiTurn

                byte[] cmd = new byte[]
                {0x01,03,0x00,0x00,0x00,0x04};
                ushort crc = ModbusCalcCRC(cmd);
                byte[] tx = new byte[]
                {cmd[0], cmd[1],cmd[2],cmd[3],cmd[4],cmd[5],(byte)(crc & 0xFF),(byte)(crc >> 8)};
                SerialPortManager.WriteData(tx);
                if (showDebugInfo)
                {
                    textBox1.AppendText(
                        "TX: " +
                        BitConverter.ToString(tx) +
                        Environment.NewLine);
                }
                Thread.Sleep(50);
                int count = SerialPortManager.sp.BytesToRead;
                // 01 03 08 + 8byte数据 + CRC16
                // = 13 byte
                if (count < 13)
                {
                    if (showDebugInfo)
                        textBox1.AppendText(
                            "接受数据错误\r\n");
                    return null;
                }
                byte[] rx = new byte[count];

                SerialPortManager.sp.Read(rx, 0, count);
                if (showDebugInfo)
                {
                    textBox1.AppendText(
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
                ushort calcCRC =
                    ModbusCalcCRC(crcData);
                if (recvCRC != calcCRC)
                {
                    data.CRC_OK = false;
                    if (showDebugInfo)
                        textBox1.AppendText(
                            "CRC FAIL\r\n");
                    return null;
                }
                data.CRC_OK = true;
                // Modbus正常返回
                if (rx.Length >= 11 &&
                   rx[1] == 0x03 &&
                   rx[2] == 0x08)
                {
                    // SingleTurn_Data
                    uint singleRaw = ((uint)rx[3] << 8) | rx[4];
                    singleRaw = singleRaw << 16 | ((uint)rx[5] << 8) | rx[6];
                    // MultiTurn_Data
                    uint multiRaw =
                        ((uint)rx[7] << 24) |
                        ((uint)rx[8] << 16) |
                        ((uint)rx[9] << 8) |
                        rx[10];
                    // 19bit SingleTurn
                    data.Abs =
                        singleRaw & EncoderConfig.SingleTurnMax;
                    // 12bit MultiTurn
                    data.MultiTurn =
                        multiRaw & 0xFFF;
                    data.Angle =
                        data.Abs * 360.0 / Math.Pow(2, EncoderConfig.SingleTurnBits);
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

        private void MultiTurnShow_TextChanged(object sender, EventArgs e)
        {

        }

        private void SingleTurnShow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}