using RITAutomation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    public class UdpReceiverFactory : AbstractReceiverFactory
    {
        public UdpReceiverFactory(string source) : base(source)
        {
        }

        public override IReceiver Create()
        {
            return new UdpGPSReceiver(int.Parse(source));
        }
    }
}
