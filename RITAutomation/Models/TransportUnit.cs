using RITAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Models
{
    public class TransportUnit
    {
        public int id;
        public string name;
        public double latitude;
        public double longtitude;
        public SourceTypeEnum sourceType = SourceTypeEnum.UDP;
        public string source = "";

        public TransportUnit(int id, string name, double latitude, double longtitude, SourceTypeEnum sourceType, string source)
        { 
            this.id = id;
            this.name = name;
            this.latitude = latitude;
            this.longtitude = longtitude;
            this.sourceType = sourceType;
            this.source = source;
        }
    }
}