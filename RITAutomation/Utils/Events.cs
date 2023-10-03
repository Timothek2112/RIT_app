using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    public class Events
    {
        private static Events _instance;
        public static Events instance
        {
            get
            {
                if(_instance == null )
                    _instance = new Events();
                return _instance;
            }
        }
        public delegate void OnMarkerPositionChanged(Marker marker);
        public event OnMarkerPositionChanged OnPositionChanged;

        public void MarkerPositionChanged(Marker marker)
        {
            OnPositionChanged?.Invoke(marker);
        }

    }
}
