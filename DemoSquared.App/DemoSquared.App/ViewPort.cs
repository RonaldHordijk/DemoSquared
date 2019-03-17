using DemoSquared.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.App
{
    public class ViewPort
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private readonly ViewModel.Point MinWorld_;
        private readonly ViewModel.Point MaxWorld_;
        private ViewModel.Point MidWorld_;
        private double scale_;

        public ViewPort(int screenWidth, int screenHeight, ViewModel.Point MinWorld, ViewModel.Point MaxWorld)
        {
            Width = screenWidth;
            Height = screenHeight;

            MinWorld_ = MinWorld;
            MaxWorld_ = MaxWorld;

            CalulateTransformation();
        }

        private void CalulateTransformation()
        {
            const double PercetageOfScreenUse = 0.9;

            scale_ = PercetageOfScreenUse * Math.Min(
              Width / (MaxWorld_.X - MinWorld_.X),
              Height / (MaxWorld_.Y - MinWorld_.Y));

            MidWorld_ = new ViewModel.Point
            {
                X = 0.5 * MinWorld_.X + 0.5 * MaxWorld_.X,
                Y = 0.5 * MinWorld_.Y + 0.5 * MaxWorld_.Y,
                Z = 0.5 * MinWorld_.Z + 0.5 * MaxWorld_.Z
            };
        }

        public void ResizeScreen(int screenWidth, int screenHeight)
        {
            Width = screenWidth;
            Height = screenHeight;

            CalulateTransformation();
        }

        public PointF WorldToScreen(ViewModel.Point point)
        {
            return new PointF
            {
                X = (float)((point.X - MidWorld_.X) * scale_ + 0.5 * Width),
                Y = (float)((point.Y - MidWorld_.Y) * scale_ + 0.5 * Height),
            };
        }
    }
}
