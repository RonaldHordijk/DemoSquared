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
    private DisplayModel _displayModel;
    private ViewPort _viewPort;
    private Renderer _renderer;
    private bool _updating;

    public MainForm()
    {
      InitializeComponent();
    }

    private void LoadFile(string filename)
    {
      try
      {
        var building = Loader.Load(filename);
        _displayModel = Converter.Convert(building);
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Unable to load file: {filename}.\n error: {ex.Message}",
            "Loading failed",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        return;
      }

      var (minWorld, maxWorld) = DisplayModelQuery.GetModelBounds(_displayModel);
      _viewPort = new ViewPort(pbMain.Width, pbMain.Height, minWorld, maxWorld);

      _renderer = new Renderer(_displayModel, _viewPort);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      LoadFile(@"C:\Code\DemoSquared\Data\OfficeBuilding.xml");

      FillFloorListBox();
      FillSpacesListBox();

      UpdateDisplay();
    }

    private void FillFloorListBox()
    {
      _updating = true;

      foreach (var floor in _displayModel.Floors)
      {
        lbFloors.Items.Add(floor);
        lbFloors.SetSelected(lbFloors.Items.Count - 1, floor.Visible);
      }
      _updating = false;
    }

    private void FillSpacesListBox()
    {
      _updating = true;
      lbSpaces.Items.Clear();

      foreach (var floor in _displayModel.Floors)
      {
        if (!floor.Visible)
          continue;

        foreach (var space in floor.Spaces)
        {
          lbSpaces.Items.Add(space);
          lbSpaces.SetSelected(lbSpaces.Items.Count - 1, space.Selected);
        }
      }
      _updating = false;
    }

    private void UpdateDisplay()
    {
      pbMain.Image = _renderer.MakeImage();
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      _viewPort.ResizeScreen(pbMain.Width, pbMain.Height);

      UpdateDisplay();
    }

    private void lbFloors_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updating)
        return;

      foreach (var floor in _displayModel.Floors)
      {
        floor.Visible = lbFloors.SelectedItems.Contains(floor);
      }

      FillSpacesListBox();

      UpdateDisplay();
    }

    private void lbSpaces_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updating)
        return;

      foreach (var floor in _displayModel.Floors)
      {
        if (!floor.Visible)
          continue;

        foreach (var space in floor.Spaces)
        {
          space.Selected = lbSpaces.SelectedItems.Contains(space);
        }
      }

      UpdateDisplay();
    }
  }
}
