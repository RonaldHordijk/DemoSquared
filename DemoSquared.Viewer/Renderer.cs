using DemoSquared.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.Viewer
{
  internal sealed class Renderer
  {
    private readonly DisplayModel _displayModel;
    private readonly ViewPort _viewPort;

    public Renderer(DisplayModel displayModel, ViewPort viewPort)
    {
      _displayModel = displayModel;
      _viewPort = viewPort;
    }

    public Bitmap MakeImage()
    {
      Bitmap bmp = new Bitmap(_viewPort.Width, _viewPort.Height);
      Graphics g = Graphics.FromImage(bmp);

      g.SmoothingMode = SmoothingMode.HighQuality;

      g.FillRectangle(new SolidBrush(Color.White), 0, 0, _viewPort.Width, _viewPort.Height);

      var pen = new Pen(Color.Black);
      var fill = new SolidBrush(Color.Lime);

      foreach (var floor in _displayModel.Floors)
      {
        if (!floor.Visible)
          continue;

        foreach (var space in floor.Spaces)
        {
          foreach (var polygon in space.Polygons)
          {
            var points = polygon.Points.Select(_viewPort.WorldToScreen).ToArray();
            g.DrawPolygon(pen, points);

            if (space.Selected)
            {
              g.FillPolygon(fill, points);
            }
          }
        }
      }

      return bmp;
    }
  }
}
