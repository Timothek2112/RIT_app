using RITAutomation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    public abstract class AbstractReceiverFactory
    {
        public string source;

        public AbstractReceiverFactory(string source)
        {
            this.source = source;
        }

        abstract public IReceiver Create();
    }
}
