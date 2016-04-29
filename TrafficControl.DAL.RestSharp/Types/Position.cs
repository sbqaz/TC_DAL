using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.DAL.RestSharp.Types
{
    public class Position
    {
        public long Id { get; set; }
        public double Latitude { get; }
        public double Longtitude { get; }
    }
}
