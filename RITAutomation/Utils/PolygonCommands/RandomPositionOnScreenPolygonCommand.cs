using GMap.NET.WindowsForms;
using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.PolygonCommands
{
    public class RandomPositionOnScreenPolygonCommand : IPolygonCommand
    {
        Marker marker;
        public RandomPositionOnScreenPolygonCommand(Marker marker)
        {
            this.marker = marker;
        }

        public Marker Execute()
        {
            GMapControl map = marker.Overlay.Control;
            double maxLatitude = Math.Max(map.ViewArea.LocationTopLeft.Lat, map.ViewArea.LocationRightBottom.Lat);
            double maxLongtitude = Math.Max(map.ViewArea.LocationTopLeft.Lng, map.ViewArea.LocationRightBottom.Lng);
            double minLatitude = Math.Min(map.ViewArea.LocationTopLeft.Lat, map.ViewArea.LocationRightBottom.Lat);
            double minLongtitude = Math.Min(map.ViewArea.LocationTopLeft.Lng, map.ViewArea.LocationRightBottom.Lng);
            double newLat = new Random().NextDouble() * (maxLatitude - minLatitude) + minLatitude;
            double newLng = new Random().NextDouble() * (maxLongtitude - minLongtitude) + minLongtitude;
            marker.UpdateCoordinates(newLat, newLng);
            return marker;
        }

        public void Undo()
        {

        }
    }
}
