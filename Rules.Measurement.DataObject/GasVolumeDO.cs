using System;

namespace Rules.Measurement.DataObject
{
    public class GasVolumeDO
    {
        public string Meter { get; set; }
        public UnitTimeCode UnitTimeCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Volume { get; set; }
        public double Energy { get; set; }
        public GasVolumeUom GasVolumeUom { get; set; }
        public GasEnergyUom GasEnergyUom { get; set; }
    }
}
