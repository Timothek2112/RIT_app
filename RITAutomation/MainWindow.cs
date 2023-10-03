using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using RITAutomation.Services;
using RITAutomation.Utils;
using System.Threading;
using RITAutomation.Models;
using RITAutomation.Utils.PolygonCommandFactories;
using Microsoft.Ajax.Utilities;

namespace RITAutomation
{
    public partial class MainWindow : Form
    {
        GMapOverlay markersOverlay;
        GMapOverlay polygonsOverlay;
        Marker dragMarker;
        Marker markerUnderMouse;
        Marker selectedMarker;
        Polygon selectedPolygon;
        MarkersService markersService;
        bool selectedMarkerSettingsChanged = false;

        public MainWindow()
        {
            InitializeComponent();
            markersService = new MarkersService();
            InitializeMap();
            LoadMarkerModes();
            LoadReceiverTypes();
            LoadMarkerColors();
            LoadPolygonCommands();
            Utils.Events.instance.OnPositionChanged += OnMarkerPositionChanged;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadAllMarkers();
            CreateExamplePolygon();
        }

        private void CreateExamplePolygon()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(55.008111, 82.921768));
            points.Add(new PointLatLng(56.008111, 82.921768));
            points.Add(new PointLatLng(56.008111, 83.921768));
            points.Add(new PointLatLng(55.008111, 83.921768));
            Polygon polygon = new Polygon(points, "Example Polygon");
            commandPolygonCb.SelectedValue = PolygonCommandEnum.None;
            polygon.IsHitTestVisible = true;
            polygonsOverlay.Polygons.Add(polygon);
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
        }

        private void InitializeMap()
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            Map.MapProvider = GoogleMapProvider.Instance;
            Map.MinZoom = 2;
            Map.MaxZoom = 16;
            Map.Zoom = 11;
            Map.Position = new PointLatLng(55.008111, 82.921768);
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            Map.CanDragMap = true;
            Map.DragButton = MouseButtons.Left;
            Map.ShowCenter = false;
            Map.ShowTileGridLines = false;
            markersOverlay = new GMapOverlay("Markers");
            Map.Overlays.Add(markersOverlay);
            GMapOverlay polygons = new GMapOverlay("polygons");
            polygonsOverlay = polygons;
            Map.Overlays.Add(polygonsOverlay);
        }

        private void LoadPolygonCommands()
        {
            commandPolygonCb.DataSource = PolygonCommandsTypes.types;
            commandPolygonCb.DisplayMember = "name";
            commandPolygonCb.ValueMember = "commandType";
        }
        
        private void LoadMarkerModes()
        {
            sourceCbx.DataSource = MarkerMode.modes;
            sourceCbx.DisplayMember = "name";
            sourceCbx.ValueMember = "mode";
        }

        private void LoadMarkerColors()
        {
            colorChangePickerCb.DataSource = MarkerColors.colors;
            colorChangePickerCb.DisplayMember = "name";
            colorChangePickerCb.ValueMember = "type";
        }

        private void LoadReceiverTypes()
        {
            sourceTypeCb.DataSource = SourceTypes.types;
            sourceTypeCb.DisplayMember = "name";
            sourceTypeCb.ValueMember = "type";
        }

        private void LoadAllMarkers()
        {
            try
            {
                List<Marker> markers = markersService.GetAllMarkersFromDatabase();
                markersService.AddAllMarkersToOverlay(markers, markersOverlay);
            }
            catch(NoRowsException ex)
            {
                ShowWarning(ex.Message);
            }
            catch(Exception ex) 
            {
                ShowException(ex.Message);
            }
        }

        public void ShowWarning(string message)
        {
            new Thread(() => MessageBox.Show(message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning)).Start();
        }

        public void ShowException(string message)
        {
            new Thread(() => MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error)).Start();
        }

        private void gMapControl1_OnMarkerEnter(GMapMarker item)
        {
            markerUnderMouse = (Marker)item;
        }

        private void gMapControl1_OnMarkerLeave(GMapMarker item)
        {
            markerUnderMouse = null;
        }

        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (markerUnderMouse == null)
                return;
            dragMarker = markerUnderMouse;
            ChangeSelectedMarkerInfo(markerUnderMouse);
        }

        public void ChangeSelectedMarkerInfo(Marker newSelection)
        {
            fieldGb.Visible = false;
            markerGb.Visible = true;
            selectedMarker = newSelection;
            nameTb.Text = selectedMarker.ToolTipText;
            idTb.Text = selectedMarker.id.ToString();
            sourceCbx.SelectedValue= selectedMarker.mode;
            sourceTb.Text = selectedMarker.source;
        }

        private void UpdateSelectedPolygonInfo(Polygon polygon)
        {
            fieldGb.Visible = true;
            markerGb.Visible = false;
            if (polygon.isCommandSet)
            {
                commandPolygonCb.SelectedValue = polygon.commandType;
            }
            switch (commandPolygonCb.SelectedValue)
            {
                case PolygonCommandEnum.RandomPositionOnScreen:
                    sendMessageGb.Visible = false;
                    changeColorGb.Visible = false;
                    break;
                case PolygonCommandEnum.SendMessage:
                    sendMessageGb.Visible = true;
                    changeColorGb.Visible = false;
                    break;
                case PolygonCommandEnum.ChangeColor:
                    changeColorGb.Visible = true;
                    sendMessageGb.Visible = false;
                    break;
                case PolygonCommandEnum.None:
                    changeColorGb.Visible = false;
                    sendMessageGb.Visible = false; 
                    break;
            }
        }

        private void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (dragMarker == null)
                    return;
                var lat = Map.FromLocalToLatLng(e.X, e.Y).Lat;
                var lng = Map.FromLocalToLatLng(e.X, e.Y).Lng;
                dragMarker.UpdateCoordinates(lat, lng);
                markersService.SaveMarkerCoordinates(dragMarker.id, dragMarker.Position.Lat, dragMarker.Position.Lng);
            }
            catch (Exception ex)
            {
                new Thread(() => MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error)).Start();
            }
            finally
            {
                dragMarker = null;
            }
        }

        private void gMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragMarker == null)
                return;
            var lat = Map.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = Map.FromLocalToLatLng(e.X, e.Y).Lng;
            dragMarker.UpdateCoordinates(lat, lng);
        }

        private void sourceCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectedMarker == null ) return;
            selectedMarker.SetMode((MarkerModeEnum)sourceCbx.SelectedValue);
        }

        private void sourceTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectedMarker == null ) return;
            selectedMarkerSettingsChanged = true;
            UpdateMarkerSettingsState();
        }

        private void sourceTb_TextChanged(object sender, EventArgs e)
        {
            if(selectedMarker == null ) return;
            selectedMarkerSettingsChanged = true;
            UpdateMarkerSettingsState();
        }

        private void UpdateMarkerSettingsState()
        {
            acceptBtn.Enabled = selectedMarkerSettingsChanged;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            if(selectedMarker == null ) return;
            selectedMarkerSettingsChanged = false;
            UpdateMarkerSettingsState();
            selectedMarker.ChangeReceiverType((SourceTypeEnum)sourceTypeCb.SelectedValue, sourceTb.Text);
        }

        private void Map_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            selectedPolygon = (Polygon)item;
            UpdateSelectedPolygonInfo(selectedPolygon);
        }

        private void OnMarkerPositionChanged(Marker marker)
        {
            markersService.SaveMarkerCoordinates(marker.id, marker.Position.Lat, marker.Position.Lng);
            foreach (var polygon in polygonsOverlay.Polygons)
            {
                if(polygon == null) continue;
                if (polygon.IsInside(marker.Position) && !marker.inside.Contains(polygon))
                {
                    Polygon poly = (Polygon)polygon;
                    poly.SetCommand(new PolygonCommandFactoryClient(poly.commandType, poly.commandArg, marker).Create());
                    Marker entered = poly.ExecuteCommand();
                    entered.inside.Add((Polygon)polygon);
                    if (entered.mode == MarkerModeEnum.manual)
                        dragMarker = entered;
                    else
                        dragMarker = null;
                    if(poly.commandType == PolygonCommandEnum.RandomPositionOnScreen)
                    {
                        marker.StopReceiving();
                        dragMarker = null;
                    }
                }
                else if(!polygon.IsInside(marker.Position))
                {
                    marker.inside.Remove((Polygon)polygon);
                }
            }
        }

        private void colorChangePickerCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectedPolygon == null) return;
            selectedPolygon.commandArg = ((ComboBox)sender).SelectedValue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (selectedPolygon == null) return;
            selectedPolygon.commandArg = ((TextBox)sender).Text;
        }

        private void commandPolygonCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedPolygon == null) return;
            selectedPolygon.commandType = (PolygonCommandEnum)((ComboBox)sender).SelectedValue;
            UpdateSelectedPolygonInfo(selectedPolygon);
        }
    }
}
