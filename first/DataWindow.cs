using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace TamagawaUSB
{
    public partial class DataWindow : Form
    {
        private WPF.DialControl dialControl1;
        public DataWindow()
        {
            InitializeComponent();
            dialControl1 = new WPF.DialControl();           //調用角度盤
            elementHost_AngleShow.Child = dialControl1;     //調用角度盤
        }
        public void UpdateEncoderData(uint abs)
        {
            double angle = abs * 360.0 / 524288.0;

            textBox_Binary.Text =
                Convert.ToString(abs, 2).PadLeft(19, '0');

            textBox_Resolution.Text =
                "524288";

            textBox_Angle.Text =
                angle.ToString("000.000") + " deg";

            dialControl1.UpdateAngle(angle);
        }
        public void UpdateAngle(double angle)
        {
            if (dialControl1 != null)
            {
                dialControl1.UpdateAngle(angle);
            }
        }
        private void DataWindow_Load(object sender, EventArgs e)
        {
           
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void textBox_Binary_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Angle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
