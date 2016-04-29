using System;

namespace TrafficControl.DAL.RestSharp.Types
{
    public class Case
    {
        public int Status { get; set; }
        public int? Observer { get; set; }
        public long Id { get; set; }
        public long? InstallationsID { get; set; }
        public string Worker { get; set; }
        public string damageNo { get; set; }
        public DateTime? Time { get; set; }
        public bool? police { get; set; }
        public bool? randers { get; set; }
        public bool? thirdParties { get; set; }
        public bool? selfObservation { get; set; }
        public bool? alarmList { get; set; }
        public bool? lampError { get; set; }
        public bool? errorToneAlert { get; set; }
        public bool? errorPedestrianPressure { get; set; }
        public bool? turnOffError { get; set; }
        public bool? trafficDamage { get; set; }
        public bool? detectorError { get; set; }
        public long? detectorNo { get; set; }
        public string image { get; set; }
        public string errorDescription { get; set; }
        public string MadeRepair { get; set; }
        public int? selfMonitoring1 { get; set; }
        public int? selfMonitoring2 { get; set; }
        public int? selfMonitoring3 { get; set; }
        public int? selfMonitoring4 { get; set; }
        public int? selfMonitoring5 { get; set; }
        public int? selfMonitoring6 { get; set; }
        public int? selfMonitoring7 { get; set; }
        public string ErrorDescription { get; set;  }
        
    }
}
