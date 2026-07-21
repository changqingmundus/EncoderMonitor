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
        public Advance_Settings()
        {
            InitializeComponent();
        }
        private void Advance_Settings_Load(object sender, EventArgs e)
        {

        }

        private void LoadConfig_Click(object sender, EventArgs e)
        {

        }

        private void SaveConfig_Click(object sender, EventArgs e)
        {
            EncoderConfig.Modbus.SlaveID =
        (byte)SetSlaveID.Value;


            EncoderConfig.Modbus.FunctionCode =
                Convert.ToByte(
                    SetFunctionCode.SelectedItem.ToString(),
                    16);


            EncoderConfig.Modbus.AllAddress =
                Convert.ToUInt16(
                    SetAddress.Text,
                    16);


            EncoderConfig.Modbus.AllCount =
                (ushort)SetRegisterCount.Value;


            MessageBox.Show("Save OK");
        }
    }
}
