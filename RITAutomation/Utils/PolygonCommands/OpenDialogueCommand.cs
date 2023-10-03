using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RITAutomation.Utils.PolygonCommands
{
    internal class OpenDialogueCommand : IPolygonCommand
    {
        string message;
        Marker marker;

        public OpenDialogueCommand(string message, Marker marker)
        {
            this.message = message;
            this.marker = marker;
        }

        public Marker Execute()
        {
            new Thread(() => MessageBox.Show(message)).Start();
            return marker;
        }

        public void Undo() { }
    }
}
