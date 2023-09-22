using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using RITAutomation.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Models
{
    public class Marker : GMarkerGoogle
    {
        public int id;
        public IReceiver receiver;

        public Marker(int id, int port, PointLatLng p, GMarkerGoogleType type) : base(p, type)
        {
            this.id = id;
            this.receiver = new UdpGPSReceiver(port);
        }

        public Marker(int id, int port, PointLatLng p, Bitmap Bitmap) : base(p, Bitmap)
        {
            this.id = id;
            this.receiver = new UdpGPSReceiver(port);
        }

        protected Marker(int id, int port, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.id = id;
            this.receiver = new UdpGPSReceiver(port);
        }

        public void UpdateCoordinates(double latitude, double longitude)
        {
            Position = new PointLatLng(latitude, longitude);
        }

        public void StartReceiving()
        {
            receiver.StartReceiving();
        }

        public void StopReceiving()
        {
            receiver.StopReceiving();
        }
    }
}
