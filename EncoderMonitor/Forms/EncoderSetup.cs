using EncoderMonitor.Communication;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;

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
            Factory_BaudRate.SelectedItem = "38400";
            Factory_Parity.SelectedIndex = 0;
            Factory_ST.SelectedItem = "19";
            Factory_MT.SelectedItem = "12";
            Factory_CRC.SelectedItem = "6";
            
            StatusLabel.Text = "Status: Ready";
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void btnFactoryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (Factory_ST.SelectedItem == null ||
                    Factory_MT.SelectedItem == null ||
                    Factory_CRC.SelectedItem == null ||
                    Factory_BaudRate.SelectedItem == null ||
                    Factory_Parity.SelectedItem == null)
                {
                    MessageBox.Show("請選擇配置參數");
                    return;
                }

                FactoryConfig.WriteEncoder(
                   (byte)Factory_SlaveID.Value,
                   byte.Parse(Factory_ST.SelectedItem.ToString()),
                   byte.Parse(Factory_MT.SelectedItem.ToString()),
                   byte.Parse(Factory_CRC.SelectedItem.ToString()));

                   // 等待設備回覆
                   byte[] response = ModbusReceiver.ReadResponse();
      
                   // 解析回覆
                   CheckFactoryResponse(response);
            }
            catch (Exception ex)
            {
                UpdateStatusError("Write Error: " + ex.Message);
            }
        }
        private bool CheckFactoryResponse(byte[] response)
        {
            if (response == null || response.Length < 5)
            {
                UpdateStatusError("Factory Config No Response");
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
                UpdateStatusError("Factory Config CRC Error");
                return false;
            }


            // Slave
            // Function
            if (response[1] == 0x66)
            {
                // 成功
                if (response[2] == 0x88)
                {
                    UpdateStatusSuccess("Factory Config Success");
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
        private void UpdateStatusSuccess(string text)
        {
            StatusLabel.Text = text;
            StatusLabel.ForeColor = Color.Green;
        }


        private void UpdateStatusError(string text)
        {
            StatusLabel.Text = text;
            StatusLabel.ForeColor = Color.Red;
        }
    }
}
