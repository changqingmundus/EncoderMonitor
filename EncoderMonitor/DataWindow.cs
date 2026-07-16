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

namespace EncoderMonitor
{
    public partial class DataWindow : Form
    {
        private WPF.DialControl dialControl1;
        public DataWindow()
        {
            InitializeComponent();
            dialControl1 = new WPF.DialControl();           //調用角度盤
            elementHost_AngleShow.Child = dialControl1;     //調用角度盤
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void UpdateEncoderData(uint abs)
        {
            uint resolution = (uint)(1UL << EncoderConfig.SingleTurnBits);
            double angle =
                abs * 360.0 / resolution;
            // 二进制显示，根据单圈位数变化
            textBox_Binary.Text =
                Convert.ToString(abs, 2)
                .PadLeft(EncoderConfig.SingleTurnBits, '0');
            // 实时位置 / 分辨率
            textBox_Resolution.Text =
                $"{abs} / {resolution}";
            // 角度显示
            textBox_Angle.Text =
                angle.ToString("000.000") + " deg";
            // 更新表盘
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

        private void textBox_Resolution_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
