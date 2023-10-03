using RITAutomation.Services;
using RITAutomation.Utils.ReceiverFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.ReceiverFactory
{
    public class ReceiverFactoryClient
    {
        AbstractReceiverFactory factory;

        public ReceiverFactoryClient(SourceTypeEnum sourceType, string source) 
        {
            if (!int.TryParse(source, out var sourceParsed))
                return;
            switch (sourceType)
            {
                case SourceTypeEnum.FILE:
                    factory = new FileReceiverFactory(source);
                    break;
                case SourceTypeEnum.UDP:
                    factory = new UdpReceiverFactory(source);
                    break;
                case SourceTypeEnum.COM:
                    factory = new ComReceiverFactory(source);
                    break;
            }
        }

        public IReceiver Create()
        {
            if (factory == null) return null;
            return factory.Create();
        }
    }
}
