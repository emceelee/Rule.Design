using Rule.Measurement.DataObject;

namespace Rule.Measurement.Validation.Rules.GasVolume
{
    public class ValidEffectiveDateRule : GasVolumeRuleBase
    {
		public override bool Validate(GasVolumeDO gasVolume)
		{
			// Ensure StartDateTime is less than EndDateTime
			return gasVolume.StartDateTime < gasVolume.EndDateTime;
		}

        public override ValidationLevel ValidationLevel => ValidationLevel.Error;

        public override string ValidationMessage => "StartDateTime must be less than EndDateTime.";
    }
}
