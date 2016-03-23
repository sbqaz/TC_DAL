using System;

namespace TrafficControl.DAL.Types
{
    public partial class Case
    {
        public long id { get; set; }
        public Nullable<long> installations { get; set; }
        public string worker { get; set; }
        public string damageNo { get; set; }
        public Nullable<DateTime> time { get; set; }
        public Nullable<bool> police { get; set; }
        public Nullable<bool> randers { get; set; }
        public Nullable<bool> thirdParties { get; set; }
        public Nullable<bool> selfObservation { get; set; }
        public Nullable<bool> alarmList { get; set; }
        public Nullable<bool> lampError { get; set; }
        public Nullable<bool> errorToneAlert { get; set; }
        public Nullable<bool> errorPedestrianPressure { get; set; }
        public Nullable<bool> turnOffError { get; set; }
        public Nullable<bool> trafficDamage { get; set; }
        public Nullable<bool> detectorError { get; set; }
        public Nullable<long> detectorNo { get; set; }
        public string image { get; set; }
        public string errorDescription { get; set; }
        public string madeRepair { get; set; }
        public Nullable<int> selfMonitoring1 { get; set; }
        public Nullable<int> selfMonitoring2 { get; set; }
        public Nullable<int> selfMonitoring3 { get; set; }
        public Nullable<int> selfMonitoring4 { get; set; }
        public Nullable<int> selfMonitoring5 { get; set; }
        public Nullable<int> selfMonitoring6 { get; set; }
        public Nullable<int> selfMonitoring7 { get; set; }
    }
}
