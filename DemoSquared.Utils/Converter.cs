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

    private static ViewModel.Space ConvertSpace(Model.Space space)
    {
      Debug.Assert(space != null);

      var result = new ViewModel.Space
      {
        Name = ModelQuery.GetSpaceName(space)
      };

      var shellGeometry = ModelQuery.GetShellGeometryFromSpace(space);
      var closedShell = ModelQuery.GetClosedShellFromShellGeometry(shellGeometry);
      var polyloops = closedShell?.Items;
      var polygons = polyloops.Select(ConvertPolygon);

      // only need to display the floor 
      result.Polygons.AddRange(DisplayModelQuery.GetFloorPolygons(polygons));

      return result;
    }

    public static DisplayModel Convert(gbXML model)
    {
      if (model is null)
        return null;

      var campus = ModelQuery.GetCampusFromModel(model);
      var building = ModelQuery.GetBuildingFromCampus(campus);
      var spaces = ModelQuery.GetSpacesFromBuilding(building);

      var displayModel = new DisplayModel();
      displayModel.Spaces.AddRange(spaces.Select(ConvertSpace));
      displayModel.Floors.AddRange(DisplayModelQuery.CreateFloors(displayModel));

      return displayModel;
    }
  }
}
