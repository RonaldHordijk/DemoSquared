using DemoSquared.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DemoSquared.Utils
{
  static public class Loader
  {
    static public gbXML Load(string filename)
    {
      var serializer = new XmlSerializer(typeof(gbXML));
      using (var file = File.OpenText(filename))
      {
        return serializer.Deserialize(file) as gbXML;
      }
    }
  }
}
