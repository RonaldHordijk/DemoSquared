using DemoSquared.ViewModel;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.App
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

        public void Draw(SKCanvas canvas)
        {
            canvas.Clear(new SKColor(255, 255, 255));



            using (var Pen = new SKPaint
            {
                Color = new SKColor(0, 0, 0),
                Style = SKPaintStyle.Stroke,
                IsAntialias = true,
                StrokeWidth = 5
            })
            using (var Selected = new SKPaint
            {
                Color = new SKColor(64, 64, 255),
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                StrokeWidth = 15
            })
            {

                foreach (var floor in _displayModel.Floors)
                {
                    if (!floor.Visible)
                        continue;

                    foreach (var space in floor.Spaces)
                    {
                        foreach (var polygon in space.Polygons)
                        {
                            var points = polygon.Points
                                .Select(_viewPort.WorldToScreen)
                                .Select(p => new SKPoint(p.X, p.Y))
                                .ToList();
                            points.Add(points[0]);

                            canvas.DrawPoints(SKPointMode.Polygon, points.ToArray(), Pen);

                            if (space.Selected)
                            {
                                canvas.DrawPoints(SKPointMode.Polygon, points.ToArray(), Selected);
                            }
                        }
                    }
                }
            }
        }
    }
}
