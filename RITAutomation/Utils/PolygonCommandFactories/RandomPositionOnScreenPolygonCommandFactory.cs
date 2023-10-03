using RITAutomation.Models;
using RITAutomation.Utils.PolygonCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.PolygonCommandFactories
{
    public class RandomPositionOnScreenPolygonCommandFactory : AbstractPolygonCommandFactory
    {
        Marker marker;

        public RandomPositionOnScreenPolygonCommandFactory(Marker marker)
        {
            this.marker = marker;
        }

        public override IPolygonCommand Create()
        {
            return new RandomPositionOnScreenPolygonCommand(marker);
        }
    }
}
