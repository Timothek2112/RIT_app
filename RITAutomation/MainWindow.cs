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

namespace RITAutomation
{
    public partial class MainWindow : Form
    {
        GMapOverlay markersOverlay;
        Marker dragMarker;
        Marker markerUnderMouse;
        Marker selectedMarker;
        MarkersService markersService;
        bool selectedMarkerSettingsChanged = false;

        public MainWindow()
        {
            InitializeComponent();
            markersService = new MarkersService();
            InitializeMap();
            LoadMarkerModes();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadAllMarkers();
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
        }

        private void LoadMarkerModes()
        {
            sourceCbx.DataSource = MarkerMode.modes;
            sourceCbx.DisplayMember = "name";
            sourceCbx.ValueMember = "mode";
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
                new Thread(() => ShowWarning(ex.Message)).Start();
            }
            catch(Exception ex) 
            {
                new Thread(() => ShowException(ex.Message)).Start();
            }
        }

        public void ShowWarning(string message)
        {
            MessageBox.Show(message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowException(string message)
        {
            MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (dragMarker == null)
                    return;
                var lat = Map.FromLocalToLatLng(e.X, e.Y).Lat;
                var lng = Map.FromLocalToLatLng(e.X, e.Y).Lng;
                dragMarker.Position = new PointLatLng(lat, lng);
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
            selectedMarkerSettingsChanged = true;
            UpdateMarkerSettingsState();
            selectedMarker.SetMode((MarkerModeEnum)sourceCbx.SelectedValue);
        }

        private void sourceLbl_Click(object sender, EventArgs e)
        {

        }

        private void sourceTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMarkerSettingsChanged = true;
            UpdateMarkerSettingsState();
        }

        private void sourceTb_Leave(object sender, EventArgs e)
        {

        }

        private void sourceTb_TextChanged(object sender, EventArgs e)
        {
            selectedMarkerSettingsChanged = true;
            UpdateMarkerSettingsState();
        }

        private void UpdateMarkerSettingsState()
        {
            if (selectedMarkerSettingsChanged)
            {
                acceptBtn.Enabled = true;
            }
            else
            {
                acceptBtn.Enabled = false;
            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            selectedMarkerSettingsChanged = false;
            UpdateMarkerSettingsState();
        }
    }
}
