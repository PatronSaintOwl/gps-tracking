using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpsTest.WebClient.Models
{
    public class LatLong
    {
        public DateTime TimeStamp { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public double Speed { get; set; }

        public double VerticalAccuracy { get; set; }

        public double HorizontalAccuracy { get; set; }

        public double Altitude { get; set; }

        public double Course { get; set; }
    }
}