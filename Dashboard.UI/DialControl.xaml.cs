using System.Windows.Controls;

namespace Dashboard.UI
{
    public partial class DialControl : UserControl
    {
        public DialControl()
        {
            InitializeComponent();
        }
        private double _angle;
        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                PointerTransform.Angle = value;
            }
        }
    }
}