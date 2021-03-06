using System;
using Newtonsoft.Json;

namespace TrafficControl.DAL.RestSharp.Types
{
    public class Case
    {
        public long Id { get; set; }

        [JsonProperty("InstallationId")]
        public Installation Installation { get; set; }

        public string Worker { get; set; }
        public CaseStatus Status { get; set; }
        public ObserverSelection Observer { get; set; }
        // ReSharper disable once InconsistentNaming
        public string ErrorDescription { get; set; }
        public DateTime? Time { get; set; }
        public string MadeRepair { get; set; }
        public string UserComment { get; set; }
    }
}