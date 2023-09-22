using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    public static class NMEAParser
    {
        public static GPGGA ParseGPGGA(string data)
        {
            string[] parts = data.Split(',');
            TimeSpan UTCtime = new TimeSpan(int.Parse(parts[1].Substring(0, 2)), int.Parse(parts[1].Substring(2, 2)), int.Parse(parts[1].Substring(4, 2)));

        }
    }
}
