using System;

namespace TrafficControl.DAL.RestSharp.Types
{
    public partial class User
    {
        
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int privileges { get; set; }
        public string number { get; set; }
        public bool EmailNotification { get; set; }
        public bool SMSNotification { get; set; }
    }
}
