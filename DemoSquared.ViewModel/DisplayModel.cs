using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.ViewModel
{
  public class DisplayModel
  {
    public List<Floor> Floors { get; } = new List<Floor>();
    public List<Space> Spaces { get; } = new List<Space>();
  }
}
