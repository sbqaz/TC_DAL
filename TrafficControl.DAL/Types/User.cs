using System;

namespace TrafficControl.DAL.Types
{
    public partial class User
    {
        public long id { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string name { get; set; }
        public Nullable<int> privileges { get; set; }
    }
}
