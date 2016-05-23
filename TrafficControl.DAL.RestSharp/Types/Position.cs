using Newtonsoft.Json;

namespace TrafficControl.DAL.RestSharp.Types
{
    public class Position
    {
        public long Id { get; set; }
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longtitude { get; set; }
    }
}