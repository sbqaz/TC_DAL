using Newtonsoft.Json;

namespace TrafficControl.DAL.RestSharp
{
    public enum ObserverSelection
    {
        [JsonProperty("undefined")] Undefined,
        [JsonProperty("police")] Police,
        [JsonProperty("user")] User,
        [JsonProperty("thirdPart")] ThirdPart,
        [JsonProperty("own")] Own
    }
}