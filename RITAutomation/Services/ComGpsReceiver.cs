using RITAutomation.Models;
using RITAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Services
{
    public class ComGpsReceiver : IReceiver
    {
        private bool _isReceiving = false;
        public bool isReceiving
        { get { return _isReceiving; } }
        SerialPort serialPort;

        public ComGpsReceiver(string port)
        {
            serialPort = new SerialPort(port, 1200);
        }

        public GPGGA lastData { get; set; }

        public GPGGA GetLastData()
        {
            return lastData;
        }

        public void ReceiveAsync()
        {
            while (isReceiving)
            {
                string data = serialPort.ReadLine();
                if (data == String.Empty || !data.StartsWith("$GPGGA")) continue;
                Debug.WriteLine("Строка: " + data);
                GPGGA gpgga = NMEAParser.ParseGPGGA(data);
                lastData = gpgga;
            }
        }

        public void StartReceiving()
        {
            _isReceiving = true;
            serialPort.Open();
            Task receiving = new Task(ReceiveAsync);
            receiving.Start();
        }

        public void StopReceiving()
        {
            _isReceiving = false;
            serialPort.Close();
        }
    }
}
