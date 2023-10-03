using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils.PolygonCommandFactories
{
    public abstract class AbstractPolygonCommandFactory
    {
        abstract public IPolygonCommand Create();
    }
}
