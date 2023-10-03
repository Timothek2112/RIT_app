using RITAutomation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.ReceiverFactories
{
    public class FileReceiverFactory : AbstractReceiverFactory
    {
        public FileReceiverFactory(string source) : base(source)
        {
        }

        public override IReceiver Create()
        {
            return new FileGpsReceiver(source);
        }
    }
}
