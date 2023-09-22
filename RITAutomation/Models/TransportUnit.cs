﻿using System;
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

        public TransportUnit(int id, string name, double latitude, double longtitude)
        {
            this.id = id;
            this.name = name;
            this.latitude = latitude;
            this.longtitude = longtitude;
        }

        public void SetCoordinates(double latitude, double longtitude)
        {
            this.latitude = latitude;
            this.longtitude = longtitude;
        }
    }
}