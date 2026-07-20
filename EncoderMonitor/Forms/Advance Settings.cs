using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderMonitor
{
    public partial class Advance_Settings : Form
    {
        private void Advance_Settings_Load(object sender, EventArgs e)
        {

        }

        private void LoadConfig_Click(object sender, EventArgs e)
        {

        }

        private void SaveConfig_Click(object sender, EventArgs e)
        {
            EncoderConfig.Modbus.SlaveID =
        (byte)numericSlaveID.Value;


            EncoderConfig.Modbus.FunctionCode =
                Convert.ToByte(
                    comboFunctionCode.SelectedItem.ToString(),
                    16);


            EncoderConfig.Modbus.StartAddress =
                Convert.ToUInt16(
                    textAddress.Text,
                    16);


            EncoderConfig.Modbus.RegisterCount =
                (ushort)numericCount.Value;


            MessageBox.Show("Save OK");
        }
    }
}
