using Encoder.Core.Communication;
using Encoder.Core.Configuration;
using Encoder.Core.Protocol;
using EncoderMonitor.Communication;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

namespace EncoderMonitor
{
    public partial class EncoderSetup : Form
    {
        private byte currentSlaveId;
        public EncoderSetup(byte slaveId)
        {
            InitializeComponent();
            currentSlaveId = slaveId;
        }
        private void EncoderSetup_Load(object sender, EventArgs e)
        {
            Factory_Mode.SelectedItem = "多圈";
            Factory_STChip.SelectedItem = "IC-MU";
            Factory_MTChip.SelectedItem = "IC-PVL";
            Factory_STBits.SelectedItem = "24";
            Factory_MTBits.SelectedItem = "24";
            Factory_CRC.SelectedItem = "6";
            Factory_RegMap.SelectedItem = "Auto";

            UpdateStatusSuccess("Load Complete!");
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void btnFactoryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (Factory_Mode.SelectedItem == null ||
                    Factory_STBits.SelectedItem == null ||
                    Factory_MTBits.SelectedItem == null ||
                    Factory_CRC.SelectedItem == null ||
                    Factory_RegMap.SelectedItem == null)
                {
                    UpdateStatusError("請選擇完整的配置參數");
                    return;
                }


                if (tb_select_setup.SelectedTab == TabTamagawa)
                {
                    UpdateStatusError(
                    "Tamagawa Factory Config: Not Implemented");
                    //WriteTamagawaFactory();
                }
                else if (tb_select_setup.SelectedTab == TabModBusRTU)
                {
                    WriteModbusFactory();
                }
                else if (tb_select_setup.SelectedTab == TabCANopen)
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

            // CRC 检查：最后两个字节是低字节在前
            ushort calcCRC = ModbusCRC.Calculate(
                response.Take(response.Length - 2).ToArray());

            ushort recvCRC = (ushort)(
                response[response.Length - 2] |
                (response[response.Length - 1] << 8));

            if (calcCRC != recvCRC)
            {
                UpdateStatusError("Factory Config: CRC Error");
                return false;
            }

            // 功能码
            if (response[0] != 0x66)
            {
                UpdateStatusError(
                    $"Factory Config: Unexpected Function 0x{response[0]:X2}");
                return false;
            }

            // 成功响应：功能码 + 0x88 + 地址(2) + 写入数量(2) + CRC(2)
            if (response.Length >= 8 && response[1] == 0x88)
            {
                ushort address = (ushort)(
                    (response[2] << 8) | response[3]);

                ushort quantityWritten = (ushort)(
                    (response[4] << 8) | response[5]);

                UpdateStatusSuccess(
                    $"Factory Config: Success, Address=0x{address:X4}, Written={quantityWritten}");

                return true;
            }

            // Modbus 异常响应通常为：功能码 | 异常功能码 | 异常码 | CRC
            if (response.Length >= 5 && response[1] == (0x66 | 0x80))
            {
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
                            $"Factory Config Error: 0x{response[2]:X2}");
                        break;
                }

                return false;
            }

            UpdateStatusError("Factory Config: Invalid Response");
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
                currentSlaveId,
                FactoryConfig.FactoryKey,
                GetFactoryModeValue(),
                GetFactorySTChipValue(),
                GetFactoryMTChipValue(),
                byte.Parse(Factory_STBits.SelectedItem.ToString()),
                byte.Parse(Factory_MTBits.SelectedItem.ToString()),
                GetFactoryCRCValue(),
                GetFactoryRegMapValue(),
                FactoryConfig.FactorySaveKey);

            byte[] response = ModbusReceiver.ReadResponse(1500);
            if (response == null)
            {
                UpdateStatusError("Factory Config Timeout");
                return;
            }
            CheckFactoryResponse(response);
        }

        private byte GetFactoryModeValue()
        {
            switch (Factory_Mode.SelectedItem?.ToString())
            {
                case "单圈":
                    return 0x01;

                case "多圈":
                    return 0x02;

                default:
                    throw new InvalidOperationException("请选择有效的编码器模式");
            }
        }
        private byte GetFactoryRegMapValue()
        {
            switch (Factory_RegMap.SelectedItem?.ToString())
            {
                case "Auto":
                    return 0x00;

                case "16Bits":
                    return 0x01;

                case "32Bits":
                    return 0x02;

                default:
                    throw new InvalidOperationException("请选择有效的寄存器映射模式");
            }
        }
        private byte GetFactorySTChipValue()
        {
            switch (Factory_STChip.SelectedItem?.ToString())
            {
                case "None":
                    return 0x00;

                case "IC-MU":
                    return 0x01;

                case "IC-PZ":
                    return 0x02;

                default:
                    throw new InvalidOperationException("请选择有效的 ST Chip");
            }
        }
        private byte GetFactoryMTChipValue()
        {
            switch (Factory_MTChip.SelectedItem?.ToString())
            {
                case "None":
                    return 0x00;

                case "IC-PVL":
                    return 0x01;

                default:
                    throw new InvalidOperationException("请选择有效的 MT Chip");
            }
        }
        private byte GetFactoryCRCValue()
        {
            switch (Factory_CRC.SelectedItem?.ToString())
            {
                case "6":
                    return 0x00;

                case "16":
                    return 0x01;

                default:
                    throw new InvalidOperationException("请选择有效的 CRC 配置");
            }
        }

        private void Factory_BaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
