using DemoSquared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.Utils
{
  public static class ModelQuery
  {
    public static List<object> GetSurfaces(gbXML building)
    {
      if (building is null)
        return null;

      foreach (var buildingItem in building.Items)
      {
        if (buildingItem is Campus)
        {
          var campus = buildingItem as Campus;

          foreach (var campusItem in campus.Items)
          {
            if (campusItem is Surface)
            {

            }
          }
        }
      }

      return null;
    }

    public static IEnumerable<Space> GetSpaces(gbXML model)
    {
      if (model is null)
        yield break;

      foreach (var modelItem in model.Items)
      {
        if (modelItem is Campus)
        {
          var campus = modelItem as Campus;

          foreach (var campusItem in campus.Items)
          {
            if (campusItem is Building)
            {
              var building = campusItem as Building;
              foreach (var buildingItem in building.Items)
              {
                if (buildingItem is Space)
                  yield return buildingItem as Space;
              }
            }
          }
        }
      }
    }

    public static IEnumerable<string> GetSpacesNames(IEnumerable<Space> spaces)
    {
      foreach (var space in spaces)
      {
        foreach (var spaceItem in space.Items)
        {
          if (spaceItem is string)
          {
            if (spaceItem is string)
              yield return spaceItem as string;
          }
        }
      }
    }
  }
}
