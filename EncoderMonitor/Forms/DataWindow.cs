using Dashboard.UI;
using Encoder.Core.Configuration;
using Encoder.Core.Data;
using System;
using System.Windows.Forms;

namespace EncoderMonitor
{
    public partial class DataWindow : Form
    {
        private Dashboard.UI.DialControl dialControl1;
        public DataWindow()
        {
            InitializeComponent();
            dialControl1 = new Dashboard.UI.DialControl();  //調用角度盤
            ele_AngleShow.Child = dialControl1;     //調用角度盤
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void UpdateEncoderData(EncoderData data)
        {
            uint resolution = (uint)(1UL << EncoderConfig.SingleTurnBits);
            double angle = data.SingleTurn * 360.0 / resolution;
            // 二进制显示，根据单圈位数变化
            textBox_Binary.Text = Convert.ToString(data.SingleTurn, 2)
                                 .PadLeft(EncoderConfig.SingleTurnBits, '0');
            // 实时位置 / 分辨率
            textBox_Resolution.Text = $"{data.SingleTurn} / {resolution - 1}";
            // 角度显示
            textBox_Angle.Text = angle.ToString("000.000") + " deg";
            // 更新表盘
            dialControl1.Angle = angle;

            directionIndicator2.UpdateDirection(data.Direction, data.Speed);
        }
        public void UpdateAngle(double angle)
        {
            if (dialControl1 != null)
            {
                dialControl1.Angle = angle;
            }
        }
    }
}
