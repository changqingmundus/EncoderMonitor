using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Dashboard.UI
{
    public partial class DirectionIndicator : UserControl
    {
        private double angle = 0;
        private int speed = 0;
        private int direction = 0;

        private DispatcherTimer timer;
        public DirectionIndicator()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public void UpdateDirection(int dir, int rpm)
        {
            direction = dir;
            speed = rpm;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (direction == 1)       // CW
            {
                angle += speed * 0.02;
            }
            else if (direction == 2)  // CCW
            {
                angle -= speed * 0.02;
            }

            InvalidateVisual();
        }


        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);


            double cx = ActualWidth / 2;
            double cy = ActualHeight / 2;

            double radius =
                Math.Min(ActualWidth, ActualHeight) / 2 - 10;


            dc.PushTransform(
                new TranslateTransform(cx, cy));


            dc.PushTransform(
                new RotateTransform(angle));


            List<Point> points = new List<Point>();

            int turns = 3;
            int count = 120;


            for (int i = 0; i < count; i++)
            {
                double t =
                    (double)i / (count - 1);

                double r =
                    radius * t;

                double a =
                    t * turns * 2 * Math.PI;


                points.Add(
                    new Point(
                        r * Math.Cos(a),
                        r * Math.Sin(a)));
            }


            Pen pen = new Pen(
                Brushes.DodgerBlue,
                3);


            for (int i = 0; i < points.Count - 1; i++)
            {
                dc.DrawLine(
                    pen,
                    points[i],
                    points[i + 1]);
            }


            dc.DrawEllipse(
                Brushes.Black,
                null,
                new Point(0, 0),
                5,
                5);


            dc.Pop();
            dc.Pop();
        }
    }
}