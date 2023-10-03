using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RITAutomation.Models;
using System.Windows.Forms;
using System.Threading;
using RITAutomation.Utils;
using System.Diagnostics;

namespace RITAutomation.Services
{
    public class MarkersService
    {
        TransportCoordinatesService transportCoordinatesService;

        public MarkersService()
        {
            transportCoordinatesService = new TransportCoordinatesService();
        }

        public Marker CreateMarker(int id, SourceTypeEnum sourceType, string source, double latitude, double longtitude, string description)
        {
            Marker marker = new Marker(id, sourceType, source, new PointLatLng(latitude, longtitude), GMarkerGoogleType.blue_dot);
            marker.ToolTipText = description;
            return marker;
        }

        public void AddMarkerToOverlay(Marker marker, GMapOverlay overlay)
        {
            overlay.Markers.Add(marker);
        }

        public List<Marker> GetAllMarkersFromDatabase() 
        {
            List<Marker> markers = new List<Marker>();
            List<TransportUnit> units = transportCoordinatesService.GetTransportUnits();
            foreach (TransportUnit unit in units)
            {
                Marker marker = CreateMarker(unit.id, unit.sourceType, unit.source, unit.latitude, unit.longtitude, unit.name);
                markers.Add(marker);
            }
            return markers;
        }

        public void AddAllMarkersToOverlay(List<Marker> markers, GMapOverlay overlay)
        {
            foreach(var marker in markers)
            {
                AddMarkerToOverlay(marker, overlay);
            }
        }

        public void SaveMarkerCoordinates(int id, double latitude, double longtitude)
        {
            transportCoordinatesService.SaveTransportUnitCoordinates(id, latitude, longtitude);
        }
    }
}
