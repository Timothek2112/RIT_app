using GMap.NET;
using GMap.NET.WindowsForms;
using RITAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Models
{
    public class Polygon : GMapPolygon
    {
        IPolygonCommand command;
        public PolygonCommandEnum commandType;
        public object commandArg;
        public bool isCommandSet = false;

        public Polygon(List<PointLatLng> points, string name) : base(points, name)
        {

        }

        public void SetCommand(IPolygonCommand command)
        {
            this.command = command;
            isCommandSet = true;
        }

        public Marker ExecuteCommand()
        {
            return command.Execute();
        }

        
    }
}
