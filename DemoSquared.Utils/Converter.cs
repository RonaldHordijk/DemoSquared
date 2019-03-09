using DemoSquared.Model;
using DemoSquared.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.Utils
{
  static public class Converter
  {

    private static string GetSpaceName(Model.Space space)
    {
      foreach (var spaceItem in space.Items)
      {
        if (spaceItem is string)
        {
          return spaceItem as string;
        }
      }

      return null;
    }

    private static ShellGeometry GetSpaceShellGeometry(Model.Space space)
    {
      if (space is null)
        return null;

      foreach (var spaceItem in space.Items)
      {
        if (spaceItem is ShellGeometry)
        {
          return spaceItem as ShellGeometry;
        }
      }

      return null;
    }

    private static ClosedShell GetShellGeometryClosedShell(ShellGeometry shellGeometry)
    {
      if (shellGeometry is null)
        return null;


      foreach (var item in shellGeometry.Items)
      {
        if (item is ClosedShell)
        {
          return item as ClosedShell;
        }
      }

      return null;
    }

    public static ViewModel.Space ConvertSpace(Model.Space space)
    {
      Debug.Assert(space != null);

      var result = new ViewModel.Space();

      result.Name = GetSpaceName(space);

      var closedShell = GetShellGeometryClosedShell(GetSpaceShellGeometry(space));
      foreach (var polyloop in closedShell.Items)
      {
        // Seeing we are going to draw in 2D only keep the vertical polygons
        if (IsHorizontal(polyloop))
        {
          result.Polygons.Add(ConvertPolygon(polyloop));
        }
      }

      return result;
    }

    private static bool IsHorizontal(PolyLoop polyLoop)
    {
      if (polyLoop.Items.Length < 2)
        return true;

      // fist point, third coordinate
      var z = (double)polyLoop.Items[0].Items[2].Value;

      foreach (var item in polyLoop.Items)
      {
        var otherZ = (double)polyLoop.Items[0].Items[2].Value;
        if (Math.Abs(z - otherZ) > 0.01)
          return false;
      }

      return true;
    }

    private static Polygon ConvertPolygon(PolyLoop polyLoop)
    {
      var polygon = new Polygon();
      foreach (var item in polyLoop.Items)
      {
        polygon.Points.Add(new Point
        {
          X = (double)item.Items[0].Value,
          Y = (double)item.Items[1].Value,
          Z = (double)item.Items[2].Value
        });
      }
      return polygon;
    }

    public static IEnumerable<ViewModel.Space> ConvertSpaces(IEnumerable<Model.Space> space)
    {
      return space.Select(ConvertSpace);
    }
  }
}