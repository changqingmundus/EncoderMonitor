using System.Windows.Controls;

namespace WPF
{
    public partial class DialControl : UserControl
    {
        public DialControl()
        {
            InitializeComponent();
        }

        public void UpdateAngle(double angle)
        {
            PointerTransform.Angle = angle;
        }
    }
}