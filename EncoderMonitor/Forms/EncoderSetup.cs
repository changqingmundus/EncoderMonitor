using EncoderMonitor.Communication;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EncoderMonitor
{
    public partial class EncoderSetup : Form
    {
        public EncoderSetup()
        {
            InitializeComponent();
        }
        private void EncoderSetup_Load(object sender, EventArgs e)
        {
            Factory_BaudRate.SelectedItem = "9600";
            Factory_Parity.SelectedIndex = 0;
            Factory_ST.SelectedItem = "16";
            Factory_MT.SelectedItem = "12";
            Factory_CRC.SelectedItem = "6";

            UpdateStatusSuccess("Load Complete!");
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void btnFactoryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                // 檢查參數
                if (Factory_ST.SelectedItem == null ||
                    Factory_MT.SelectedItem == null ||
                    Factory_CRC.SelectedItem == null)
                {
                    UpdateStatusError("請選擇配置參數");
                    return;
                }


                if (tabControl1.SelectedTab == TabTamagawa)
                {
                    UpdateStatusError(
                    "Tamagawa Factory Config: Not Implemented");
                    //WriteTamagawaFactory();
                }
                else if (tabControl1.SelectedTab == TabModBusRTU)
                {
                    WriteModbusFactory();
                }
                else if (tabControl1.SelectedTab == TabCANopen)
                {
                    UpdateStatusError(
                    "CAN Factory Config: Not Implemented");
                    //WriteCANFactory();
                }
            }
            catch (Exception ex)
            {
                UpdateStatusError(
                    $"Factory Config Error: {ex.Message}");
            }
        }
        private bool CheckFactoryResponse(byte[] response)
        {
            if (response == null || response.Length < 5)
            {
                UpdateStatusError("Factory Config: No Response");
                return false;
            }


            // CRC檢查
            ushort calcCRC = ModbusCRC.Calculate(
                response.Take(response.Length - 2).ToArray()
            );

            ushort recvCRC =
                (ushort)(
                    response[response.Length - 2] |
                    (response[response.Length - 1] << 8)
                );


            if (calcCRC != recvCRC)
            {
                UpdateStatusError("Factory Config: CRC Error");
                return false;
            }

            // Slave
            if (response[0] != (byte)Factory_SlaveID.Value)
            {
                UpdateStatusError("Slave ID Error");
                return false;
            }

            // Function
            if (response[1] == 0x66)
            {
                // 成功
                if (response[2] == 0x88)
                {
                    UpdateStatusSuccess("Factory Config: Success");
                    return true;
                }


                // Modbus異常碼
                switch (response[2])
                {
                    case 0x01:
                        UpdateStatusError("Illegal Function");
                        break;

                    case 0x02:
                        UpdateStatusError("Illegal Address");
                        break;

                    case 0x03:
                        UpdateStatusError("Illegal Data");
                        break;

                    case 0x04:
                        UpdateStatusError("Slave Device Error");
                        break;

                    default:
                        UpdateStatusError(
                            $"Factory Config Error: 0x{response[2]:X2}"
                        );
                        break;
                }
            }

            return false;
        }
        private void LogToUIsetup(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogToUIsetup), msg);
                return;
            }


            string time =
                DateTime.Now.ToString("HH:mm:ss.fff");


            LogShowbox.AppendText(
                $"[{time}] {msg}\r\n"
            );


            // 自動滾動到底部
            LogShowbox.SelectionStart = LogShowbox.Text.Length;
            LogShowbox.ScrollToCaret();
        }
        private void UpdateStatusSuccess(string text)
        {
            LogToUIsetup(text + "[OK] ");
        }
        private void UpdateStatusError(string text)
        {
            LogToUIsetup(text + "[ERROR] ");
        }
        private void WriteModbusFactory()
        {
            FactoryConfig.WriteEncoder(
                (byte)Factory_SlaveID.Value,
                byte.Parse(Factory_ST.SelectedItem.ToString()),
                byte.Parse(Factory_MT.SelectedItem.ToString()),
                byte.Parse(Factory_CRC.SelectedItem.ToString())
            );
            byte[] response = ModbusReceiver.ReadResponse(500);
            if (response == null)
            {
                UpdateStatusError("Factory Config Timeout");
                return;
            }
            CheckFactoryResponse(response);
        }

        private void Change_FreeMode_Click(object sender, EventArgs e)
        {
            byte[] cmd ={EncoderConfig.Modbus.SlaveID,0x06,0x00,0x08,0x00,0x02};
            ushort crc = ModbusCRC.Calculate(cmd);
            byte[] frame ={cmd[0],cmd[1],cmd[2],cmd[3],cmd[4],cmd[5],
                           (byte)(crc & 0xff),(byte)(crc >> 8)};
            try
            {
                SerialPortManager.WriteData(frame);
                UpdateStatusSuccess("FreeMode Enable Command Sent");
                // 等待設備回覆 500ms
                byte[] response =
                    ModbusReceiver.ReadResponse(500);
                if (response == null)
                {
                    UpdateStatusSuccess(
                        "FreeMode Enable Timeout"
                    );
                    return;
                }
                //UpdateStatusSuccess("RX: " + BitConverter.ToString(response));
                if (response.Length == 8)
                {
                    UpdateStatusSuccess("FreeMode Enable Success");
                }
                else
                {
                    UpdateStatusError("FreeMode Response Length Error");
                }
            }
            catch (Exception ex)
            {
                UpdateStatusError(
                    "FreeMode Send Error: " + ex.Message
                );
            }
        }
    }
}
