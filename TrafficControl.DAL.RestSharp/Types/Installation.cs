using System;

namespace TrafficControl.DAL.RestSharp.Types
{
    
    public partial class Installation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public int Status { get; set; } //Enum maybe?
    }
}
