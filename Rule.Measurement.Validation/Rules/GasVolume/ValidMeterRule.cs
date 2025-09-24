using Rule.Measurement.DataObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rule.Measurement.Validation.Rules.GasVolume
{
    public class ValidMeterRule : GasVolumeRuleBase
    {
        public override ValidationLevel ValidationLevel => ValidationLevel.Error;

        public override string ValidationMessage => "Meter must not be empty";

        public override bool Validate(GasVolumeDO obj)
        {
            var valid = !string.IsNullOrEmpty(obj.Meter);

            return valid;
        }
    }
}
