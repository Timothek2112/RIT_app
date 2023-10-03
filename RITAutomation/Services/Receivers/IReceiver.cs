using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RITAutomation.Utils;

namespace RITAutomation.Services
{
    public interface IReceiver
    {
        bool isReceiving { get; }
        GPGGA lastData { get; set; }
        GPGGA GetLastData();
        void StartReceiving();
        void StopReceiving();
        void ReceiveAsync();
    }
}
