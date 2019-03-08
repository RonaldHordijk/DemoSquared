using DemoSquared.Model;
using DemoSquared.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSquared.Viewer
{
  public partial class MainForm : Form
  {
    private gbXML _building;

    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      var filename = @"C:\Code\DemoSquared\Data\OfficeBuilding.xml";

      try
      {
        _building = Loader.Load(filename);
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Unable to load file: {filename}.\n error: {ex.Message}",
            "Loading failed",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }
  }
}
