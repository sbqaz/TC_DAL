using System;

namespace TrafficControl.DAL.RestSharp.Types
{
    
    public partial class Installation
    {
        public object Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Position Position { get; set; }
        public string QRKode { get; set; }
        public int Status { get; set; }
    }
}
