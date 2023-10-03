using GMap.NET;
using RITAutomation.Models;
using RITAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RITAutomation.Services
{
    public class UdpGPSReceiver : IReceiver
    {
        readonly int _port;
        public GPGGA lastData { get; set; }
        private bool _isReceiving = false;
        public bool isReceiving
        {
            get
            {
                return _isReceiving;
            }
        }
        UdpClient client;

        public UdpGPSReceiver(int port)
        {
            _port = port;
        }

        public GPGGA GetLastData()
        {
            return lastData;
        }

        public async void ReceiveAsync()
        {
            while (isReceiving)
            {
                try
                {
                    var bytes = await client.ReceiveAsync();
                    var data = Encoding.UTF8.GetString(bytes.Buffer);
                    GPGGA gpgga = NMEAParser.ParseGPGGA(data);
                    lastData = gpgga;
                }
                catch { }
            }
        }

        public void StartReceiving()
        {
            if (_isReceiving) return;
            client = new UdpClient(_port);
            _isReceiving = true;
            Task.Run(() => ReceiveAsync());
        }

        public void StopReceiving()
        {
            if(client != null) 
                client.Close();
            if(!_isReceiving) return;
            _isReceiving = false;
        }
    }
}
