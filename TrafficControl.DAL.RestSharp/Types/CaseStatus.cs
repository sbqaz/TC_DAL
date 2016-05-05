using Newtonsoft.Json;

namespace TrafficControl.DAL.RestSharp
{
    public enum CaseStatus
    {
        [JsonProperty("created")]
        Created,
        [JsonProperty("started")]
        Started,
        [JsonProperty("done")]
        Done,
        [JsonProperty("pending")]
        Pending,
    }
}