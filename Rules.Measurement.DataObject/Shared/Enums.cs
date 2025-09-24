using System;
using System.Collections.Generic;
using System.Text;

namespace Rules.Measurement.DataObject
{
    public enum UnitTimeCode
    {
        Undefined = 0,
        Hourly,
        Daily,
        Monthly
    }
    public enum GasVolumeUom
    {
        Undefined = 0,
        Cf,
        Mcf,
        Mmcf
    }
    public enum GasEnergyUom
    {
        Undefined = 0,
        Btu,
        Mmbtu,
        Dth
    }
}
