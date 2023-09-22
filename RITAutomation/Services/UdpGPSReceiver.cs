﻿using GMap.NET;
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
            client = new UdpClient(port);
        }

        public GPGGA GetLastData()
        {
            return lastData;
        }

        public async void ReceiveAsync()
        {
            while (isReceiving)
            {
                var bytes = await client.ReceiveAsync();
                var data = Encoding.UTF8.GetString(bytes.Buffer);
                GPGGA gpgga = NMEAParser.ParseGPGGA(data);
                lastData = gpgga;
            }
        }

        public void StartReceiving()
        {
            _isReceiving = true;
            Task receiving = new Task(ReceiveAsync);
            receiving.Start();
        }

        public void StopReceiving()
        {
            _isReceiving = false;
        }
    }
}
