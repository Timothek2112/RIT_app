using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Services
{
    public class UdpGPSReceiver : IReceiver
    {
        readonly int _port;
        PointLatLng lastPoint;
        public string lastData;
        private bool _isReceiving = false;
        UdpClient client;
        public bool isReceiving
        {
            get
            {
                return _isReceiving;
            }
        }

        public UdpGPSReceiver(int port)
        {
            _port = port;
            client = new UdpClient(port);
        }

        public string GetLastData()
        {
            return lastData;
        }

        public async Task<string> ReceiveAsync()
        {
            while (isReceiving)
            {
                var bytes = await client.ReceiveAsync();
                var data = Encoding.UTF8.GetString(bytes.Buffer);
                lastData = data;
                return data;
            }
            return lastData;
        }

        public void StartReceiving()
        {
            _isReceiving = true;
            ReceiveAsync();
        }

        public void StopReceiving()
        {
            _isReceiving = false;
        }
    }
}
