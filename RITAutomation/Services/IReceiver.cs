using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Services
{
    public interface IReceiver
    {
        bool isReceiving { get; }
        GPGGA lastData { get; set; }
        void StartReceiving();
        void StopReceiving();
        GPGGA GetLastData();
        void ReceiveAsync();
    }
}
