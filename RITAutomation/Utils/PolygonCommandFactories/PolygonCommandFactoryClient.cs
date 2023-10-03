using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using RITAutomation.Models;
using RITAutomation.Utils.PolygonCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.PolygonCommandFactories
{
    public class PolygonCommandFactoryClient
    {
        AbstractPolygonCommandFactory factory;

        public PolygonCommandFactoryClient(PolygonCommandEnum commandType, object arg, Marker marker)
        {
            switch (commandType)
            {
                case PolygonCommandEnum.ChangeColor:
                    factory = new ChangeMarkerColorCommandFactory((GMarkerGoogleType)arg, marker);
                    break;
                case PolygonCommandEnum.SendMessage:
                    factory = new SendMessagePolygonCommandFactory((string)arg, marker);
                    break;
                case PolygonCommandEnum.None:
                    factory = new EmptyPolygonCommandFactory(marker);
                    break;
                case PolygonCommandEnum.RandomPositionOnScreen:
                    factory = new RandomPositionOnScreenPolygonCommandFactory(marker);
                    break;
            }
        }

        public IPolygonCommand Create()
        {
            return factory.Create();
        }
    }
}
