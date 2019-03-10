using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.ViewModel
{
  public class Floor
  {
    public string Name { get; set; }
    public bool Visible { get; set; } = true;
    public List<Space> Spaces { get; } = new List<Space>();

    public override string ToString() => Name;
  }
}
