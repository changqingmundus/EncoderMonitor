using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EncoderMonitor
{
    public partial class Advance_Settings : Form
    {
        public Advance_Settings()
        {
            InitializeComponent();
        }
        public enum ModbusFunction : byte
        {

            ReadCoils = 0x01,                  // 01H - Read Coils
            ReadDiscreteInputs = 0x02,         // 02H - Read Discrete Inputs
            ReadHoldingRegisters = 0x03,       // 03H - Read Holding Registers
            ReadInputRegisters = 0x04,         // 04H - Read Input Registers
            WriteSingleCoil = 0x05,            // 05H - Write Single Coil
            WriteSingleRegister = 0x06,        // 06H - Write Single Register
            WriteMultipleCoils = 0x0F,         // 0FH - Write Multiple Coils
            WriteMultipleRegisters = 0x10,     // 10H - Write Multiple Registers
            MaskWriteRegister = 0x16,          // 16H - Mask Write Register
            ReadWriteMultipleRegisters = 0x17, // 17H - Read/Write Multiple Registers
            ReadFIFOQueue = 0x18               // 18H - Read FIFO Queue
        }
        private void Advance_Settings_Load(object sender, EventArgs e)
        {
            InitFunctionCode();
            InitRegisterMap();

            // 列寬自動填滿
            dgvRegisterMap.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Name列禁止修改
            dgvRegisterMap.Columns["colName"].ReadOnly = true;

            // Address列允許修改
            dgvRegisterMap.Columns["colAddress"].ReadOnly = false;

            // 列寬比例
            dgvRegisterMap.Columns["colName"].FillWeight = 70;
            dgvRegisterMap.Columns["colAddress"].FillWeight = 30;

            // 禁止拖動調整行高和列寬
            dgvRegisterMap.AllowUserToResizeRows = false;
            dgvRegisterMap.AllowUserToResizeColumns = false;

            // 隱藏左側行標
            dgvRegisterMap.RowHeadersVisible = false;

            // 固定行高度
            foreach (DataGridViewRow row in dgvRegisterMap.Rows)
            {
                row.Height = 30;
            }

            // 禁止新增空白行
            dgvRegisterMap.AllowUserToAddRows = false;
            dgvRegisterMap.SelectionMode =
                          DataGridViewSelectionMode.FullRowSelect;

        }
        public class ModbusFunctionItem
        {
            public byte Code { get; set; }

            public string Name { get; set; }

            public override string ToString()
            {
                return $"{Code:X2}H - {Name}";
            }
        }
        private void InitFunctionCode()
        {
            List<ModbusFunctionItem> list = new List<ModbusFunctionItem>(){
        new ModbusFunctionItem
        {
            Code = 0x01,
            Name = "Read Coils"
        },

        new ModbusFunctionItem
        {
            Code = 0x02,
            Name = "Read Discrete Inputs"
        },

        new ModbusFunctionItem
        {
            Code = 0x03,
            Name = "Read Holding Registers"
        },

        new ModbusFunctionItem
        {
            Code = 0x04,
            Name = "Read Input Registers"
        },

        new ModbusFunctionItem
        {
            Code = 0x05,
            Name = "Write Single Coil"
        },

        new ModbusFunctionItem
        {
            Code = 0x06,
            Name = "Write Single Register"
        },

        new ModbusFunctionItem
        {
            Code = 0x0F,
            Name = "Write Multiple Coils"
        },

        new ModbusFunctionItem
        {
            Code = 0x10,
            Name = "Write Multiple Registers"
        },

        new ModbusFunctionItem
        {
            Code = 0x16,
            Name = "Mask Write Register"
        },

         new ModbusFunctionItem
         {
             Code = 0x17,
             Name = "Read/Write Multiple Registers"
         }
         };
            cmbFunctionCode.DataSource = list;
        }
        private void InitRegisterMap()
        {
            dgvRegisterMap.Rows.Clear();
            dgvRegisterMap.RowHeadersVisible = false;

            dgvRegisterMap.Rows.Add(
                "SlaveID",
                "0x0002"
            );
            dgvRegisterMap.Rows.Add(
                "SingleTurn",
                "0x0000"
            );
            dgvRegisterMap.Rows.Add(
                "MultiTurn",
                "0x0001"
            );
            dgvRegisterMap.Rows.Add(
                "Count Direction",
                "0x0006"
            );
            dgvRegisterMap.Rows.Add(
                "Rotation Direction",
                "0x000B"
            );
            dgvRegisterMap.Rows.Add(
                "Rotation Speed",
                "0x000C"
            );

            dgvRegisterMap.Rows.Add(
                "Clear Zero",
                "0x0005"
            );
            dgvRegisterMap.Rows.Add(
                "Zero Position",
                "0x0023"
            );
            dgvRegisterMap.Rows.Add(
                "Speed Update Period",
                "0x0024"
            );
            dgvRegisterMap.Rows.Add(
                "Write Position Low",
                "0x0032"
            );
            dgvRegisterMap.Rows.Add(
                "Write Position High",
                "0x0033"
            );
            dgvRegisterMap.Rows.Add(
                "Encoder Value High",
                "0x0009"
            );
            dgvRegisterMap.Rows.Add(
                "Encoder Value Low",
                "0x000A"
            );
            // 補空行
            for (int i = 0; i < 5; i++)
            {
                dgvRegisterMap.Rows.Add(
                    "",
                    ""
                );
            }
        }
        private void InitWrite10Grid()
        {
            dgvWrite10Registers.Columns.Clear();


            dgvWrite10Registers.Columns.Add(
                "Address",
                "寄存器地址");


            DataGridViewComboBoxColumn typeColumn =
                new DataGridViewComboBoxColumn();

            typeColumn.Name = "DataType";
            typeColumn.HeaderText = "數據類型";

            typeColumn.Items.Add("UINT16");
            typeColumn.Items.Add("INT16");

            dgvWrite10Registers.Columns.Add(typeColumn);


            dgvWrite10Registers.Columns.Add(
                "Value",
                "數值(十進制)");

            dgvWrite10Registers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void cmbFunctionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFunctionCode.SelectedItem is ModbusFunctionItem item)
            {
                byte function = item.Code;

                Console.WriteLine(function.ToString("X2"));
            }
        }
        private byte[] GenerateCommand()
        {
            ModbusFunctionItem item =
                cmbFunctionCode.SelectedItem as ModbusFunctionItem;


            if (item == null)
                return null;


            switch (item.Code)
            {
                case 0x03:
                    return BuildRead03();

                case 0x06:
                    return BuildWrite06();

                case 0x10:
                    return BuildWrite10();

                default:
                    return null;
            }
        }
        private void SaveConfig_Click(object sender, EventArgs e)
        {
            byte[] frame = GenerateCommand();
            if (frame == null)
            {
                MessageBox.Show("Command Error");
                return;
            }
            SerialPortManager.WriteData(frame);
        }

        private byte[] BuildRead03()
        {
            byte slave = EncoderConfig.Modbus.SlaveID;
            ushort address =
                Convert.ToUInt16(txtStartAddress.Text, 16);
            ushort quantity = (ushort)numQuantity.Value;
            byte[] frame =
            {slave,0x03,(byte)(address >> 8),
                        (byte)address,
                        (byte)(quantity >> 8),
                        (byte)quantity};
            return ModbusCRC.AppendCRC(frame);
        }
        private byte[] BuildWrite06()
        {
            byte slave = EncoderConfig.Modbus.SlaveID;
            ushort address =
                Convert.ToUInt16(txtStartAddress.Text, 16);
            ushort quantity = (ushort)numQuantity.Value;
            byte[] frame =
            {slave,0x06,(byte)(address >> 8),
                        (byte)address,
                        (byte)(value >> 8),
                        (byte)value};
            return ModbusCRC.AppendCRC(frame);
        }
        private byte[] BuildWrite10()
        {
            List<byte> frame = new();

            frame.Add(
                EncoderConfig.Modbus.SlaveID);

            frame.Add(0x10);

            ushort startAddress =
                Convert.ToUInt16(
                    dgvWrite10Registers.Rows[0]
                    .Cells["Address"].Value.ToString(),16);

            ushort quantity =
                (ushort)dgvWrite10Registers.Rows.Count;

            frame.Add((byte)(startAddress >> 8));
            frame.Add((byte)startAddress);

            frame.Add((byte)(quantity >> 8));
            frame.Add((byte)quantity);

            frame.Add((byte)(quantity * 2));

            foreach (DataGridViewRow row
                in dgvWrite10Registers.Rows)
            {
                ushort value =
                    Convert.ToUInt16(
                        row.Cells["Value"].Value);


                frame.Add((byte)(value >> 8));
                frame.Add((byte)value);
            }

            return ModbusCRC.AppendCRC(frame.ToArray());
        }
        private void dgvRegisterMap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabCommandConfig_Click(object sender, EventArgs e)
        {

        }

        private void rdoHex_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoDec_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
