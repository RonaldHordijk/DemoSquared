using DemoSquared.Utils;
using DemoSquared.ViewModel;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoSquared.App
{
    public partial class MainPage : ContentPage
    {
        private DisplayModel _displayModel;
        private ViewPort _viewPort;
        private Renderer _renderer;

        public MainPage()
        {
            //InitializeComponent();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            var stream = assembly.GetManifestResourceStream("DemoSquared.App.OfficeBuilding.xml");
            var building = Loader.Load(stream);

            _displayModel = Converter.Convert(building);
            var (minWorld, maxWorld) = DisplayModelQuery.GetModelBounds(_displayModel);
            _viewPort = new ViewPort(100, 100, minWorld, maxWorld);
            _renderer = new Renderer(_displayModel, _viewPort);

            Picker pickerFloor = new Picker
            {
                Title = "Floor",
                VerticalOptions = LayoutOptions.Start,
            };

            Picker pickerSpace = new Picker
            {
                Title = "Space",
                VerticalOptions = LayoutOptions.Start,
            };

            SKCanvasView skCanvas = new SKCanvasView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            skCanvas.PaintSurface += OnPaintSample;

            foreach (var floor in _displayModel.Floors)
            {
                pickerFloor.Items.Add(floor.Name);
            }

            pickerFloor.SelectedIndexChanged += (sender, args) =>
            {
                pickerSpace.Items.Clear();

                var floor = _displayModel.Floors.First(f => f.Name == pickerFloor.SelectedItem as string);
                if (floor is null)
                    return;

                foreach (var wfloor in _displayModel.Floors)
                {
                    wfloor.Visible = false;
                }

                floor.Visible = true;

                foreach (var space in floor.Spaces)
                {
                    pickerSpace.Items.Add(space.Name);
                }

                skCanvas.InvalidateSurface();
            };

            pickerSpace.SelectedIndexChanged += (sender, args) =>
            {
                foreach (var space in _displayModel.Spaces)
                {
                    space.Selected = false;
                }

                if (pickerSpace.SelectedItem != null)
                {
                    var selectedSpace = _displayModel.Spaces.First(s => s.Name == pickerSpace.SelectedItem as string);
                    if (selectedSpace != null)
                        selectedSpace.Selected = true;
                    skCanvas.InvalidateSurface();
                }
            };

            pickerFloor.SelectedIndex = 0;
            pickerSpace.SelectedIndex = 0;
                       
            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    pickerFloor,
                    pickerSpace,
                    skCanvas
                }
            };
        }

        private void OnPaintSample(object sender, SKPaintSurfaceEventArgs e)
        {
            _viewPort.ResizeScreen(e.Info.Width, e.Info.Height);
            _renderer.Draw(e.Surface.Canvas);
        }
    }
}
