using RITAutomation.Models;
using RITAutomation.Utils.PolygonCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.PolygonCommandFactories
{
    internal class SendMessagePolygonCommandFactory : AbstractPolygonCommandFactory
    {
        string message;
        Marker marker;

        public SendMessagePolygonCommandFactory(string message, Marker marker)
        {
            this.message = message;
            this.marker = marker;
        }

        public override IPolygonCommand Create()
        {
            return new OpenDialogueCommand(message, marker);
        }
    }
}
