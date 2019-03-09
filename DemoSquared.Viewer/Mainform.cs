using DemoSquared.Model;
using DemoSquared.Utils;
using DemoSquared.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSquared.Viewer
{
  public partial class MainForm : Form
  {
    private gbXML _building;
    private DisplayModel _displayModel;
    private ViewPort _viewPort;

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

      _displayModel = Converter.Convert(_building);

      foreach (var space in _displayModel.Spaces)
      {
        clbSpaces.Items.Add(space);
      }

      var (minWorld, maxWorld) = DisplayModelQuery.GetModelBounds(_displayModel);

      _viewPort = new ViewPort(pbMain.Width, pbMain.Height, minWorld, maxWorld);

      var bmp = MakeImage(pbMain.Width, pbMain.Height);
      pbMain.Image = bmp;
    }

    private Bitmap MakeImage(int width, int height)
    {
      Bitmap bmp = new Bitmap(width, height);
      Graphics g = Graphics.FromImage(bmp);

      g.SmoothingMode = SmoothingMode.HighQuality;

      g.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);

      var pen = new Pen(Color.Black);
      var fill = new SolidBrush(Color.Lime);

      foreach (ViewModel.Space space in clbSpaces.Items)
      {
        var selected = clbSpaces.CheckedItems.Contains(space);

        foreach (var polygon in space.Polygons)
        {
          var points = polygon.Points.Select(_viewPort.WorldToScreen).ToArray();
          g.DrawPolygon(pen, points);

          if (selected)
            g.FillPolygon(fill, points);
        }
      }

      return bmp;
    }

    private void clbSpaces_SelectedValueChanged(object sender, EventArgs e)
    {
      var bmp = MakeImage(pbMain.Width, pbMain.Height);
      pbMain.Image = bmp;
    }

    private void clbSpaces_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      var bmp = MakeImage(pbMain.Width, pbMain.Height);
      pbMain.Image = bmp;
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      _viewPort.ResizeScreen(pbMain.Width, pbMain.Height);

      var bmp = MakeImage(pbMain.Width, pbMain.Height);
      pbMain.Image = bmp;
    }
  }
}
