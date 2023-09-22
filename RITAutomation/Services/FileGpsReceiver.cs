using RITAutomation.Models;
using RITAutomation.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RITAutomation.Services
{
    public class FileGpsReceiver : IReceiver
    {
        public bool _isReceiving = false;
        public bool isReceiving { get { return _isReceiving; } }
        public GPGGA lastData { get; set; }
        public string source;
        public int readDelay = 1000;

        public FileGpsReceiver(string source)
        {
            this.source = source;
        }

        public GPGGA GetLastData()
        {
            return lastData;
        }

        public void ReceiveAsync()
        {
            using (StreamReader file = new StreamReader(source))
            {
                while (isReceiving)
                {
                    Thread.Sleep(readDelay);
                    string data = file.ReadLine();
                    if (data == null || !data.StartsWith("$GPGGA")) continue;
                    GPGGA gpgga = NMEAParser.ParseGPGGA(data);
                    lastData = gpgga;
                }
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
