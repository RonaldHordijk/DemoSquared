using DemoSquared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.Utils
{
  // helper functions for getting infromation out the gbxml data structure
  internal static class ModelQuery
  {
    public static Campus GetCampusFromModel(gbXML model)
    {
      if (model is null)
        return null;

      foreach (var item in model.Items)
      {
        if (item is Campus)
        {
          return item as Campus;
        }
      }

      return null;
    }

    public static Building GetBuildingFromCampus(Campus campus)
    {
      if (campus is null)
        return null;

      foreach (var item in campus.Items)
      {
        if (item is Building)
        {
          return item as Building;
        }
      }

      return null;
    }

    public static IEnumerable<Model.Space> GetSpacesFromBuilding(Building building)
    {
      if (building is null)
        yield break;

      foreach (var item in building.Items)
      {
        if (item is Model.Space)
        {
          yield return item as Model.Space;
        }
      }
    }

    public static ShellGeometry GetShellGeometryFromSpace(Model.Space space)
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

    public static ClosedShell GetClosedShellFromShellGeometry(ShellGeometry shellGeometry)
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

    public static string GetSpaceName(Model.Space space)
    {
      if (space is null)
        return null;

      foreach (var spaceItem in space.Items)
      {
        if (spaceItem is string)
        {
          return spaceItem as string;
        }
      }

      return null;
    }
  }
}
