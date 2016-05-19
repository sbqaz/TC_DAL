using Newtonsoft.Json;

namespace TrafficControl.DAL.RestSharp
{
    public class PostCaseDTO 
    {
        public string ErrorDescription { get; set; }
        [JsonProperty("InstallationId")]
        public long Installation { get; set; }
        public ObserverSelection Observer { get; set; }
    }
}