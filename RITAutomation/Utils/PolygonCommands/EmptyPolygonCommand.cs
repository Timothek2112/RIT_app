using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.PolygonCommands
{
    public class EmptyPolygonCommand : IPolygonCommand
    {
        Marker marker;

        public EmptyPolygonCommand(Marker marker)
        {
            this.marker = marker;
        }

        public Marker Execute()
        {
            return marker;
        }

        public void Undo()
        {
        }
    }
}
