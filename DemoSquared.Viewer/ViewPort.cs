using DemoSquared.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.Viewer
{
  public class ViewPort
  {
    private int screenWidth_;
    private int screenHeight_;
    private readonly ViewModel.Point MinWorld_;
    private readonly ViewModel.Point MaxWorld_;
    private ViewModel.Point MidWorld_;
    private double scale_;

    public ViewPort(int screenWidth, int screenHeight, ViewModel.Point MinWorld, ViewModel.Point MaxWorld)
    {
      screenWidth_ = screenWidth;
      screenHeight_ = screenHeight;

      MinWorld_ = MinWorld;
      MaxWorld_ = MaxWorld;

      CalulateTransformation();
    }

    private void CalulateTransformation()
    {
      const double PercetageOfScreenUse = 0.9;

      scale_ = PercetageOfScreenUse * Math.Min(screenWidth_ / (MaxWorld_.X - MinWorld_.X),
        screenHeight_ / (MaxWorld_.Y - MinWorld_.Y));

      MidWorld_ = new ViewModel.Point
      {
        X = 0.5 * MinWorld_.X + 0.5 * MaxWorld_.X,
        Y = 0.5 * MinWorld_.Y + 0.5 * MaxWorld_.Y,
        Z = 0.5 * MinWorld_.Z + 0.5 * MaxWorld_.Z
      };
    }

    public void ResizeScreen(int screenWidth, int screenHeight)
    {
      screenWidth_ = screenWidth;
      screenHeight_ = screenHeight;

      CalulateTransformation();
    }

    public PointF WorldToScreen(ViewModel.Point point)
    {
      return new PointF
      {
        X = (float)((point.X - MidWorld_.X) * scale_ + 0.5 * screenWidth_),
        Y = (float)((point.Y - MidWorld_.Y) * scale_ + 0.5 * screenHeight_),
      };
    }
  }
}
