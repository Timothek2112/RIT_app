using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Services
{
    public interface IReceiver
    {
        void StartReceiving();
        void StopReceiving();
        string GetLastData();
        Task<string> ReceiveAsync();
    }
}
