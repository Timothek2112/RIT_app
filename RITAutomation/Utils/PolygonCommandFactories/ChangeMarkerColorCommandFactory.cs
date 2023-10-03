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
    public class ChangeMarkerColorCommandFactory : AbstractPolygonCommandFactory
    {
        GMarkerGoogleType type;
        Marker marker;

        public ChangeMarkerColorCommandFactory(GMarkerGoogleType type, Marker marker)
        {
            this.type = type;
            this.marker = marker;
        }

        public override IPolygonCommand Create()
        {
            return new ChangeColorCommand(type, marker);
        }
    }
}
