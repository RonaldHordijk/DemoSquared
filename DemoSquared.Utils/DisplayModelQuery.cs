using DemoSquared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.Utils
{
  public static class DisplayModelQuery
  {
    private const double MinHeightDifference = 0.01;

    private static bool IsHorizontal(Polygon polygon)
    {
      if ((polygon is null) || (polygon.Points.Count == 0))
        return false;

      var minZ = polygon.Points.Min(p => p.Z);
      var maxZ = polygon.Points.Max(p => p.Z);

      return maxZ - minZ < MinHeightDifference;
    }

    public static List<Polygon> GetFloorPolygons(IEnumerable<Polygon> polygons)
    {
      var horizontalPolygons = polygons.Where(IsHorizontal);
      if (!horizontalPolygons.Any())
        return new List<Polygon>();

      var FloorLevel = horizontalPolygons.Select(p => p.Points[0].Z).Min();

      return horizontalPolygons.Where(p => Math.Abs(p.Points[0].Z - FloorLevel) < MinHeightDifference).ToList();
    }

    public static (Point min, Point max) GetModelBounds(DisplayModel displayModel)
    {
      var points = displayModel.Spaces.SelectMany(sp => sp.Polygons).SelectMany(sp => sp.Points);
      return (new Point
      {
        X = points.Min(p => p.X),
        Y = points.Min(p => p.Y),
        Z = points.Min(p => p.Z)
      }, new Point
      {
        X = points.Max(p => p.X),
        Y = points.Max(p => p.Y),
        Z = points.Max(p => p.Z)
      });
    }

    public static IEnumerable<Floor> CreateFloors(DisplayModel displayModel)
    {
      var levels = displayModel.Spaces
        .Select(s => s.FloorLevel)
        .Distinct()
        .ToList();

      levels.Sort();

      foreach (var level in levels)
      {
        var newFloor = new Floor
        {
          Name = $"Floor Z = {level}"
        };

        newFloor.Spaces.AddRange(displayModel.Spaces
                    .Where(s => Math.Abs(s.FloorLevel - level) < MinHeightDifference));

        yield return newFloor;
      }
    }
  }
}
