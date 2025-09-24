using Rule.Measurement.DataObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rule.Measurement.Validation.Rules.GasVolume
{
    //All GasVolumeDO validation rules should inherit from GasVolumeRuleBase
    public abstract class GasVolumeRuleBase : MeasurementValidationRuleBase<GasVolumeDO> {}
}
