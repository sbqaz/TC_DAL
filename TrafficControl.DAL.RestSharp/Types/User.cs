using System;

namespace TrafficControl.DAL.RestSharp.Types
{
    public partial class User
    {
        
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int privileges { get; set; }
        public string number { get; set; }
    }
}
