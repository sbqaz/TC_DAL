using Newtonsoft.Json;

namespace TrafficControl.DAL.RestSharp.Types
{
    public partial class User
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("PhoneNumber")]
        public string Number { get; set; }
        [JsonProperty("EmailNotification")]
        public bool EmailNotification { get; set; }
        [JsonProperty("SMSNotification")]
        public bool SMSNotification { get; set; }
        [JsonProperty("Role")]
        public int Role { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }

    }
}
