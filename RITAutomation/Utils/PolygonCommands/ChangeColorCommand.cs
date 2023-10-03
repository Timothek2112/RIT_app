using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.PolygonCommands
{
    public class ChangeColorCommand : IPolygonCommand
    {
        GMarkerGoogleType type;
        Marker marker;

        public ChangeColorCommand(GMarkerGoogleType type, Marker marker)
        {
            this.type = type;
            this.marker = marker;
        }
    
        public Marker Execute()
        {
            GMapOverlay overlay = marker.Overlay;
            overlay.Markers.Remove(marker);
            var newMarker = marker.Clone(this.type);
            overlay.Markers.Add(newMarker);
            return newMarker;
        }

        public void Undo()
        {

        }
    }
}
