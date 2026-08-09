using System;
using System.Collections.Generic;
using System.Net;
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
            InitWrite10Grid();

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

            panelRead.Visible = true;
            panelWriteSingle.Visible = false;
            panelWriteMultiple.Visible = false;

            panelRead.BorderStyle = BorderStyle.FixedSingle;
            panelWriteSingle.BorderStyle = BorderStyle.FixedSingle;
            panelWriteMultiple.BorderStyle = BorderStyle.FixedSingle;

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
                "Register Address");


            DataGridViewComboBoxColumn typeColumn =
                new DataGridViewComboBoxColumn();

            typeColumn.Name = "DataType";
            typeColumn.HeaderText = "Data Type";

            typeColumn.Items.AddRange("UINT16","INT16","UINT32",
                                      "INT32","FLOAT32","UINT64","INT64");

            dgvWrite10Registers.Columns.Add(typeColumn);

            DataGridViewComboBoxColumn endian = new DataGridViewComboBoxColumn();

            endian.Name = "Endian";
            endian.HeaderText = "Byte Order";

            endian.Items.AddRange(
                "ABCD",
                "BADC",
                "CDAB",
                "DCBA");
            dgvWrite10Registers.Columns.Add(endian);

            dgvWrite10Registers.Columns.Add(
                "Value",
                "Value(Decimal)");

            dgvWrite10Registers.Columns["Address"].FillWeight = 30;
            dgvWrite10Registers.Columns["DataType"].FillWeight = 20;
            dgvWrite10Registers.Columns["Endian"].FillWeight = 20;
            dgvWrite10Registers.Columns["Value"].FillWeight = 30;
            dgvWrite10Registers.AllowUserToResizeRows = false;
            dgvWrite10Registers.AllowUserToResizeColumns = false;

            // 隱藏左側行標
            dgvWrite10Registers.RowHeadersVisible = false;

            // 固定行高度
            foreach (DataGridViewRow row in dgvWrite10Registers.Rows)
            {
                row.Height = 20;
            }

            // 禁止新增空白行
            dgvWrite10Registers.AllowUserToAddRows = false;
            dgvWrite10Registers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvWrite10Registers.MultiSelect = false;
            dgvWrite10Registers.Columns["Address"].ReadOnly = true;
            dgvWrite10Registers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void cmbFunctionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModbusFunctionItem item =
                cmbFunctionCode.SelectedItem
                as ModbusFunctionItem;

            if (item == null)
                return;

            panelRead.Visible = false;
            panelWriteSingle.Visible = false;
            panelWriteMultiple.Visible = false;

            switch (item.Code)
            {
                case 0x03:
                    panelRead.Visible = true;
                    break;

                case 0x06:
                    panelWriteSingle.Visible = true;
                    break;

                case 0x10:
                    panelWriteMultiple.Visible = true;
                    break;
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
                Convert.ToUInt16(txtStartAddress03.Text, 16);
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
                Convert.ToUInt16(txtStartAddress06.Text, 16);
            ushort value = (ushort)Convert.ToInt32(t_bvalue06.Text);
            byte[] frame =
            {slave,0x06,(byte)(address >> 8),
                        (byte)address,
                        (byte)(value >> 8),
                        (byte)value};
            return ModbusCRC.AppendCRC(frame);
        }
        private byte[] BuildWrite10()
        {
            List<byte> frame = new List<byte>();

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

        private void dgvWrite10Registers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvWrite10Registers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvWrite10Registers.IsCurrentCellDirty)
            {
                dgvWrite10Registers.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dgvWrite10Registers_CellValueChanged(object sender,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (e.ColumnIndex ==
                dgvWrite10Registers.Columns["DataType"].Index)
            {

                string type =
                    dgvWrite10Registers.Rows[e.RowIndex]
                    .Cells["DataType"].Value?.ToString();


                DataGridViewCell endianCell =
                    dgvWrite10Registers.Rows[e.RowIndex]
                    .Cells["Endian"];


                if (type == "UINT16" ||
                    type == "INT16")
                {
                    endianCell.Value = "";

                    endianCell.ReadOnly = true;
                }
                else
                {
                    endianCell.Value = "ABCD";

                    endianCell.ReadOnly = false;
                }


                UpdateRegisterAddress();
            }
        }
        private void dgvWrite10Registers_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex ==
               dgvWrite10Registers.Columns["Endian"].Index)
            {

                string type =
                    dgvWrite10Registers.Rows[e.RowIndex]
                    .Cells["DataType"].Value?.ToString();


                if (type == "UINT16" ||
                   type == "INT16")
                {
                    e.Cancel = true;
                }
            }
        }
        private void Button_AddRegister_Click(object sender, EventArgs e)
        {
            UpdateRegisterAddress();
            int index = dgvWrite10Registers.Rows.Count;

            dgvWrite10Registers.Rows.Add(
                "",
                "UINT16",
                "ABCD",
                "0"
            );
            UpdateRegisterAddress();
        }

        private void Button_DelRegister_Click(object sender, EventArgs e)
        {
            if (dgvWrite10Registers.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please Select A Register");
                return;
            }


            foreach (DataGridViewRow row
                in dgvWrite10Registers.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dgvWrite10Registers.Rows.Remove(row);
                }
            }
        }
        private void UpdateRegisterAddress()
        {
            ushort address;

            if (!ushort.TryParse(
                txtStartAddress10.Text,
                System.Globalization.NumberStyles.HexNumber,
                null,
                out address))
            {
                return;
            }


            foreach (DataGridViewRow row in dgvWrite10Registers.Rows)
            {
                if (row.IsNewRow)
                    continue;


                string type =
                    row.Cells["DataType"].Value?.ToString();


                ushort length = GetRegisterLength(type);
                row.Cells["Address"].Value =
                    string.Format("{0:X4} ({1})",
                    address,
                    length);

                address += length;
            }

            txtWrite10Quantity.Text =
                GetTotalRegisterCount().ToString();
        }
        private ushort GetRegisterLength(string type)
        {
            switch (type)
            {
                case "UINT16":
                case "INT16":
                    return 1;


                case "UINT32":
                case "INT32":
                case "FLOAT32":
                    return 2;


                case "UINT64":
                case "INT64":
                    return 4;


                default:
                    return 1;
            }
        }
        private int GetTotalRegisterCount()
        {
            int count = 0;


            foreach (DataGridViewRow row
                in dgvWrite10Registers.Rows)
            {
                if (row.IsNewRow)
                    continue;


                count += GetRegisterLength(
                    row.Cells["DataType"].Value.ToString());
            }


            return count;
        }
    }
}
