using EncoderMonitor.Communication;
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
    public partial class EncoderSetup : Form
    {
        public EncoderSetup()
        {
            InitializeComponent();
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
                    byte.Parse(Factory_CRC.SelectedItem.ToString())
                    );

                    //uint.Parse(Factory_BaudRate.SelectedItem.ToString()),
                    //(byte)Factory_Parity.SelectedIndex
                /*FactoryConfig.WriteAllFactoryConfig(

                    (byte)Factory_SlaveID.Value,

                    byte.Parse(Factory_ST.SelectedItem.ToString()),
                    byte.Parse(Factory_MT.SelectedItem.ToString()),
                    byte.Parse(Factory_CRC.SelectedItem.ToString()),

                    uint.Parse(Factory_BaudRate.SelectedItem.ToString()),
                    (byte)Factory_Parity.SelectedIndex
                );*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "寫入失敗:\r\n" + ex.Message
                );
            }
        }
    }
}
