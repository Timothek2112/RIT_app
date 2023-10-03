using RITAutomation.Models;
using RITAutomation.Utils.PolygonCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.PolygonCommandFactories
{
    public class EmptyPolygonCommandFactory : AbstractPolygonCommandFactory
    {
        Marker marker;
        public EmptyPolygonCommandFactory(Marker marker)
        {
            this.marker = marker;
        }

        public override IPolygonCommand Create()
        {
            return new EmptyPolygonCommand(marker);
        }
    }
}
