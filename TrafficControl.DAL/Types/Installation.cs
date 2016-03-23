using System;

namespace TrafficControl.DAL.Types
{
    
    public partial class Installation
    {
        public long id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Nullable<long> Latitude { get; set; }
        public Nullable<long> Longitude { get; set; }
        public string QRKode { get; set; }
    }
}
