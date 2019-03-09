using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.ViewModel
{
  public class Space
  {
    public string Name { get; set; }
    public List<Polygon> Polygons { get; } = new List<Polygon>();

    public override string ToString() => Name;
  }
}
