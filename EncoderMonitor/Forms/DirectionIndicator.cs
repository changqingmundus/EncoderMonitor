using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EncoderMonitor
{
    public partial class DirectionIndicator : UserControl
    {
        private float angle = 0;
        private int speed = 0;
        private int direction = 0;
        private Timer timer;

        public DirectionIndicator()
        {
            InitializeComponent();
            DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public void UpdateDirection(
            int dir,
            int rpm)
        {
            direction = dir;
            speed = rpm;
        }
        private void Timer_Tick(
            object sender,
            EventArgs e)
        {
            if (direction == 1)       // CCW
            {
                angle -= speed * 0.02f;
            }
            else if (direction == 2)  // CW
            {
                angle += speed * 0.02f;
            }
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float cx = Width / 2f;
            float cy = Height / 2f;
            float radius =
                Math.Min(Width, Height) / 2f - 10;
            g.TranslateTransform(cx, cy);
            g.RotateTransform(angle);
            // 螺旋線
            List<PointF> points = new List<PointF>();
            int turns = 3;        // 螺旋圈數
            int count = 120;      // 平滑程度
            for (int i = 0; i < count; i++)
            {
                float t =
                    (float)i / (count - 1);
                float r =
                    radius * t;
                float a =
                    t * turns * 2 *
                    (float)Math.PI;
                float x =
                    r * (float)Math.Cos(a);
                float y =
                    r * (float)Math.Sin(a);
                points.Add(
                    new PointF(x, y));
            }
            using (Pen pen =
                new Pen(Color.DodgerBlue, 3))
            {
                g.DrawLines(
                    pen,
                    points.ToArray());
            }
            // 中心圓
            g.FillEllipse(
                Brushes.Black,
                -5,
                -5,
                10,
                10);
            g.ResetTransform();
        }
    }
}