using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    public interface IPolygonCommand
    {
        Marker Execute();
        void Undo();
    }
}
