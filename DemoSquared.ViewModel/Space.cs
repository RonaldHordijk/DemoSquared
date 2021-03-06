﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquared.ViewModel
{
  public class Space
  {
    public string Name { get; set; }
    public bool Selected { get; set; } = false;
    public List<Polygon> Polygons { get; } = new List<Polygon>();

    public override string ToString() => Name;

    public double FloorLevel => Polygons.Count == 0 ? 0.0 : Polygons[0].Points[0].Z;
  }
}
